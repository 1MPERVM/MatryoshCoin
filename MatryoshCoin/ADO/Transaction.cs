//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MatryoshCoin.ADO
{
    using System;
    using System.Collections.Generic;
    
    public partial class Transaction
    {
        public int TransactionID { get; set; }
        public int SenderID { get; set; }
        public int RecipientID { get; set; }
        public string QR_code { get; set; }
    
        public virtual User User { get; set; }
        public virtual User User1 { get; set; }
    }
}