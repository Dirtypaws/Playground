/// <binding Clean='clean' ProjectOpened='watch' />
"use strict";

var gulp = require("gulp"),
    rimraf = require("rimraf"),
    concat = require("gulp-concat"),
    cssmin = require("gulp-cssmin"),
    uglify = require("gulp-uglify"),
    flatten = require("gulp-flatten"),
    watch = require("gulp-watch"),
    less = require("gulp-less"),
    sass = require("gulp-sass"),
    merge = require("merge-stream"),
    dest = "./wwwroot";

var paths = {
    libs: "./bower/_libs/",
    bower: "./bower/"
};

gulp.task("clean", function (cb) {
    rimraf(dest, cb);
});

gulp.task("js:libs", function () {
    return gulp.src([
            paths.libs + "**/dist/jquery.js",
            paths.libs + "**/dist/js/bootstrap.js",
            paths.libs + "**/routie.js",
            paths.bower + "kendo/**/kendo.web.js",
            paths.libs + "**/pnotify.js",
            paths.libs + "**/isotope.pkgd.js",
            paths.libs + "**/select2.js"
    ])
        .pipe(concat("libs.min.js"))
        .pipe(uglify())
        .pipe(gulp.dest(dest));
});

gulp.task("js:app", function () {
    gulp.src(["Scripts/**", "!Scripts/*.js"], { base: "Scripts" })
        .pipe(uglify())
        .pipe(gulp.dest(dest));

    return gulp.src([
            "Scripts/*.js",
            "!Scripts/*.min.js"
    ])
        .pipe(concat("app.min.js"))
        .pipe(uglify())
        .pipe(gulp.dest(dest));
});

gulp.task("js", ["js:libs", "js:app"]);

gulp.task("css:app", function () {
    return gulp.src(["Content/*.css", "!Content/*.min.css", "Content/*.less"])
        .pipe(less())
        .pipe(cssmin())
        .pipe(concat("app.min.css"))
        .pipe(gulp.dest(dest));

});

gulp.task("css", ["css:libs", "css:app", "css:fonts", "css:images"]);


gulp.task("css:libs", function () {
    var sassStream = gulp.src([
            paths.bower + "font-awesome/font-awesome.scss",
            paths.bower + "select2/core.scss"
        ])
        .pipe(sass())
        .pipe(concat("sass.css"));

    var cssStream = gulp.src([
            paths.libs + "pnotify/dist/pnotify.css"
        ])
        .pipe(concat("less.css"));

    var lessStream = gulp.src([
            paths.bower + "bootstrap/bootstrap.less",
            paths.bower + "kendo/kendo.common-bootstrap.less",
            paths.bower + "kendo/kendo.bootstrap.less"
    ])
        .pipe(less().on("error", function(e) { console.log(e); }))
        .pipe(concat("libs.min.css"));

    return merge(sassStream, cssStream, lessStream)
        .pipe(concat("libs.min.css"))
        .pipe(gulp.dest(dest));
});

gulp.task("css:fonts", function () {
    return gulp.src([paths.libs + "**/font-awesome/fonts/**/*.*", "!**/*.html", "!**/*.txt", "!**/*.less"])
        .pipe(flatten())
        .pipe(gulp.dest(dest + "/fonts"));
});

gulp.task("css:images", function () {
    return gulp.src([
            paths.bower + "kendo/_lib/Bootstrap/*.*"
    ])
        .pipe(flatten())
        .pipe(gulp.dest(dest + "/images"));

});

gulp.task("watch", function () {
    watch(paths.bower + "*/*.scss", function () {
        gulp.start("css:libs");
    });

    watch(paths.bower + "*/*.less", function () {
        gulp.start("css:libs");
    });

    watch(["./Content/**/*.less", "./Content/**/*.scss", "./Content/*.less", "./Content/*.scss"], function () {
        gulp.start("css:app");
    });

    watch("./Scripts/**/*.js", function () {
        gulp.start("js:app");
    });
});