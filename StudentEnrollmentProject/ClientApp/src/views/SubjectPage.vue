<template>
    <div id="app">
        <i type="button" @click="toggleModalSubjectPage()" style="font-style: normal">All Subject</i>

        <div v-show="modalSubjectOpen" class="modal" tabindex="0" @keyup.esc="modalSubjectOpen = false" ref="modal">
            <div class="modal-inner">
                <div class="upper" @click="modalSubjectOpen = false">
                    <h1 id="subjh1">Subject List</h1>
                    <i @click="close" type="button"><svg xmlns="http://www.w3.org/2000/svg" height="30px"
                            fill="currentColor" class="bi" viewBox="0 0 16 16">
                            <path
                                d="M4.646 4.646a.5.5 0 0 1 .708 0L8 7.293l2.646-2.647a.5.5 0 0 1 .708.708L8.707 8l2.647 2.646a.5.5 0 0 1-.708.708L8 8.707l-2.646 2.647a.5.5 0 0 1-.708-.708L7.293 8 4.646 5.354a.5.5 0 0 1 0-.708z" />
                        </svg></i>
                </div>
                <div class="home-subjectpage">
                    <div class="modal-content-subject">
                        <table id="home-subjectpagetable">
                            <thead>
                                <tr>
                                    <th>Subject ID</th>
                                    <th>Subject Name</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr v-for="subject in this.Subject" :key="subject.subjectID">
                                    <td>{{ subject.subjectID }}</td>
                                    <td>{{ subject.subjectName }}</td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
import { studentStore } from "./../stores/student_module";
export default {
    el: "#app",
    data() {
        return {
            modalSubjectOpen: false,
            Subject: [],
        };
    },
    async created() {
        try {
            await studentStore().getSubject();
            this.Subject = studentStore().$state.subjects;
        } catch (error) {
            console.log(error);
        }
    },

    methods: {
        toggleModalSubjectPage() {
            this.modalSubjectOpen = true;

            this.$refs.modal.focus();

            this.$nextTick(() => {
                this.$refs.modal.focus();
            });
        },
    },
};
</script>
