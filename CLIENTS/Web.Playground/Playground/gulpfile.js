/// <binding Clean='clean' ProjectOpened='watch' />
"use strict";

var gulp = require("gulp"),
    rimraf = require("rimraf"),
    concat = require("gulp-concat"),
    cssmin = require("gulp-cssmin"),
    uglify = require("gulp-uglify"),
    flatten = require("gulp-flatten"),
    sass = require("gulp-sass"),
    watch = require("gulp-watch"),
    dest = "./wwwroot";

var paths = {
    src: "./bower_components/libs/",
    css: {
        libs: dest + "/libs.min.css",
        site: dest + "/site.min.css"
    },
    js: {
        libs: dest + "/libs.min.js",
        site: dest + "/site.min.js"
    },
    fonts: dest + "/fonts"
};

gulp.task("clean:js", function (cb) {
    rimraf(paths.js.libs, cb);
    rimraf(paths.js.site, cb);
});

gulp.task("clean:css", function (cb) {
    rimraf(paths.css.libs, cb);
    rimraf(paths.css.site, cb);
});

gulp.task("clean:fonts", function(cb) {
    rimraf(dest + "/fonts", cb);
});

gulp.task("clean", ["clean:js", "clean:css", "clean:fonts"]);

gulp.task("js:lib", function() {
    return gulp.src([
            paths.src + "**/dist/jquery.js",
            "!" + paths.src + "**/dist/jquery.min.js",
            paths.src + "**/dist/js/bootstrap.js",
            "!" + paths.src + "**/dist/js/bootstrap.min.js",
            paths.src + "**/dist/**/select2.js",
            "!" + paths.src + "**/dist/**/select2.min.js",
            paths.src + "**/bootbox.js",
            "!" + paths.src + "**/bootbox.min.js",
            paths.src + "**/isotope.pkgd.js",
            "!" + paths.src + "**/isotope.pkgd.min.js",
            paths.src + "**/routie.js",
            "!" + paths.src + "**/routie.min.js",
            paths.src + "**/jquery.jqGrid.js",
            "!" + paths.src + "**/jquery.jqGrid.min.js"
        ])
        .pipe(concat("libs.min.js"))
        .pipe(uglify())
        .pipe(gulp.dest(dest));
});

gulp.task("js:app", function () {
    return gulp.src([
            "Scripts/*.js",
            "!Scripts/*.min.js"
    ])
        .pipe(concat("app.min.js"))
        .pipe(uglify())
        .pipe(gulp.dest(dest));
});

gulp.task("js", ["js:lib", "js:app"]);

gulp.task("css:app", function() {
    return gulp.src(["Content/*.css", "!Content/*.min.css"])
        .pipe(concat("app.min.css"))
        .pipe(cssmin())
        .pipe(gulp.dest(dest));

});

gulp.task("css", ["css:libs", "css:app", "css:fonts"]);


gulp.task("css:libs", function () {
    return gulp.src([
            "./bower_components/libs/jqgrid/css/*.css",
            //"!./bower_components/libs/select2/dist/css/*.min.css",
            "./bower_components/libs/select2/src/scss/core.scss",
            "./bower_components/libs/select2/src/scss/layout.scss",
            "./bower_components/select2/build.scss",
            "./bower_components/bootstrap/bootstrap.scss",
            "./bower_components/font-awesome/font-awesome.scss"
        ])
        .pipe(sass())
        .pipe(cssmin())
        .pipe(concat("libs.min.css"))
        .pipe(gulp.dest(dest));
});

gulp.task("css:fonts", function () {
    gulp.src([paths.src + "**/fonts/**/*.*", "!**/.html"])
        .pipe(flatten())
        .pipe(gulp.dest(dest + "/fonts"));
});

gulp.task("watch", function() {
    watch("./bower_components/*/*.scss", function() {
        gulp.start("css:libs");
    });
});
