//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace mingrisoft_3_
{
    using System;
    using System.Collections.Generic;
    
    public partial class ZYF_JG_YFKC
    {
        public string YFKCID { get; set; }
        public string YFID { get; set; }
        public string YPID { get; set; }
        public Nullable<int> YFKCResidueNum { get; set; }
        public Nullable<decimal> YFKCPrice { get; set; }
        public Nullable<System.DateTime> YFKCBuildTime { get; set; }
        public Nullable<int> YFKCQualityGuauaPeriod { get; set; }
        public Nullable<System.DateTime> YFKCInsideTimeUp { get; set; }
        public Nullable<System.DateTime> YFKCOutsideTimeUp { get; set; }
        public Nullable<int> YFKCExceedQGP { get; set; }
        public Nullable<int> YFKCShare { get; set; }
    
        public virtual ZYF_JG_YF ZYF_JG_YF { get; set; }
        public virtual ZYF_JG_YP ZYF_JG_YP { get; set; }
    }
}