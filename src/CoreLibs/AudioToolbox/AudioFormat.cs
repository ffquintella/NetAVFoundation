using System.Runtime.InteropServices;
using ObjCRuntime;

namespace CoreLibs.AudioToolbox;

static partial class AudioFormatPropertyNative {
		[DllImport (Constants.AudioToolboxLibrary)]
		public unsafe extern static AudioFormatError AudioFormatGetPropertyInfo (AudioFormatProperty propertyID, int inSpecifierSize, AudioType.AudioFormatType* inSpecifier,
			uint* outPropertyDataSize);

		[DllImport (Constants.AudioToolboxLibrary)]
		public unsafe extern static AudioFormatError AudioFormatGetPropertyInfo (AudioFormatProperty propertyID, int inSpecifierSize, AudioType.AudioStreamBasicDescription* inSpecifier,
			uint* outPropertyDataSize);

		[DllImport (Constants.AudioToolboxLibrary)]
		public unsafe extern static AudioFormatError AudioFormatGetPropertyInfo (AudioFormatProperty propertyID, int inSpecifierSize, AudioType.AudioFormatInfo* inSpecifier,
			uint* outPropertyDataSize);

		[DllImport (Constants.AudioToolboxLibrary)]
		public unsafe extern static AudioFormatError AudioFormatGetPropertyInfo (AudioFormatProperty propertyID, int inSpecifierSize, int* inSpecifier,
			int* outPropertyDataSize);

		[DllImport (Constants.AudioToolboxLibrary)]
		public unsafe extern static AudioFormatError AudioFormatGetPropertyInfo (AudioFormatProperty propertyID, int inSpecifierSize, IntPtr inSpecifier,
			int* outPropertyDataSize);

		[DllImport (Constants.AudioToolboxLibrary)]
		public unsafe extern static AudioFormatError AudioFormatGetProperty (AudioFormatProperty propertyID, int inSpecifierSize, AudioType.AudioFormatType* inSpecifier,
			uint* ioDataSize, IntPtr outPropertyData);

		[DllImport (Constants.AudioToolboxLibrary)]
		public unsafe extern static AudioFormatError AudioFormatGetProperty (AudioFormatProperty propertyID, int inSpecifierSize, int* inSpecifier,
			int* ioDataSize, IntPtr outPropertyData);

		[DllImport (Constants.AudioToolboxLibrary)]
		public unsafe extern static AudioFormatError AudioFormatGetProperty (AudioFormatProperty propertyID, int inSpecifierSize, IntPtr inSpecifier,
			int* ioDataSize, IntPtr outPropertyData);

		[DllImport (Constants.AudioToolboxLibrary)]
		public unsafe extern static AudioFormatError AudioFormatGetProperty (AudioFormatProperty propertyID, int inSpecifierSize, IntPtr inSpecifier,
			int* ioDataSize, IntPtr* outPropertyData);

		[DllImport (Constants.AudioToolboxLibrary)]
		public unsafe extern static AudioFormatError AudioFormatGetProperty (AudioFormatProperty propertyID, int inSpecifierSize, IntPtr inSpecifier,
			int* ioDataSize, int* outPropertyData);

		[DllImport (Constants.AudioToolboxLibrary)]
		public unsafe extern static AudioFormatError AudioFormatGetProperty (AudioFormatProperty propertyID, int inSpecifierSize, int* inSpecifier,
			int* ioDataSize, int* outPropertyData);

		[DllImport (Constants.AudioToolboxLibrary)]
		public unsafe extern static AudioFormatError AudioFormatGetProperty (AudioFormatProperty propertyID, int inSpecifierSize, IntPtr inSpecifier,
			IntPtr ioDataSize, IntPtr outPropertyData);

		[DllImport (Constants.AudioToolboxLibrary)]
		public unsafe extern static AudioFormatError AudioFormatGetProperty (AudioFormatProperty propertyID, int inSpecifierSize, AudioType.AudioFormatInfo* inSpecifier,
			uint* ioDataSize, AudioFormat* outPropertyData);

		[DllImport (Constants.AudioToolboxLibrary)]
		public unsafe extern static AudioFormatError AudioFormatGetProperty (AudioFormatProperty propertyID, int inSpecifierSize, AudioType.AudioStreamBasicDescription* inSpecifier,
			uint* ioDataSize, int* outPropertyData);

		[DllImport (Constants.AudioToolboxLibrary)]
		public unsafe extern static AudioFormatError AudioFormatGetProperty (AudioFormatProperty propertyID, int inSpecifierSize, IntPtr* inSpecifier,
			int* ioDataSize, int* outPropertyData);

		[DllImport (Constants.AudioToolboxLibrary)]
		public unsafe extern static AudioFormatError AudioFormatGetProperty (AudioFormatProperty propertyID, int inSpecifierSize, IntPtr* inSpecifier,
			int* ioDataSize, float* outPropertyData);

		[DllImport (Constants.AudioToolboxLibrary)]
		public unsafe extern static AudioFormatError AudioFormatGetProperty (AudioFormatProperty propertyID, int inSpecifierSize, IntPtr inSpecifier,
			int* ioDataSize, float* outPropertyData);

		[DllImport (Constants.AudioToolboxLibrary)]
		public unsafe extern static AudioFormatError AudioFormatGetProperty (AudioFormatProperty inPropertyID, int inSpecifierSize, AudioType.AudioStreamBasicDescription* inSpecifier,
			int* ioPropertyDataSize, IntPtr* outPropertyData);

		[DllImport (Constants.AudioToolboxLibrary)]
		public unsafe extern static AudioFormatError AudioFormatGetProperty (AudioFormatProperty inPropertyID, int inSpecifierSize, AudioType.AudioStreamBasicDescription* inSpecifier,
			int* ioPropertyDataSize, uint* outPropertyData);

		[DllImport (Constants.AudioToolboxLibrary)]
		public unsafe extern static AudioFormatError AudioFormatGetProperty (AudioFormatProperty inPropertyID, int inSpecifierSize, IntPtr inSpecifier, int* ioPropertyDataSize,
			AudioType.AudioStreamBasicDescription* outPropertyData);

		[DllImport (Constants.AudioToolboxLibrary)]
		public unsafe extern static AudioFormatError AudioFormatGetProperty (AudioFormatProperty inPropertyID, int inSpecifierSize, AudioFormat* inSpecifier, int* ioPropertyDataSize,
			uint* outPropertyData);
	}

	// Properties are used from various types (most suitable should be used)
	enum AudioFormatProperty : uint // UInt32 AudioFormatPropertyID
	{
		FormatInfo = 0x666d7469,    // 'fmti'
		FormatName = 0x666e616d,    // 'fnam'
		EncodeFormatIDs = 0x61636f66,   // 'acof'
		DecodeFormatIDs = 0x61636966,   // 'acif'
		FormatList = 0x666c7374,    // 'flst'
		ASBDFromESDS = 0x65737364,  // 'essd'	// TODO: FromElementaryStreamDescriptor
		ChannelLayoutFromESDS = 0x6573636c, // 'escl'	// TODO:
		OutputFormatList = 0x6f666c73,  // 'ofls'
		FirstPlayableFormatFromList = 0x6670666c,   // 'fpfl'
		FormatIsVBR = 0x66766272,   // 'fvbr'
		FormatIsExternallyFramed = 0x66657866,  // 'fexf'
		FormatIsEncrypted = 0x63727970, // 'cryp'
		Encoders = 0x6176656e,  // 'aven'	
		Decoders = 0x61766465,  // 'avde'
		AvailableEncodeChannelLayoutTags = 0x6165636c,  // 'aecl'
		AvailableEncodeNumberChannels = 0x61766e63, // 'avnc'
		AvailableEncodeBitRates = 0x61656272,   // 'aebr'
		AvailableEncodeSampleRates = 0x61657372,    // 'aesr'
		ASBDFromMPEGPacket = 0x61646d70,    // 'admp'	// TODO:

		BitmapForLayoutTag = 0x626d7467,    // 'bmtg'
		MatrixMixMap = 0x6d6d6170,  // 'mmap'
		ChannelMap = 0x63686d70,    // 'chmp'
		NumberOfChannelsForLayout = 0x6e63686d, // 'nchm'
		AreChannelLayoutsEquivalent = 0x63686571,   // 'cheq'	// TODO:
		ChannelLayoutHash = 0x63686861,   // 'chha'
		ValidateChannelLayout = 0x7661636c, // 'vacl'
		ChannelLayoutForTag = 0x636d706c,   // 'cmpl'
		TagForChannelLayout = 0x636d7074,   // 'cmpt'
		ChannelLayoutName = 0x6c6f6e6d, // 'lonm'
		ChannelLayoutSimpleName = 0x6c6f6e6d,   // 'lsnm'
		ChannelLayoutForBitmap = 0x636d7062,    // 'cmpb'
		ChannelName = 0x636e616d,   // 'cnam'
		ChannelShortName = 0x63736e6d,  // 'csnm'

		TagsForNumberOfChannels = 0x74616763,   // 'tagc'
		PanningMatrix = 0x70616e6d, // 'panm'
		BalanceFade = 0x62616c66,   // 'balf'

		ID3TagSize = 0x69643373,    // 'id3s' // TODO:
		ID3TagToDictionary = 0x69643364,    // 'id3d' // TODO:

#if !MONOMAC
#if NET
		[SupportedOSPlatform ("ios")]
		[SupportedOSPlatform ("maccatalyst")]
		[SupportedOSPlatform ("tvos")]
		[ObsoletedOSPlatform ("ios8.0")]
		[ObsoletedOSPlatform ("maccatalyst13.1")]
		[ObsoletedOSPlatform ("tvos9.0")]
#else
		[Deprecated (PlatformName.iOS, 8, 0)]
#endif
		HardwareCodecCapabilities = 0x68776363, // 'hwcc'
#endif
	}
	
	public enum AudioFormatError : int // Implictly cast to OSType
	{
		None = 0,
		Unspecified = 0x77686174,   // 'what'
		UnsupportedProperty = 0x70726f70,   // 'prop'
		BadPropertySize = 0x2173697a,   // '!siz'
		BadSpecifierSize = 0x21737063,  // '!spc'
		UnsupportedDataFormat = 0x666d743f, // 'fmt?'
		UnknownFormat = 0x21666d74  // '!fmt'

		// TODO: Not documented
		// '!dat'
	}
	
	[StructLayout (LayoutKind.Sequential)]
	public struct AudioFormat {
		public AudioType.AudioStreamBasicDescription AudioStreamBasicDescription;
		public AudioType.AudioChannelLayoutTag AudioChannelLayoutTag;

		public unsafe static AudioFormat? GetFirstPlayableFormat (AudioFormat [] formatList)
		{
			if (formatList is null)
				ObjCRuntime.ThrowHelper.ThrowArgumentNullException (nameof (formatList));
			if (formatList.Length < 2)
				ObjCRuntime.ThrowHelper.ThrowArgumentNullException (nameof (formatList));

			fixed (AudioFormat* item = formatList) {
				uint index;
				int size = sizeof (uint);
				var ptr_size = sizeof (AudioFormat) * formatList.Length;
				if (AudioFormatPropertyNative.AudioFormatGetProperty (AudioFormatProperty.FirstPlayableFormatFromList, ptr_size, item, &size, &index) != 0)
					return null;
				return formatList [index];
			}
		}

		public override string ToString ()
		{
			return AudioChannelLayoutTag + ":" + AudioStreamBasicDescription.ToString ();
		}
	}