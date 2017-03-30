var gulp = require('gulp');

gulp.task('WriteFile', function() {
  gulp.src('{inputFile}')
  //can perform other logic tasks here
  .pipe(gulp.dest('{outputDestination}'))
});