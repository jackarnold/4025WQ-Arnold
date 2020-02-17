using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using SQLite;



namespace Mine.Models
{
    /// <summary>
    /// Item for the Game
    /// </summary>
    public class ItemModel : BaseModel
    {

        [Ignore]
        public List<History> AuditHistory { get; set; } = new List<History>();

        // Holds the AuditHistory Json
        public string AuditHistoryString { get; set; } = string.Empty;
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
    public class History
    {
        // Change DateTime
        public DateTime ChangeDateTime { get; set; } = DateTime.Now;

        // Comments about the Change
        public string Note { get; set; } = "Note";

        // The Latest Record
        public string ChangedLatest { get; set; } = string.Empty;

        // The Previous Record
        public string ChangedPrevious { get; set; } = string.Empty;

        // The Size of the change between Latest - Prevous
        public int ChangeSize { get; set; } = 0;
    }
}
