namespace Mido.PlatformService.Dtos
{
    // Data Transfer Object - abstarct representation of the internal Platform model class - to be read by a consumer
    // We decouple internal model from the external interface so we can modify the internal model without modifying the external interface.
    public class PlatformReadDto 
    {
        // For now we expose all properties when data is read but we have the ability to hide or modify the exposed data
        // without affecting the internal model
         public int Id { get; set; }
         public string Name { get; set; } = default!;
         public string Publisher { get; set; } = default!; 
        public string Cost { get; set; } = default!;
    }

}