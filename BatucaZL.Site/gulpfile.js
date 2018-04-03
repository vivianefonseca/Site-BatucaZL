/// <binding BeforeBuild='default' Clean='clean, minify, scripts, default' />
/*
This file in the main entry point for defining Gulp tasks and using Gulp plugins.
Click here to learn more. http://go.microsoft.com/fwlink/?LinkId=518007
*/

var gulp = require('gulp');
var uglify = require('gulp-uglify');
var concat = require('gulp-concat');
var rimraf = require("rimraf");
var merge = require('merge-stream');

gulp.task("minify", function () {

    //var streams = [
    //    gulp.src(["wwwroot/js/*.js", '!wwwroot/js/tour*.js', '!wwwroot/js/contact.js'])
    //        .pipe(uglify())
    //        .pipe(concat("BatucaZL.min.js"))
    //        .pipe(gulp.dest("wwwroot/lib/site")),
    //    gulp.src(["wwwroot/js/contact.js"])
    //        .pipe(uglify())
    //        .pipe(concat("contact.min.js"))
    //        .pipe(gulp.dest("wwwroot/lib/site"))
    //];

    //return merge(streams);
});

// Dependency Dirs
var deps = {
    "jquery": {
        "dist/*": ""
    },
    "bootstrap": {
        "dist/**/*": ""
    },
    "font-awesome": {
        "css/*": "css",
        "fonts/*": "fonts"
    },
    "popper.js": {
        "dist/*": ""
    }
};

gulp.task("clean", function (cb) {
    return rimraf("wwwroot/vendor/", cb);
});

gulp.task("scripts", function () {

    var streams = [];

    for (var prop in deps) {
        console.log("Prepping Scripts for: " + prop);
        for (var itemProp in deps[prop]) {
            streams.push(gulp.src("node_modules/" + prop + "/" + itemProp)
                .pipe(gulp.dest("wwwroot/vendor/" + prop + "/" + deps[prop][itemProp])));
        }
    }

    return merge(streams);

});

gulp.task("default", ['clean', 'minify', 'scripts']);