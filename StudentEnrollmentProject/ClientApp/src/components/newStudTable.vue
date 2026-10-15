<template>
  <div class="home">
    <!-- homeview table -->
    <table id="hometable">
      <thead>
        <tr>
          <th>Student No.</th>
          <th>Name</th>
          <th>Birthdate</th>
          <th>Email Address</th>
          <th></th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="studentData in Student" :key="studentData.studentID" class="clickable" type="button">
          <td @click="this.studentinfo(studentData.studentID)">
            {{ studentData.studentID }}
          </td>
          <td @click="this.studentinfo(studentData.studentID)">
            {{ studentData.firstName }} {{ studentData.middleName }}
            {{ studentData.lastName }}
          </td>
          <td @click="this.studentinfo(studentData.studentID)">
            {{ dateConvert(studentData.birthDate) }}
          </td>
          <td @click="this.studentinfo(studentData.studentID)">
            {{ studentData.emailAddress }}
          </td>

          <td>
            <button class="edit" @click="this.studentupdate(studentData.studentID)">
              Edit
            </button>
            <button class="delete" @click="ShowDelete(studentData)">Delete</button>
          </td>
        </tr>
      </tbody>
    </table>

    <!-- MODAL FOR STUDENT INFO -->
    <div v-show="modalStudentInfoOpen" class="modalstudentinfo" tabindex="0" @keyup.esc="modalStudentInfoOpen = false"
      ref="modalStudentInfo">
      <div class="modal-inner-info">
        <div class="upper" @click="modalStudentInfoOpen = false">
          <h1></h1>
          <i @click="close" type="button"><svg xmlns="http://www.w3.org/2000/svg" height="30px" fill="currentColor"
              class="bi" viewBox="0 0 16 16">
              <path
                d="M4.646 4.646a.5.5 0 0 1 .708 0L8 7.293l2.646-2.647a.5.5 0 0 1 .708.708L8.707 8l2.647 2.646a.5.5 0 0 1-.708.708L8 8.707l-2.646 2.647a.5.5 0 0 1-.708-.708L7.293 8 4.646 5.354a.5.5 0 0 1 0-.708z" />
            </svg></i>
        </div>

        <div class="stud-subj-title">
          <h1>Student Information</h1>
          <h2>Subjects Enrolled</h2>
        </div>

        <div class="student-studentinfo">
          <div class="title-studentinfo">
            <p2-studentinfo>Student No: <p1-studentinfo>{{ studentInfoResponse.student.studentID
            }}</p1-studentinfo></p2-studentinfo>
            <p2-studentinfo>Name: <p1-studentinfo>{{ studentInfoResponse.student.firstName }} {{
              studentInfoResponse.student.middleName }} {{ studentInfoResponse.student.lastName
              }}</p1-studentinfo></p2-studentinfo>
            <p2-studentinfo>Birthdate: <p1-studentinfo>{{ dateConvert(studentInfoResponse.student.birthDate) }}</p1-studentinfo></p2-studentinfo>
            <p2-studentinfo>Email Address: <p1-studentinfo>{{ studentInfoResponse.student.emailAddress }}</p1-studentinfo></p2-studentinfo>
          </div>

          <div class="line"></div>
          <div class="subjectinfo">
            <table id="subjectinfo">
              <thead></thead>
              <tr v-for="subject in studentInfoResponse.subjects" :key="subject.subjectID">
                <td>{{ subject.subjectName }}</td>
              </tr>
            </table>
          </div>
        </div>
      </div>
    </div>

    <!-- MODAL FOR STUDENT UPDATE -->
    <div v-show="modalUpdateOpen" class="modal" tabindex="0" @keyup.esc="modalUpdateOpen = false" ref="modalUpdate">
      <div class="modal-inner">
        <div class="upper" @click="modalUpdateOpen = false">
          <h1>Update Information</h1>
          <i @click="close" type="button"><svg xmlns="http://www.w3.org/2000/svg" height="30px" fill="currentColor"
              class="bi" viewBox="0 0 16 16">
              <path
                d="M4.646 4.646a.5.5 0 0 1 .708 0L8 7.293l2.646-2.647a.5.5 0 0 1 .708.708L8.707 8l2.647 2.646a.5.5 0 0 1-.708.708L8 8.707l-2.646 2.647a.5.5 0 0 1-.708-.708L7.293 8 4.646 5.354a.5.5 0 0 1 0-.708z" />
            </svg></i>
        </div>

        <div class="modal-content-update">
          <div class="updatestudent">
            <div class="title">
              <p2-updatestudent>Student No:</p2-updatestudent>
            </div>
            <div>
              <tr>
                <p1-updatestudent>{{
                  studentInfoResponse.student.studentID
                }}</p1-updatestudent>
              </tr>
            </div>
          </div>

          <div class="home2-updatestudent">
            <div class="modal-contents-updatestudent">
              <div class="name-updatestudent">
                <p>Name:</p>
                <input type="text" v-model="this.first" />
                <input type="text" v-model="this.middle" />
                <input type="text" v-model="this.last" />
              </div>

              <div class="dob-updatestudent">
                <p>Date of Birth:</p>
                <input type="date" v-model="this.birth" />
                <p>Email Address:</p>
                <input type="text" v-model="this.email" />
              </div>

              <div class="subjectupdate">
                <table id="subjectupdate">
                  <thead>
                    <tr>
                      <td>
                        <input type="checkbox" v-model="isAllSelected" @click="selectAll" />
                      </td>
                      <th>Subjects</th>
                    </tr>
                  </thead>
                  <tbody>
                    <tr v-for="subject in this.Subject" :key="subject.subjectID">
                      <td>
                        <input type="checkbox" v-model="subjectIds" :value="subject.subjectID" />
                      </td>
                      <td>{{ subject.subjectName }}</td>
                    </tr>
                  </tbody>
                </table>
              </div>
            </div>
          </div>
        </div>

        <div class="update-buttons">
          <button type="submit" class="save" @click="ShowUpdate(studentInfoResponse)">
            Save
          </button>
        </div>
      </div>
    </div>

    <!-- div for home -->
  </div>

  <!-- UPDATE INFO ALERT Dialog Start -->
  <div class="custom-alert-modal" v-if="showdialogUpdate">
    <div class="custom-alert-dialog">
      <p class="message">
        Are you sure you want to update the information?
      </p>
      <div class="buttons">
        <button style="margin-right: 10px" class="primary-button" @click="YesUpdate()">
          Yes
        </button>
        <button class="secondary-button" @click="CloseUpdate()">Cancel</button>
      </div>
    </div>
  </div>
  <!-- UPDATE INFO ALERT Dialog End -->

  <!-- Delete Account ALERT Dialog Start -->
  <div class="custom-alert-modal" v-if="showdialog">
    <div class="custom-alert-dialog">
      <p class="message">
        Are you sure you want to delete this data permanently?
      </p>
      <div class="buttons">
        <button style="margin-right: 10px" class="primary-button" @click="YesDelete()">
          Yes
        </button>
        <button class="secondary-button" @click="CloseDelete()">Cancel</button>
      </div>
    </div>
  </div>
  <!-- Delete Account ALERT Dialog End -->
</template>

<script>
import { ref } from "vue";
import { studentStore } from "./../stores/student_module";
import { mapState } from "pinia";

export default {
  name: "app",
  data() {
    return {
      Student: [],
      Subject: [],
      subjectIds: [],

      StudentSubject: {
        result1: {
          studentID: "",
          firstName: "",
          middleName: "",
          lastName: "",
          birthDate: "",
          emailAddress: "",
        },
        result2: {
          subjectID: "",
          subjectName: "",
        },
      },
      selectedStudent: 0,
      updateid: 0,
      student: {},
      showdialog: false,
      showdialogUpdate: false,
      modalUpdateOpen: false,
      modalStudentInfoOpen: false,
    };
  },
  mounted() {
    this.created();
    this.subjectdata();
  },
  computed: {
    ...mapState(studentStore, {
      studentInfoResponse: "studentInfoResponse"
    })
  },

  methods: {
    toggleModalStudentInfoPage() {
      this.modalStudentInfoOpen = true;
      this.$refs.modalStudentInfo.focus();
      this.$nextTick(() => {
        this.$refs.modalStudentInfo.focus();
      });
    },

    // getStudent with ID
    async studentinfo(studentIDs) {
      this.toggleModalStudentInfoPage();
      const res = await studentStore().getStudentID(studentIDs)
    },

    //toggle FOR MODAL UPDATE
    toggleModalUpdatePage() {
      this.modalUpdateOpen = true;
      this.$refs.modalUpdate.focus();
      this.$nextTick(() => {
        this.$refs.modalUpdate.focus();
      });
    },
    // CODE FOR MODAL OF STUDENT UPDATE
    async studentupdate(studentID) {

      // Set the student ID and show the modal
      try {
        await studentStore()
          .getStudentID(studentID)
          .then((res) => {
            this.StudentSubject = res;
            this.first = this.studentInfoResponse.student.firstName;
            this.middle = this.studentInfoResponse.student.middleName;
            this.last = this.studentInfoResponse.student.lastName;
            this.birth = this.studentInfoResponse.student.birthDate;
            this.email = this.studentInfoResponse.student.emailAddress;
            this.toggleModalUpdatePage();
          });
      } catch (error) {
        console.log(error);
      }
    },
    //alert box for update
    async YesUpdate() {
      const updatestudentID = this.studentInfoResponse.student.studentID;
      const res = await studentStore().updateStudent(updatestudentID, {
        student: {
          studentID: this.studentInfoResponse.student.studentID,
          firstName: this.first,
          middleName: this.middle,
          lastName: this.last,
          birthDate: this.birth,
          emailAddress: this.email,
        },
        subjectIds: this.subjectIds,

      });
      if (res) {
        this.$toast.show(`Success!! Data Updated successfully`, {
          position: "top",
        });
        window.location.reload();
      } else {
        this.$toast.show(`ERROR`, {
          position: "top",
        });
        this.CloseDelete();
      }
    },
    ShowUpdate(StudentSubject) {
      this.showdialogUpdate = true;
      this.updateid = StudentSubject;
    },
    CloseUpdate() {
      this.showdialogUpdate = false;
    },

    //alert box for delete
    async YesDelete() {
      const studentID = this.selectedStudent.studentID;
      console.log("studentID", studentID);
      const res = await studentStore().deleteStudent(studentID);
      if (res) {
        this.$toast.show(`Success!! Data deleted successfully`, {
          position: "top",
        });
        this.CloseDelete();
        this.created();
      } else {
        this.$toast.show(`ERROR`, {
          position: "top",
        });
        this.CloseDelete();
      }
    },
    ShowDelete(student) {
      this.showdialog = true;
      this.selectedStudent = student;
    },
    CloseDelete() {
      this.showdialog = false;
    },

    // getStudent
    async created() {
      try {
        await studentStore().getStudent();
        this.Student = studentStore().$state.students;
      } catch (error) {
        console.log(error);
      }
    },

    // getSubject
    async subjectdata() {
      try {
        await studentStore().getSubject();
        this.Subject = studentStore().$state.subjects;
      } catch (error) {
        console.log(error);
      }
    },

    //for date convert
    dateConvert(dateParams) {
      const inputDate = new Date(dateParams);
      const month = String(inputDate.getMonth() + 1).padStart(2, "0");
      const day = String(inputDate.getDate()).padStart(2, "0");
      const year = inputDate.getFullYear();
      const formattedDate = `${year}-${month}-${day}`;
      return formattedDate;
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

  // For MODAL
  setup() {
    const modalActive = ref(false);
    const modalOpen = ref(false);
    const toggleModal = () => {
      modalActive.value = !modalActive.value;
    };
    const openModal = () => {
      modalOpen.value = !modalOpen.value;
    };
    return { modalActive, modalOpen, toggleModal, openModal };
  },
};
</script>
