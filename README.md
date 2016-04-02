# SeoPack

A library packed with lots of SEO goodness for ASP.Net MVC projects. Get access to a bunch of Html Seo Helper methods for rendering SEO compliant Html tags including Open Graph tags. Please see "Planned features" below for other SEO features to come.

The Html SEO Helper methods are extension methods of the ASP.Net MVC HtmlHelper class. These helper methods render SEO compliant html tags according to the recommendations defined in the [MOZ SEO Cheat Sheet](https://d2eeipcrcdle6.cloudfront.net/seo-cheat-sheet.pdf) for Web developers.

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
2. Robots.txt
3. Sitemap.xml
4. Rich Snippets and Structured Data
5. Script Tag management
6. etc.

### Examples

Rendering a SEO compliant Title tag - checks length is 70 chars or less
```c#
@Html.UnpackSeo().Title(new Title("Welcome to the SeoPack Github page"))
```

Rendering a SEO compliant Meta Description tag - checks length is 155 chars or less
```c#
@Html.UnpackSeo().MetaDescription("The SeoPack lib is packed with lots of SEO goodness"))
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

### Installing SeoPack [nuget](https://www.nuget.org/packages/SeoPack/)
```
PM> Install-Package SeoPack
```
