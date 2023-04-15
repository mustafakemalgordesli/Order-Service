using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common;

public static class Messages
{
    public static readonly string CarrierNotActive = "Kargo firması aktif değil";
    public static readonly string CarrierNotFound = "Kargo firması bulunamadı";
    public static readonly string CarrierNotValidate = "Kargo firma bilgileri eksik";
    public static readonly string CarrierNameNotEmpty = "Kargo ismi boş olamaz";
    public static readonly string CarrierAdded = "Kargo eklendi";
    public static readonly string CarrierUpdated = "Kargo bilgileri güncellendi";
    public static readonly string CarrierConfigurationNotFound = "Kargo firma konfigürasyonu bulunamadı";
    public static readonly string CarrierConfigurationDeleted = "Kargo firma konfigürasyonu silindi";
    public static readonly string CarrierDeleted = "Kargo firması silindi";
    public static readonly string SuitableCarrierNotFound = "Sipariş için uygun kargo firması bulunamadı";
    public static readonly string OrderNotFound = "Sipariş bulunamadı";
    public static readonly string OrderDeleted = "Sipariş silindi";
}
