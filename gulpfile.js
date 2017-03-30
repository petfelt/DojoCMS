var gulp = require('gulp');
var DestinationDirectory = 'someDirectory'
var OutputFileName = 'someFileName'

gulp.task('WriteFile', function() {
    gulp.src('{./inputFile}'), {base: DestinationDirectory}
  .pipe(gulp.dest(OutputFileName))
});