namespace Dolittle.Runtime.Events.Relativity.Specs.when_setting_the_offset_for_a_geodesic_connection
{
    using System;
    using Dolittle.Runtime.Events.Processing;
    using Dolittle.Runtime.Events.Store;
    using Machine.Specifications;

    [Subject(typeof(IGeodesics), nameof(IGeodesics.SetOffset))]
    public class and_it_is_a_new_processor : given.a_geodesics
    {
        static IGeodesics geodesics;
        static ulong last_processed;
        static EventHorizonKey event_horizon;
        
        Establish context = () => 
        {
            last_processed = 100;
            event_horizon = get_event_horizon_key();
            geodesics = get_geodesics();
        };

        Because of = () => geodesics.SetOffset(event_horizon,last_processed);

        It should_set_the_last_processed_version_for_the_processor = () => geodesics.GetOffset(event_horizon).ShouldEqual(last_processed);
    }

    [Subject(typeof(IGeodesics), nameof(IGeodesics.SetOffset))]
    public class and_has_a_previous_offset : given.a_geodesics
    {
        static IGeodesics geodesics;
        static ulong current_version;
        static ulong last_processed;
        static EventHorizonKey event_horizon;
        
        Establish context = () => 
        {
            current_version = 99;
            last_processed = 100;
            event_horizon = get_event_horizon_key();
            geodesics = get_geodesics();
            geodesics.SetOffset(event_horizon,current_version);
        };

        Because of = () => geodesics.SetOffset(event_horizon,last_processed);

        It should_update_the_last_processed_version_for_the_processor = () => geodesics.GetOffset(event_horizon).ShouldEqual(last_processed);
    }

    [Subject(typeof(IGeodesics), nameof(IGeodesics.SetOffset))]
    public class to_an_earlier_version : given.a_geodesics
    {
        static IGeodesics geodesics;
        static ulong current_version;
        static ulong last_processed;
        static EventHorizonKey event_horizon;
        
        Establish context = () => 
        {
            current_version = 101;
            last_processed = 100;
            event_horizon = get_event_horizon_key();
            geodesics = get_geodesics();
            geodesics.SetOffset(event_horizon,current_version);
        };

        Because of = () => geodesics.SetOffset(event_horizon,last_processed);

        It should_update_the_last_processed_version_for_the_processor_to_the_earlier_version = () => geodesics.GetOffset(event_horizon).ShouldEqual(last_processed);
    }
}