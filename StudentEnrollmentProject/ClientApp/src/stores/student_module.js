import { ref, computed } from "vue";
import { defineStore } from "pinia";
import axios from "axios";

var instance = axios.create({
  baseURL: window.location.origin,
  headers: {
    Accept: "*/*",
    "Content-Type": "application/json",
  },
});

export const studentStore = defineStore({
  id: "studentStore",
  state: () => ({
    studentData: [
      {
        firstName: "",
        middleName: "",
        lastName: "",
      },
    ],
    studentInfoResponse: {
      student: {
        studentID: "",
        firstName: "",
        middleName: "",
        lastName: "",
        birthDate: "",
        emailAddress: "",
      },
      subjects: [
        {
          subjectID: 0,
          subjectName: "",
        },
      ],
    },
    students: [
      {
        studentID: "1",
        firstName: "Cyril",
        middleName: "Da",
        lastName: "Paraluman",
        birthDate: "February 14, 1995",
        emailAddress: "cydparaluman@gmail.com",
      },
      {
        studentID: "2",
        firstName: "Mark Edison",
        middleName: "Cruz",
        lastName: " Nico",
        birthDate: "March 21, 1994",
        emailAddress: "edison@gmail.com",
      },
    ],
    subjects: [],
    addStudentResponse: {
      enroll: {
        student: {
          firstName: "",
          middleName: "",
          lastName: "",
          birthDate: "",
          emailAddress: "",
        },
        subjectIds: 0,
      },
    },
  }),

  actions: {
    async getStudent() {
      return instance
        .get("/api/Student", {
          headers: {},
        })
        .then((response) => {
          this.students = response.data;
        })
        .catch((error) => {
          console.error("Failed to fetch students", error);
        });
    },

    async getSubject() {
      this.subjects = [];
      try {
        const response = await instance.get("/api/Subject", {
          headers: {},
        });
        this.subjects = response.data;
        console.log("subjects", this.subjects);
        return this.subjects;
      } catch (error) {
        alert(error);
        console.log(error);
      }
    },

    async getStudentID(studentID) {
      var studentinfo = "";
      try {
        const response = await instance
          .get(`/api/Student/${studentID}`, {
            headers: {
              "Content-Type": "application/json",
            },
          })
          .then((res) => {
            studentinfo = res.data;
            this.studentInfoResponse = res.data;
          });
        return this.studentInfoResponse;
      } catch (error) {
        alert(error);
        console.log(error);
      }
    },

    async deleteStudent(studentID) {
      var deletestud = "";
      try {
        const response = await instance
          .delete(`/api/Student/${studentID}`, {
            headers: {},
          })
          .then((res) => {
            deletestud = res.data;
          });
        return true;
      } catch (error) {
        alert(error);
        console.log(error);
        return false;
      }
    },

    async addStudent(studentdetails) {
      return instance
        .post(`/api/Student`, studentdetails, {
          headers: {
            "Content-Type": "application/json",
          },
        })
        .then((res) => {
          this.addStudentResponse.push(res.data);
        })
        .catch((error) => {
          console.log(error);
        });
    },

    async updateStudent(studentID, studentdetails) {
      var updatestud = "";
      try {
        const response = await instance
          .put(`/api/Student/${studentID}`, studentdetails, {
            headers: {
              "Content-Type": "application/json",
            },
          })
          .then((res) => {
            updatestud = res.data;
          });
        return true;
      } catch (error) {
        alert(error);
        console.log(error);
        return false;
      }
    },
  },
});
