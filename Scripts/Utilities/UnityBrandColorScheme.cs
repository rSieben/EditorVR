﻿#if UNITY_EDITOR
using System.Collections.Generic;
using UnityEditor.Experimental.EditorVR.Helpers;
using UnityEngine;

namespace UnityEditor.Experimental.EditorVR.Utilities
{
	/// <summary>
	/// Class defining the Unity brancd color swatches & gradients
	/// </summary>
	public static class UnityBrandColorScheme
	{
		/// <summary>
		/// Random used to aid in lack of repeating color choices
		/// </summary>
		private static System.Random s_ColorRandom = new System.Random();

		/// <summary>
		/// Collection of Unity brand color swatches
		/// </summary>
		private static readonly List<Color> s_ColorSwatches = new List<Color>();

		/// <summary>
		/// Cache standard color swatch collection size, to reduce further lookups
		/// </summary>
		private static int s_ColorSwatchRange;
		private static int s_RandomSwatchColorPosition;

		/// <summary>
		/// Collection of Unity brand gradients, composed of unity-brand color swatches
		/// </summary>
		private static readonly List<GradientPair> s_Gradients = new List<GradientPair>();
		private static int s_RandomGradientPairColorAPosition;
		
		private static Color s_Red;
		private static Color s_RedLight;
		private static Color s_RedDark;

		private static Color s_Magenta;
		private static Color s_MagentaLight;
		private static Color s_MagentaDark;

		private static Color s_Purple;
		private static Color s_PurpleLight;
		private static Color s_PurpleDark;

		private static Color s_Blue;
		private static Color s_BlueLight;
		private static Color s_BlueDark;

		private static Color s_Cyan;
		private static Color s_CyanLight;
		private static Color s_CyanDark;

		private static Color s_Teal;
		private static Color s_TealLight;
		private static Color s_TealDark;

		private static Color s_Green;
		private static Color s_GreenLight;
		private static Color s_GreenDark;

		private static Color s_Lime;
		private static Color s_LimeLight;
		private static Color s_LimeDark;

		private static Color s_Yellow;
		private static Color s_YellowLight;
		private static Color s_YellowDark;

		private static Color s_Orange;
		private static Color s_OrangeLight;
		private static Color s_OrangeDark;

		private static Color s_DarkBlue;
		private static Color s_DarkBlueLight;

		private static Color s_Dark;
		private static Color s_Darker;
		private static Color s_Light;

		/// <summary>
		/// Collection of pre-defined Unity brand gradients
		/// </summary>
		public static List<GradientPair> gradients { get { return s_Gradients; } }

		// Unity Swatches 2016
		public static Color red { get { return s_Red; } }
		public static Color redLight { get { return s_RedLight; } }
		public static Color redDark { get { return s_RedDark; } }

		public static Color magenta { get { return s_Magenta; } }
		public static Color magentaLight { get { return s_MagentaLight; } }
		public static Color magentaDark { get { return s_MagentaDark; } }

		public static Color purple { get { return s_Purple; } }
		public static Color purpleLight { get { return s_PurpleLight; } }
		public static Color purpleDark { get { return s_PurpleDark; } }

		public static Color blue { get { return s_Blue; } }
		public static Color blueLight { get { return s_BlueLight; } }
		public static Color blueDark { get { return s_BlueDark; } }

		public static Color cyan { get { return s_Cyan; } }
		public static Color cyanLight { get { return s_CyanLight; } }
		public static Color cyanDark { get { return s_CyanDark; } }

		public static Color teal { get { return s_Teal; } }
		public static Color tealLight { get { return s_TealLight; } }
		public static Color tealDark { get { return s_TealDark; } }

		public static Color green { get { return s_Green; } }
		public static Color greenLight { get { return s_GreenLight; } }
		public static Color greenDark { get { return s_GreenDark; } }

		public static Color lime { get { return s_Lime; } }
		public static Color limeLight { get { return s_LimeLight; } }
		public static Color limeDark { get { return s_LimeDark; } }

		public static Color yellow { get { return s_Yellow; } }
		public static Color yellowLight { get { return s_YellowLight; } }
		public static Color yellowDark { get { return s_YellowDark; } }

		public static Color orange { get { return s_Orange; } }
		public static Color orangeLight { get { return s_OrangeLight; } }
		public static Color orangeDark { get { return s_OrangeDark; } }

		public static Color darkBlue { get { return s_DarkBlue; } }
		public static Color darkBlueLight { get { return s_DarkBlueLight; } }

		public static Color dark { get { return s_Dark; } }
		public static Color darker { get { return s_Darker; } }
		public static Color light { get { return s_Light; } }

		/// <summary>
		/// A unique Unity brand color gradient that can be set manually
		/// UI elements (or otherwise) can fetch this common gradient, for a uniform appearance across various elements
		/// </summary>
		public static GradientPair sessionGradient { get; set; }

		/// <summary>
		/// A high-contrast/grayscale Unity brand color gradient, having no chroma
		/// UI elements (or otherwise) can fetch this common gradient, for a uniform appearance across various elements
		/// </summary>
		public static GradientPair grayscaleSessionGradient { get; private set; }

		/// <summary>
		/// Static Constructor that sets up the swatch and gradient data
		/// </summary>
		static UnityBrandColorScheme()
		{
			SetupUnityBrandColors();
		}

		/// <summary>
		/// Setup Unity branded swatches and gradients
		/// </summary>
		private static void SetupUnityBrandColors()
		{
			s_Red = MaterialUtils.HexToColor("F44336");
			s_RedLight = MaterialUtils.HexToColor("FFEBEE");
			s_RedDark = MaterialUtils.HexToColor("B71C1C");

			s_Magenta = MaterialUtils.HexToColor("E91E63");
			s_MagentaLight = MaterialUtils.HexToColor("FCE4EC");
			s_MagentaDark = MaterialUtils.HexToColor("880E4F");

			s_Purple = MaterialUtils.HexToColor("9C27B0");
			s_PurpleLight = MaterialUtils.HexToColor("F3E5F5");
			s_PurpleDark = MaterialUtils.HexToColor("4A148C");

			s_Blue = MaterialUtils.HexToColor("03A9F4");
			s_BlueLight = MaterialUtils.HexToColor("E1F5FE");
			s_BlueDark = MaterialUtils.HexToColor("01579B");

			s_Cyan = MaterialUtils.HexToColor("00BCD4");
			s_CyanLight = MaterialUtils.HexToColor("E0F7FA");
			s_CyanDark = MaterialUtils.HexToColor("006064");

			s_Teal = MaterialUtils.HexToColor("009688");
			s_TealLight = MaterialUtils.HexToColor("E0F2F1");
			s_TealDark = MaterialUtils.HexToColor("004D40");

			s_Green = MaterialUtils.HexToColor("8AC249");
			s_GreenLight = MaterialUtils.HexToColor("F1F8E9");
			s_GreenDark = MaterialUtils.HexToColor("33691E");

			s_Lime = MaterialUtils.HexToColor("CDDC39");
			s_LimeLight = MaterialUtils.HexToColor("F9FBE7");
			s_LimeDark = MaterialUtils.HexToColor("827717");

			s_Yellow = MaterialUtils.HexToColor("FFEB3B");
			s_YellowLight = MaterialUtils.HexToColor("FFFDE7");
			s_YellowDark = MaterialUtils.HexToColor("F57F17");

			s_Orange = MaterialUtils.HexToColor("FF9800");
			s_OrangeLight = MaterialUtils.HexToColor("FFF3E0");
			s_OrangeDark = MaterialUtils.HexToColor("E65100");

			s_DarkBlue = MaterialUtils.HexToColor("222C37");
			s_DarkBlueLight = MaterialUtils.HexToColor("E9EBEC");

			s_Dark = MaterialUtils.HexToColor("323333");
			s_Darker = MaterialUtils.HexToColor("1A1A1A");
			s_Light = MaterialUtils.HexToColor("F5F8F9");

			// Set default neutral(luma) swatches
			s_ColorSwatches.Add(s_Red);
			s_ColorSwatches.Add(s_Magenta);
			s_ColorSwatches.Add(s_Purple);
			s_ColorSwatches.Add(s_Blue);
			s_ColorSwatches.Add(s_Cyan);
			s_ColorSwatches.Add(s_Teal);
			s_ColorSwatches.Add(s_Green);
			s_ColorSwatches.Add(s_Lime);
			s_ColorSwatches.Add(s_Yellow);
			s_ColorSwatches.Add(s_Orange);

			// cache standard color swatch list size
			s_ColorSwatchRange = s_ColorSwatches.Count - 1;

			// Define default gradients
			s_Gradients.Add(new GradientPair(s_Yellow, s_OrangeDark));
			s_Gradients.Add(new GradientPair(s_Purple, s_Green));
			s_Gradients.Add(new GradientPair(s_Teal, s_Lime));
			s_Gradients.Add(new GradientPair(s_Cyan, s_Red));
			s_Gradients.Add(new GradientPair(s_Blue, s_Magenta));
			s_Gradients.Add(new GradientPair(s_Red, s_Blue));
			s_Gradients.Add(new GradientPair(s_Blue, s_Lime));
			s_Gradients.Add(new GradientPair(s_Orange, s_Lime));

			// Setup default session gradient; can be set with a random gradient externally,
			// allowing all UI objects fetching this gradient to have a uniform color-scheme
			sessionGradient = new GradientPair(s_Light, s_Dark);

			// Setup grayscale light/dark contrasting session gradient
			grayscaleSessionGradient = new GradientPair(MaterialUtils.HexToColor("898A8AFF"), s_Light);
		}

		/// <summary>
		/// Fetch a Unity brand-specific color swatch
		/// </summary>
		/// <returns>Random color swatch</returns>
		public static Color GetRandomSwatch()
		{
			var randomPosition = s_ColorRandom.Next(s_ColorSwatchRange);
			while (s_RandomSwatchColorPosition == randomPosition)
				randomPosition = s_ColorRandom.Next(s_ColorSwatchRange);

			var color = s_ColorSwatches[randomPosition];

			s_RandomSwatchColorPosition = randomPosition;

			return color;
		}

		/// <summary>
		/// Fetch a Unity brand-specific color scheme (pair of differing brand-swatches)
		/// </summary>
		/// <returns>Gradient pair of two brand-swatches</returns>
		public static GradientPair GetRandomGradient()
		{
			var randomPositionA = s_ColorRandom.Next(s_ColorSwatchRange);
			var randomPositionB = s_ColorRandom.Next(s_ColorSwatchRange);

			// Return a new random colorA that is not the same as the previous A
			while (SwatchesSimilar(s_ColorSwatches[randomPositionA], s_ColorSwatches[s_RandomGradientPairColorAPosition], 0.35f))
				randomPositionA = s_ColorRandom.Next(s_ColorSwatchRange);

			// Mandate that the second color in the gradient is not the first color
			// Require additional swatch chroma separation for the second color chosen, making the gradient contrast more evident
			while (SwatchesSimilar(s_ColorSwatches[randomPositionB], s_ColorSwatches[randomPositionA], 1.0f))
				randomPositionB = s_ColorRandom.Next(s_ColorSwatchRange);

			var colorA = s_ColorSwatches[randomPositionA];
			var colorB = s_ColorSwatches[randomPositionB];

			// Set the first random color position value so it can be compared to the next gradient fetch
			s_RandomGradientPairColorAPosition = randomPositionA;

			colorA *= colorA; // multiply color to increase contrast/saturation for color A between gradients
			return new GradientPair(colorA, colorB);
		}

		/// <summary>
		/// Validate that two swatches/colors diverge by a minimum amount (or greater)
		/// </summary>
		/// <param name="swatchA">First swatch/color</param>
		/// <param name="swatchB">Second swatch/color</param>
		/// <param name="requiredMinimumDifference">The minimum amount of divergence required of the swatches</param>
		/// <returns>Bool denoting that(when false) the two color parameters differ by at least the required minimum</returns>
		static bool SwatchesSimilar(Color swatchA, Color swatchB, float requiredMinimumDifference = 0.75f)
		{
			var difference = Mathf.Abs(swatchA.r - swatchB.r) + Mathf.Abs(swatchA.g - swatchB.g) + Mathf.Abs(swatchA.b - swatchB.b);
			return difference < requiredMinimumDifference;
		}
	}
}
#endif
