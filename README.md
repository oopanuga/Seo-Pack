# SeoPack

A library packed with lots of SEO goodness for ASP.Net MVC projects. Get access to a bunch of Html Seo Helpers for rendering SEO compliant Html tags including Open Graph tags. Please see "Planned features" below for other SEO features to come.

The Html Seo Helpers are an extension of the standard MVC Html Helpers. These helpers were built according to the recommendations defined in the [MOZ SEO Cheat Sheet](https://d2eeipcrcdle6.cloudfront.net/seo-cheat-sheet.pdf) for Web developers.

## Supported Tags
1. Title
2. Meta Description
3. Anchor
4. Image
5. ImageLink
6. Canonical Links
7. Pagination Links (rel=prev, rel=next pagination attributes)
8. HrefLang Links
9. Open Graph 

## Planned features
1. Friendly urls
2. Robots.txt
3. Sitemap.xml
4. Rich Snippets and Structured Data
5. Script Tag management
6. etc.

## Examples

Rendering a SEO compliant Title tag - Ensures the title doesn't exceed the recommended length of 70
```c#
@Html.UnpackSeo().Title(new Title("This is the official SeoPack website"))
```

Rendering a SEO compliant Meta Description tag - Ensures the Meta Description doesn't exceed the recommended length of 155
```c#
@Html.UnpackSeo().Title(new MetaDescription("This is the official SeoPack website"))
```

Rendering a SEO compliant Anchor tag
```c#
@Html.UnpackSeo().Anchor(new Anchor(
                    href: anchorUrl,
                    text: anchorText,
                    nofollow: true,
                    attributes: new {
                        target = "_blank",
                        @class = "coupon-code-link",
                        data_aff_url = offerUrl
                        }))
```


```
PM> Install-Package SeoPack
```
