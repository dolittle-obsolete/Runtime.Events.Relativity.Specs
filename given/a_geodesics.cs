// Copyright (c) Dolittle. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Linq;
using System.Reflection;

namespace Dolittle.Runtime.Events.Relativity.Specs.given
{
    public class a_geodesics
    {
        protected static Func<IGeodesics> get_geodesics = () =>
        {
            if (_sut_provider_type == null)
            {
                var asm = Assembly.GetExecutingAssembly();
                _sut_provider_type = asm.GetExportedTypes().Where(t => t.IsClass && typeof(IProvideGeodesics).IsAssignableFrom(t)).Single();
            }

            var factory = Activator.CreateInstance(_sut_provider_type) as IProvideGeodesics;
            return factory.Build();
        };

        static Type _sut_provider_type;

        protected static EventHorizonKey get_event_horizon_key() => new EventHorizonKey(Guid.NewGuid(), Guid.NewGuid());
    }
}