# SeoPack

A library packed with lots of SEO goodness for ASP.Net MVC projects. Get access to a bunch of SEO Helper methods for rendering SEO compliant Html tags and for generating Canonical Urls based on a set of predefined url policies. Please see "Planned features" below for other SEO features to come.

The Html SEO Helper methods are extension methods of the ASP.Net MVC HtmlHelper class. These render SEO compliant html tags according to the recommendations defined in the [MOZ SEO Cheat Sheet](https://d2eeipcrcdle6.cloudfront.net/seo-cheat-sheet.pdf) for Web developers.

The Url SEO Helper methods are extension methods of the ASP.Net MVC UrlHelper class. These generate outbound Route and Action Canonical Urls based on a predefined set of url policies. Url policies are also applied to inbound urls via the UrlPolicyCheckAttribute filter. So you end up with a consistent set of url policies that apply to both inbound and outbound urls. The concept of url policies was inspired by an awesome library called [Canonicalize](https://github.com/schourode/canonicalize).

At the heart of creating Canonical Urls is the CanonicalUrl class. The class runs a url through the url policies and ensures that the resultant url is one that conforms to these url policies.

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

### Url features
1. Configure Url Policies for inbound and outbound urls
2. Generate canonical route and action urls
3. Do 301 redirects to canonical version of requested url if not in line with url policies
4. Convert urls to canonical version

### Planned features
1. Robots.txt
2. Sitemap.xml

### Installing SeoPack - [nuget](https://www.nuget.org/packages/SeoPack/)
```
PM> Install-Package SeoPack
```

### Using SeoPack - Urls

Configuring Url Policies - this is best done on application startup
```c#
UrlPolicyConfiguration.Configure().LowercasePolicy().WwwPolicy().NoTrailingSlashPolicy()
```

Outbound urls - Creating Canonical outbound urls. SeoPack Url helpers return absolute urls by default. However there is an overload that can be used to specify that relative urls should be returned.
```c#
@Url.SpRouteUrl("Users", new { pageNumber = 1 })
@Url.SpActionUrl("Index", "Users", new { pageNumber = 1 })
```

Inbound urls - Use the UrlPolicyCheckAttribute filter to permanently (301) redirect a url to its Canonical version in the event that it doesn't conform to the set of predefined url policies. The Canonical version conforms to these policies.
```c#
GlobalFilters.Filters.Add(new UrlPolicyCheckAttribute())
```

Convert a url to a Canonical one
```c#
@Url.SpToCanonicalUrl("http://WWW.google.com/")
//OR
var canonicalUrl = new CanonicalUrl("http://WWW.google.com/").Value.AbsoluteUri
```

The AppendTrailingSlash and LowercaseUrls options introduced in .NET 4.5 apply only to outbound urls. As a result devs have had to opt for other options to handle inbound urls e.g. url rewriting. So you end up with url policies/rules defined in multiple places and maintenance could be daunting. SeoPack enables you to use the same set of predefined url policies for both inbound and outbound urls. 

SeoPack also provides you with more options for url policies and the ability to create custom ones. AppendTrailingSlash and LowercaseUrls options seem to be the only options provided by the .Net framework.

### Using SeoPack - Html

Rendering a SEO compliant Title tag - checks length is 70 chars or less
```c#
@Html.SpTitle("Welcome to the SeoPack Github page")
```

Rendering a SEO compliant Meta Description tag - checks length is 155 chars or less
```c#
@Html.SpMetaDescription("The SeoPack lib is packed with lots of SEO goodness")
```

Rendering a SEO compliant Anchor tag
```c#
@Html.SpAnchor(new Anchor(
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


### License

SeoPack is released under the MIT license.
