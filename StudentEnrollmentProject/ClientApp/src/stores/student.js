import { ref, computed } from 'vue'
import { defineStore } from 'pinia'

export const usestudentStore = defineStore('studentStore', {
    state: () => ({
        students: [{
                Student: "1",
                Name: "Cyril D. Paraluman",
                Email: "cydparaluman@gmai.com",
                Birthdate: "February 14, 1995",
            },
            {
                Student: "2",
                Name: "Mark Edison C. Nico",
                Email: "edison@gmai.com",
                Birthdate: "March 21, 1994",
            },
            {
                Student: "3",
                Name: "Delilah N. Samson",
                Email: "samson.delilah@gmai.com",
                Birthdate: "January 03, 1996",
            },
            {
                Student: "4",
                Name: "Oliver A. Estella",
                Email: "oliverestella@gmai.com",
                Birthdate: "December 28, 1995",
            },
            {
                Student: "5",
                Name: "Rowna Sabaelinna",
                Email: "rownasabellina@gmai.com",
                Birthdate: "September 18, 1996",
            },
            {
                Student: "6",
                Name: "Juan Dela Cruz",
                Email: "j.delacruz@gmai.com",
                Birthdate: "March 05, 1995",
            },
            {
                Student: "7",
                Name: "Jesamine Ong",
                Email: "jesaong@gmai.com",
                Birthdate: "October 24, 1995",
            },
            {
                Student: "8",
                Name: "Joseph Cua",
                Email: "josephcua@gmai.com",
                Birthdate: "November 01, 1995",
            }
        ]

    }),

    actions: {
        addStudent(student) {
            this.students.push(task)
        },
        deleteStudent(Student) {
            this.students = this.students.filter(t => {
                return t.Student !== Student
            })
        }
    }
})