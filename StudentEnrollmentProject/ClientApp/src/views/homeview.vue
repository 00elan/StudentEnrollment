<template>
  <main>
    <div class="stud">
      <table>
        <tr>
          <td>
            <div class="total">
              <people />
              <h1>
                <totalStud />
              </h1>
            </div>
            <h2>Total Students</h2>
          </td>
        </tr>
        <tr>
          <td>
            <div class="all">
              <button style="margin-top: 5px">All Student</button>
            </div>
          </td>
        </tr>
      </table>
    </div>

    <div class="subj">
      <table>
        <tr>
          <td>
            <div class="totals">
              <subj />
              <h1>12</h1>
            </div>
            <h2>Total Subjects</h2>
          </td>
        </tr>
        <tr>
          <td>
            <div class="alls">
              <button style="margin-top: 5px">
                <subject />
              </button>
            </div>
          </td>
        </tr>
      </table>
    </div>
  </main>

  <div class="upperhomeview">
    <addStudent />
  </div>
  <div class="center">
    <newStudTable />
  </div>
</template>

<script setup>
import people from "../components/icons/IconPeople.vue";
import subj from "../components/icons/Iconsubj.vue";
import newStudTable from "../components/newstudtable.vue";
import totalStud from "../components/totalStud.vue";
import subject from "./SubjectPage.vue";
import addStudent from "./AddStudentPage.vue"
</script>
