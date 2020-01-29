namespace Mine.Models
{
    /// <summary>
    /// Item for the Game
    /// </summary>
    public class ItemModel : BaseModel
    {
        // Add Unique attributes for Item
        public int Value { get; set; } = 0;

        public bool Update(ItemModel data)
        {
            //DO NOT UPDATE THE ID, otherwise the record will be orphaned
            //Id = data.id //leave commented out

            //update the base
            Name = data.Name;
            Description = data.Description;
            //update the extended
            Value = data.Value;
            return true;
        }


    }
}
