namespace Dolittle.Runtime.Events.Relativity.Specs.when_fetching_the_offset_for_a_geodesic_connection
{
    using System;
    using Dolittle.Runtime.Events.Store;
    using Machine.Specifications;

    [Subject(typeof(IGeodesics), nameof(IGeodesics.GetOffset))]
    public class for_a_geodesic_connection_with_an_offset : given.a_geodesics
    {
        static IGeodesics geodesics;
        static ulong result;
        static EventHorizonKey key;
        static ulong last_version;
        Establish context = () => 
        {
            key = new EventHorizonKey(Guid.NewGuid(), Guid.NewGuid());
            last_version = 100;
            geodesics = get_geodesics();
            geodesics.SetOffset(key,last_version);
        };

        Because of = () => result = geodesics.GetOffset(key);

        It should_return_the_offset = () => result.ShouldEqual(last_version);
    }
}