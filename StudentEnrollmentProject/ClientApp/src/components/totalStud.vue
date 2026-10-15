<template>
  {{ this.Student.length }}
</template>

<script>
import { studentStore } from "./../stores/student_module";

export default {
  name: "app",
  data() {
    return {
      Student: [],
    };
  },

  async created() {
    try {
      await studentStore().getStudent();
      this.Student = studentStore().$state.students;
    } catch (error) {
      console.log(error);
    }
  },
};
</script>
<style></style>
