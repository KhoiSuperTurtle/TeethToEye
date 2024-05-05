using System;
using System.Collections.Generic;

namespace TeethToEyeAPI.Models;

public partial class SaveRecord
{
    public int IdSaveRecord { get; set; }

    public string Uid { get; set; } = null!;

    public byte[] BinData { get; set; } = null!;

    public string SaveRecordDataType { get; set; } = null!;

    public int Slotfile { get; set; }

  
}
