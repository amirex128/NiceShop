using NiceShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NiceShop.Domain.Enums;
using Newtonsoft.Json;

namespace NiceShop.Infrastructure.Data.Configurations;

public class ProvinceConfiguration : IEntityTypeConfiguration<Province>
{
    public void Configure(EntityTypeBuilder<Province> builder)
    {
        builder.HasKey(p => p.Id);
        builder.HasMany(p => p.Cities).WithOne(c => c.Province).HasForeignKey(c => c.ProvinceId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.Property(p => p.Status)
            .HasConversion(new EnumToStringConverter<StatusEnum>());
        string json =
            @"[{""id"":1,""name"":""آذربایجان شرقی"",""slug"":""آذربایجان-شرقی""},{""id"":2,""name"":""آذربایجان غربی"",""slug"":""آذربایجان-غربی""},{""id"":3,""name"":""اردبیل"",""slug"":""اردبیل""},{""id"":4,""name"":""اصفهان"",""slug"":""اصفهان""},{""id"":5,""name"":""البرز"",""slug"":""البرز""},{""id"":6,""name"":""ایلام"",""slug"":""ایلام""},{""id"":7,""name"":""بوشهر"",""slug"":""بوشهر""},{""id"":8,""name"":""تهران"",""slug"":""تهران""},{""id"":9,""name"":""چهارمحال و بختیاری"",""slug"":""چهارمحال-بختیاری""},{""id"":10,""name"":""خراسان جنوبی"",""slug"":""خراسان-جنوبی""},{""id"":11,""name"":""خراسان رضوی"",""slug"":""خراسان-رضوی""},{""id"":12,""name"":""خراسان شمالی"",""slug"":""خراسان-شمالی""},{""id"":13,""name"":""خوزستان"",""slug"":""خوزستان""},{""id"":14,""name"":""زنجان"",""slug"":""زنجان""},{""id"":15,""name"":""سمنان"",""slug"":""سمنان""},{""id"":16,""name"":""سیستان و بلوچستان"",""slug"":""سیستان-بلوچستان""},{""id"":17,""name"":""فارس"",""slug"":""فارس""},{""id"":18,""name"":""قزوین"",""slug"":""قزوین""},{""id"":19,""name"":""قم"",""slug"":""قم""},{""id"":20,""name"":""کردستان"",""slug"":""کردستان""},{""id"":21,""name"":""کرمان"",""slug"":""کرمان""},{""id"":22,""name"":""کرمانشاه"",""slug"":""کرمانشاه""},{""id"":23,""name"":""کهگیلویه و بویراحمد"",""slug"":""کهگیلویه-بویراحمد""},{""id"":24,""name"":""گلستان"",""slug"":""گلستان""},{""id"":25,""name"":""لرستان"",""slug"":""لرستان""},{""id"":26,""name"":""گیلان"",""slug"":""گیلان""},{""id"":27,""name"":""مازندران"",""slug"":""مازندران""},{""id"":28,""name"":""مرکزی"",""slug"":""مرکزی""},{""id"":29,""name"":""هرمزگان"",""slug"":""هرمزگان""},{""id"":30,""name"":""همدان"",""slug"":""همدان""},{""id"":31,""name"":""یزد"",""slug"":""یزد""}]";

        builder.HasData(JsonConvert.DeserializeObject<List<Province>>(json) ?? null!);
    }
}
