﻿using System.Web;
using System.Web.Optimization;

namespace Store
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery.unobtrusive-ajax.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.min.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/angular-block-ui.min.css"));

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                      "~/Scripts/angular/angular.min.js",
                      "~/Scripts/angular/angular-route.min.js",
                      "~/Scripts/angular-ui/ui-bootstrap-tpls.min.js",
                      "~/Scripts/angular-block-ui/angular-block-ui.min.js",
                      "~/Scripts/angular/angular-sanitize.min.js"));

            
                bundles.Add(new ScriptBundle("~/bundles/menu").Include(
                      "~/Scripts/menu/navigationBar.js"));
        }
    }
}
