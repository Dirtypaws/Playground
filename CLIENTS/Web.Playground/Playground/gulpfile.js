/// <binding />
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
    src: "./bower_components/_libs/",
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

gulp.task("clean:fonts", function (cb) {
    rimraf(dest + "/fonts", cb);
});

gulp.task("clean", ["clean:js", "clean:css", "clean:fonts"]);

gulp.task("js:libs", function () {
    return gulp.src([
            paths.src + "**/dist/jquery.js",
            paths.src + "**/dist/js/bootstrap.js",

            paths.src + "**/routie.js", "./bower_components/kendo/**/kendo.web.js",
            // paths.src + "**/routie.js",

            paths.src + "**/pnotify.js",
            paths.src + "**/isotope.pkgd.js",
            paths.src + "**/select2.js"
            // paths.src + "**/bootstrap-toggle.js"
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
            "./bower_components/select2/core.scss"
        ])
        .pipe(sass())
        .pipe(concat("sass.css"));

    var cssStream = gulp.src([
            "./bower_components/_libs/pnotify/dist/pnotify.css"
        ])
        .pipe(concat("less.css"));

    var lessStream = gulp.src([
            "./bower_components/bootstrap/bootstrap.less",
             "./bower_components/kendo/kendo.common-bootstrap.less",
             "./bower_components/kendo/kendo.bootstrap.less",
            "./bower_components/font-awesome/font-awesome.less"
    ])
        .pipe(less().on("error", function(e) { console.log(e); }))
        .pipe(concat("libs.min.css"));

    return merge(sassStream, cssStream, lessStream)
        .pipe(concat("libs.min.css"))
        .pipe(gulp.dest(dest));
});

gulp.task("css:fonts", function () {
    return gulp.src([paths.src + "**/font-awesome/fonts/**/*.*", "!**/*.html", "!**/*.txt", "!**/*.less"])
        .pipe(flatten())
        .pipe(gulp.dest(dest + "/fonts"));
});

gulp.task("css:images", function () {
    return gulp.src([
            "./bower_components/kendo/_lib/Bootstrap/*.*"
    ])
        .pipe(flatten())
        .pipe(gulp.dest(dest + "/images"));

});

gulp.task("watch", function () {
    watch("./bower_components/*/*.scss", function () {
        gulp.start("css:libs");
    });

    watch("./bower_components/*/*.less", function () {
        gulp.start("css:libs");
    });

    watch("./Content/**/*.less", function () {
        gulp.start("css:app");
    });

    watch("./Scripts/**/*.js", function () {
        gulp.start("js:app");
    });
});