<template>
    <div id="appStudent">
        <div class="addicon">
            <i type="button" @click="toggleModalAddPage()">
                <svg xmlns="http://www.w3.org/2000/svg" width="40" height="40" class="bi" viewBox="0 0 16 16">
                    <path
                        d="M12.5 16a3.5 3.5 0 1 0 0-7 3.5 3.5 0 0 0 0 7Zm.5-5v1h1a.5.5 0 0 1 0 1h-1v1a.5.5 0 0 1-1 0v-1h-1a.5.5 0 0 1 0-1h1v-1a.5.5 0 0 1 1 0Zm-2-6a3 3 0 1 1-6 0 3 3 0 0 1 6 0Z" />
                    <path
                        d="M2 13c0 1 1 1 1 1h5.256A4.493 4.493 0 0 1 8 12.5a4.49 4.49 0 0 1 1.544-3.393C9.077 9.038 8.564 9 8 9c-5 0-6 3-6 4Z" />
                </svg>
            </i>
        </div>
        <div v-show="modalAddOpen" class="modal" tabindex="0" @keyup.esc="modalAddOpen = false" ref="modalAdd">
            <div class="modal-inner-add">
                <div class="upper" @click="modalAddOpen = false">
                    <h1>Registration</h1>
                    <i @click="close" type="button"><svg xmlns="http://www.w3.org/2000/svg" height="30px"
                            fill="currentColor" class="bi" viewBox="0 0 16 16">
                            <path
                                d="M4.646 4.646a.5.5 0 0 1 .708 0L8 7.293l2.646-2.647a.5.5 0 0 1 .708.708L8.707 8l2.647 2.646a.5.5 0 0 1-.708.708L8 8.707l-2.646 2.647a.5.5 0 0 1-.708-.708L7.293 8 4.646 5.354a.5.5 0 0 1 0-.708z" />
                        </svg></i>
                </div>

                <div class="home-addstudent">
                    <div class="modal-content-addstudent">
                        <div class="student-add-info">
                            <div class="name-addstudent">
                                <p>Name: <span class="text-danger">*</span> </p>
                                <!-- <div class="name-field"> -->
                                <input type="text" v-model="firstNameData" placeholder="First Name" />
                                <label id="First" class="text-danger" v-if="isFirstNameError">First Name is required</label>
                                <input type="text" v-model="middleNameData" placeholder="Middle Name" />
                                <label id="Middle" class="text-danger" v-if="isMiddleNameError">Middle Name is
                                    required</label>
                                <input type="text" v-model="lastNameData" placeholder="Last Name" />
                                <label id="Last" class="text-danger" v-if="isLastNameError">Last Name is required</label>
                                <!-- </div> -->
                            </div>
                            <div class="dob-addstudent">
                                <p>Date of Birth: <span class="text-danger">*</span> </p>
                                <input type="date" v-model="birthDateData" placeholder="" />
                                <label id="birth" class="text-danger" v-if="isBirthdateError">Birthdate is required</label>
                                <p>Email Address: <span class="text-danger">*</span></p>
                                <input type="text" v-model="emailAddressData" placeholder="Email Address" required />
                                <label id="emailInvalid" class="text-danger" v-if="isEmailInvalidError">The e-mail address
                                    is not in a valid format</label>
                            </div>
                        </div>

                        <div class="subject-addstudent">
                            <table id="addstudent-table">
                                <thead>
                                    <tr>
                                        <td>
                                            <input type="checkbox" v-model="isAllSelected" @click="selectAll" />
                                        </td>
                                        <th>Subjects</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr v-for="subject in Subject" :key="subject.subjectID">
                                        <td>
                                            <input type="checkbox" v-model="subjectIds" :value="subject.subjectID" />
                                        </td>

                                        <td>{{ subject.subjectName }}</td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </div>

                    <div class="buttons-addstudent">
                        <button type="submit" class="save" @click="this.addStudent">
                            Save
                        </button>
                    </div>
                </div>
            </div>
        </div>
        <div v-if="showAlert" class="alert">
            Student information already exists in the database!
        </div>
    </div>
</template>

<script>
import { mapState } from "pinia";
import { computed } from "vue";
import { studentStore } from "./../stores/student_module";


export default {
    el: "#appStudent",

    data() {
        return {

            modalAddOpen: false,
            enroll: {
                student: {
                    firstName: "",
                    middleName: "",
                    lastName: "",
                    birthDate: "",
                    emailAddress: "",
                },
                subjectIds: [],
            },
            Subject: [],
            subjectIds: [],
            currentDateTime: null,
            isAllSelected: false,
            showAlert: false,
            firstNameData: "",
            middleNameData: "",
            lastNameData: "",
            birthDateData: "",
            emailAddressData: "",

            isFirstNameError: false,
            isMiddleNameError: false,
            isLastNameError: false,
            isBirthdateError: false,
            isEmailInvalidError: false,

        };
    },
    computed: {
        ...mapState(studentStore, {
            studentInfoResponse: "studentInfoResponse",
            students: "students"
        })
    },


    mounted() {
        this.subjectdata();
        setInterval(() => {
            this.currentDateTime = new Date();
        }, 1000);
    },

    methods: {
        toggleModalAddPage() {
            this.modalAddOpen = true;
            this.$refs.modalAdd.focus();
            this.$nextTick(() => {
                this.$refs.modalAdd.focus();
            });
        },

        async subjectdata() {
            try {
                await studentStore().getSubject();
                this.Subject = studentStore().$state.subjects;
            } catch (error) {
                console.log(error);
            }
        },

        addStudent() {
            this.isFirstNameError = false;
            this.isMiddleNameError = false;
            this.isLastNameError = false;
            this.isBirthdateError = false;
            this.isEmailInvalidError = false;


            const studentStoreData = studentStore()
            const isEmailValid = /^[^\s@]+@[^\s@]+\.[^\s@]+$/.test(this.emailAddressData);
            const existingStudent = computed(() =>
                studentStoreData.students.find(
                    (studentData) => studentData.firstName === this.firstNameData && studentData.middleName === this.middleNameData && studentData.lastName === this.lastNameData && studentData.emailAddress === this.emailAddressData
                )
            )

            if (existingStudent.value) {
                this.$toast.error(`Student Record already exists`, {
                    position: "top",

                })
            } else if (
                this.firstNameData !== "" &&
                this.middleNameData !== "" &&
                this.lastNameData !== "" &&
                this.birthDateData !== "" &&
                this.emailAddressData !== "" &&
                this.emailAddressData !== !isEmailValid
            ){
                const newStudent = {
                    enroll: {
                        student: {
                            firstName: this.firstNameData,
                            middleName: this.middleNameData,
                            lastName: this.lastNameData,
                            birthDate: this.birthDateData,
                            emailAddress: this.emailAddressData,
                        },
                        subjectIds: this.subjectIds,
                    }
                }

                studentStoreData.addStudent(newStudent).then(() => {
                    this.$toast.show(`Success!! Data saved successfully`, {
                        position: "top",
                    });
                    window.location.reload();
                });
            }

            if (!isEmailValid) {
                this.isEmailInvalidError = true
            }
            if (this.firstNameData === "") {
                this.isFirstNameError = true
            }
            if (this.middleNameData === "") {

                this.isMiddleNameError = true
            }
            if (this.lastNameData === "") {
                this.isLastNameError = true
            }
            if (this.birthDateData === "") {
                this.isBirthdateError = true
            }
           

            // try {
            //     await studentStore()
            //         .addStudent({
            //             enroll: {
            //                 student: {
            //                     firstName: this.firstNameData,
            //                     middleName: this.middleNameData,
            //                     lastName: this.lastNameData,
            //                     birthDate: this.birthDate,
            //                     emailAddress: this.emailAddress,
            //                 },
            //                 subjectIds: this.subjectIds,
            //             }
            //         })
            //         .then((response) => {
            //             console.log(response.data);
            //             this.$toast.show(`Success!! Data saved successfully`, {
            //                 position: "top",
            //             });
            //             window.location.reload();
            //         });
            // } catch (error) {
            //     console.log(error);
            // }
        },
        selectAll() {
            this.subjectIds = [];

            if (!this.isAllSelected) {
                this.Subject.forEach((subject) => {
                    this.subjectIds.push(subject.subjectID);
                });
            }
            this.isAllSelected = !this.isAllSelected;
        },

    },
    watch: {
        subjectIds(value) {
            if (value.length === 0) {
                this.isAllSelected = false;
            } else if (value.length === this.Subject.length) {
                this.isAllSelected = true;
            } else {
                this.isAllSelected = false;
            }
        },
    },

};
</script>