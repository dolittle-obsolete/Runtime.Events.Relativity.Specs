# Dolittle.Runtime.Events.Relativity.Specs

This is a set of acceptance tests that should be implemented for an IGeodesics implementation.

This is not a .csproj.  Instead it should be included in the implementation as a submodule.

```

git submodule add https://github.com/dolittle/Runtime.Events.Store.Relativity.git Specifications/Relativity/Specs

```

and then added as a Compile directive.

So, for example, the Submodule could be in Specifications/Specs and the following added to the
implementation .csproj file:

```
  <ItemGroup>
    <Compile Include="./Specs/**/*.cs" Exclude="./Specs/obj/**/*.cs;./Specs/bin/**/*.cs"/>
  </ItemGroup>

```

The implementation should implement the IProvideGeodesics interface which has a single Build() method
that returns the implementation of IGeodesics that you wish to test.

```
using Dolittle.Runtime.Events.Relativity.Specs;

namespace Dolittle.Runtime.Events.Relativity.Specs
{
    public class SUTProvider : IProvideGeodesics
    {
        public IEventStore Build() => new Relativity.Geodesics();
    }
}

```
