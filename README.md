# SeoPack

A library packed with lots of SEO goodness for ASP.Net MVC projects. Get access to a bunch of SEO Helper methods for rendering SEO compliant Html tags and for generating SEO Friendly Urls based on a set of predefined url policies. Please see "Planned features" below for other SEO features to come.

The Html SEO Helper methods are extension methods of the ASP.Net MVC HtmlHelper class. These render SEO compliant html tags according to the recommendations defined in the [MOZ SEO Cheat Sheet](https://d2eeipcrcdle6.cloudfront.net/seo-cheat-sheet.pdf) for Web developers.

The Url SEO Helper methods are extension methods of the ASP.Net MVC UrlHelper class. These generate outbound Route and Action SEO Friendly Urls based on a predefined set of url policies. Url policies are also applied to inbound urls via the RedirectToSeoFriendlyUrlAttribute filter. So you end up with a consistent set of url policies that apply to both inbound and outbound urls. The concept of url policies was inspired by the [Canonicalize](https://github.com/schourode/canonicalize) library.

At the heart of creating SEO Friendly Urls is the SeoFriendlyUrl class. The class runs a url through the url policies and ensures that the resultant url is one that conforms to these url policies.

### Supported Html Tags
1. Title
2. Meta Description
3. Anchor
4. Image
5. ImageLink
6. Canonical Links
7. Pagination Links (rel=prev, rel=next pagination attributes)
8. HrefLang Links
9. Open Graph 

### Planned features
1. Friendly urls
2. Canonicalization
3. Robots.txt
4. Sitemap.xml
5. Rich Snippets and Structured Data
6. Script Tag management
7. etc.

### Installing SeoPack - [nuget](https://www.nuget.org/packages/SeoPack/)
```
PM> Install-Package SeoPack
```

### Using SeoPack - Urls

Configuring Url Policies - this is best done on application startup.
```c#
UrlPolicyConfiguration.Configure().LowercasePolicy().WwwPolicy().NoTrailingSlashPolicy()
```

Creating outbound urls.
```c#
@Url.RouteSeoFriendlyUrl("Users", new { pageNumber = 1 })
or
@Url.ActionSeoFriendlyUrl("Index", "Users", new { pageNumber = 1 })
```

Handling inbound urls - configure the RedirectToSeoFriendlyUrlAttribute filter
```c#
GlobalFilters.Filters.Add(new RedirectToSeoFriendlyUrlAttribute())
```

Creating Seo Friendly Urls
```c#
@Url.UnpackSeo().ToSeoFriendlyUrl("http://WWW.google.com/")
or
var seoFriendlyUrl = new SeoFriendlyUrl("http://WWW.google.com/").Value.AbsoluteUri
```

### Using SeoPack - Html

Rendering a SEO compliant Title tag - checks length is 70 chars or less
```c#
@Html.UnpackSeo().Title("Welcome to the SeoPack Github page")
```

Rendering a SEO compliant Meta Description tag - checks length is 155 chars or less
```c#
@Html.UnpackSeo().MetaDescription("The SeoPack lib is packed with lots of SEO goodness")
```

Rendering a SEO compliant Anchor tag
```c#
@Html.UnpackSeo().Anchor(new Anchor(
                    href: "https://github.com/oopanuga/seo-pack",
                    text: "The SeoPack Github Page",
                    noFollow: true,
                    attributes: new {
                        target = "_blank",
                        @class = "seo-pack-github-anchor",
                        some_other_attr = "other-attr"
                        }))
```

And lots more....
