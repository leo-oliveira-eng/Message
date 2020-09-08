# Message ![.NET Core](https://github.com/leo-oliveira-eng/Message/workflows/.NET%20Core/badge.svg) [![License](https://img.shields.io/badge/license-MIT-blue.svg)](LICENSE.md)

This package encapsulates responses between methods preventing traffic from null objects in an application. 

## Installation

Message.Response.Maybe is available on [NuGet](https://www.nuget.org/packages/Message.Response.Maybe/).  You can find the raw NuGet file [here](https://www.nuget.org/api/v2/package/Message.Response.Maybe/1.0.0-preview-2) or install it by the commands below depending on your platform:

 - Package Manager
```
pm> Install-Package Message.Response.Maybe -Version 1.0.0-preview-2
```

 - via the .NET Core CLI:
```
> dotnet add package Message.Response.Maybe --version 1.0.0-preview-2
```

 - PackageReference
```
<PackageReference Include="Message.Response.Maybe" Version="1.0.0-preview-2" />
```

 - PaketCLI
```
> paket add Message.Response.Maybe --version 1.0.0-preview-2
```


## Setup

There is no need to configure dependency injection. Just install it in the project you want to use.


## How to Use

### Maybe

When using a method that has the possibility of returning a null, the envelopment with Maybe indicates that the return must be verified, preventing the application from break down due to the absence of the object value.

```csharp
public class RepositoryAsync<Entity> : SpecificMethods<Entity>, IRepositoryAsync<Entity>
{
   ...

   public async Task<Maybe<Entity>> FindAsync(int id)
     => await DbSet.FirstOrDefaultAsync(entity => entity.Id.Equals(id));
     
   ...
}

     
```

The developer can act as follows when receiving the response:

```csharp

  ...

    var entity = await EntityRepository.FindAsync(entityId);

    if (!house.HasValue)
        return response.WithBusinessError("Not found");

  ...

```

### Response e Message

The response is not only intended to encapsulate the objects exchanged between the application's methods, but it also encapsulates information about the status of this response, error messages and can also indicate which was the property where the problem happened.

```csharp

...

public static Response<Entity> Create(string name, string document)
{
     var response = Response<Entity>.Create();

     if (string.IsNullOrEmpty(name))
            response.WithBusinessError(nameof(name), $"{nameof(name)} is invalid");

     if (string.IsNullOrEmpty(document))
            response.WithBusinessError(nameof(role), $"{nameof(document)} is invalid");

     if (response.HasError)
         return response;

     return response.SetValue(new Entity(name, document));
}

...

```

## License [![FOSSA Status](https://app.fossa.com/api/projects/git%2Bgithub.com%2Fleo-oliveira-eng%2FMessage.svg?type=shield)](https://app.fossa.com/projects/git%2Bgithub.com%2Fleo-oliveira-eng%2FMessage?ref=badge_shield)
The project is under [MIT License](LICENSE.md), so it grants you permission to use, copy, and modify a piece of this software free of charge, as is, without restriction or warranty.
[![FOSSA Status](https://app.fossa.com/api/projects/git%2Bgithub.com%2Fleo-oliveira-eng%2FMessage.svg?type=large)](https://app.fossa.com/projects/git%2Bgithub.com%2Fleo-oliveira-eng%2FMessage?ref=badge_large)
