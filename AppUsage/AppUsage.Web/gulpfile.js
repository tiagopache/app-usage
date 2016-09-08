/// <binding ProjectOpened='watch' />
/// <binding Clean='clean' />
/*
This file in the main entry point for defining Gulp tasks and using Gulp plugins.
Click here to learn more. http://go.microsoft.com/fwlink/?LinkId=518007
*/

"use strict"

var gulp = require('gulp'),
    tsc = require('gulp-typescript'),
    concat = require('gulp-concat'),
    cssmin = require('gulp-cssmin'),
    uglify = require('gulp-uglify'),
    rimraf = require('rimraf');

var paths = {
    ts: {
        src: ["ts/**/*.ts", "typings/index.d.ts"],
        dest: "./wwwroot/app"
    },
    npm: "./node_modules/",
    bower: "./bower_components/",
    lib: "./wwwroot/libs/",
    webroot: "./wwwroot/"
}

paths.bootstrapCss = paths.bower + "bootstrap/dist/css/bootstrap.css";
paths.sbAdminCss = paths.bower + "startbootstrap-sb-admin-2/dist/css/sb-admin-2.css";
paths.fontAwesomeCss = paths.bower + "font-awesome/css/font-awesome.css";
paths.morrisCss = paths.bower + "morrisjs/morris.css";
paths.metisCss = paths.bower + "metisMenu/dist/metisMenu.css";

paths.sbAdminJs = paths.bower + "startbootstrap-sb-admin-2/dist/js/sb-admin-2.js";
paths.jqueryJs = paths.bower + "jquery/dist/jquery.js";
paths.raphaelJs = paths.bower + "raphael/raphael.js";
paths.morrisJs = paths.bower + "morrisjs/morris.js";
paths.metisJs = paths.bower + "metisMenu/dist/metisMenu.js";

paths.fonts = paths.bower + "font-awesome/fonts/*";

paths.jsDest = paths.lib;
paths.cssDest = paths.webroot + "css";
paths.fontDest = paths.webroot + "css/fonts";

gulp.task("build", function () {
    var tsProject = tsc.createProject("tsConfig.json");

    return gulp.src(paths.ts.src)
            .pipe(tsc(tsProject))
            .pipe(gulp.dest(paths.ts.dest));
});

gulp.task("bundle:js", function () {
    // bundle jquery
    gulp.src(paths.npm + "jquery/dist/*.js", { base: paths.npm + "jquery/dist" })
        .pipe(gulp.dest(paths.lib + "jquery/"));

    // bundle systemjs
    gulp.src(paths.npm + "systemjs/dist/**/*.*", { base: paths.npm + "systemjs/dist" })
        .pipe(gulp.dest(paths.lib + "systemjs/"));

    // bundle angular2
    gulp.src(paths.npm + "angular2/bundles/**/*.js", { base: paths.npm + "angular2/bundles" })
        .pipe(gulp.dest(paths.lib + "angular2/"));

    // bundle es6-shim
    gulp.src(paths.npm + "es6-shim/es6-sh*", { base: paths.npm + "es6-shim/" })
        .pipe(gulp.dest(paths.lib + "es6-shim/"));

    // bundle es6-promise
    gulp.src(paths.npm + "es6-promise/dist/**/*.*", { base: paths.npm + "es6-promise/dist" })
        .pipe(gulp.dest(paths.lib + "es6-promise/"));

    // bundle rxjs
    gulp.src(paths.npm + "rxjs/bundles/*.*", { base: paths.npm + "rxjs/bundles" })
        .pipe(gulp.dest(paths.lib + "rxjs/"));

    // bundle bootstrap
    gulp.src(paths.npm + "bootstrap/dist/js/*.*", { base: paths.npm + "bootstrap/dist/js" })
        .pipe(gulp.dest(paths.lib + "bootstrap/"));
});

gulp.task("bundle:css", function () {
    gulp.src(paths.npm + "bootstrap/dist/css/bootstrap.min.css")
        .pipe(gulp.dest(paths.cssDest));

    gulp.src(paths.npm + "bootstrap/dist/fonts/*.*")
        .pipe(gulp.dest(paths.fontDest));
})

gulp.task("copy:js", function () {
    return gulp.src([paths.jqueryJs, paths.raphaelJs, paths.morrisJs, paths.metisJs, paths.sbAdminJs])
            .pipe(gulp.dest(paths.jsDest));
});

gulp.task("copy:css", function () {
    return gulp.src([paths.bootstrapCss, paths.sbAdminCss, paths.fontAwesomeCss, paths.morrisCss, paths.metisCss, paths.sbAdminCss])
            .pipe(gulp.dest(paths.cssDest));
});

gulp.task("copy:fonts", function () {
    return gulp.src([paths.fonts])
            .pipe(gulp.dest(paths.fontDest));
});

gulp.task("min:js", function () {
    return gulp.src([paths.jqueryJs, paths.raphaelJs, paths.morrisJs, paths.metisJs, paths.sbAdminJs])
            .pipe(concat(paths.jsDest + "/min/site.min.js"))
            .pipe(uglify())
            .pipe(gulp.dest("."));
});

gulp.task("min:css", function () {
    return gulp.src([paths.bootstrapCss, paths.sbAdminCss, paths.fontAwesomeCss, paths.morrisCss, paths.metisCss, paths.sbAdminCss])
            .pipe(concat(paths.cssDest + "/min/site.min.css"))
            .pipe(cssmin())
            .pipe(gulp.dest("."));
});

gulp.task("watch", function () {
    return gulp.watch(paths.ts.src, ["build"]);
});

gulp.task('default', function () {
    // place code for your default task here
});

gulp.task("copy", ["copy:js", "copy:css", "copy:fonts"]);
gulp.task("min", ["min:js", "min:css"]);