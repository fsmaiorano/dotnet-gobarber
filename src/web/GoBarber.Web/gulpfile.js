"use strict";

const autoprefixer = require("gulp-autoprefixer");
const concat = require("gulp-concat");
const gulp = require("gulp");
const gulpif = require("gulp-if");
const minify = require("gulp-minifier");
const sass = require("gulp-sass");
const sourcemaps = require("gulp-sourcemaps");
const strip = require("gulp-strip-css-comments");
const ts = require("gulp-typescript");
const tsProject = ts.createProject("./tsconfig.json");

let isProduction = false;

const paths = {
    dist: {
        scripts: "./wwwroot/assets/scripts/",
        styles: "./wwwroot/assets/styles/",
        vendor: "./wwwroot/lib/"
    },
    srcFiles: {
        scripts: "./Source/scripts/**/*.ts",
        styles: "./Source/styles/**/*.scss",
        stylesVendor: [
            ///* 01 */ "node_modules/bootstrap/dist/css/bootstrap.min.css",
            ///* 02 */ "node_modules/toastr/build/toastr.min.css",
            ///* 03 */ "node_modules/flickity/dist/flickity.min.css",
            ///* 04 */ "node_modules/plyr/dist/plyr.css",
            ///* 05 */ "node_modules/malihu-custom-scrollbar-plugin/jquery.mCustomScrollbar.css"
        ],
        scriptsVendors: [
            ///* 01 - polyfill */ "node_modules/classlist.js/classList.min.js",
            ///* 01 - polyfill */ "node_modules/intersection-observer/intersection-observer.js",
            ///* 02 */ "node_modules/lozad/dist/lozad.min.js",
            ///* 03 */ "node_modules/jquery/dist/jquery.min.js",
            ///* 04 */ "node_modules/popper.js/dist/umd/popper.min.js",
            ///* 05 */ "node_modules/bootstrap/dist/js/bootstrap,min.js",
            ///* 06 */ "node_modules/toastr/build/toastr.min.js",
            ///* 07 */ "node_modules/flickity/dist/flickity.pkgd.min.js",
            ///* 08 */ "node_modules/plyr/dist/plyr.polyfilled.min.js",
            ///* 09 */ "node_modules/vanilla-masker/build/vanilla-masker.min.js",
            ///* 10 */ "node_modules/clipboard/dist/clipboard.min.js",
            ///* 11 */ "node_modules/malihu-custom-scrollbar-plugin/jquery.mCustomScrollbar.concat.min.js",
            ///* 12 */ "node_modules/isotope-layout/dist/isotope.pkgd.min.js",
            ///* 13 */ "node_modules/isotope-masonry-horizontal/masonry-horizontal.js",
            ///* 14 */ "node_modules/hls.js/dist/hls.min.js",
            /* 99 */ "node_modules/requirejs/require.js"
        ]
    }
};

/* ===================== SCRIPTS =====================*/
function scripts() {
    return gulp
        .src(paths.srcFiles.scripts)
        .pipe(gulpif(!isProduction, sourcemaps.init()))
        .pipe(tsProject())
        .pipe(gulpif(!isProduction, sourcemaps.write()))
        .pipe(
            gulpif(
                isProduction,
                minify({
                    minify: true,
                    minifyJS: true,
                    getKeptComment: function (content) {
                        var m = content.match(/\/\*![\s\S]*?\*\//gim);
                        return (m && m.join("\n") + "\n") || "";
                    }
                })
            )
        )
        .pipe(gulp.dest(paths.dist.scripts));
};

/* ===================== STYLES =====================*/
function styles() {
    return gulp
        .src(paths.srcFiles.styles)
        .pipe(gulpif(!isProduction, sourcemaps.init()))
        .pipe(sass())
        .pipe(autoprefixer())
        .pipe(gulpif(!isProduction, sourcemaps.write()))
        .pipe(gulpif(isProduction, strip()))
        .pipe(gulpif(isProduction, minify({ minify: true, minifyCSS: true })))
        .pipe(gulp.dest(paths.dist.styles));
};

/* ===================== VENDOR =====================*/
function vendorScripts() {
    return gulp
        .src(paths.srcFiles.scriptsVendors)
        .pipe(
            minify({
                minify: true,
                minifyJS: true,
                getKeptComment: function (content) {
                    var m = content.match(/\/\*![\s\S]*?\*\//gim);
                    return (m && m.join("\n") + "\n") || "";
                }
            })
        )
        .pipe(concat("lib.js"))
        .pipe(gulp.dest(paths.dist.vendor));
};

function vendorStyles() {
    return gulp
        .src(paths.srcFiles.stylesVendor)
        .pipe(strip())
        .pipe(minify({ minify: true, minifyCSS: true }))
        .pipe(concat("lib.css"))
        .pipe(gulp.dest(paths.dist.vendor));
};

const dev = function (done) {
    gulp.watch(paths.srcFiles.scripts, scripts);
    gulp.watch(paths.srcFiles.styles, styles);
    gulp.watch(paths.srcFiles.scriptsVendors, vendorScripts);
    done();
}

const build = gulp.series(scripts, styles, vendorScripts);

exports.dev = dev;
exports.build = build;
exports.default = build;