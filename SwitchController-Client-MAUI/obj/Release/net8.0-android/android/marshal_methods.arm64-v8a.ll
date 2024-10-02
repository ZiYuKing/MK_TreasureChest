; ModuleID = 'marshal_methods.arm64-v8a.ll'
source_filename = "marshal_methods.arm64-v8a.ll"
target datalayout = "e-m:e-i8:8:32-i16:16:32-i64:64-i128:128-n32:64-S128"
target triple = "aarch64-unknown-linux-android21"

%struct.MarshalMethodName = type {
	i64, ; uint64_t id
	ptr ; char* name
}

%struct.MarshalMethodsManagedClass = type {
	i32, ; uint32_t token
	ptr ; MonoClass klass
}

@assembly_image_cache = dso_local local_unnamed_addr global [140 x ptr] zeroinitializer, align 8

; Each entry maps hash of an assembly name to an index into the `assembly_image_cache` array
@assembly_image_cache_hashes = dso_local local_unnamed_addr constant [280 x i64] [
	i64 98382396393917666, ; 0: Microsoft.Extensions.Primitives.dll => 0x15d8644ad360ce2 => 44
	i64 120698629574877762, ; 1: Mono.Android => 0x1accec39cafe242 => 139
	i64 131669012237370309, ; 2: Microsoft.Maui.Essentials.dll => 0x1d3c844de55c3c5 => 49
	i64 196720943101637631, ; 3: System.Linq.Expressions.dll => 0x2bae4a7cd73f3ff => 102
	i64 210515253464952879, ; 4: Xamarin.AndroidX.Collection.dll => 0x2ebe681f694702f => 56
	i64 232391251801502327, ; 5: Xamarin.AndroidX.SavedState.dll => 0x3399e9cbc897277 => 73
	i64 750875890346172408, ; 6: System.Threading.Thread => 0xa6ba5a4da7d1ff8 => 130
	i64 799765834175365804, ; 7: System.ComponentModel.dll => 0xb1956c9f18442ac => 90
	i64 805302231655005164, ; 8: hu\Microsoft.Maui.Controls.resources.dll => 0xb2d021ceea03bec => 12
	i64 872800313462103108, ; 9: Xamarin.AndroidX.DrawerLayout => 0xc1ccf42c3c21c44 => 61
	i64 1120440138749646132, ; 10: Xamarin.Google.Android.Material.dll => 0xf8c9a5eae431534 => 77
	i64 1301626418029409250, ; 11: System.Diagnostics.FileVersionInfo => 0x12104e54b4e833e2 => 93
	i64 1369545283391376210, ; 12: Xamarin.AndroidX.Navigation.Fragment.dll => 0x13019a2dd85acb52 => 69
	i64 1404195534211153682, ; 13: System.IO.FileSystem.Watcher.dll => 0x137cb4660bd87f12 => 100
	i64 1476839205573959279, ; 14: System.Net.Primitives.dll => 0x147ec96ece9b1e6f => 109
	i64 1486715745332614827, ; 15: Microsoft.Maui.Controls.dll => 0x14a1e017ea87d6ab => 46
	i64 1513467482682125403, ; 16: Mono.Android.Runtime => 0x1500eaa8245f6c5b => 138
	i64 1537168428375924959, ; 17: System.Threading.Thread.dll => 0x15551e8a954ae0df => 130
	i64 1624659445732251991, ; 18: Xamarin.AndroidX.AppCompat.AppCompatResources.dll => 0x168bf32877da9957 => 54
	i64 1628611045998245443, ; 19: Xamarin.AndroidX.Lifecycle.ViewModelSavedState.dll => 0x1699fd1e1a00b643 => 66
	i64 1735388228521408345, ; 20: System.Net.Mail.dll => 0x181556663c69b759 => 106
	i64 1743969030606105336, ; 21: System.Memory.dll => 0x1833d297e88f2af8 => 104
	i64 1767386781656293639, ; 22: System.Private.Uri.dll => 0x188704e9f5582107 => 118
	i64 1795316252682057001, ; 23: Xamarin.AndroidX.AppCompat.dll => 0x18ea3e9eac997529 => 53
	i64 1835311033149317475, ; 24: es\Microsoft.Maui.Controls.resources => 0x197855a927386163 => 6
	i64 1836611346387731153, ; 25: Xamarin.AndroidX.SavedState => 0x197cf449ebe482d1 => 73
	i64 1881198190668717030, ; 26: tr\Microsoft.Maui.Controls.resources => 0x1a1b5bc992ea9be6 => 28
	i64 1920760634179481754, ; 27: Microsoft.Maui.Controls.Xaml => 0x1aa7e99ec2d2709a => 47
	i64 1981742497975770890, ; 28: Xamarin.AndroidX.Lifecycle.ViewModel.dll => 0x1b80904d5c241f0a => 65
	i64 2080945842184875448, ; 29: System.IO.MemoryMappedFiles => 0x1ce10137d8416db8 => 101
	i64 2262844636196693701, ; 30: Xamarin.AndroidX.DrawerLayout.dll => 0x1f673d352266e6c5 => 61
	i64 2287834202362508563, ; 31: System.Collections.Concurrent => 0x1fc00515e8ce7513 => 82
	i64 2329709569556905518, ; 32: Xamarin.AndroidX.Lifecycle.LiveData.Core.dll => 0x2054ca829b447e2e => 64
	i64 2470498323731680442, ; 33: Xamarin.AndroidX.CoordinatorLayout => 0x2248f922dc398cba => 57
	i64 2497223385847772520, ; 34: System.Runtime => 0x22a7eb7046413568 => 124
	i64 2547086958574651984, ; 35: Xamarin.AndroidX.Activity.dll => 0x2359121801df4a50 => 52
	i64 2602673633151553063, ; 36: th\Microsoft.Maui.Controls.resources => 0x241e8de13a460e27 => 27
	i64 2632269733008246987, ; 37: System.Net.NameResolution => 0x2487b36034f808cb => 107
	i64 2656907746661064104, ; 38: Microsoft.Extensions.DependencyInjection => 0x24df3b84c8b75da8 => 39
	i64 2662981627730767622, ; 39: cs\Microsoft.Maui.Controls.resources => 0x24f4cfae6c48af06 => 2
	i64 2895129759130297543, ; 40: fi\Microsoft.Maui.Controls.resources => 0x282d912d479fa4c7 => 7
	i64 3017136373564924869, ; 41: System.Net.WebProxy => 0x29df058bd93f63c5 => 115
	i64 3017704767998173186, ; 42: Xamarin.Google.Android.Material => 0x29e10a7f7d88a002 => 77
	i64 3135773902340015556, ; 43: System.IO.FileSystem.DriveInfo.dll => 0x2b8481c008eac5c4 => 99
	i64 3289520064315143713, ; 44: Xamarin.AndroidX.Lifecycle.Common => 0x2da6b911e3063621 => 63
	i64 3311221304742556517, ; 45: System.Numerics.Vectors.dll => 0x2df3d23ba9e2b365 => 116
	i64 3325875462027654285, ; 46: System.Runtime.Numerics => 0x2e27e21c8958b48d => 123
	i64 3328853167529574890, ; 47: System.Net.Sockets.dll => 0x2e327651a008c1ea => 113
	i64 3344514922410554693, ; 48: Xamarin.KotlinX.Coroutines.Core.Jvm => 0x2e6a1a9a18463545 => 79
	i64 3425002567197763177, ; 49: NLog.dll => 0x2f880db03c9fa669 => 51
	i64 3429672777697402584, ; 50: Microsoft.Maui.Essentials => 0x2f98a5385a7b1ed8 => 49
	i64 3437845325506641314, ; 51: System.IO.MemoryMappedFiles.dll => 0x2fb5ae1beb8f7da2 => 101
	i64 3494946837667399002, ; 52: Microsoft.Extensions.Configuration => 0x30808ba1c00a455a => 37
	i64 3522470458906976663, ; 53: Xamarin.AndroidX.SwipeRefreshLayout => 0x30e2543832f52197 => 74
	i64 3551103847008531295, ; 54: System.Private.CoreLib.dll => 0x31480e226177735f => 136
	i64 3567343442040498961, ; 55: pt\Microsoft.Maui.Controls.resources => 0x3181bff5bea4ab11 => 22
	i64 3571415421602489686, ; 56: System.Runtime.dll => 0x319037675df7e556 => 124
	i64 3638003163729360188, ; 57: Microsoft.Extensions.Configuration.Abstractions => 0x327cc89a39d5f53c => 38
	i64 3647754201059316852, ; 58: System.Xml.ReaderWriter => 0x329f6d1e86145474 => 133
	i64 3655542548057982301, ; 59: Microsoft.Extensions.Configuration.dll => 0x32bb18945e52855d => 37
	i64 3716579019761409177, ; 60: netstandard.dll => 0x3393f0ed5c8c5c99 => 135
	i64 3727469159507183293, ; 61: Xamarin.AndroidX.RecyclerView => 0x33baa1739ba646bd => 72
	i64 3869221888984012293, ; 62: Microsoft.Extensions.Logging.dll => 0x35b23cceda0ed605 => 41
	i64 3890352374528606784, ; 63: Microsoft.Maui.Controls.Xaml.dll => 0x35fd4edf66e00240 => 47
	i64 3933965368022646939, ; 64: System.Net.Requests => 0x369840a8bfadc09b => 110
	i64 3966267475168208030, ; 65: System.Memory => 0x370b03412596249e => 104
	i64 4070326265757318011, ; 66: da\Microsoft.Maui.Controls.resources.dll => 0x387cb42c56683b7b => 3
	i64 4073500526318903918, ; 67: System.Private.Xml.dll => 0x3887fb25779ae26e => 119
	i64 4073631083018132676, ; 68: Microsoft.Maui.Controls.Compatibility.dll => 0x388871e311491cc4 => 45
	i64 4120493066591692148, ; 69: zh-Hant\Microsoft.Maui.Controls.resources => 0x392eee9cdda86574 => 33
	i64 4154383907710350974, ; 70: System.ComponentModel => 0x39a7562737acb67e => 90
	i64 4168469861834746866, ; 71: System.Security.Claims.dll => 0x39d96140fb94ebf2 => 125
	i64 4187479170553454871, ; 72: System.Linq.Expressions => 0x3a1cea1e912fa117 => 102
	i64 4205801962323029395, ; 73: System.ComponentModel.TypeConverter => 0x3a5e0299f7e7ad93 => 89
	i64 4360412976914417659, ; 74: tr\Microsoft.Maui.Controls.resources.dll => 0x3c834c8002fcc7fb => 28
	i64 4477672992252076438, ; 75: System.Web.HttpUtility.dll => 0x3e23e3dcdb8ba196 => 132
	i64 4672453897036726049, ; 76: System.IO.FileSystem.Watcher => 0x40d7e4104a437f21 => 100
	i64 4794310189461587505, ; 77: Xamarin.AndroidX.Activity => 0x4288cfb749e4c631 => 52
	i64 4795410492532947900, ; 78: Xamarin.AndroidX.SwipeRefreshLayout.dll => 0x428cb86f8f9b7bbc => 74
	i64 4814660307502931973, ; 79: System.Net.NameResolution.dll => 0x42d11c0a5ee2a005 => 107
	i64 4853321196694829351, ; 80: System.Runtime.Loader.dll => 0x435a75ea15de7927 => 122
	i64 4871824391508510238, ; 81: nb\Microsoft.Maui.Controls.resources.dll => 0x439c3278d7f2c61e => 18
	i64 4953714692329509532, ; 82: sv\Microsoft.Maui.Controls.resources.dll => 0x44bf21444aef129c => 26
	i64 5103417709280584325, ; 83: System.Collections.Specialized => 0x46d2fb5e161b6285 => 85
	i64 5182934613077526976, ; 84: System.Collections.Specialized.dll => 0x47ed7b91fa9009c0 => 85
	i64 5290786973231294105, ; 85: System.Runtime.Loader => 0x496ca6b869b72699 => 122
	i64 5471532531798518949, ; 86: sv\Microsoft.Maui.Controls.resources => 0x4beec9d926d82ca5 => 26
	i64 5522859530602327440, ; 87: uk\Microsoft.Maui.Controls.resources => 0x4ca5237b51eead90 => 29
	i64 5570799893513421663, ; 88: System.IO.Compression.Brotli => 0x4d4f74fcdfa6c35f => 97
	i64 5573260873512690141, ; 89: System.Security.Cryptography.dll => 0x4d58333c6e4ea1dd => 126
	i64 5669817223594541669, ; 90: SysBot.Base.dll => 0x4eaf3cb991be8265 => 80
	i64 5692067934154308417, ; 91: Xamarin.AndroidX.ViewPager2.dll => 0x4efe49a0d4a8bb41 => 76
	i64 5979151488806146654, ; 92: System.Formats.Asn1 => 0x52fa3699a489d25e => 96
	i64 6200764641006662125, ; 93: ro\Microsoft.Maui.Controls.resources => 0x560d8a96830131ed => 23
	i64 6300676701234028427, ; 94: es\Microsoft.Maui.Controls.resources.dll => 0x57708013cda25f8b => 6
	i64 6357457916754632952, ; 95: _Microsoft.Android.Resource.Designer => 0x583a3a4ac2a7a0f8 => 34
	i64 6401687960814735282, ; 96: Xamarin.AndroidX.Lifecycle.LiveData.Core => 0x58d75d486341cfb2 => 64
	i64 6471714727257221498, ; 97: fi\Microsoft.Maui.Controls.resources.dll => 0x59d026417dd4a97a => 7
	i64 6478287442656530074, ; 98: hr\Microsoft.Maui.Controls.resources => 0x59e7801b0c6a8e9a => 11
	i64 6548213210057960872, ; 99: Xamarin.AndroidX.CustomView.dll => 0x5adfed387b066da8 => 60
	i64 6560151584539558821, ; 100: Microsoft.Extensions.Options => 0x5b0a571be53243a5 => 43
	i64 6733841634999213036, ; 101: SwitchController-Client-MAUI => 0x5d73694a23dd1bec => 81
	i64 6743165466166707109, ; 102: nl\Microsoft.Maui.Controls.resources => 0x5d948943c08c43a5 => 19
	i64 6786606130239981554, ; 103: System.Diagnostics.TraceSource => 0x5e2ede51877147f2 => 95
	i64 6894844156784520562, ; 104: System.Numerics.Vectors => 0x5faf683aead1ad72 => 116
	i64 7270811800166795866, ; 105: System.Linq => 0x64e71ccf51a90a5a => 103
	i64 7377312882064240630, ; 106: System.ComponentModel.TypeConverter.dll => 0x66617afac45a2ff6 => 89
	i64 7489048572193775167, ; 107: System.ObjectModel => 0x67ee71ff6b419e3f => 117
	i64 7592577537120840276, ; 108: System.Diagnostics.Process => 0x695e410af5b2aa54 => 94
	i64 7654504624184590948, ; 109: System.Net.Http => 0x6a3a4366801b8264 => 105
	i64 7694700312542370399, ; 110: System.Net.Mail => 0x6ac9112a7e2cda5f => 106
	i64 7714652370974252055, ; 111: System.Private.CoreLib => 0x6b0ff375198b9c17 => 136
	i64 7735352534559001595, ; 112: Xamarin.Kotlin.StdLib.dll => 0x6b597e2582ce8bfb => 78
	i64 7742555799473854801, ; 113: it\Microsoft.Maui.Controls.resources.dll => 0x6b73157a51479951 => 14
	i64 7836164640616011524, ; 114: Xamarin.AndroidX.AppCompat.AppCompatResources => 0x6cbfa6390d64d704 => 54
	i64 7975724199463739455, ; 115: sk\Microsoft.Maui.Controls.resources.dll => 0x6eaf76e6f785e03f => 25
	i64 8064050204834738623, ; 116: System.Collections.dll => 0x6fe942efa61731bf => 86
	i64 8083354569033831015, ; 117: Xamarin.AndroidX.Lifecycle.Common.dll => 0x702dd82730cad267 => 63
	i64 8087206902342787202, ; 118: System.Diagnostics.DiagnosticSource => 0x703b87d46f3aa082 => 92
	i64 8108129031893776750, ; 119: ko\Microsoft.Maui.Controls.resources.dll => 0x7085dc65530f796e => 16
	i64 8167236081217502503, ; 120: Java.Interop.dll => 0x7157d9f1a9b8fd27 => 137
	i64 8185542183669246576, ; 121: System.Collections => 0x7198e33f4794aa70 => 86
	i64 8246048515196606205, ; 122: Microsoft.Maui.Graphics.dll => 0x726fd96f64ee56fd => 50
	i64 8264926008854159966, ; 123: System.Diagnostics.Process.dll => 0x72b2ea6a64a3a25e => 94
	i64 8368701292315763008, ; 124: System.Security.Cryptography => 0x7423997c6fd56140 => 126
	i64 8386351099740279196, ; 125: zh-HK\Microsoft.Maui.Controls.resources.dll => 0x74624de475b9d19c => 31
	i64 8400357532724379117, ; 126: Xamarin.AndroidX.Navigation.UI.dll => 0x749410ab44503ded => 71
	i64 8518412311883997971, ; 127: System.Collections.Immutable => 0x76377add7c28e313 => 83
	i64 8563666267364444763, ; 128: System.Private.Uri => 0x76d841191140ca5b => 118
	i64 8599632406834268464, ; 129: CommunityToolkit.Maui => 0x7758081c784b4930 => 35
	i64 8626175481042262068, ; 130: Java.Interop => 0x77b654e585b55834 => 137
	i64 8639588376636138208, ; 131: Xamarin.AndroidX.Navigation.Runtime => 0x77e5fbdaa2fda2e0 => 70
	i64 8677882282824630478, ; 132: pt-BR\Microsoft.Maui.Controls.resources => 0x786e07f5766b00ce => 21
	i64 8725526185868997716, ; 133: System.Diagnostics.DiagnosticSource.dll => 0x79174bd613173454 => 92
	i64 9045785047181495996, ; 134: zh-HK\Microsoft.Maui.Controls.resources => 0x7d891592e3cb0ebc => 31
	i64 9312692141327339315, ; 135: Xamarin.AndroidX.ViewPager2 => 0x813d54296a634f33 => 76
	i64 9324707631942237306, ; 136: Xamarin.AndroidX.AppCompat => 0x8168042fd44a7c7a => 53
	i64 9363564275759486853, ; 137: el\Microsoft.Maui.Controls.resources.dll => 0x81f21019382e9785 => 5
	i64 9551379474083066910, ; 138: uk\Microsoft.Maui.Controls.resources.dll => 0x848d5106bbadb41e => 29
	i64 9659729154652888475, ; 139: System.Text.RegularExpressions => 0x860e407c9991dd9b => 128
	i64 9678050649315576968, ; 140: Xamarin.AndroidX.CoordinatorLayout.dll => 0x864f57c9feb18c88 => 57
	i64 9702891218465930390, ; 141: System.Collections.NonGeneric.dll => 0x86a79827b2eb3c96 => 84
	i64 9773637193738963987, ; 142: ca\Microsoft.Maui.Controls.resources.dll => 0x87a2ef3ea85b4c13 => 1
	i64 9808709177481450983, ; 143: Mono.Android.dll => 0x881f890734e555e7 => 139
	i64 9836529246295212050, ; 144: System.Reflection.Metadata => 0x88825f3bbc2ac012 => 120
	i64 9956195530459977388, ; 145: Microsoft.Maui => 0x8a2b8315b36616ac => 48
	i64 10038780035334861115, ; 146: System.Net.Http.dll => 0x8b50e941206af13b => 105
	i64 10051358222726253779, ; 147: System.Private.Xml => 0x8b7d990c97ccccd3 => 119
	i64 10092835686693276772, ; 148: Microsoft.Maui.Controls => 0x8c10f49539bd0c64 => 46
	i64 10143853363526200146, ; 149: da\Microsoft.Maui.Controls.resources => 0x8cc634e3c2a16b52 => 3
	i64 10209869394718195525, ; 150: nl\Microsoft.Maui.Controls.resources.dll => 0x8db0be1ecb4f7f45 => 19
	i64 10229024438826829339, ; 151: Xamarin.AndroidX.CustomView => 0x8df4cb880b10061b => 60
	i64 10236703004850800690, ; 152: System.Net.ServicePoint.dll => 0x8e101325834e4832 => 112
	i64 10406448008575299332, ; 153: Xamarin.KotlinX.Coroutines.Core.Jvm.dll => 0x906b2153fcb3af04 => 79
	i64 10430153318873392755, ; 154: Xamarin.AndroidX.Core => 0x90bf592ea44f6673 => 58
	i64 10506226065143327199, ; 155: ca\Microsoft.Maui.Controls.resources => 0x91cd9cf11ed169df => 1
	i64 10761706286639228993, ; 156: zh-Hant\Microsoft.Maui.Controls.resources.dll => 0x955942d988382841 => 33
	i64 10785150219063592792, ; 157: System.Net.Primitives => 0x95ac8cfb68830758 => 109
	i64 10880838204485145808, ; 158: CommunityToolkit.Maui.dll => 0x970080b2a4d614d0 => 35
	i64 11002576679268595294, ; 159: Microsoft.Extensions.Logging.Abstractions => 0x98b1013215cd365e => 42
	i64 11009005086950030778, ; 160: Microsoft.Maui.dll => 0x98c7d7cc621ffdba => 48
	i64 11103970607964515343, ; 161: hu\Microsoft.Maui.Controls.resources => 0x9a193a6fc41a6c0f => 12
	i64 11156122287428000958, ; 162: th\Microsoft.Maui.Controls.resources.dll => 0x9ad2821cdcf6dcbe => 27
	i64 11157797727133427779, ; 163: fr\Microsoft.Maui.Controls.resources.dll => 0x9ad875ea9172e843 => 8
	i64 11162124722117608902, ; 164: Xamarin.AndroidX.ViewPager => 0x9ae7d54b986d05c6 => 75
	i64 11220793807500858938, ; 165: ja\Microsoft.Maui.Controls.resources => 0x9bb8448481fdd63a => 15
	i64 11226290749488709958, ; 166: Microsoft.Extensions.Options.dll => 0x9bcbcbf50c874146 => 43
	i64 11340910727871153756, ; 167: Xamarin.AndroidX.CursorAdapter => 0x9d630238642d465c => 59
	i64 11485890710487134646, ; 168: System.Runtime.InteropServices => 0x9f6614bf0f8b71b6 => 121
	i64 11518296021396496455, ; 169: id\Microsoft.Maui.Controls.resources => 0x9fd9353475222047 => 13
	i64 11529969570048099689, ; 170: Xamarin.AndroidX.ViewPager.dll => 0xa002ae3c4dc7c569 => 75
	i64 11530571088791430846, ; 171: Microsoft.Extensions.Logging => 0xa004d1504ccd66be => 41
	i64 11597940890313164233, ; 172: netstandard => 0xa0f429ca8d1805c9 => 135
	i64 11855031688536399763, ; 173: vi\Microsoft.Maui.Controls.resources.dll => 0xa485888294361f93 => 30
	i64 12040886584167504988, ; 174: System.Net.ServicePoint => 0xa719d28d8e121c5c => 112
	i64 12269460666702402136, ; 175: System.Collections.Immutable.dll => 0xaa45e178506c9258 => 83
	i64 12341818387765915815, ; 176: CommunityToolkit.Maui.Core.dll => 0xab46f26f152bf0a7 => 36
	i64 12451044538927396471, ; 177: Xamarin.AndroidX.Fragment.dll => 0xaccaff0a2955b677 => 62
	i64 12466513435562512481, ; 178: Xamarin.AndroidX.Loader.dll => 0xad01f3eb52569061 => 67
	i64 12475113361194491050, ; 179: _Microsoft.Android.Resource.Designer.dll => 0xad2081818aba1caa => 34
	i64 12517810545449516888, ; 180: System.Diagnostics.TraceSource.dll => 0xadb8325e6f283f58 => 95
	i64 12538491095302438457, ; 181: Xamarin.AndroidX.CardView.dll => 0xae01ab382ae67e39 => 55
	i64 12550732019250633519, ; 182: System.IO.Compression => 0xae2d28465e8e1b2f => 98
	i64 12700543734426720211, ; 183: Xamarin.AndroidX.Collection => 0xb041653c70d157d3 => 56
	i64 12843321153144804894, ; 184: Microsoft.Extensions.Primitives => 0xb23ca48abd74d61e => 44
	i64 12859557719246324186, ; 185: System.Net.WebHeaderCollection.dll => 0xb276539ce04f41da => 114
	i64 12989346753972519995, ; 186: ar\Microsoft.Maui.Controls.resources.dll => 0xb4436e0d5ee7c43b => 0
	i64 13005833372463390146, ; 187: pt-BR\Microsoft.Maui.Controls.resources.dll => 0xb47e008b5d99ddc2 => 21
	i64 13343850469010654401, ; 188: Mono.Android.Runtime.dll => 0xb92ee14d854f44c1 => 138
	i64 13381594904270902445, ; 189: he\Microsoft.Maui.Controls.resources => 0xb9b4f9aaad3e94ad => 9
	i64 13465488254036897740, ; 190: Xamarin.Kotlin.StdLib => 0xbadf06394d106fcc => 78
	i64 13540124433173649601, ; 191: vi\Microsoft.Maui.Controls.resources => 0xbbe82f6eede718c1 => 30
	i64 13572454107664307259, ; 192: Xamarin.AndroidX.RecyclerView.dll => 0xbc5b0b19d99f543b => 72
	i64 13717397318615465333, ; 193: System.ComponentModel.Primitives.dll => 0xbe5dfc2ef2f87d75 => 88
	i64 13811877368409317699, ; 194: SwitchController-Client-MAUI.dll => 0xbfada549c14b6143 => 81
	i64 13881769479078963060, ; 195: System.Console.dll => 0xc0a5f3cade5c6774 => 91
	i64 13948298724954241148, ; 196: SysBot.Base => 0xc1924fca01ee787c => 80
	i64 13959074834287824816, ; 197: Xamarin.AndroidX.Fragment => 0xc1b8989a7ad20fb0 => 62
	i64 14124974489674258913, ; 198: Xamarin.AndroidX.CardView => 0xc405fd76067d19e1 => 55
	i64 14125464355221830302, ; 199: System.Threading.dll => 0xc407bafdbc707a9e => 131
	i64 14220608275227875801, ; 200: System.Diagnostics.FileVersionInfo.dll => 0xc559bfe1def019d9 => 93
	i64 14349907877893689639, ; 201: ro\Microsoft.Maui.Controls.resources.dll => 0xc7251d2f956ed127 => 23
	i64 14461014870687870182, ; 202: System.Net.Requests.dll => 0xc8afd8683afdece6 => 110
	i64 14464374589798375073, ; 203: ru\Microsoft.Maui.Controls.resources => 0xc8bbc80dcb1e5ea1 => 24
	i64 14491877563792607819, ; 204: zh-Hans\Microsoft.Maui.Controls.resources.dll => 0xc91d7ddcee4fca4b => 32
	i64 14556034074661724008, ; 205: CommunityToolkit.Maui.Core => 0xca016bdea6b19f68 => 36
	i64 14610046442689856844, ; 206: cs\Microsoft.Maui.Controls.resources.dll => 0xcac14fd5107d054c => 2
	i64 14669215534098758659, ; 207: Microsoft.Extensions.DependencyInjection.dll => 0xcb9385ceb3993c03 => 39
	i64 14690985099581930927, ; 208: System.Web.HttpUtility => 0xcbe0dd1ca5233daf => 132
	i64 14705122255218365489, ; 209: ko\Microsoft.Maui.Controls.resources => 0xcc1316c7b0fb5431 => 16
	i64 14735017007120366644, ; 210: ja\Microsoft.Maui.Controls.resources.dll => 0xcc7d4be604bfbc34 => 15
	i64 14744092281598614090, ; 211: zh-Hans\Microsoft.Maui.Controls.resources => 0xcc9d89d004439a4a => 32
	i64 14832630590065248058, ; 212: System.Security.Claims => 0xcdd816ef5d6e873a => 125
	i64 14852515768018889994, ; 213: Xamarin.AndroidX.CursorAdapter.dll => 0xce1ebc6625a76d0a => 59
	i64 14904040806490515477, ; 214: ar\Microsoft.Maui.Controls.resources => 0xced5ca2604cb2815 => 0
	i64 14912225920358050525, ; 215: System.Security.Principal.Windows => 0xcef2de7759506add => 127
	i64 14954917835170835695, ; 216: Microsoft.Extensions.DependencyInjection.Abstractions.dll => 0xcf8a8a895a82ecef => 40
	i64 14984936317414011727, ; 217: System.Net.WebHeaderCollection => 0xcff5302fe54ff34f => 114
	i64 14987728460634540364, ; 218: System.IO.Compression.dll => 0xcfff1ba06622494c => 98
	i64 15015154896917945444, ; 219: System.Net.Security.dll => 0xd0608bd33642dc64 => 111
	i64 15076659072870671916, ; 220: System.ObjectModel.dll => 0xd13b0d8c1620662c => 117
	i64 15111608613780139878, ; 221: ms\Microsoft.Maui.Controls.resources => 0xd1b737f831192f66 => 17
	i64 15115185479366240210, ; 222: System.IO.Compression.Brotli.dll => 0xd1c3ed1c1bc467d2 => 97
	i64 15133485256822086103, ; 223: System.Linq.dll => 0xd204f0a9127dd9d7 => 103
	i64 15203009853192377507, ; 224: pt\Microsoft.Maui.Controls.resources.dll => 0xd2fbf0e9984b94a3 => 22
	i64 15227001540531775957, ; 225: Microsoft.Extensions.Configuration.Abstractions.dll => 0xd3512d3999b8e9d5 => 38
	i64 15370334346939861994, ; 226: Xamarin.AndroidX.Core.dll => 0xd54e65a72c560bea => 58
	i64 15391712275433856905, ; 227: Microsoft.Extensions.DependencyInjection.Abstractions => 0xd59a58c406411f89 => 40
	i64 15527772828719725935, ; 228: System.Console => 0xd77dbb1e38cd3d6f => 91
	i64 15536481058354060254, ; 229: de\Microsoft.Maui.Controls.resources => 0xd79cab34eec75bde => 4
	i64 15557562860424774966, ; 230: System.Net.Sockets => 0xd7e790fe7a6dc536 => 113
	i64 15582737692548360875, ; 231: Xamarin.AndroidX.Lifecycle.ViewModelSavedState => 0xd841015ed86f6aab => 66
	i64 15609085926864131306, ; 232: System.dll => 0xd89e9cf3334914ea => 134
	i64 15661133872274321916, ; 233: System.Xml.ReaderWriter.dll => 0xd9578647d4bfb1fc => 133
	i64 15783653065526199428, ; 234: el\Microsoft.Maui.Controls.resources => 0xdb0accd674b1c484 => 5
	i64 15847085070278954535, ; 235: System.Threading.Channels.dll => 0xdbec27e8f35f8e27 => 129
	i64 15928521404965645318, ; 236: Microsoft.Maui.Controls.Compatibility => 0xdd0d79d32c2eec06 => 45
	i64 16018552496348375205, ; 237: System.Net.NetworkInformation.dll => 0xde4d54a020caa8a5 => 108
	i64 16056281320585338352, ; 238: ru\Microsoft.Maui.Controls.resources.dll => 0xded35eca8f3a9df0 => 24
	i64 16154507427712707110, ; 239: System => 0xe03056ea4e39aa26 => 134
	i64 16219561732052121626, ; 240: System.Net.Security => 0xe1177575db7c781a => 111
	i64 16288847719894691167, ; 241: nb\Microsoft.Maui.Controls.resources => 0xe20d9cb300c12d5f => 18
	i64 16321164108206115771, ; 242: Microsoft.Extensions.Logging.Abstractions.dll => 0xe2806c487e7b0bbb => 42
	i64 16337011941688632206, ; 243: System.Security.Principal.Windows.dll => 0xe2b8b9cdc3aa638e => 127
	i64 16405810414439010633, ; 244: NLog => 0xe3ad25a6750a9149 => 51
	i64 16454459195343277943, ; 245: System.Net.NetworkInformation => 0xe459fb756d988f77 => 108
	i64 16649148416072044166, ; 246: Microsoft.Maui.Graphics => 0xe70da84600bb4e86 => 50
	i64 16677317093839702854, ; 247: Xamarin.AndroidX.Navigation.UI => 0xe771bb8960dd8b46 => 71
	i64 16758309481308491337, ; 248: System.IO.FileSystem.DriveInfo => 0xe89179af15740e49 => 99
	i64 16803648858859583026, ; 249: ms\Microsoft.Maui.Controls.resources.dll => 0xe9328d9b8ab93632 => 17
	i64 16890310621557459193, ; 250: System.Text.RegularExpressions.dll => 0xea66700587f088f9 => 128
	i64 16933958494752847024, ; 251: System.Net.WebProxy.dll => 0xeb018187f0f3b4b0 => 115
	i64 16942731696432749159, ; 252: sk\Microsoft.Maui.Controls.resources => 0xeb20acb622a01a67 => 25
	i64 16998075588627545693, ; 253: Xamarin.AndroidX.Navigation.Fragment => 0xebe54bb02d623e5d => 69
	i64 17008137082415910100, ; 254: System.Collections.NonGeneric => 0xec090a90408c8cd4 => 84
	i64 17031351772568316411, ; 255: Xamarin.AndroidX.Navigation.Common.dll => 0xec5b843380a769fb => 68
	i64 17062143951396181894, ; 256: System.ComponentModel.Primitives => 0xecc8e986518c9786 => 88
	i64 17118171214553292978, ; 257: System.Threading.Channels => 0xed8ff6060fc420b2 => 129
	i64 17201328579425343169, ; 258: System.ComponentModel.EventBasedAsync => 0xeeb76534d96c16c1 => 87
	i64 17203614576212522419, ; 259: pl\Microsoft.Maui.Controls.resources.dll => 0xeebf844ef3e135b3 => 20
	i64 17310278548634113468, ; 260: hi\Microsoft.Maui.Controls.resources.dll => 0xf03a76a04e6695bc => 10
	i64 17342750010158924305, ; 261: hi\Microsoft.Maui.Controls.resources => 0xf0add33f97ecc211 => 10
	i64 17514990004910432069, ; 262: fr\Microsoft.Maui.Controls.resources => 0xf311be9c6f341f45 => 8
	i64 17623389608345532001, ; 263: pl\Microsoft.Maui.Controls.resources => 0xf492db79dfbef661 => 20
	i64 17704177640604968747, ; 264: Xamarin.AndroidX.Loader => 0xf5b1dfc36cac272b => 67
	i64 17710060891934109755, ; 265: Xamarin.AndroidX.Lifecycle.ViewModel => 0xf5c6c68c9e45303b => 65
	i64 17712670374920797664, ; 266: System.Runtime.InteropServices.dll => 0xf5d00bdc38bd3de0 => 121
	i64 17777860260071588075, ; 267: System.Runtime.Numerics.dll => 0xf6b7a5b72419c0eb => 123
	i64 17827813215687577648, ; 268: hr\Microsoft.Maui.Controls.resources.dll => 0xf7691da9f3129030 => 11
	i64 17942426894774770628, ; 269: de\Microsoft.Maui.Controls.resources.dll => 0xf9004e329f771bc4 => 4
	i64 18025913125965088385, ; 270: System.Threading => 0xfa28e87b91334681 => 131
	i64 18121036031235206392, ; 271: Xamarin.AndroidX.Navigation.Common => 0xfb7ada42d3d42cf8 => 68
	i64 18146411883821974900, ; 272: System.Formats.Asn1.dll => 0xfbd50176eb22c574 => 96
	i64 18146811631844267958, ; 273: System.ComponentModel.EventBasedAsync.dll => 0xfbd66d08820117b6 => 87
	i64 18245806341561545090, ; 274: System.Collections.Concurrent.dll => 0xfd3620327d587182 => 82
	i64 18305135509493619199, ; 275: Xamarin.AndroidX.Navigation.Runtime.dll => 0xfe08e7c2d8c199ff => 70
	i64 18324163916253801303, ; 276: it\Microsoft.Maui.Controls.resources => 0xfe4c81ff0a56ab57 => 14
	i64 18342408478508122430, ; 277: id\Microsoft.Maui.Controls.resources.dll => 0xfe8d53543697013e => 13
	i64 18358161419737137786, ; 278: he\Microsoft.Maui.Controls.resources.dll => 0xfec54a8ba8b6827a => 9
	i64 18439108438687598470 ; 279: System.Reflection.Metadata.dll => 0xffe4df6e2ee1c786 => 120
], align 8

@assembly_image_cache_indices = dso_local local_unnamed_addr constant [280 x i32] [
	i32 44, ; 0
	i32 139, ; 1
	i32 49, ; 2
	i32 102, ; 3
	i32 56, ; 4
	i32 73, ; 5
	i32 130, ; 6
	i32 90, ; 7
	i32 12, ; 8
	i32 61, ; 9
	i32 77, ; 10
	i32 93, ; 11
	i32 69, ; 12
	i32 100, ; 13
	i32 109, ; 14
	i32 46, ; 15
	i32 138, ; 16
	i32 130, ; 17
	i32 54, ; 18
	i32 66, ; 19
	i32 106, ; 20
	i32 104, ; 21
	i32 118, ; 22
	i32 53, ; 23
	i32 6, ; 24
	i32 73, ; 25
	i32 28, ; 26
	i32 47, ; 27
	i32 65, ; 28
	i32 101, ; 29
	i32 61, ; 30
	i32 82, ; 31
	i32 64, ; 32
	i32 57, ; 33
	i32 124, ; 34
	i32 52, ; 35
	i32 27, ; 36
	i32 107, ; 37
	i32 39, ; 38
	i32 2, ; 39
	i32 7, ; 40
	i32 115, ; 41
	i32 77, ; 42
	i32 99, ; 43
	i32 63, ; 44
	i32 116, ; 45
	i32 123, ; 46
	i32 113, ; 47
	i32 79, ; 48
	i32 51, ; 49
	i32 49, ; 50
	i32 101, ; 51
	i32 37, ; 52
	i32 74, ; 53
	i32 136, ; 54
	i32 22, ; 55
	i32 124, ; 56
	i32 38, ; 57
	i32 133, ; 58
	i32 37, ; 59
	i32 135, ; 60
	i32 72, ; 61
	i32 41, ; 62
	i32 47, ; 63
	i32 110, ; 64
	i32 104, ; 65
	i32 3, ; 66
	i32 119, ; 67
	i32 45, ; 68
	i32 33, ; 69
	i32 90, ; 70
	i32 125, ; 71
	i32 102, ; 72
	i32 89, ; 73
	i32 28, ; 74
	i32 132, ; 75
	i32 100, ; 76
	i32 52, ; 77
	i32 74, ; 78
	i32 107, ; 79
	i32 122, ; 80
	i32 18, ; 81
	i32 26, ; 82
	i32 85, ; 83
	i32 85, ; 84
	i32 122, ; 85
	i32 26, ; 86
	i32 29, ; 87
	i32 97, ; 88
	i32 126, ; 89
	i32 80, ; 90
	i32 76, ; 91
	i32 96, ; 92
	i32 23, ; 93
	i32 6, ; 94
	i32 34, ; 95
	i32 64, ; 96
	i32 7, ; 97
	i32 11, ; 98
	i32 60, ; 99
	i32 43, ; 100
	i32 81, ; 101
	i32 19, ; 102
	i32 95, ; 103
	i32 116, ; 104
	i32 103, ; 105
	i32 89, ; 106
	i32 117, ; 107
	i32 94, ; 108
	i32 105, ; 109
	i32 106, ; 110
	i32 136, ; 111
	i32 78, ; 112
	i32 14, ; 113
	i32 54, ; 114
	i32 25, ; 115
	i32 86, ; 116
	i32 63, ; 117
	i32 92, ; 118
	i32 16, ; 119
	i32 137, ; 120
	i32 86, ; 121
	i32 50, ; 122
	i32 94, ; 123
	i32 126, ; 124
	i32 31, ; 125
	i32 71, ; 126
	i32 83, ; 127
	i32 118, ; 128
	i32 35, ; 129
	i32 137, ; 130
	i32 70, ; 131
	i32 21, ; 132
	i32 92, ; 133
	i32 31, ; 134
	i32 76, ; 135
	i32 53, ; 136
	i32 5, ; 137
	i32 29, ; 138
	i32 128, ; 139
	i32 57, ; 140
	i32 84, ; 141
	i32 1, ; 142
	i32 139, ; 143
	i32 120, ; 144
	i32 48, ; 145
	i32 105, ; 146
	i32 119, ; 147
	i32 46, ; 148
	i32 3, ; 149
	i32 19, ; 150
	i32 60, ; 151
	i32 112, ; 152
	i32 79, ; 153
	i32 58, ; 154
	i32 1, ; 155
	i32 33, ; 156
	i32 109, ; 157
	i32 35, ; 158
	i32 42, ; 159
	i32 48, ; 160
	i32 12, ; 161
	i32 27, ; 162
	i32 8, ; 163
	i32 75, ; 164
	i32 15, ; 165
	i32 43, ; 166
	i32 59, ; 167
	i32 121, ; 168
	i32 13, ; 169
	i32 75, ; 170
	i32 41, ; 171
	i32 135, ; 172
	i32 30, ; 173
	i32 112, ; 174
	i32 83, ; 175
	i32 36, ; 176
	i32 62, ; 177
	i32 67, ; 178
	i32 34, ; 179
	i32 95, ; 180
	i32 55, ; 181
	i32 98, ; 182
	i32 56, ; 183
	i32 44, ; 184
	i32 114, ; 185
	i32 0, ; 186
	i32 21, ; 187
	i32 138, ; 188
	i32 9, ; 189
	i32 78, ; 190
	i32 30, ; 191
	i32 72, ; 192
	i32 88, ; 193
	i32 81, ; 194
	i32 91, ; 195
	i32 80, ; 196
	i32 62, ; 197
	i32 55, ; 198
	i32 131, ; 199
	i32 93, ; 200
	i32 23, ; 201
	i32 110, ; 202
	i32 24, ; 203
	i32 32, ; 204
	i32 36, ; 205
	i32 2, ; 206
	i32 39, ; 207
	i32 132, ; 208
	i32 16, ; 209
	i32 15, ; 210
	i32 32, ; 211
	i32 125, ; 212
	i32 59, ; 213
	i32 0, ; 214
	i32 127, ; 215
	i32 40, ; 216
	i32 114, ; 217
	i32 98, ; 218
	i32 111, ; 219
	i32 117, ; 220
	i32 17, ; 221
	i32 97, ; 222
	i32 103, ; 223
	i32 22, ; 224
	i32 38, ; 225
	i32 58, ; 226
	i32 40, ; 227
	i32 91, ; 228
	i32 4, ; 229
	i32 113, ; 230
	i32 66, ; 231
	i32 134, ; 232
	i32 133, ; 233
	i32 5, ; 234
	i32 129, ; 235
	i32 45, ; 236
	i32 108, ; 237
	i32 24, ; 238
	i32 134, ; 239
	i32 111, ; 240
	i32 18, ; 241
	i32 42, ; 242
	i32 127, ; 243
	i32 51, ; 244
	i32 108, ; 245
	i32 50, ; 246
	i32 71, ; 247
	i32 99, ; 248
	i32 17, ; 249
	i32 128, ; 250
	i32 115, ; 251
	i32 25, ; 252
	i32 69, ; 253
	i32 84, ; 254
	i32 68, ; 255
	i32 88, ; 256
	i32 129, ; 257
	i32 87, ; 258
	i32 20, ; 259
	i32 10, ; 260
	i32 10, ; 261
	i32 8, ; 262
	i32 20, ; 263
	i32 67, ; 264
	i32 65, ; 265
	i32 121, ; 266
	i32 123, ; 267
	i32 11, ; 268
	i32 4, ; 269
	i32 131, ; 270
	i32 68, ; 271
	i32 96, ; 272
	i32 87, ; 273
	i32 82, ; 274
	i32 70, ; 275
	i32 14, ; 276
	i32 13, ; 277
	i32 9, ; 278
	i32 120 ; 279
], align 4

@marshal_methods_number_of_classes = dso_local local_unnamed_addr constant i32 0, align 4

@marshal_methods_class_cache = dso_local local_unnamed_addr global [0 x %struct.MarshalMethodsManagedClass] zeroinitializer, align 8

; Names of classes in which marshal methods reside
@mm_class_names = dso_local local_unnamed_addr constant [0 x ptr] zeroinitializer, align 8

@mm_method_names = dso_local local_unnamed_addr constant [1 x %struct.MarshalMethodName] [
	%struct.MarshalMethodName {
		i64 0, ; id 0x0; name: 
		ptr @.MarshalMethodName.0_name; char* name
	} ; 0
], align 8

; get_function_pointer (uint32_t mono_image_index, uint32_t class_index, uint32_t method_token, void*& target_ptr)
@get_function_pointer = internal dso_local unnamed_addr global ptr null, align 8

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
	store ptr %fn, ptr @get_function_pointer, align 8, !tbaa !3
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
attributes #0 = { "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind "stack-protector-buffer-size"="8" "target-cpu"="generic" "target-features"="+fix-cortex-a53-835769,+neon,+outline-atomics,+v8a" uwtable willreturn }
attributes #1 = { nofree nounwind }
attributes #2 = { noreturn "no-trapping-math"="true" nounwind "stack-protector-buffer-size"="8" "target-cpu"="generic" "target-features"="+fix-cortex-a53-835769,+neon,+outline-atomics,+v8a" }

; Metadata
!llvm.module.flags = !{!0, !1, !7, !8, !9, !10}
!0 = !{i32 1, !"wchar_size", i32 4}
!1 = !{i32 7, !"PIC Level", i32 2}
!llvm.ident = !{!2}
!2 = !{!"Xamarin.Android remotes/origin/release/8.0.1xx @ f1b7113872c8db3dfee70d11925e81bb752dc8d0"}
!3 = !{!4, !4, i64 0}
!4 = !{!"any pointer", !5, i64 0}
!5 = !{!"omnipotent char", !6, i64 0}
!6 = !{!"Simple C++ TBAA"}
!7 = !{i32 1, !"branch-target-enforcement", i32 0}
!8 = !{i32 1, !"sign-return-address", i32 0}
!9 = !{i32 1, !"sign-return-address-all", i32 0}
!10 = !{i32 1, !"sign-return-address-with-bkey", i32 0}
