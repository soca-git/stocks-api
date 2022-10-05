using System.ComponentModel;

/// <summary>
/// A currency's ISO-4217 standard code
/// </summary>
public enum CurrencyCode
{
#pragma warning disable CS1591
    [Description("UAE Dirham")]
    AED,
	[Description("Afghani")]
    AFN,
	[Description("Lek")]
    ALL,
	[Description("Armenian Dram")]
    AMD,
	[Description("Netherlands Antillean Guilder")]
    ANG,
	[Description("Kwanza")]
    AOA,
	[Description("Argentine Peso")]
    ARS,
	[Description("Australian Dollar")]
    AUD,
	[Description("Aruban Florin")]
    AWG,
	[Description("Azerbaijanian Manat")]
    AZN,
	[Description("Convertible Mark")]
    BAM,
	[Description("Barbados Dollar")]
    BBD,
	[Description("Taka")]
    BDT,
	[Description("Bulgarian Lev")]
    BGN,
	[Description("Bahraini Dinar")]
    BHD,
	[Description("Burundi Franc")]
    BIF,
	[Description("Bermudian Dollar")]
    BMD,
	[Description("Brunei Dollar")]
    BND,
	[Description("Boliviano")]
    BOB,
	[Description("Mvdol")]
    BOV,
	[Description("Brazilian Real")]
    BRL,
	[Description("Bahamian Dollar")]
    BSD,
	[Description("Ngultrum")]
    BTN,
	[Description("Pula")]
    BWP,
	[Description("Belarussian Ruble")]
    BYN,
	[Description("Belize Dollar")]
    BZD,
	[Description("Canadian Dollar")]
    CAD,
	[Description("Congolese Franc")]
    CDF,
	[Description("WIR Euro")]
    CHE,
	[Description("Swiss Franc")]
    CHF,
	[Description("WIR Franc")]
    CHW,
	[Description("Unidad de Fomento")]
    CLF,
	[Description("Chilean Peso")]
    CLP,
	[Description("Yuan Renminbi")]
    CNY,
	[Description("Colombian Peso")]
    COP,
	[Description("Unidad de Valor Real")]
    COU,
	[Description("Costa Rican Colon")]
    CRC,
	[Description("Peso Convertible")]
    CUC,
	[Description("Cuban Peso")]
    CUP,
	[Description("Cabo Verde Escudo")]
    CVE,
	[Description("Czech Koruna")]
    CZK,
	[Description("Djibouti Franc")]
    DJF,
	[Description("Danish Krone")]
    DKK,
	[Description("Dominican Peso")]
    DOP,
	[Description("Algerian Dinar")]
    DZD,
	[Description("Egyptian Pound")]
    EGP,
	[Description("Nakfa")]
    ERN,
	[Description("Ethiopian Birr")]
    ETB,
	[Description("Euro")]
    EUR,
	[Description("Fiji Dollar")]
    FJD,
	[Description("Falkland Islands Pound")]
    FKP,
	[Description("Pound Sterling")]
    GBP,
	[Description("Lari")]
    GEL,
	[Description("Ghana Cedi")]
    GHS,
	[Description("Gibraltar Pound")]
    GIP,
	[Description("Dalasi")]
    GMD,
	[Description("Guinea Franc")]
    GNF,
	[Description("Quetzal")]
    GTQ,
	[Description("Guyana Dollar")]
    GYD,
	[Description("Hong Kong Dollar")]
    HKD,
	[Description("Lempira")]
    HNL,
	[Description("Kuna")]
    HRK,
	[Description("Gourde")]
    HTG,
	[Description("Forint")]
    HUF,
	[Description("Rupiah")]
    IDR,
	[Description("New Israeli Sheqel")]
    ILS,
	[Description("Indian Rupee")]
    INR,
	[Description("Iraqi Dinar")]
    IQD,
	[Description("Iranian Rial")]
    IRR,
	[Description("Iceland Krona")]
    ISK,
	[Description("Jamaican Dollar")]
    JMD,
	[Description("Jordanian Dinar")]
    JOD,
	[Description("Yen")]
    JPY,
	[Description("Kenyan Shilling")]
    KES,
	[Description("Som")]
    KGS,
	[Description("Riel")]
    KHR,
	[Description("Comoro Franc")]
    KMF,
	[Description("North Korean Won")]
    KPW,
	[Description("Won")]
    KRW,
	[Description("Kuwaiti Dinar")]
    KWD,
	[Description("Cayman Islands Dollar")]
    KYD,
	[Description("Tenge")]
    KZT,
	[Description("Kip")]
    LAK,
	[Description("Lebanese Pound")]
    LBP,
	[Description("Sri Lanka Rupee")]
    LKR,
	[Description("Liberian Dollar")]
    LRD,
	[Description("Loti")]
    LSL,
	[Description("Libyan Dinar")]
    LYD,
	[Description("Moroccan Dirham")]
    MAD,
	[Description("Moldovan Leu")]
    MDL,
	[Description("Malagasy Ariary")]
    MGA,
	[Description("Denar")]
    MKD,
	[Description("Kyat")]
    MMK,
	[Description("Tugrik")]
    MNT,
	[Description("Pataca")]
    MOP,
	[Description("Ouguiya")]
    MRU,
	[Description("Mauritius Rupee")]
    MUR,
	[Description("Rufiyaa")]
    MVR,
	[Description("Kwacha")]
    MWK,
	[Description("Mexican Peso")]
    MXN,
	[Description("Mexican Unidad de Inversion (UDI)")]
    MXV,
	[Description("Malaysian Ringgit")]
    MYR,
	[Description("Mozambique Metical")]
    MZN,
	[Description("Namibia Dollar")]
    NAD,
	[Description("Naira")]
    NGN,
	[Description("Cordoba Oro")]
    NIO,
	[Description("Norwegian Krone")]
    NOK,
	[Description("Nepalese Rupee")]
    NPR,
	[Description("New Zealand Dollar")]
    NZD,
	[Description("Rial Omani")]
    OMR,
	[Description("Balboa")]
    PAB,
	[Description("Nuevo Sol")]
    PEN,
	[Description("Kina")]
    PGK,
	[Description("Philippine Peso")]
    PHP,
	[Description("Pakistan Rupee")]
    PKR,
	[Description("Zloty")]
    PLN,
	[Description("Guarani")]
    PYG,
	[Description("Qatari Rial")]
    QAR,
	[Description("Romanian Leu")]
    RON,
	[Description("Serbian Dinar")]
    RSD,
	[Description("Russian Ruble")]
    RUB,
	[Description("Rwanda Franc")]
    RWF,
	[Description("Saudi Riyal")]
    SAR,
	[Description("Solomon Islands Dollar")]
    SBD,
	[Description("Seychelles Rupee")]
    SCR,
	[Description("Sudanese Pound")]
    SDG,
	[Description("Swedish Krona")]
    SEK,
	[Description("Singapore Dollar")]
    SGD,
	[Description("Saint Helena Pound")]
    SHP,
	[Description("Leone")]
    SLE,
	[Description("Somali Shilling")]
    SOS,
	[Description("Surinam Dollar")]
    SRD,
	[Description("South Sudanese Pound")]
    SSP,
	[Description("Dobra")]
    STN,
	[Description("El Salvador Colon")]
    SVC,
	[Description("Syrian Pound")]
    SYP,
	[Description("Lilangeni")]
    SZL,
	[Description("Baht")]
    THB,
	[Description("Somoni")]
    TJS,
	[Description("Turkmenistan New Manat")]
    TMT,
	[Description("Tunisian Dinar")]
    TND,
	[Description("Pa’anga")]
    TOP,
	[Description("Turkish Lira")]
    TRY,
	[Description("Trinidad and Tobago Dollar")]
    TTD,
	[Description("New Taiwan Dollar")]
    TWD,
	[Description("Tanzanian Shilling")]
    TZS,
	[Description("Hryvnia")]
    UAH,
	[Description("Uganda Shilling")]
    UGX,
	[Description("US Dollar")]
    USD,
	[Description("US Dollar (Next day)")]
    USN,
	[Description("Uruguay Peso en Unidades Indexadas (URUIURUI)")]
    UYI,
	[Description("Peso Uruguayo")]
    UYU,
	[Description("Uzbekistan Sum")]
    UZS,
	[Description("Bolivar")]
    VED,
	[Description("Bolivar")]
    VEF,
	[Description("Dong")]
    VND,
	[Description("Vatu")]
    VUV,
	[Description("Tala")]
    WST,
	[Description("CFA Franc BEAC")]
    XAF,
	[Description("East Caribbean Dollar")]
    XCD,
	[Description("SDR (Special Drawing Right)")]
    XDR,
	[Description("CFA Franc BCEAO")]
    XOF,
	[Description("CFP Franc")]
    XPF,
	[Description("Sucre")]
    XSU,
	[Description("ADB Unit of Account")]
    XUA,
	[Description("Yemeni Rial")]
    YER,
	[Description("Rand")]
    ZAR,
	[Description("Zambian Kwacha")]
    ZMW,
	[Description("Zimbabwe Dollar")]
    ZWL
}
