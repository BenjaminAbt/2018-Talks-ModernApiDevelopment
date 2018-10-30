## Modern API Development

This sample code is used for my talk about the evolution and modern APIs of Json and ASP.NET Core.
Additional there is a sample about GraphQL.

## Projects 

### Common

This library contains demo resources: Authors and Books
Also there is an "engine" based in MediatR to show how to decouple Queries and Commands in modern architectures.
This project is used in every sample as hard reference.

### Simple Json

Show how to deliver Json.
In this case business models are returned like some Microsoft samples and the documentation shows.
The problem: if you return business models you expose maybe too much and you lose flexibility.

### Json SDK

The SDK shows how deliver isolated API models like you work in WPF with ViewModels.
It's a way to decouple business models from API models to gain flexibility.

### Swagger

Compared to SOAP or OData Json by default delivers no schema about your API, your calls and contents.
Swagger is an official way to describe your API.

The project contains both "big" packages for ASP.NET Core: NSwag and Swashbuckle.

### OData

Shows the latest implementation of OData for ASP.NET Core.

### GraphQL

Show as sample of GraphQL engine with ASP.NET Core
Sample queries:

```
## Books

{
  books{
    name,
    price
  }
}

## Authors

{
  author(id: "##guid of user##"){
    id,
    firstName,
    lastName
  }
}
```

## Hints

Obviously there is a bug in the ASP.NET Core Modelbinder
See: https://github.com/aspnet/Mvc/issues/8636

## License

```
Copyright (c) 2018

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
```

## Links

| Name | Link |
|-|-|
| ASP.NET Core ModelBinder | https://docs.microsoft.com/en-us/aspnet/core/mvc/advanced/custom-model-binding?view=aspnetcore-2.1#custom-model-binder-sample |
| MediatR | https://github.com/jbogard/MediatR |
| GraphQL Learn | https://graphql.org/learn/ |
| REST APIs | https://restfulapi.net/ |
| REST PUT vs POST | https://restfulapi.net/rest-put-vs-post/ |
| REST HATEOAS | https://restfulapi.net/hateoas/ |
| Glory REST (Richardson Maturity Model) | https://martinfowler.com/articles/richardsonMaturityModel.html |
| Traefik | https://traefik.io/ |
| Azure API Management | https://azure.microsoft.com/en-us/services/api-management/ |
| AWS API Gateway | https://aws.amazon.com/de/api-gateway/ |
| Token-based Auth Sample | https://github.com/BenjaminAbt/Samples.AspNetCore-IdentityServer4 |
| IdentityServer Community Samples | http://docs.identityserver.io/en/release/quickstarts/community.html |
| Refit automatic REST | https://github.com/reactiveui/refit |

## Extensions and Tools I recommend to use

- [FiraCode](https://github.com/tonsky/FiraCode)
- [viasfora](https://viasfora.com/)
- [OzCode](https://www.oz-code.com/)