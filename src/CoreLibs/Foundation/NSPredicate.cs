// Copyright 2014, Xamarin Inc. All rights reserved.

#if !COREBUILD

namespace Foundation {

	public partial class NSPredicate {

		public static NSPredicate FromFormat (string predicateFormat)
		{
			return _FromFormat (predicateFormat, null);
		}

		// a single `nil` is a valid parameter, not to be confused with no parameters
		public static NSPredicate FromFormat (string predicateFormat, NSObject argument)
		{
			return _FromFormat (predicateFormat, new NSObject [] { argument });
		}

		public static NSPredicate FromFormat (string predicateFormat, params NSObject [] arguments)
		{
			return _FromFormat (predicateFormat, arguments);
		}
	}
	
	[BaseType (typeof (NSObject))]
	// 'init' returns NIL
	public partial class NSPredicate :  NSCopying {
		[Static]
		[Internal]
		[Export ("predicateWithFormat:argumentArray:")]
		public static extern NSPredicate _FromFormat (string predicateFormat, [NullAllowed] NSObject [] arguments);

		[Static, Export ("predicateWithValue:")]
		public static extern NSPredicate FromValue (bool value);

		[Static, Export ("predicateWithBlock:")]
		public static extern NSPredicate FromExpression (NSPredicateEvaluator evaluator);

		[Export ("predicateFormat")]
		public extern string PredicateFormat { get; }

		[Export ("predicateWithSubstitutionVariables:")]
		public extern NSPredicate PredicateWithSubstitutionVariables (NSDictionary substitutionVariables);

		[Export ("evaluateWithObject:")]
		public extern bool EvaluateWithObject (NSObject obj);

		[Export ("evaluateWithObject:substitutionVariables:")]
		public extern bool EvaluateWithObject (NSObject obj, NSDictionary substitutionVariables);

		[return: NullAllowed]
		[Static]
		[NoiOS]
		[NoMacCatalyst]
		[NoWatch]
		[NoTV]
		[Export ("predicateFromMetadataQueryString:")]
		public extern NSPredicate? FromMetadataQueryString (string query);

		[MacCatalyst (13, 1)]
		[Export ("allowEvaluation")]
		public extern void AllowEvaluation ();
	}

	//[Category, BaseType (typeof (NSOrderedSet))] 
	public partial class NSPredicateSupport_NSOrderedSet: NSOrderedSet {
		[Export ("filteredOrderedSetUsingPredicate:")]
		public extern NSOrderedSet FilterUsingPredicate (NSPredicate p);
	}

	//[Category, BaseType (typeof (NSMutableOrderedSet))]
	public partial class NSPredicateSupport_NSMutableOrderedSet: NSMutableOrderedSet {
		[Export ("filterUsingPredicate:")]
		public extern void FilterUsingPredicate (NSPredicate p);
	}

	//[Category, BaseType (typeof (NSArray))]
	public partial class NSPredicateSupport_NSArray: NSArray {
		[Export ("filteredArrayUsingPredicate:")]
		public extern NSArray FilterUsingPredicate (NSArray array);
	}
	
	public delegate bool NSPredicateEvaluator (NSObject evaluatedObject, NSDictionary bindings);
	
}

#endif
