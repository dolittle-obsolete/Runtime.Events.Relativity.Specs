namespace Dolittle.Runtime.Events.Relativity.Specs.given
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Dolittle.Runtime.Events.Relativity;
    public class a_geodesics
    {
        static Type _sut_provider_type;
        protected static Func<IGeodesics> get_geodesics = () => {
            if(_sut_provider_type == null){
                var asm = Assembly.GetExecutingAssembly();      
                _sut_provider_type = asm.GetExportedTypes().Where(t => t.IsClass && typeof(IProvideGeodesics).IsAssignableFrom(t)).Single();
            }
            var factory = Activator.CreateInstance(_sut_provider_type) as IProvideGeodesics;
            return factory.Build();
        };

        protected static EventHorizonKey get_event_horizon_key() => new EventHorizonKey(Guid.NewGuid(),Guid.NewGuid());
    }
} 