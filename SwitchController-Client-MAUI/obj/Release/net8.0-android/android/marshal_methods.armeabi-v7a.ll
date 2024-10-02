; ModuleID = 'marshal_methods.armeabi-v7a.ll'
source_filename = "marshal_methods.armeabi-v7a.ll"
target datalayout = "e-m:e-p:32:32-Fi8-i64:64-v128:64:128-a:0:32-n32-S64"
target triple = "armv7-unknown-linux-android21"

%struct.MarshalMethodName = type {
	i64, ; uint64_t id
	ptr ; char* name
}

%struct.MarshalMethodsManagedClass = type {
	i32, ; uint32_t token
	ptr ; MonoClass klass
}

@assembly_image_cache = dso_local local_unnamed_addr global [140 x ptr] zeroinitializer, align 4

; Each entry maps hash of an assembly name to an index into the `assembly_image_cache` array
@assembly_image_cache_hashes = dso_local local_unnamed_addr constant [280 x i32] [
	i32 2616222, ; 0: System.Net.NetworkInformation.dll => 0x27eb9e => 108
	i32 10166715, ; 1: System.Net.NameResolution.dll => 0x9b21bb => 107
	i32 34839235, ; 2: System.IO.FileSystem.DriveInfo => 0x2139ac3 => 99
	i32 38948123, ; 3: ar\Microsoft.Maui.Controls.resources.dll => 0x2524d1b => 0
	i32 42244203, ; 4: he\Microsoft.Maui.Controls.resources.dll => 0x284986b => 9
	i32 42639949, ; 5: System.Threading.Thread => 0x28aa24d => 130
	i32 67008169, ; 6: zh-Hant\Microsoft.Maui.Controls.resources => 0x3fe76a9 => 33
	i32 72070932, ; 7: Microsoft.Maui.Graphics.dll => 0x44bb714 => 50
	i32 83839681, ; 8: ms\Microsoft.Maui.Controls.resources.dll => 0x4ff4ac1 => 17
	i32 117431740, ; 9: System.Runtime.InteropServices => 0x6ffddbc => 121
	i32 122350210, ; 10: System.Threading.Channels.dll => 0x74aea82 => 129
	i32 136584136, ; 11: zh-Hans\Microsoft.Maui.Controls.resources.dll => 0x8241bc8 => 32
	i32 140062828, ; 12: sk\Microsoft.Maui.Controls.resources.dll => 0x859306c => 25
	i32 142721839, ; 13: System.Net.WebHeaderCollection => 0x881c32f => 114
	i32 165246403, ; 14: Xamarin.AndroidX.Collection.dll => 0x9d975c3 => 56
	i32 182336117, ; 15: Xamarin.AndroidX.SwipeRefreshLayout.dll => 0xade3a75 => 74
	i32 205061960, ; 16: System.ComponentModel => 0xc38ff48 => 90
	i32 317674968, ; 17: vi\Microsoft.Maui.Controls.resources => 0x12ef55d8 => 30
	i32 318968648, ; 18: Xamarin.AndroidX.Activity.dll => 0x13031348 => 52
	i32 321963286, ; 19: fr\Microsoft.Maui.Controls.resources.dll => 0x1330c516 => 8
	i32 342366114, ; 20: Xamarin.AndroidX.Lifecycle.Common => 0x146817a2 => 63
	i32 375677976, ; 21: System.Net.ServicePoint.dll => 0x16646418 => 112
	i32 379916513, ; 22: System.Threading.Thread.dll => 0x16a510e1 => 130
	i32 385762202, ; 23: System.Memory.dll => 0x16fe439a => 104
	i32 395744057, ; 24: _Microsoft.Android.Resource.Designer => 0x17969339 => 34
	i32 409257351, ; 25: tr\Microsoft.Maui.Controls.resources.dll => 0x1864c587 => 28
	i32 442565967, ; 26: System.Collections => 0x1a61054f => 86
	i32 450948140, ; 27: Xamarin.AndroidX.Fragment.dll => 0x1ae0ec2c => 62
	i32 456227837, ; 28: System.Web.HttpUtility.dll => 0x1b317bfd => 132
	i32 469710990, ; 29: System.dll => 0x1bff388e => 134
	i32 489220957, ; 30: es\Microsoft.Maui.Controls.resources.dll => 0x1d28eb5d => 6
	i32 498788369, ; 31: System.ObjectModel => 0x1dbae811 => 117
	i32 513247710, ; 32: Microsoft.Extensions.Primitives.dll => 0x1e9789de => 44
	i32 538707440, ; 33: th\Microsoft.Maui.Controls.resources.dll => 0x201c05f0 => 27
	i32 539058512, ; 34: Microsoft.Extensions.Logging => 0x20216150 => 41
	i32 597488923, ; 35: CommunityToolkit.Maui => 0x239cf51b => 35
	i32 627609679, ; 36: Xamarin.AndroidX.CustomView => 0x2568904f => 60
	i32 627931235, ; 37: nl\Microsoft.Maui.Controls.resources => 0x256d7863 => 19
	i32 660647836, ; 38: SwitchController-Client-MAUI.dll => 0x2760af9c => 81
	i32 672442732, ; 39: System.Collections.Concurrent => 0x2814a96c => 82
	i32 681425351, ; 40: SysBot.Base.dll => 0x289db9c7 => 80
	i32 683518922, ; 41: System.Net.Security => 0x28bdabca => 111
	i32 722857257, ; 42: System.Runtime.Loader.dll => 0x2b15ed29 => 122
	i32 759454413, ; 43: System.Net.Requests => 0x2d445acd => 110
	i32 775507847, ; 44: System.IO.Compression => 0x2e394f87 => 98
	i32 777317022, ; 45: sk\Microsoft.Maui.Controls.resources => 0x2e54ea9e => 25
	i32 789151979, ; 46: Microsoft.Extensions.Options => 0x2f0980eb => 43
	i32 823281589, ; 47: System.Private.Uri.dll => 0x311247b5 => 118
	i32 830298997, ; 48: System.IO.Compression.Brotli => 0x317d5b75 => 97
	i32 869139383, ; 49: hi\Microsoft.Maui.Controls.resources.dll => 0x33ce03b7 => 10
	i32 880668424, ; 50: ru\Microsoft.Maui.Controls.resources.dll => 0x347def08 => 24
	i32 904024072, ; 51: System.ComponentModel.Primitives.dll => 0x35e25008 => 88
	i32 911108515, ; 52: System.IO.MemoryMappedFiles.dll => 0x364e69a3 => 101
	i32 918734561, ; 53: pt-BR\Microsoft.Maui.Controls.resources.dll => 0x36c2c6e1 => 21
	i32 961460050, ; 54: it\Microsoft.Maui.Controls.resources.dll => 0x394eb752 => 14
	i32 967690846, ; 55: Xamarin.AndroidX.Lifecycle.Common.dll => 0x39adca5e => 63
	i32 990727110, ; 56: ro\Microsoft.Maui.Controls.resources.dll => 0x3b0d4bc6 => 23
	i32 992768348, ; 57: System.Collections.dll => 0x3b2c715c => 86
	i32 1012816738, ; 58: Xamarin.AndroidX.SavedState.dll => 0x3c5e5b62 => 73
	i32 1028951442, ; 59: Microsoft.Extensions.DependencyInjection.Abstractions => 0x3d548d92 => 40
	i32 1035644815, ; 60: Xamarin.AndroidX.AppCompat => 0x3dbaaf8f => 53
	i32 1043950537, ; 61: de\Microsoft.Maui.Controls.resources.dll => 0x3e396bc9 => 4
	i32 1044663988, ; 62: System.Linq.Expressions.dll => 0x3e444eb4 => 102
	i32 1052210849, ; 63: Xamarin.AndroidX.Lifecycle.ViewModel.dll => 0x3eb776a1 => 65
	i32 1082857460, ; 64: System.ComponentModel.TypeConverter => 0x408b17f4 => 89
	i32 1084122840, ; 65: Xamarin.Kotlin.StdLib => 0x409e66d8 => 78
	i32 1098259244, ; 66: System => 0x41761b2c => 134
	i32 1108272742, ; 67: sv\Microsoft.Maui.Controls.resources.dll => 0x420ee666 => 26
	i32 1117529484, ; 68: pl\Microsoft.Maui.Controls.resources.dll => 0x429c258c => 20
	i32 1118262833, ; 69: ko\Microsoft.Maui.Controls.resources => 0x42a75631 => 16
	i32 1168523401, ; 70: pt\Microsoft.Maui.Controls.resources => 0x45a64089 => 22
	i32 1178241025, ; 71: Xamarin.AndroidX.Navigation.Runtime.dll => 0x463a8801 => 70
	i32 1208641965, ; 72: System.Diagnostics.Process => 0x480a69ad => 94
	i32 1260983243, ; 73: cs\Microsoft.Maui.Controls.resources => 0x4b2913cb => 2
	i32 1293217323, ; 74: Xamarin.AndroidX.DrawerLayout.dll => 0x4d14ee2b => 61
	i32 1308624726, ; 75: hr\Microsoft.Maui.Controls.resources.dll => 0x4e000756 => 11
	i32 1324164729, ; 76: System.Linq => 0x4eed2679 => 103
	i32 1336711579, ; 77: zh-HK\Microsoft.Maui.Controls.resources.dll => 0x4fac999b => 31
	i32 1373134921, ; 78: zh-Hans\Microsoft.Maui.Controls.resources => 0x51d86049 => 32
	i32 1376866003, ; 79: Xamarin.AndroidX.SavedState => 0x52114ed3 => 73
	i32 1406073936, ; 80: Xamarin.AndroidX.CoordinatorLayout => 0x53cefc50 => 57
	i32 1430672901, ; 81: ar\Microsoft.Maui.Controls.resources => 0x55465605 => 0
	i32 1452070440, ; 82: System.Formats.Asn1.dll => 0x568cd628 => 96
	i32 1458022317, ; 83: System.Net.Security.dll => 0x56e7a7ad => 111
	i32 1461004990, ; 84: es\Microsoft.Maui.Controls.resources => 0x57152abe => 6
	i32 1461234159, ; 85: System.Collections.Immutable.dll => 0x5718a9ef => 83
	i32 1462112819, ; 86: System.IO.Compression.dll => 0x57261233 => 98
	i32 1469204771, ; 87: Xamarin.AndroidX.AppCompat.AppCompatResources => 0x57924923 => 54
	i32 1470490898, ; 88: Microsoft.Extensions.Primitives => 0x57a5e912 => 44
	i32 1479771757, ; 89: System.Collections.Immutable => 0x5833866d => 83
	i32 1480492111, ; 90: System.IO.Compression.Brotli.dll => 0x583e844f => 97
	i32 1526286932, ; 91: vi\Microsoft.Maui.Controls.resources.dll => 0x5af94a54 => 30
	i32 1543031311, ; 92: System.Text.RegularExpressions.dll => 0x5bf8ca0f => 128
	i32 1622152042, ; 93: Xamarin.AndroidX.Loader.dll => 0x60b0136a => 67
	i32 1624863272, ; 94: Xamarin.AndroidX.ViewPager2 => 0x60d97228 => 76
	i32 1634654947, ; 95: CommunityToolkit.Maui.Core.dll => 0x616edae3 => 36
	i32 1636350590, ; 96: Xamarin.AndroidX.CursorAdapter => 0x6188ba7e => 59
	i32 1639515021, ; 97: System.Net.Http.dll => 0x61b9038d => 105
	i32 1639986890, ; 98: System.Text.RegularExpressions => 0x61c036ca => 128
	i32 1641389582, ; 99: System.ComponentModel.EventBasedAsync.dll => 0x61d59e0e => 87
	i32 1657153582, ; 100: System.Runtime => 0x62c6282e => 124
	i32 1658251792, ; 101: Xamarin.Google.Android.Material.dll => 0x62d6ea10 => 77
	i32 1675553242, ; 102: System.IO.FileSystem.DriveInfo.dll => 0x63dee9da => 99
	i32 1677501392, ; 103: System.Net.Primitives.dll => 0x63fca3d0 => 109
	i32 1679769178, ; 104: System.Security.Cryptography => 0x641f3e5a => 126
	i32 1691477237, ; 105: System.Reflection.Metadata => 0x64d1e4f5 => 120
	i32 1728033016, ; 106: System.Diagnostics.FileVersionInfo.dll => 0x66ffb0f8 => 93
	i32 1729485958, ; 107: Xamarin.AndroidX.CardView.dll => 0x6715dc86 => 55
	i32 1743415430, ; 108: ca\Microsoft.Maui.Controls.resources => 0x67ea6886 => 1
	i32 1763938596, ; 109: System.Diagnostics.TraceSource.dll => 0x69239124 => 95
	i32 1766324549, ; 110: Xamarin.AndroidX.SwipeRefreshLayout => 0x6947f945 => 74
	i32 1770582343, ; 111: Microsoft.Extensions.Logging.dll => 0x6988f147 => 41
	i32 1780572499, ; 112: Mono.Android.Runtime.dll => 0x6a216153 => 138
	i32 1782862114, ; 113: ms\Microsoft.Maui.Controls.resources => 0x6a445122 => 17
	i32 1788241197, ; 114: Xamarin.AndroidX.Fragment => 0x6a96652d => 62
	i32 1793755602, ; 115: he\Microsoft.Maui.Controls.resources => 0x6aea89d2 => 9
	i32 1808609942, ; 116: Xamarin.AndroidX.Loader => 0x6bcd3296 => 67
	i32 1813058853, ; 117: Xamarin.Kotlin.StdLib.dll => 0x6c111525 => 78
	i32 1813201214, ; 118: Xamarin.Google.Android.Material => 0x6c13413e => 77
	i32 1818569960, ; 119: Xamarin.AndroidX.Navigation.UI.dll => 0x6c652ce8 => 71
	i32 1828688058, ; 120: Microsoft.Extensions.Logging.Abstractions.dll => 0x6cff90ba => 42
	i32 1853025655, ; 121: sv\Microsoft.Maui.Controls.resources => 0x6e72ed77 => 26
	i32 1858542181, ; 122: System.Linq.Expressions => 0x6ec71a65 => 102
	i32 1875935024, ; 123: fr\Microsoft.Maui.Controls.resources => 0x6fd07f30 => 8
	i32 1889954781, ; 124: System.Reflection.Metadata.dll => 0x70a66bdd => 120
	i32 1893218855, ; 125: cs\Microsoft.Maui.Controls.resources.dll => 0x70d83a27 => 2
	i32 1906231652, ; 126: NLog.dll => 0x719ec964 => 51
	i32 1910275211, ; 127: System.Collections.NonGeneric.dll => 0x71dc7c8b => 84
	i32 1953182387, ; 128: id\Microsoft.Maui.Controls.resources.dll => 0x746b32b3 => 13
	i32 1968388702, ; 129: Microsoft.Extensions.Configuration.dll => 0x75533a5e => 37
	i32 1968956012, ; 130: SwitchController-Client-MAUI => 0x755be26c => 81
	i32 2003115576, ; 131: el\Microsoft.Maui.Controls.resources => 0x77651e38 => 5
	i32 2019465201, ; 132: Xamarin.AndroidX.Lifecycle.ViewModel => 0x785e97f1 => 65
	i32 2045470958, ; 133: System.Private.Xml => 0x79eb68ee => 119
	i32 2055257422, ; 134: Xamarin.AndroidX.Lifecycle.LiveData.Core.dll => 0x7a80bd4e => 64
	i32 2066184531, ; 135: de\Microsoft.Maui.Controls.resources => 0x7b277953 => 4
	i32 2070888862, ; 136: System.Diagnostics.TraceSource => 0x7b6f419e => 95
	i32 2079903147, ; 137: System.Runtime.dll => 0x7bf8cdab => 124
	i32 2090596640, ; 138: System.Numerics.Vectors => 0x7c9bf920 => 116
	i32 2127167465, ; 139: System.Console => 0x7ec9ffe9 => 91
	i32 2142473426, ; 140: System.Collections.Specialized => 0x7fb38cd2 => 85
	i32 2159891885, ; 141: Microsoft.Maui => 0x80bd55ad => 48
	i32 2169148018, ; 142: hu\Microsoft.Maui.Controls.resources => 0x814a9272 => 12
	i32 2181898931, ; 143: Microsoft.Extensions.Options.dll => 0x820d22b3 => 43
	i32 2192057212, ; 144: Microsoft.Extensions.Logging.Abstractions => 0x82a8237c => 42
	i32 2193016926, ; 145: System.ObjectModel.dll => 0x82b6c85e => 117
	i32 2201107256, ; 146: Xamarin.KotlinX.Coroutines.Core.Jvm.dll => 0x83323b38 => 79
	i32 2201231467, ; 147: System.Net.Http => 0x8334206b => 105
	i32 2207618523, ; 148: it\Microsoft.Maui.Controls.resources => 0x839595db => 14
	i32 2266799131, ; 149: Microsoft.Extensions.Configuration.Abstractions => 0x871c9c1b => 38
	i32 2279755925, ; 150: Xamarin.AndroidX.RecyclerView.dll => 0x87e25095 => 72
	i32 2295906218, ; 151: System.Net.Sockets => 0x88d8bfaa => 113
	i32 2298471582, ; 152: System.Net.Mail => 0x88ffe49e => 106
	i32 2303942373, ; 153: nb\Microsoft.Maui.Controls.resources => 0x89535ee5 => 18
	i32 2305521784, ; 154: System.Private.CoreLib.dll => 0x896b7878 => 136
	i32 2353062107, ; 155: System.Net.Primitives => 0x8c40e0db => 109
	i32 2366048013, ; 156: hu\Microsoft.Maui.Controls.resources.dll => 0x8d07070d => 12
	i32 2368005991, ; 157: System.Xml.ReaderWriter.dll => 0x8d24e767 => 133
	i32 2371007202, ; 158: Microsoft.Extensions.Configuration => 0x8d52b2e2 => 37
	i32 2383496789, ; 159: System.Security.Principal.Windows.dll => 0x8e114655 => 127
	i32 2395872292, ; 160: id\Microsoft.Maui.Controls.resources => 0x8ece1c24 => 13
	i32 2401565422, ; 161: System.Web.HttpUtility => 0x8f24faee => 132
	i32 2427813419, ; 162: hi\Microsoft.Maui.Controls.resources => 0x90b57e2b => 10
	i32 2435356389, ; 163: System.Console.dll => 0x912896e5 => 91
	i32 2458678730, ; 164: System.Net.Sockets.dll => 0x928c75ca => 113
	i32 2471841756, ; 165: netstandard.dll => 0x93554fdc => 135
	i32 2475788418, ; 166: Java.Interop.dll => 0x93918882 => 137
	i32 2480646305, ; 167: Microsoft.Maui.Controls => 0x93dba8a1 => 46
	i32 2483903535, ; 168: System.ComponentModel.EventBasedAsync => 0x940d5c2f => 87
	i32 2484371297, ; 169: System.Net.ServicePoint => 0x94147f61 => 112
	i32 2503351294, ; 170: ko\Microsoft.Maui.Controls.resources.dll => 0x95361bfe => 16
	i32 2520912855, ; 171: SysBot.Base => 0x964213d7 => 80
	i32 2550873716, ; 172: hr\Microsoft.Maui.Controls.resources => 0x980b3e74 => 11
	i32 2576534780, ; 173: ja\Microsoft.Maui.Controls.resources.dll => 0x9992ccfc => 15
	i32 2593496499, ; 174: pl\Microsoft.Maui.Controls.resources => 0x9a959db3 => 20
	i32 2605712449, ; 175: Xamarin.KotlinX.Coroutines.Core.Jvm => 0x9b500441 => 79
	i32 2617129537, ; 176: System.Private.Xml.dll => 0x9bfe3a41 => 119
	i32 2620871830, ; 177: Xamarin.AndroidX.CursorAdapter.dll => 0x9c375496 => 59
	i32 2626831493, ; 178: ja\Microsoft.Maui.Controls.resources => 0x9c924485 => 15
	i32 2663698177, ; 179: System.Runtime.Loader => 0x9ec4cf01 => 122
	i32 2717744543, ; 180: System.Security.Claims => 0xa1fd7d9f => 125
	i32 2724373263, ; 181: System.Runtime.Numerics.dll => 0xa262a30f => 123
	i32 2732626843, ; 182: Xamarin.AndroidX.Activity => 0xa2e0939b => 52
	i32 2735172069, ; 183: System.Threading.Channels => 0xa30769e5 => 129
	i32 2737747696, ; 184: Xamarin.AndroidX.AppCompat.AppCompatResources.dll => 0xa32eb6f0 => 54
	i32 2740698338, ; 185: ca\Microsoft.Maui.Controls.resources.dll => 0xa35bbce2 => 1
	i32 2752995522, ; 186: pt-BR\Microsoft.Maui.Controls.resources => 0xa41760c2 => 21
	i32 2758225723, ; 187: Microsoft.Maui.Controls.Xaml => 0xa4672f3b => 47
	i32 2764765095, ; 188: Microsoft.Maui.dll => 0xa4caf7a7 => 48
	i32 2778768386, ; 189: Xamarin.AndroidX.ViewPager.dll => 0xa5a0a402 => 75
	i32 2785988530, ; 190: th\Microsoft.Maui.Controls.resources => 0xa60ecfb2 => 27
	i32 2801831435, ; 191: Microsoft.Maui.Graphics => 0xa7008e0b => 50
	i32 2810250172, ; 192: Xamarin.AndroidX.CoordinatorLayout.dll => 0xa78103bc => 57
	i32 2853208004, ; 193: Xamarin.AndroidX.ViewPager => 0xaa107fc4 => 75
	i32 2861189240, ; 194: Microsoft.Maui.Essentials => 0xaa8a4878 => 49
	i32 2868488919, ; 195: CommunityToolkit.Maui.Core => 0xaaf9aad7 => 36
	i32 2909740682, ; 196: System.Private.CoreLib => 0xad6f1e8a => 136
	i32 2916838712, ; 197: Xamarin.AndroidX.ViewPager2.dll => 0xaddb6d38 => 76
	i32 2919462931, ; 198: System.Numerics.Vectors.dll => 0xae037813 => 116
	i32 2959614098, ; 199: System.ComponentModel.dll => 0xb0682092 => 90
	i32 2968338931, ; 200: System.Security.Principal.Windows => 0xb0ed41f3 => 127
	i32 2978675010, ; 201: Xamarin.AndroidX.DrawerLayout => 0xb18af942 => 61
	i32 3038032645, ; 202: _Microsoft.Android.Resource.Designer.dll => 0xb514b305 => 34
	i32 3053864966, ; 203: fi\Microsoft.Maui.Controls.resources.dll => 0xb6064806 => 7
	i32 3057625584, ; 204: Xamarin.AndroidX.Navigation.Common => 0xb63fa9f0 => 68
	i32 3059408633, ; 205: Mono.Android.Runtime => 0xb65adef9 => 138
	i32 3059793426, ; 206: System.ComponentModel.Primitives => 0xb660be12 => 88
	i32 3099732863, ; 207: System.Security.Claims.dll => 0xb8c22b7f => 125
	i32 3103600923, ; 208: System.Formats.Asn1 => 0xb8fd311b => 96
	i32 3160747431, ; 209: System.IO.MemoryMappedFiles => 0xbc652da7 => 101
	i32 3178803400, ; 210: Xamarin.AndroidX.Navigation.Fragment.dll => 0xbd78b0c8 => 69
	i32 3220365878, ; 211: System.Threading => 0xbff2e236 => 131
	i32 3258312781, ; 212: Xamarin.AndroidX.CardView => 0xc235e84d => 55
	i32 3303498502, ; 213: System.Diagnostics.FileVersionInfo => 0xc4e76306 => 93
	i32 3305363605, ; 214: fi\Microsoft.Maui.Controls.resources => 0xc503d895 => 7
	i32 3316684772, ; 215: System.Net.Requests.dll => 0xc5b097e4 => 110
	i32 3317135071, ; 216: Xamarin.AndroidX.CustomView.dll => 0xc5b776df => 60
	i32 3346324047, ; 217: Xamarin.AndroidX.Navigation.Runtime => 0xc774da4f => 70
	i32 3357674450, ; 218: ru\Microsoft.Maui.Controls.resources => 0xc8220bd2 => 24
	i32 3362522851, ; 219: Xamarin.AndroidX.Core => 0xc86c06e3 => 58
	i32 3366347497, ; 220: Java.Interop => 0xc8a662e9 => 137
	i32 3374999561, ; 221: Xamarin.AndroidX.RecyclerView => 0xc92a6809 => 72
	i32 3381016424, ; 222: da\Microsoft.Maui.Controls.resources => 0xc9863768 => 3
	i32 3428513518, ; 223: Microsoft.Extensions.DependencyInjection.dll => 0xcc5af6ee => 39
	i32 3430777524, ; 224: netstandard => 0xcc7d82b4 => 135
	i32 3452344032, ; 225: Microsoft.Maui.Controls.Compatibility.dll => 0xcdc696e0 => 45
	i32 3458724246, ; 226: pt\Microsoft.Maui.Controls.resources.dll => 0xce27f196 => 22
	i32 3471940407, ; 227: System.ComponentModel.TypeConverter.dll => 0xcef19b37 => 89
	i32 3476120550, ; 228: Mono.Android => 0xcf3163e6 => 139
	i32 3484440000, ; 229: ro\Microsoft.Maui.Controls.resources => 0xcfb055c0 => 23
	i32 3580758918, ; 230: zh-HK\Microsoft.Maui.Controls.resources => 0xd56e0b86 => 31
	i32 3592228221, ; 231: zh-Hant\Microsoft.Maui.Controls.resources.dll => 0xd61d0d7d => 33
	i32 3608519521, ; 232: System.Linq.dll => 0xd715a361 => 103
	i32 3641597786, ; 233: Xamarin.AndroidX.Lifecycle.LiveData.Core => 0xd90e5f5a => 64
	i32 3643446276, ; 234: tr\Microsoft.Maui.Controls.resources => 0xd92a9404 => 28
	i32 3643854240, ; 235: Xamarin.AndroidX.Navigation.Fragment => 0xd930cda0 => 69
	i32 3657292374, ; 236: Microsoft.Extensions.Configuration.Abstractions.dll => 0xd9fdda56 => 38
	i32 3660523487, ; 237: System.Net.NetworkInformation => 0xda2f27df => 108
	i32 3672681054, ; 238: Mono.Android.dll => 0xdae8aa5e => 139
	i32 3700866549, ; 239: System.Net.WebProxy.dll => 0xdc96bdf5 => 115
	i32 3724971120, ; 240: Xamarin.AndroidX.Navigation.Common.dll => 0xde068c70 => 68
	i32 3732100267, ; 241: System.Net.NameResolution => 0xde7354ab => 107
	i32 3748608112, ; 242: System.Diagnostics.DiagnosticSource => 0xdf6f3870 => 92
	i32 3751619990, ; 243: da\Microsoft.Maui.Controls.resources.dll => 0xdf9d2d96 => 3
	i32 3786282454, ; 244: Xamarin.AndroidX.Collection => 0xe1ae15d6 => 56
	i32 3792276235, ; 245: System.Collections.NonGeneric => 0xe2098b0b => 84
	i32 3800979733, ; 246: Microsoft.Maui.Controls.Compatibility => 0xe28e5915 => 45
	i32 3802395368, ; 247: System.Collections.Specialized.dll => 0xe2a3f2e8 => 85
	i32 3817368567, ; 248: CommunityToolkit.Maui.dll => 0xe3886bf7 => 35
	i32 3819260425, ; 249: System.Net.WebProxy => 0xe3a54a09 => 115
	i32 3823082795, ; 250: System.Security.Cryptography.dll => 0xe3df9d2b => 126
	i32 3841636137, ; 251: Microsoft.Extensions.DependencyInjection.Abstractions.dll => 0xe4fab729 => 40
	i32 3844307129, ; 252: System.Net.Mail.dll => 0xe52378b9 => 106
	i32 3849253459, ; 253: System.Runtime.InteropServices.dll => 0xe56ef253 => 121
	i32 3885497537, ; 254: System.Net.WebHeaderCollection.dll => 0xe797fcc1 => 114
	i32 3896106733, ; 255: System.Collections.Concurrent.dll => 0xe839deed => 82
	i32 3896760992, ; 256: Xamarin.AndroidX.Core.dll => 0xe843daa0 => 58
	i32 3920221145, ; 257: nl\Microsoft.Maui.Controls.resources.dll => 0xe9a9d3d9 => 19
	i32 3928044579, ; 258: System.Xml.ReaderWriter => 0xea213423 => 133
	i32 3931092270, ; 259: Xamarin.AndroidX.Navigation.UI => 0xea4fb52e => 71
	i32 3955647286, ; 260: Xamarin.AndroidX.AppCompat.dll => 0xebc66336 => 53
	i32 4003436829, ; 261: System.Diagnostics.Process.dll => 0xee9f991d => 94
	i32 4025784931, ; 262: System.Memory => 0xeff49a63 => 104
	i32 4046471985, ; 263: Microsoft.Maui.Controls.Xaml.dll => 0xf1304331 => 47
	i32 4073602200, ; 264: System.Threading.dll => 0xf2ce3c98 => 131
	i32 4091086043, ; 265: el\Microsoft.Maui.Controls.resources.dll => 0xf3d904db => 5
	i32 4094352644, ; 266: Microsoft.Maui.Essentials.dll => 0xf40add04 => 49
	i32 4100113165, ; 267: System.Private.Uri => 0xf462c30d => 118
	i32 4103439459, ; 268: uk\Microsoft.Maui.Controls.resources.dll => 0xf4958463 => 29
	i32 4126470640, ; 269: Microsoft.Extensions.DependencyInjection => 0xf5f4f1f0 => 39
	i32 4127667938, ; 270: System.IO.FileSystem.Watcher => 0xf60736e2 => 100
	i32 4150914736, ; 271: uk\Microsoft.Maui.Controls.resources => 0xf769eeb0 => 29
	i32 4164802419, ; 272: System.IO.FileSystem.Watcher.dll => 0xf83dd773 => 100
	i32 4182413190, ; 273: Xamarin.AndroidX.Lifecycle.ViewModelSavedState.dll => 0xf94a8f86 => 66
	i32 4211164729, ; 274: NLog => 0xfb014639 => 51
	i32 4213026141, ; 275: System.Diagnostics.DiagnosticSource.dll => 0xfb1dad5d => 92
	i32 4249188766, ; 276: nb\Microsoft.Maui.Controls.resources.dll => 0xfd45799e => 18
	i32 4271975918, ; 277: Microsoft.Maui.Controls.dll => 0xfea12dee => 46
	i32 4274976490, ; 278: System.Runtime.Numerics => 0xfecef6ea => 123
	i32 4292120959 ; 279: Xamarin.AndroidX.Lifecycle.ViewModelSavedState => 0xffd4917f => 66
], align 4

@assembly_image_cache_indices = dso_local local_unnamed_addr constant [280 x i32] [
	i32 108, ; 0
	i32 107, ; 1
	i32 99, ; 2
	i32 0, ; 3
	i32 9, ; 4
	i32 130, ; 5
	i32 33, ; 6
	i32 50, ; 7
	i32 17, ; 8
	i32 121, ; 9
	i32 129, ; 10
	i32 32, ; 11
	i32 25, ; 12
	i32 114, ; 13
	i32 56, ; 14
	i32 74, ; 15
	i32 90, ; 16
	i32 30, ; 17
	i32 52, ; 18
	i32 8, ; 19
	i32 63, ; 20
	i32 112, ; 21
	i32 130, ; 22
	i32 104, ; 23
	i32 34, ; 24
	i32 28, ; 25
	i32 86, ; 26
	i32 62, ; 27
	i32 132, ; 28
	i32 134, ; 29
	i32 6, ; 30
	i32 117, ; 31
	i32 44, ; 32
	i32 27, ; 33
	i32 41, ; 34
	i32 35, ; 35
	i32 60, ; 36
	i32 19, ; 37
	i32 81, ; 38
	i32 82, ; 39
	i32 80, ; 40
	i32 111, ; 41
	i32 122, ; 42
	i32 110, ; 43
	i32 98, ; 44
	i32 25, ; 45
	i32 43, ; 46
	i32 118, ; 47
	i32 97, ; 48
	i32 10, ; 49
	i32 24, ; 50
	i32 88, ; 51
	i32 101, ; 52
	i32 21, ; 53
	i32 14, ; 54
	i32 63, ; 55
	i32 23, ; 56
	i32 86, ; 57
	i32 73, ; 58
	i32 40, ; 59
	i32 53, ; 60
	i32 4, ; 61
	i32 102, ; 62
	i32 65, ; 63
	i32 89, ; 64
	i32 78, ; 65
	i32 134, ; 66
	i32 26, ; 67
	i32 20, ; 68
	i32 16, ; 69
	i32 22, ; 70
	i32 70, ; 71
	i32 94, ; 72
	i32 2, ; 73
	i32 61, ; 74
	i32 11, ; 75
	i32 103, ; 76
	i32 31, ; 77
	i32 32, ; 78
	i32 73, ; 79
	i32 57, ; 80
	i32 0, ; 81
	i32 96, ; 82
	i32 111, ; 83
	i32 6, ; 84
	i32 83, ; 85
	i32 98, ; 86
	i32 54, ; 87
	i32 44, ; 88
	i32 83, ; 89
	i32 97, ; 90
	i32 30, ; 91
	i32 128, ; 92
	i32 67, ; 93
	i32 76, ; 94
	i32 36, ; 95
	i32 59, ; 96
	i32 105, ; 97
	i32 128, ; 98
	i32 87, ; 99
	i32 124, ; 100
	i32 77, ; 101
	i32 99, ; 102
	i32 109, ; 103
	i32 126, ; 104
	i32 120, ; 105
	i32 93, ; 106
	i32 55, ; 107
	i32 1, ; 108
	i32 95, ; 109
	i32 74, ; 110
	i32 41, ; 111
	i32 138, ; 112
	i32 17, ; 113
	i32 62, ; 114
	i32 9, ; 115
	i32 67, ; 116
	i32 78, ; 117
	i32 77, ; 118
	i32 71, ; 119
	i32 42, ; 120
	i32 26, ; 121
	i32 102, ; 122
	i32 8, ; 123
	i32 120, ; 124
	i32 2, ; 125
	i32 51, ; 126
	i32 84, ; 127
	i32 13, ; 128
	i32 37, ; 129
	i32 81, ; 130
	i32 5, ; 131
	i32 65, ; 132
	i32 119, ; 133
	i32 64, ; 134
	i32 4, ; 135
	i32 95, ; 136
	i32 124, ; 137
	i32 116, ; 138
	i32 91, ; 139
	i32 85, ; 140
	i32 48, ; 141
	i32 12, ; 142
	i32 43, ; 143
	i32 42, ; 144
	i32 117, ; 145
	i32 79, ; 146
	i32 105, ; 147
	i32 14, ; 148
	i32 38, ; 149
	i32 72, ; 150
	i32 113, ; 151
	i32 106, ; 152
	i32 18, ; 153
	i32 136, ; 154
	i32 109, ; 155
	i32 12, ; 156
	i32 133, ; 157
	i32 37, ; 158
	i32 127, ; 159
	i32 13, ; 160
	i32 132, ; 161
	i32 10, ; 162
	i32 91, ; 163
	i32 113, ; 164
	i32 135, ; 165
	i32 137, ; 166
	i32 46, ; 167
	i32 87, ; 168
	i32 112, ; 169
	i32 16, ; 170
	i32 80, ; 171
	i32 11, ; 172
	i32 15, ; 173
	i32 20, ; 174
	i32 79, ; 175
	i32 119, ; 176
	i32 59, ; 177
	i32 15, ; 178
	i32 122, ; 179
	i32 125, ; 180
	i32 123, ; 181
	i32 52, ; 182
	i32 129, ; 183
	i32 54, ; 184
	i32 1, ; 185
	i32 21, ; 186
	i32 47, ; 187
	i32 48, ; 188
	i32 75, ; 189
	i32 27, ; 190
	i32 50, ; 191
	i32 57, ; 192
	i32 75, ; 193
	i32 49, ; 194
	i32 36, ; 195
	i32 136, ; 196
	i32 76, ; 197
	i32 116, ; 198
	i32 90, ; 199
	i32 127, ; 200
	i32 61, ; 201
	i32 34, ; 202
	i32 7, ; 203
	i32 68, ; 204
	i32 138, ; 205
	i32 88, ; 206
	i32 125, ; 207
	i32 96, ; 208
	i32 101, ; 209
	i32 69, ; 210
	i32 131, ; 211
	i32 55, ; 212
	i32 93, ; 213
	i32 7, ; 214
	i32 110, ; 215
	i32 60, ; 216
	i32 70, ; 217
	i32 24, ; 218
	i32 58, ; 219
	i32 137, ; 220
	i32 72, ; 221
	i32 3, ; 222
	i32 39, ; 223
	i32 135, ; 224
	i32 45, ; 225
	i32 22, ; 226
	i32 89, ; 227
	i32 139, ; 228
	i32 23, ; 229
	i32 31, ; 230
	i32 33, ; 231
	i32 103, ; 232
	i32 64, ; 233
	i32 28, ; 234
	i32 69, ; 235
	i32 38, ; 236
	i32 108, ; 237
	i32 139, ; 238
	i32 115, ; 239
	i32 68, ; 240
	i32 107, ; 241
	i32 92, ; 242
	i32 3, ; 243
	i32 56, ; 244
	i32 84, ; 245
	i32 45, ; 246
	i32 85, ; 247
	i32 35, ; 248
	i32 115, ; 249
	i32 126, ; 250
	i32 40, ; 251
	i32 106, ; 252
	i32 121, ; 253
	i32 114, ; 254
	i32 82, ; 255
	i32 58, ; 256
	i32 19, ; 257
	i32 133, ; 258
	i32 71, ; 259
	i32 53, ; 260
	i32 94, ; 261
	i32 104, ; 262
	i32 47, ; 263
	i32 131, ; 264
	i32 5, ; 265
	i32 49, ; 266
	i32 118, ; 267
	i32 29, ; 268
	i32 39, ; 269
	i32 100, ; 270
	i32 29, ; 271
	i32 100, ; 272
	i32 66, ; 273
	i32 51, ; 274
	i32 92, ; 275
	i32 18, ; 276
	i32 46, ; 277
	i32 123, ; 278
	i32 66 ; 279
], align 4

@marshal_methods_number_of_classes = dso_local local_unnamed_addr constant i32 0, align 4

@marshal_methods_class_cache = dso_local local_unnamed_addr global [0 x %struct.MarshalMethodsManagedClass] zeroinitializer, align 4

; Names of classes in which marshal methods reside
@mm_class_names = dso_local local_unnamed_addr constant [0 x ptr] zeroinitializer, align 4

@mm_method_names = dso_local local_unnamed_addr constant [1 x %struct.MarshalMethodName] [
	%struct.MarshalMethodName {
		i64 0, ; id 0x0; name: 
		ptr @.MarshalMethodName.0_name; char* name
	} ; 0
], align 8

; get_function_pointer (uint32_t mono_image_index, uint32_t class_index, uint32_t method_token, void*& target_ptr)
@get_function_pointer = internal dso_local unnamed_addr global ptr null, align 4

; Functions

; Function attributes: "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind "stack-protector-buffer-size"="8" uwtable willreturn
define void @xamarin_app_init(ptr nocapture noundef readnone %env, ptr noundef %fn) local_unnamed_addr #0
{
	%fnIsNull = icmp eq ptr %fn, null
	br i1 %fnIsNull, label %1, label %2

1: ; preds = %0
	%putsResult = call noundef i32 @puts(ptr @.str.0)
	call void @abort()
	unreachable 

2: ; preds = %1, %0
	store ptr %fn, ptr @get_function_pointer, align 4, !tbaa !3
	ret void
}

; Strings
@.str.0 = private unnamed_addr constant [40 x i8] c"get_function_pointer MUST be specified\0A\00", align 1

;MarshalMethodName
@.MarshalMethodName.0_name = private unnamed_addr constant [1 x i8] c"\00", align 1

; External functions

; Function attributes: noreturn "no-trapping-math"="true" nounwind "stack-protector-buffer-size"="8"
declare void @abort() local_unnamed_addr #2

; Function attributes: nofree nounwind
declare noundef i32 @puts(ptr noundef) local_unnamed_addr #1
attributes #0 = { "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind "stack-protector-buffer-size"="8" "target-cpu"="generic" "target-features"="+armv7-a,+d32,+dsp,+fp64,+neon,+vfp2,+vfp2sp,+vfp3,+vfp3d16,+vfp3d16sp,+vfp3sp,-aes,-fp-armv8,-fp-armv8d16,-fp-armv8d16sp,-fp-armv8sp,-fp16,-fp16fml,-fullfp16,-sha2,-thumb-mode,-vfp4,-vfp4d16,-vfp4d16sp,-vfp4sp" uwtable willreturn }
attributes #1 = { nofree nounwind }
attributes #2 = { noreturn "no-trapping-math"="true" nounwind "stack-protector-buffer-size"="8" "target-cpu"="generic" "target-features"="+armv7-a,+d32,+dsp,+fp64,+neon,+vfp2,+vfp2sp,+vfp3,+vfp3d16,+vfp3d16sp,+vfp3sp,-aes,-fp-armv8,-fp-armv8d16,-fp-armv8d16sp,-fp-armv8sp,-fp16,-fp16fml,-fullfp16,-sha2,-thumb-mode,-vfp4,-vfp4d16,-vfp4d16sp,-vfp4sp" }

; Metadata
!llvm.module.flags = !{!0, !1, !7}
!0 = !{i32 1, !"wchar_size", i32 4}
!1 = !{i32 7, !"PIC Level", i32 2}
!llvm.ident = !{!2}
!2 = !{!"Xamarin.Android remotes/origin/release/8.0.1xx @ f1b7113872c8db3dfee70d11925e81bb752dc8d0"}
!3 = !{!4, !4, i64 0}
!4 = !{!"any pointer", !5, i64 0}
!5 = !{!"omnipotent char", !6, i64 0}
!6 = !{!"Simple C++ TBAA"}
!7 = !{i32 1, !"min_enum_size", i32 4}
