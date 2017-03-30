var gulp = require('gulp');
//
return gulp.task('WriteFile', function() {
  gulp.src('{InputFile}')
  //can perform other logic tasks here
    .pipe(gulp.dest('OutputDirectory/OutputFileName'))
});