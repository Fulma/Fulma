document.write('<script src="http://' + (location.host || 'localhost').split(':')[0] + ':35729/livereload.js?snipver=1"></' + 'script>');
(function (exports) {
'use strict';

/*
object-assign
(c) Sindre Sorhus
@license MIT
*/

var getOwnPropertySymbols = Object.getOwnPropertySymbols;
var hasOwnProperty = Object.prototype.hasOwnProperty;
var propIsEnumerable = Object.prototype.propertyIsEnumerable;

function toObject(val) {
	if (val === null || val === undefined) {
		throw new TypeError('Object.assign cannot be called with null or undefined');
	}

	return Object(val);
}

function shouldUseNative() {
	try {
		if (!Object.assign) {
			return false;
		}

		// Detect buggy property enumeration order in older V8 versions.

		// https://bugs.chromium.org/p/v8/issues/detail?id=4118
		var test1 = new String('abc');  // eslint-disable-line no-new-wrappers
		test1[5] = 'de';
		if (Object.getOwnPropertyNames(test1)[0] === '5') {
			return false;
		}

		// https://bugs.chromium.org/p/v8/issues/detail?id=3056
		var test2 = {};
		for (var i = 0; i < 10; i++) {
			test2['_' + String.fromCharCode(i)] = i;
		}
		var order2 = Object.getOwnPropertyNames(test2).map(function (n) {
			return test2[n];
		});
		if (order2.join('') !== '0123456789') {
			return false;
		}

		// https://bugs.chromium.org/p/v8/issues/detail?id=3056
		var test3 = {};
		'abcdefghijklmnopqrst'.split('').forEach(function (letter) {
			test3[letter] = letter;
		});
		if (Object.keys(Object.assign({}, test3)).join('') !==
				'abcdefghijklmnopqrst') {
			return false;
		}

		return true;
	} catch (err) {
		// We don't expect any of the above to throw, but better to be safe.
		return false;
	}
}

var index = shouldUseNative() ? Object.assign : function (target, source) {
	var from;
	var to = toObject(target);
	var symbols;

	for (var s = 1; s < arguments.length; s++) {
		from = Object(arguments[s]);

		for (var key in from) {
			if (hasOwnProperty.call(from, key)) {
				to[key] = from[key];
			}
		}

		if (getOwnPropertySymbols) {
			symbols = getOwnPropertySymbols(from);
			for (var i = 0; i < symbols.length; i++) {
				if (propIsEnumerable.call(from, symbols[i])) {
					to[symbols[i]] = from[symbols[i]];
				}
			}
		}
	}

	return to;
};

/**
 * Copyright (c) 2013-present, Facebook, Inc.
 * All rights reserved.
 *
 * This source code is licensed under the BSD-style license found in the
 * LICENSE file in the root directory of this source tree. An additional grant
 * of patent rights can be found in the PATENTS file in the same directory.
 *
 * 
 */

/**
 * Copyright (c) 2013-present, Facebook, Inc.
 * All rights reserved.
 *
 * This source code is licensed under the BSD-style license found in the
 * LICENSE file in the root directory of this source tree. An additional grant
 * of patent rights can be found in the PATENTS file in the same directory.
 *
 */

var validateFormat = function validateFormat(format) {};

{
  validateFormat = function validateFormat(format) {
    if (format === undefined) {
      throw new Error('invariant requires an error message argument');
    }
  };
}

function invariant(condition, format, a, b, c, d, e, f) {
  validateFormat(format);

  if (!condition) {
    var error;
    if (format === undefined) {
      error = new Error('Minified exception occurred; use the non-minified dev environment ' + 'for the full error message and additional helpful warnings.');
    } else {
      var args = [a, b, c, d, e, f];
      var argIndex = 0;
      error = new Error(format.replace(/%s/g, function () {
        return args[argIndex++];
      }));
      error.name = 'Invariant Violation';
    }

    error.framesToPop = 1; // we don't care about invariant's own frame
    throw error;
  }
}

var invariant_1 = invariant;

var oneArgumentPooler = function (copyFieldsFrom) {
  var Klass = this;
  if (Klass.instancePool.length) {
    var instance = Klass.instancePool.pop();
    Klass.call(instance, copyFieldsFrom);
    return instance;
  } else {
    return new Klass(copyFieldsFrom);
  }
};

var twoArgumentPooler$1 = function (a1, a2) {
  var Klass = this;
  if (Klass.instancePool.length) {
    var instance = Klass.instancePool.pop();
    Klass.call(instance, a1, a2);
    return instance;
  } else {
    return new Klass(a1, a2);
  }
};

var threeArgumentPooler = function (a1, a2, a3) {
  var Klass = this;
  if (Klass.instancePool.length) {
    var instance = Klass.instancePool.pop();
    Klass.call(instance, a1, a2, a3);
    return instance;
  } else {
    return new Klass(a1, a2, a3);
  }
};

var fourArgumentPooler$1 = function (a1, a2, a3, a4) {
  var Klass = this;
  if (Klass.instancePool.length) {
    var instance = Klass.instancePool.pop();
    Klass.call(instance, a1, a2, a3, a4);
    return instance;
  } else {
    return new Klass(a1, a2, a3, a4);
  }
};

var standardReleaser = function (instance) {
  var Klass = this;
  !(instance instanceof Klass) ? invariant_1(false, 'Trying to release an instance into a pool of a different type.') : void 0;
  instance.destructor();
  if (Klass.instancePool.length < Klass.poolSize) {
    Klass.instancePool.push(instance);
  }
};

var DEFAULT_POOL_SIZE = 10;
var DEFAULT_POOLER = oneArgumentPooler;

/**
 * Augments `CopyConstructor` to be a poolable class, augmenting only the class
 * itself (statically) not adding any prototypical fields. Any CopyConstructor
 * you give this may have a `poolSize` property, and will look for a
 * prototypical `destructor` on instances.
 *
 * @param {Function} CopyConstructor Constructor that can be used to reset.
 * @param {Function} pooler Customizable pooler.
 */
var addPoolingTo = function (CopyConstructor, pooler) {
  // Casting as any so that flow ignores the actual implementation and trusts
  // it to match the type we declared
  var NewKlass = CopyConstructor;
  NewKlass.instancePool = [];
  NewKlass.getPooled = pooler || DEFAULT_POOLER;
  if (!NewKlass.poolSize) {
    NewKlass.poolSize = DEFAULT_POOL_SIZE;
  }
  NewKlass.release = standardReleaser;
  return NewKlass;
};

var PooledClass = {
  addPoolingTo: addPoolingTo,
  oneArgumentPooler: oneArgumentPooler,
  twoArgumentPooler: twoArgumentPooler$1,
  threeArgumentPooler: threeArgumentPooler,
  fourArgumentPooler: fourArgumentPooler$1
};

var PooledClass_1 = PooledClass;

/**
 * Copyright 2013-present, Facebook, Inc.
 * All rights reserved.
 *
 * This source code is licensed under the BSD-style license found in the
 * LICENSE file in the root directory of this source tree. An additional grant
 * of patent rights can be found in the PATENTS file in the same directory.
 *
 * 
 */

var ReactCurrentOwner = {

  /**
   * @internal
   * @type {ReactComponent}
   */
  current: null

};

var ReactCurrentOwner_1 = ReactCurrentOwner;

function makeEmptyFunction(arg) {
  return function () {
    return arg;
  };
}

/**
 * This function accepts and discards inputs; it has no side effects. This is
 * primarily useful idiomatically for overridable function endpoints which
 * always need to be callable, since JS lacks a null-call idiom ala Cocoa.
 */
var emptyFunction = function emptyFunction() {};

emptyFunction.thatReturns = makeEmptyFunction;
emptyFunction.thatReturnsFalse = makeEmptyFunction(false);
emptyFunction.thatReturnsTrue = makeEmptyFunction(true);
emptyFunction.thatReturnsNull = makeEmptyFunction(null);
emptyFunction.thatReturnsThis = function () {
  return this;
};
emptyFunction.thatReturnsArgument = function (arg) {
  return arg;
};

var emptyFunction_1 = emptyFunction;

var warning = emptyFunction_1;

{
  (function () {
    var printWarning = function printWarning(format) {
      for (var _len = arguments.length, args = Array(_len > 1 ? _len - 1 : 0), _key = 1; _key < _len; _key++) {
        args[_key - 1] = arguments[_key];
      }

      var argIndex = 0;
      var message = 'Warning: ' + format.replace(/%s/g, function () {
        return args[argIndex++];
      });
      if (typeof console !== 'undefined') {
        console.error(message);
      }
      try {
        // --- Welcome to debugging React ---
        // This error was thrown as a convenience so that you can use this stack
        // to find the callsite that caused this warning to fire.
        throw new Error(message);
      } catch (x) {}
    };

    warning = function warning(condition, format) {
      if (format === undefined) {
        throw new Error('`warning(condition, format, ...args)` requires a warning ' + 'message argument');
      }

      if (format.indexOf('Failed Composite propType: ') === 0) {
        return; // Ignore CompositeComponent proptype check.
      }

      if (!condition) {
        for (var _len2 = arguments.length, args = Array(_len2 > 2 ? _len2 - 2 : 0), _key2 = 2; _key2 < _len2; _key2++) {
          args[_key2 - 2] = arguments[_key2];
        }

        printWarning.apply(undefined, [format].concat(args));
      }
    };
  })();
}

var warning_1 = warning;

/**
 * Copyright 2013-present, Facebook, Inc.
 * All rights reserved.
 *
 * This source code is licensed under the BSD-style license found in the
 * LICENSE file in the root directory of this source tree. An additional grant
 * of patent rights can be found in the PATENTS file in the same directory.
 *
 * 
 */

var canDefineProperty$1 = false;
{
  try {
    // $FlowFixMe https://github.com/facebook/flow/issues/285
    Object.defineProperty({}, 'x', { get: function () {} });
    canDefineProperty$1 = true;
  } catch (x) {
    // IE will fail on defineProperty
  }
}

var canDefineProperty_1 = canDefineProperty$1;

/**
 * Copyright 2014-present, Facebook, Inc.
 * All rights reserved.
 *
 * This source code is licensed under the BSD-style license found in the
 * LICENSE file in the root directory of this source tree. An additional grant
 * of patent rights can be found in the PATENTS file in the same directory.
 *
 * 
 */

var REACT_ELEMENT_TYPE = typeof Symbol === 'function' && Symbol['for'] && Symbol['for']('react.element') || 0xeac7;

var ReactElementSymbol = REACT_ELEMENT_TYPE;

var hasOwnProperty$1 = Object.prototype.hasOwnProperty;



var RESERVED_PROPS = {
  key: true,
  ref: true,
  __self: true,
  __source: true
};

var specialPropKeyWarningShown;
var specialPropRefWarningShown;

function hasValidRef(config) {
  {
    if (hasOwnProperty$1.call(config, 'ref')) {
      var getter = Object.getOwnPropertyDescriptor(config, 'ref').get;
      if (getter && getter.isReactWarning) {
        return false;
      }
    }
  }
  return config.ref !== undefined;
}

function hasValidKey(config) {
  {
    if (hasOwnProperty$1.call(config, 'key')) {
      var getter = Object.getOwnPropertyDescriptor(config, 'key').get;
      if (getter && getter.isReactWarning) {
        return false;
      }
    }
  }
  return config.key !== undefined;
}

function defineKeyPropWarningGetter(props, displayName) {
  var warnAboutAccessingKey = function () {
    if (!specialPropKeyWarningShown) {
      specialPropKeyWarningShown = true;
      warning_1(false, '%s: `key` is not a prop. Trying to access it will result ' + 'in `undefined` being returned. If you need to access the same ' + 'value within the child component, you should pass it as a different ' + 'prop. (https://fb.me/react-special-props)', displayName);
    }
  };
  warnAboutAccessingKey.isReactWarning = true;
  Object.defineProperty(props, 'key', {
    get: warnAboutAccessingKey,
    configurable: true
  });
}

function defineRefPropWarningGetter(props, displayName) {
  var warnAboutAccessingRef = function () {
    if (!specialPropRefWarningShown) {
      specialPropRefWarningShown = true;
      warning_1(false, '%s: `ref` is not a prop. Trying to access it will result ' + 'in `undefined` being returned. If you need to access the same ' + 'value within the child component, you should pass it as a different ' + 'prop. (https://fb.me/react-special-props)', displayName);
    }
  };
  warnAboutAccessingRef.isReactWarning = true;
  Object.defineProperty(props, 'ref', {
    get: warnAboutAccessingRef,
    configurable: true
  });
}

/**
 * Factory method to create a new React element. This no longer adheres to
 * the class pattern, so do not use new to call it. Also, no instanceof check
 * will work. Instead test $$typeof field against Symbol.for('react.element') to check
 * if something is a React Element.
 *
 * @param {*} type
 * @param {*} key
 * @param {string|object} ref
 * @param {*} self A *temporary* helper to detect places where `this` is
 * different from the `owner` when React.createElement is called, so that we
 * can warn. We want to get rid of owner and replace string `ref`s with arrow
 * functions, and as long as `this` and owner are the same, there will be no
 * change in behavior.
 * @param {*} source An annotation object (added by a transpiler or otherwise)
 * indicating filename, line number, and/or other information.
 * @param {*} owner
 * @param {*} props
 * @internal
 */
var ReactElement = function (type, key, ref, self, source, owner, props) {
  var element = {
    // This tag allow us to uniquely identify this as a React Element
    $$typeof: ReactElementSymbol,

    // Built-in properties that belong on the element
    type: type,
    key: key,
    ref: ref,
    props: props,

    // Record the component responsible for creating this element.
    _owner: owner
  };

  {
    // The validation flag is currently mutative. We put it on
    // an external backing store so that we can freeze the whole object.
    // This can be replaced with a WeakMap once they are implemented in
    // commonly used development environments.
    element._store = {};

    // To make comparing ReactElements easier for testing purposes, we make
    // the validation flag non-enumerable (where possible, which should
    // include every environment we run tests in), so the test framework
    // ignores it.
    if (canDefineProperty_1) {
      Object.defineProperty(element._store, 'validated', {
        configurable: false,
        enumerable: false,
        writable: true,
        value: false
      });
      // self and source are DEV only properties.
      Object.defineProperty(element, '_self', {
        configurable: false,
        enumerable: false,
        writable: false,
        value: self
      });
      // Two elements created in two different places should be considered
      // equal for testing purposes and therefore we hide it from enumeration.
      Object.defineProperty(element, '_source', {
        configurable: false,
        enumerable: false,
        writable: false,
        value: source
      });
    } else {
      element._store.validated = false;
      element._self = self;
      element._source = source;
    }
    if (Object.freeze) {
      Object.freeze(element.props);
      Object.freeze(element);
    }
  }

  return element;
};

/**
 * Create and return a new ReactElement of the given type.
 * See https://facebook.github.io/react/docs/top-level-api.html#react.createelement
 */
ReactElement.createElement = function (type, config, children) {
  var propName;

  // Reserved names are extracted
  var props = {};

  var key = null;
  var ref = null;
  var self = null;
  var source = null;

  if (config != null) {
    if (hasValidRef(config)) {
      ref = config.ref;
    }
    if (hasValidKey(config)) {
      key = '' + config.key;
    }

    self = config.__self === undefined ? null : config.__self;
    source = config.__source === undefined ? null : config.__source;
    // Remaining properties are added to a new props object
    for (propName in config) {
      if (hasOwnProperty$1.call(config, propName) && !RESERVED_PROPS.hasOwnProperty(propName)) {
        props[propName] = config[propName];
      }
    }
  }

  // Children can be more than one argument, and those are transferred onto
  // the newly allocated props object.
  var childrenLength = arguments.length - 2;
  if (childrenLength === 1) {
    props.children = children;
  } else if (childrenLength > 1) {
    var childArray = Array(childrenLength);
    for (var i = 0; i < childrenLength; i++) {
      childArray[i] = arguments[i + 2];
    }
    {
      if (Object.freeze) {
        Object.freeze(childArray);
      }
    }
    props.children = childArray;
  }

  // Resolve default props
  if (type && type.defaultProps) {
    var defaultProps = type.defaultProps;
    for (propName in defaultProps) {
      if (props[propName] === undefined) {
        props[propName] = defaultProps[propName];
      }
    }
  }
  {
    if (key || ref) {
      if (typeof props.$$typeof === 'undefined' || props.$$typeof !== ReactElementSymbol) {
        var displayName = typeof type === 'function' ? type.displayName || type.name || 'Unknown' : type;
        if (key) {
          defineKeyPropWarningGetter(props, displayName);
        }
        if (ref) {
          defineRefPropWarningGetter(props, displayName);
        }
      }
    }
  }
  return ReactElement(type, key, ref, self, source, ReactCurrentOwner_1.current, props);
};

/**
 * Return a function that produces ReactElements of a given type.
 * See https://facebook.github.io/react/docs/top-level-api.html#react.createfactory
 */
ReactElement.createFactory = function (type) {
  var factory = ReactElement.createElement.bind(null, type);
  // Expose the type on the factory and the prototype so that it can be
  // easily accessed on elements. E.g. `<Foo />.type === Foo`.
  // This should not be named `constructor` since this may not be the function
  // that created the element, and it may not even be a constructor.
  // Legacy hook TODO: Warn if this is accessed
  factory.type = type;
  return factory;
};

ReactElement.cloneAndReplaceKey = function (oldElement, newKey) {
  var newElement = ReactElement(oldElement.type, newKey, oldElement.ref, oldElement._self, oldElement._source, oldElement._owner, oldElement.props);

  return newElement;
};

/**
 * Clone and return a new ReactElement using element as the starting point.
 * See https://facebook.github.io/react/docs/top-level-api.html#react.cloneelement
 */
ReactElement.cloneElement = function (element, config, children) {
  var propName;

  // Original props are copied
  var props = index({}, element.props);

  // Reserved names are extracted
  var key = element.key;
  var ref = element.ref;
  // Self is preserved since the owner is preserved.
  var self = element._self;
  // Source is preserved since cloneElement is unlikely to be targeted by a
  // transpiler, and the original source is probably a better indicator of the
  // true owner.
  var source = element._source;

  // Owner will be preserved, unless ref is overridden
  var owner = element._owner;

  if (config != null) {
    if (hasValidRef(config)) {
      // Silently steal the ref from the parent.
      ref = config.ref;
      owner = ReactCurrentOwner_1.current;
    }
    if (hasValidKey(config)) {
      key = '' + config.key;
    }

    // Remaining properties override existing props
    var defaultProps;
    if (element.type && element.type.defaultProps) {
      defaultProps = element.type.defaultProps;
    }
    for (propName in config) {
      if (hasOwnProperty$1.call(config, propName) && !RESERVED_PROPS.hasOwnProperty(propName)) {
        if (config[propName] === undefined && defaultProps !== undefined) {
          // Resolve default props
          props[propName] = defaultProps[propName];
        } else {
          props[propName] = config[propName];
        }
      }
    }
  }

  // Children can be more than one argument, and those are transferred onto
  // the newly allocated props object.
  var childrenLength = arguments.length - 2;
  if (childrenLength === 1) {
    props.children = children;
  } else if (childrenLength > 1) {
    var childArray = Array(childrenLength);
    for (var i = 0; i < childrenLength; i++) {
      childArray[i] = arguments[i + 2];
    }
    props.children = childArray;
  }

  return ReactElement(element.type, key, ref, self, source, owner, props);
};

/**
 * Verifies the object is a ReactElement.
 * See https://facebook.github.io/react/docs/top-level-api.html#react.isvalidelement
 * @param {?object} object
 * @return {boolean} True if `object` is a valid component.
 * @final
 */
ReactElement.isValidElement = function (object) {
  return typeof object === 'object' && object !== null && object.$$typeof === ReactElementSymbol;
};

var ReactElement_1 = ReactElement;

/**
 * Copyright 2013-present, Facebook, Inc.
 * All rights reserved.
 *
 * This source code is licensed under the BSD-style license found in the
 * LICENSE file in the root directory of this source tree. An additional grant
 * of patent rights can be found in the PATENTS file in the same directory.
 *
 * 
 */

var ITERATOR_SYMBOL = typeof Symbol === 'function' && Symbol.iterator;
var FAUX_ITERATOR_SYMBOL = '@@iterator'; // Before Symbol spec.

/**
 * Returns the iterator method function contained on the iterable object.
 *
 * Be sure to invoke the function with the iterable as context:
 *
 *     var iteratorFn = getIteratorFn(myIterable);
 *     if (iteratorFn) {
 *       var iterator = iteratorFn.call(myIterable);
 *       ...
 *     }
 *
 * @param {?object} maybeIterable
 * @return {?function}
 */
function getIteratorFn(maybeIterable) {
  var iteratorFn = maybeIterable && (ITERATOR_SYMBOL && maybeIterable[ITERATOR_SYMBOL] || maybeIterable[FAUX_ITERATOR_SYMBOL]);
  if (typeof iteratorFn === 'function') {
    return iteratorFn;
  }
}

var getIteratorFn_1 = getIteratorFn;

/**
 * Copyright 2013-present, Facebook, Inc.
 * All rights reserved.
 *
 * This source code is licensed under the BSD-style license found in the
 * LICENSE file in the root directory of this source tree. An additional grant
 * of patent rights can be found in the PATENTS file in the same directory.
 *
 * 
 */

function escape(key) {
  var escapeRegex = /[=:]/g;
  var escaperLookup = {
    '=': '=0',
    ':': '=2'
  };
  var escapedString = ('' + key).replace(escapeRegex, function (match) {
    return escaperLookup[match];
  });

  return '$' + escapedString;
}

/**
 * Unescape and unwrap key for human-readable display
 *
 * @param {string} key to unescape.
 * @return {string} the unescaped key.
 */
function unescape(key) {
  var unescapeRegex = /(=0|=2)/g;
  var unescaperLookup = {
    '=0': '=',
    '=2': ':'
  };
  var keySubstring = key[0] === '.' && key[1] === '$' ? key.substring(2) : key.substring(1);

  return ('' + keySubstring).replace(unescapeRegex, function (match) {
    return unescaperLookup[match];
  });
}

var KeyEscapeUtils = {
  escape: escape,
  unescape: unescape
};

var KeyEscapeUtils_1 = KeyEscapeUtils;

var SEPARATOR = '.';
var SUBSEPARATOR = ':';

/**
 * This is inlined from ReactElement since this file is shared between
 * isomorphic and renderers. We could extract this to a
 *
 */

/**
 * TODO: Test that a single child and an array with one item have the same key
 * pattern.
 */

var didWarnAboutMaps = false;

/**
 * Generate a key string that identifies a component within a set.
 *
 * @param {*} component A component that could contain a manual key.
 * @param {number} index Index that is used if a manual key is not provided.
 * @return {string}
 */
function getComponentKey(component, index) {
  // Do some typechecking here since we call this blindly. We want to ensure
  // that we don't block potential future ES APIs.
  if (component && typeof component === 'object' && component.key != null) {
    // Explicit key
    return KeyEscapeUtils_1.escape(component.key);
  }
  // Implicit key determined by the index in the set
  return index.toString(36);
}

/**
 * @param {?*} children Children tree container.
 * @param {!string} nameSoFar Name of the key path so far.
 * @param {!function} callback Callback to invoke with each child found.
 * @param {?*} traverseContext Used to pass information throughout the traversal
 * process.
 * @return {!number} The number of children in this subtree.
 */
function traverseAllChildrenImpl(children, nameSoFar, callback, traverseContext) {
  var type = typeof children;

  if (type === 'undefined' || type === 'boolean') {
    // All of the above are perceived as null.
    children = null;
  }

  if (children === null || type === 'string' || type === 'number' ||
  // The following is inlined from ReactElement. This means we can optimize
  // some checks. React Fiber also inlines this logic for similar purposes.
  type === 'object' && children.$$typeof === ReactElementSymbol) {
    callback(traverseContext, children,
    // If it's the only child, treat the name as if it was wrapped in an array
    // so that it's consistent if the number of children grows.
    nameSoFar === '' ? SEPARATOR + getComponentKey(children, 0) : nameSoFar);
    return 1;
  }

  var child;
  var nextName;
  var subtreeCount = 0; // Count of children found in the current subtree.
  var nextNamePrefix = nameSoFar === '' ? SEPARATOR : nameSoFar + SUBSEPARATOR;

  if (Array.isArray(children)) {
    for (var i = 0; i < children.length; i++) {
      child = children[i];
      nextName = nextNamePrefix + getComponentKey(child, i);
      subtreeCount += traverseAllChildrenImpl(child, nextName, callback, traverseContext);
    }
  } else {
    var iteratorFn = getIteratorFn_1(children);
    if (iteratorFn) {
      var iterator = iteratorFn.call(children);
      var step;
      if (iteratorFn !== children.entries) {
        var ii = 0;
        while (!(step = iterator.next()).done) {
          child = step.value;
          nextName = nextNamePrefix + getComponentKey(child, ii++);
          subtreeCount += traverseAllChildrenImpl(child, nextName, callback, traverseContext);
        }
      } else {
        {
          var mapsAsChildrenAddendum = '';
          if (ReactCurrentOwner_1.current) {
            var mapsAsChildrenOwnerName = ReactCurrentOwner_1.current.getName();
            if (mapsAsChildrenOwnerName) {
              mapsAsChildrenAddendum = ' Check the render method of `' + mapsAsChildrenOwnerName + '`.';
            }
          }
          warning_1(didWarnAboutMaps, 'Using Maps as children is not yet fully supported. It is an ' + 'experimental feature that might be removed. Convert it to a ' + 'sequence / iterable of keyed ReactElements instead.%s', mapsAsChildrenAddendum);
          didWarnAboutMaps = true;
        }
        // Iterator will provide entry [k,v] tuples rather than values.
        while (!(step = iterator.next()).done) {
          var entry = step.value;
          if (entry) {
            child = entry[1];
            nextName = nextNamePrefix + KeyEscapeUtils_1.escape(entry[0]) + SUBSEPARATOR + getComponentKey(child, 0);
            subtreeCount += traverseAllChildrenImpl(child, nextName, callback, traverseContext);
          }
        }
      }
    } else if (type === 'object') {
      var addendum = '';
      {
        addendum = ' If you meant to render a collection of children, use an array ' + 'instead or wrap the object using createFragment(object) from the ' + 'React add-ons.';
        if (children._isReactElement) {
          addendum = ' It looks like you\'re using an element created by a different ' + 'version of React. Make sure to use only one copy of React.';
        }
        if (ReactCurrentOwner_1.current) {
          var name = ReactCurrentOwner_1.current.getName();
          if (name) {
            addendum += ' Check the render method of `' + name + '`.';
          }
        }
      }
      var childrenString = String(children);
      invariant_1(false, 'Objects are not valid as a React child (found: %s).%s', childrenString === '[object Object]' ? 'object with keys {' + Object.keys(children).join(', ') + '}' : childrenString, addendum);
    }
  }

  return subtreeCount;
}

/**
 * Traverses children that are typically specified as `props.children`, but
 * might also be specified through attributes:
 *
 * - `traverseAllChildren(this.props.children, ...)`
 * - `traverseAllChildren(this.props.leftPanelChildren, ...)`
 *
 * The `traverseContext` is an optional argument that is passed through the
 * entire traversal. It can be used to store accumulations or anything else that
 * the callback might find relevant.
 *
 * @param {?*} children Children tree object.
 * @param {!function} callback To invoke upon traversing each child.
 * @param {?*} traverseContext Context for traversal.
 * @return {!number} The number of children in this subtree.
 */
function traverseAllChildren(children, callback, traverseContext) {
  if (children == null) {
    return 0;
  }

  return traverseAllChildrenImpl(children, '', callback, traverseContext);
}

var traverseAllChildren_1 = traverseAllChildren;

var twoArgumentPooler = PooledClass_1.twoArgumentPooler;
var fourArgumentPooler = PooledClass_1.fourArgumentPooler;

var userProvidedKeyEscapeRegex = /\/+/g;
function escapeUserProvidedKey(text) {
  return ('' + text).replace(userProvidedKeyEscapeRegex, '$&/');
}

/**
 * PooledClass representing the bookkeeping associated with performing a child
 * traversal. Allows avoiding binding callbacks.
 *
 * @constructor ForEachBookKeeping
 * @param {!function} forEachFunction Function to perform traversal with.
 * @param {?*} forEachContext Context to perform context with.
 */
function ForEachBookKeeping(forEachFunction, forEachContext) {
  this.func = forEachFunction;
  this.context = forEachContext;
  this.count = 0;
}
ForEachBookKeeping.prototype.destructor = function () {
  this.func = null;
  this.context = null;
  this.count = 0;
};
PooledClass_1.addPoolingTo(ForEachBookKeeping, twoArgumentPooler);

function forEachSingleChild(bookKeeping, child, name) {
  var func = bookKeeping.func,
      context = bookKeeping.context;

  func.call(context, child, bookKeeping.count++);
}

/**
 * Iterates through children that are typically specified as `props.children`.
 *
 * See https://facebook.github.io/react/docs/top-level-api.html#react.children.foreach
 *
 * The provided forEachFunc(child, index) will be called for each
 * leaf child.
 *
 * @param {?*} children Children tree container.
 * @param {function(*, int)} forEachFunc
 * @param {*} forEachContext Context for forEachContext.
 */
function forEachChildren(children, forEachFunc, forEachContext) {
  if (children == null) {
    return children;
  }
  var traverseContext = ForEachBookKeeping.getPooled(forEachFunc, forEachContext);
  traverseAllChildren_1(children, forEachSingleChild, traverseContext);
  ForEachBookKeeping.release(traverseContext);
}

/**
 * PooledClass representing the bookkeeping associated with performing a child
 * mapping. Allows avoiding binding callbacks.
 *
 * @constructor MapBookKeeping
 * @param {!*} mapResult Object containing the ordered map of results.
 * @param {!function} mapFunction Function to perform mapping with.
 * @param {?*} mapContext Context to perform mapping with.
 */
function MapBookKeeping(mapResult, keyPrefix, mapFunction, mapContext) {
  this.result = mapResult;
  this.keyPrefix = keyPrefix;
  this.func = mapFunction;
  this.context = mapContext;
  this.count = 0;
}
MapBookKeeping.prototype.destructor = function () {
  this.result = null;
  this.keyPrefix = null;
  this.func = null;
  this.context = null;
  this.count = 0;
};
PooledClass_1.addPoolingTo(MapBookKeeping, fourArgumentPooler);

function mapSingleChildIntoContext(bookKeeping, child, childKey) {
  var result = bookKeeping.result,
      keyPrefix = bookKeeping.keyPrefix,
      func = bookKeeping.func,
      context = bookKeeping.context;


  var mappedChild = func.call(context, child, bookKeeping.count++);
  if (Array.isArray(mappedChild)) {
    mapIntoWithKeyPrefixInternal(mappedChild, result, childKey, emptyFunction_1.thatReturnsArgument);
  } else if (mappedChild != null) {
    if (ReactElement_1.isValidElement(mappedChild)) {
      mappedChild = ReactElement_1.cloneAndReplaceKey(mappedChild,
      // Keep both the (mapped) and old keys if they differ, just as
      // traverseAllChildren used to do for objects as children
      keyPrefix + (mappedChild.key && (!child || child.key !== mappedChild.key) ? escapeUserProvidedKey(mappedChild.key) + '/' : '') + childKey);
    }
    result.push(mappedChild);
  }
}

function mapIntoWithKeyPrefixInternal(children, array, prefix, func, context) {
  var escapedPrefix = '';
  if (prefix != null) {
    escapedPrefix = escapeUserProvidedKey(prefix) + '/';
  }
  var traverseContext = MapBookKeeping.getPooled(array, escapedPrefix, func, context);
  traverseAllChildren_1(children, mapSingleChildIntoContext, traverseContext);
  MapBookKeeping.release(traverseContext);
}

/**
 * Maps children that are typically specified as `props.children`.
 *
 * See https://facebook.github.io/react/docs/top-level-api.html#react.children.map
 *
 * The provided mapFunction(child, key, index) will be called for each
 * leaf child.
 *
 * @param {?*} children Children tree container.
 * @param {function(*, int)} func The map function.
 * @param {*} context Context for mapFunction.
 * @return {object} Object containing the ordered map of results.
 */
function mapChildren(children, func, context) {
  if (children == null) {
    return children;
  }
  var result = [];
  mapIntoWithKeyPrefixInternal(children, result, null, func, context);
  return result;
}

function forEachSingleChildDummy(traverseContext, child, name) {
  return null;
}

/**
 * Count the number of children that are typically specified as
 * `props.children`.
 *
 * See https://facebook.github.io/react/docs/top-level-api.html#react.children.count
 *
 * @param {?*} children Children tree container.
 * @return {number} The number of children.
 */
function countChildren(children, context) {
  return traverseAllChildren_1(children, forEachSingleChildDummy, null);
}

/**
 * Flatten a children object (typically specified as `props.children`) and
 * return an array with appropriately re-keyed children.
 *
 * See https://facebook.github.io/react/docs/top-level-api.html#react.children.toarray
 */
function toArray(children) {
  var result = [];
  mapIntoWithKeyPrefixInternal(children, result, null, emptyFunction_1.thatReturnsArgument);
  return result;
}

var ReactChildren = {
  forEach: forEachChildren,
  map: mapChildren,
  mapIntoWithKeyPrefixInternal: mapIntoWithKeyPrefixInternal,
  count: countChildren,
  toArray: toArray
};

var ReactChildren_1 = ReactChildren;

function warnNoop(publicInstance, callerName) {
  {
    var constructor = publicInstance.constructor;
    warning_1(false, '%s(...): Can only update a mounted or mounting component. ' + 'This usually means you called %s() on an unmounted component. ' + 'This is a no-op. Please check the code for the %s component.', callerName, callerName, constructor && (constructor.displayName || constructor.name) || 'ReactClass');
  }
}

/**
 * This is the abstract API for an update queue.
 */
var ReactNoopUpdateQueue = {

  /**
   * Checks whether or not this composite component is mounted.
   * @param {ReactClass} publicInstance The instance we want to test.
   * @return {boolean} True if mounted, false otherwise.
   * @protected
   * @final
   */
  isMounted: function (publicInstance) {
    return false;
  },

  /**
   * Enqueue a callback that will be executed after all the pending updates
   * have processed.
   *
   * @param {ReactClass} publicInstance The instance to use as `this` context.
   * @param {?function} callback Called after state is updated.
   * @internal
   */
  enqueueCallback: function (publicInstance, callback) {},

  /**
   * Forces an update. This should only be invoked when it is known with
   * certainty that we are **not** in a DOM transaction.
   *
   * You may want to call this when you know that some deeper aspect of the
   * component's state has changed but `setState` was not called.
   *
   * This will not invoke `shouldComponentUpdate`, but it will invoke
   * `componentWillUpdate` and `componentDidUpdate`.
   *
   * @param {ReactClass} publicInstance The instance that should rerender.
   * @internal
   */
  enqueueForceUpdate: function (publicInstance) {
    warnNoop(publicInstance, 'forceUpdate');
  },

  /**
   * Replaces all of the state. Always use this or `setState` to mutate state.
   * You should treat `this.state` as immutable.
   *
   * There is no guarantee that `this.state` will be immediately updated, so
   * accessing `this.state` after calling this method may return the old value.
   *
   * @param {ReactClass} publicInstance The instance that should rerender.
   * @param {object} completeState Next state.
   * @internal
   */
  enqueueReplaceState: function (publicInstance, completeState) {
    warnNoop(publicInstance, 'replaceState');
  },

  /**
   * Sets a subset of the state. This only exists because _pendingState is
   * internal. This provides a merging strategy that is not available to deep
   * properties which is confusing. TODO: Expose pendingState or don't use it
   * during the merge.
   *
   * @param {ReactClass} publicInstance The instance that should rerender.
   * @param {object} partialState Next partial state to be merged with state.
   * @internal
   */
  enqueueSetState: function (publicInstance, partialState) {
    warnNoop(publicInstance, 'setState');
  }
};

var ReactNoopUpdateQueue_1 = ReactNoopUpdateQueue;

/**
 * Copyright (c) 2013-present, Facebook, Inc.
 * All rights reserved.
 *
 * This source code is licensed under the BSD-style license found in the
 * LICENSE file in the root directory of this source tree. An additional grant
 * of patent rights can be found in the PATENTS file in the same directory.
 *
 */

var emptyObject = {};

{
  Object.freeze(emptyObject);
}

var emptyObject_1 = emptyObject;

function ReactComponent(props, context, updater) {
  this.props = props;
  this.context = context;
  this.refs = emptyObject_1;
  // We initialize the default updater but the real one gets injected by the
  // renderer.
  this.updater = updater || ReactNoopUpdateQueue_1;
}

ReactComponent.prototype.isReactComponent = {};

/**
 * Sets a subset of the state. Always use this to mutate
 * state. You should treat `this.state` as immutable.
 *
 * There is no guarantee that `this.state` will be immediately updated, so
 * accessing `this.state` after calling this method may return the old value.
 *
 * There is no guarantee that calls to `setState` will run synchronously,
 * as they may eventually be batched together.  You can provide an optional
 * callback that will be executed when the call to setState is actually
 * completed.
 *
 * When a function is provided to setState, it will be called at some point in
 * the future (not synchronously). It will be called with the up to date
 * component arguments (state, props, context). These values can be different
 * from this.* because your function may be called after receiveProps but before
 * shouldComponentUpdate, and this new state, props, and context will not yet be
 * assigned to this.
 *
 * @param {object|function} partialState Next partial state or function to
 *        produce next partial state to be merged with current state.
 * @param {?function} callback Called after state is updated.
 * @final
 * @protected
 */
ReactComponent.prototype.setState = function (partialState, callback) {
  !(typeof partialState === 'object' || typeof partialState === 'function' || partialState == null) ? invariant_1(false, 'setState(...): takes an object of state variables to update or a function which returns an object of state variables.') : void 0;
  this.updater.enqueueSetState(this, partialState);
  if (callback) {
    this.updater.enqueueCallback(this, callback, 'setState');
  }
};

/**
 * Forces an update. This should only be invoked when it is known with
 * certainty that we are **not** in a DOM transaction.
 *
 * You may want to call this when you know that some deeper aspect of the
 * component's state has changed but `setState` was not called.
 *
 * This will not invoke `shouldComponentUpdate`, but it will invoke
 * `componentWillUpdate` and `componentDidUpdate`.
 *
 * @param {?function} callback Called after update is complete.
 * @final
 * @protected
 */
ReactComponent.prototype.forceUpdate = function (callback) {
  this.updater.enqueueForceUpdate(this);
  if (callback) {
    this.updater.enqueueCallback(this, callback, 'forceUpdate');
  }
};

/**
 * Deprecated APIs. These APIs used to exist on classic React classes but since
 * we would like to deprecate them, we're not going to move them over to this
 * modern base class. Instead, we define a getter that warns if it's accessed.
 */
{
  var deprecatedAPIs = {
    isMounted: ['isMounted', 'Instead, make sure to clean up subscriptions and pending requests in ' + 'componentWillUnmount to prevent memory leaks.'],
    replaceState: ['replaceState', 'Refactor your code to use setState instead (see ' + 'https://github.com/facebook/react/issues/3236).']
  };
  var defineDeprecationWarning = function (methodName, info) {
    if (canDefineProperty_1) {
      Object.defineProperty(ReactComponent.prototype, methodName, {
        get: function () {
          warning_1(false, '%s(...) is deprecated in plain JavaScript React classes. %s', info[0], info[1]);
          return undefined;
        }
      });
    }
  };
  for (var fnName in deprecatedAPIs) {
    if (deprecatedAPIs.hasOwnProperty(fnName)) {
      defineDeprecationWarning(fnName, deprecatedAPIs[fnName]);
    }
  }
}

var ReactComponent_1 = ReactComponent;

function ReactPureComponent(props, context, updater) {
  // Duplicated from ReactComponent.
  this.props = props;
  this.context = context;
  this.refs = emptyObject_1;
  // We initialize the default updater but the real one gets injected by the
  // renderer.
  this.updater = updater || ReactNoopUpdateQueue_1;
}

function ComponentDummy() {}
ComponentDummy.prototype = ReactComponent_1.prototype;
ReactPureComponent.prototype = new ComponentDummy();
ReactPureComponent.prototype.constructor = ReactPureComponent;
// Avoid an extra prototype jump for these methods.
index(ReactPureComponent.prototype, ReactComponent_1.prototype);
ReactPureComponent.prototype.isPureReactComponent = true;

var ReactPureComponent_1 = ReactPureComponent;

/**
 * Copyright 2013-present, Facebook, Inc.
 * All rights reserved.
 *
 * This source code is licensed under the BSD-style license found in the
 * LICENSE file in the root directory of this source tree. An additional grant
 * of patent rights can be found in the PATENTS file in the same directory.
 *
 * 
 */

var ReactPropTypeLocationNames = {};

{
  ReactPropTypeLocationNames = {
    prop: 'prop',
    context: 'context',
    childContext: 'child context'
  };
}

var ReactPropTypeLocationNames_1 = ReactPropTypeLocationNames;

var MIXINS_KEY = 'mixins';

// Helper function to allow the creation of anonymous functions which do not
// have .name set to the name of the variable being assigned to.
function identity(fn) {
  return fn;
}

/**
 * Policies that describe methods in `ReactClassInterface`.
 */


var injectedMixins = [];

/**
 * Composite components are higher-level components that compose other composite
 * or host components.
 *
 * To create a new type of `ReactClass`, pass a specification of
 * your new class to `React.createClass`. The only requirement of your class
 * specification is that you implement a `render` method.
 *
 *   var MyComponent = React.createClass({
 *     render: function() {
 *       return <div>Hello World</div>;
 *     }
 *   });
 *
 * The class specification supports a specific protocol of methods that have
 * special meaning (e.g. `render`). See `ReactClassInterface` for
 * more the comprehensive protocol. Any other properties and methods in the
 * class specification will be available on the prototype.
 *
 * @interface ReactClassInterface
 * @internal
 */
var ReactClassInterface = {

  /**
   * An array of Mixin objects to include when defining your component.
   *
   * @type {array}
   * @optional
   */
  mixins: 'DEFINE_MANY',

  /**
   * An object containing properties and methods that should be defined on
   * the component's constructor instead of its prototype (static methods).
   *
   * @type {object}
   * @optional
   */
  statics: 'DEFINE_MANY',

  /**
   * Definition of prop types for this component.
   *
   * @type {object}
   * @optional
   */
  propTypes: 'DEFINE_MANY',

  /**
   * Definition of context types for this component.
   *
   * @type {object}
   * @optional
   */
  contextTypes: 'DEFINE_MANY',

  /**
   * Definition of context types this component sets for its children.
   *
   * @type {object}
   * @optional
   */
  childContextTypes: 'DEFINE_MANY',

  // ==== Definition methods ====

  /**
   * Invoked when the component is mounted. Values in the mapping will be set on
   * `this.props` if that prop is not specified (i.e. using an `in` check).
   *
   * This method is invoked before `getInitialState` and therefore cannot rely
   * on `this.state` or use `this.setState`.
   *
   * @return {object}
   * @optional
   */
  getDefaultProps: 'DEFINE_MANY_MERGED',

  /**
   * Invoked once before the component is mounted. The return value will be used
   * as the initial value of `this.state`.
   *
   *   getInitialState: function() {
   *     return {
   *       isOn: false,
   *       fooBaz: new BazFoo()
   *     }
   *   }
   *
   * @return {object}
   * @optional
   */
  getInitialState: 'DEFINE_MANY_MERGED',

  /**
   * @return {object}
   * @optional
   */
  getChildContext: 'DEFINE_MANY_MERGED',

  /**
   * Uses props from `this.props` and state from `this.state` to render the
   * structure of the component.
   *
   * No guarantees are made about when or how often this method is invoked, so
   * it must not have side effects.
   *
   *   render: function() {
   *     var name = this.props.name;
   *     return <div>Hello, {name}!</div>;
   *   }
   *
   * @return {ReactComponent}
   * @required
   */
  render: 'DEFINE_ONCE',

  // ==== Delegate methods ====

  /**
   * Invoked when the component is initially created and about to be mounted.
   * This may have side effects, but any external subscriptions or data created
   * by this method must be cleaned up in `componentWillUnmount`.
   *
   * @optional
   */
  componentWillMount: 'DEFINE_MANY',

  /**
   * Invoked when the component has been mounted and has a DOM representation.
   * However, there is no guarantee that the DOM node is in the document.
   *
   * Use this as an opportunity to operate on the DOM when the component has
   * been mounted (initialized and rendered) for the first time.
   *
   * @param {DOMElement} rootNode DOM element representing the component.
   * @optional
   */
  componentDidMount: 'DEFINE_MANY',

  /**
   * Invoked before the component receives new props.
   *
   * Use this as an opportunity to react to a prop transition by updating the
   * state using `this.setState`. Current props are accessed via `this.props`.
   *
   *   componentWillReceiveProps: function(nextProps, nextContext) {
   *     this.setState({
   *       likesIncreasing: nextProps.likeCount > this.props.likeCount
   *     });
   *   }
   *
   * NOTE: There is no equivalent `componentWillReceiveState`. An incoming prop
   * transition may cause a state change, but the opposite is not true. If you
   * need it, you are probably looking for `componentWillUpdate`.
   *
   * @param {object} nextProps
   * @optional
   */
  componentWillReceiveProps: 'DEFINE_MANY',

  /**
   * Invoked while deciding if the component should be updated as a result of
   * receiving new props, state and/or context.
   *
   * Use this as an opportunity to `return false` when you're certain that the
   * transition to the new props/state/context will not require a component
   * update.
   *
   *   shouldComponentUpdate: function(nextProps, nextState, nextContext) {
   *     return !equal(nextProps, this.props) ||
   *       !equal(nextState, this.state) ||
   *       !equal(nextContext, this.context);
   *   }
   *
   * @param {object} nextProps
   * @param {?object} nextState
   * @param {?object} nextContext
   * @return {boolean} True if the component should update.
   * @optional
   */
  shouldComponentUpdate: 'DEFINE_ONCE',

  /**
   * Invoked when the component is about to update due to a transition from
   * `this.props`, `this.state` and `this.context` to `nextProps`, `nextState`
   * and `nextContext`.
   *
   * Use this as an opportunity to perform preparation before an update occurs.
   *
   * NOTE: You **cannot** use `this.setState()` in this method.
   *
   * @param {object} nextProps
   * @param {?object} nextState
   * @param {?object} nextContext
   * @param {ReactReconcileTransaction} transaction
   * @optional
   */
  componentWillUpdate: 'DEFINE_MANY',

  /**
   * Invoked when the component's DOM representation has been updated.
   *
   * Use this as an opportunity to operate on the DOM when the component has
   * been updated.
   *
   * @param {object} prevProps
   * @param {?object} prevState
   * @param {?object} prevContext
   * @param {DOMElement} rootNode DOM element representing the component.
   * @optional
   */
  componentDidUpdate: 'DEFINE_MANY',

  /**
   * Invoked when the component is about to be removed from its parent and have
   * its DOM representation destroyed.
   *
   * Use this as an opportunity to deallocate any external resources.
   *
   * NOTE: There is no `componentDidUnmount` since your component will have been
   * destroyed by that point.
   *
   * @optional
   */
  componentWillUnmount: 'DEFINE_MANY',

  // ==== Advanced methods ====

  /**
   * Updates the component's currently mounted DOM representation.
   *
   * By default, this implements React's rendering and reconciliation algorithm.
   * Sophisticated clients may wish to override this.
   *
   * @param {ReactReconcileTransaction} transaction
   * @internal
   * @overridable
   */
  updateComponent: 'OVERRIDE_BASE'

};

/**
 * Mapping from class specification keys to special processing functions.
 *
 * Although these are declared like instance properties in the specification
 * when defining classes using `React.createClass`, they are actually static
 * and are accessible on the constructor instead of the prototype. Despite
 * being static, they must be defined outside of the "statics" key under
 * which all other static methods are defined.
 */
var RESERVED_SPEC_KEYS = {
  displayName: function (Constructor, displayName) {
    Constructor.displayName = displayName;
  },
  mixins: function (Constructor, mixins) {
    if (mixins) {
      for (var i = 0; i < mixins.length; i++) {
        mixSpecIntoComponent(Constructor, mixins[i]);
      }
    }
  },
  childContextTypes: function (Constructor, childContextTypes) {
    {
      validateTypeDef(Constructor, childContextTypes, 'childContext');
    }
    Constructor.childContextTypes = index({}, Constructor.childContextTypes, childContextTypes);
  },
  contextTypes: function (Constructor, contextTypes) {
    {
      validateTypeDef(Constructor, contextTypes, 'context');
    }
    Constructor.contextTypes = index({}, Constructor.contextTypes, contextTypes);
  },
  /**
   * Special case getDefaultProps which should move into statics but requires
   * automatic merging.
   */
  getDefaultProps: function (Constructor, getDefaultProps) {
    if (Constructor.getDefaultProps) {
      Constructor.getDefaultProps = createMergedResultFunction(Constructor.getDefaultProps, getDefaultProps);
    } else {
      Constructor.getDefaultProps = getDefaultProps;
    }
  },
  propTypes: function (Constructor, propTypes) {
    {
      validateTypeDef(Constructor, propTypes, 'prop');
    }
    Constructor.propTypes = index({}, Constructor.propTypes, propTypes);
  },
  statics: function (Constructor, statics) {
    mixStaticSpecIntoComponent(Constructor, statics);
  },
  autobind: function () {} };

function validateTypeDef(Constructor, typeDef, location) {
  for (var propName in typeDef) {
    if (typeDef.hasOwnProperty(propName)) {
      // use a warning instead of an invariant so components
      // don't show up in prod but only in __DEV__
      warning_1(typeof typeDef[propName] === 'function', '%s: %s type `%s` is invalid; it must be a function, usually from ' + 'React.PropTypes.', Constructor.displayName || 'ReactClass', ReactPropTypeLocationNames_1[location], propName);
    }
  }
}

function validateMethodOverride(isAlreadyDefined, name) {
  var specPolicy = ReactClassInterface.hasOwnProperty(name) ? ReactClassInterface[name] : null;

  // Disallow overriding of base class methods unless explicitly allowed.
  if (ReactClassMixin.hasOwnProperty(name)) {
    !(specPolicy === 'OVERRIDE_BASE') ? invariant_1(false, 'ReactClassInterface: You are attempting to override `%s` from your class specification. Ensure that your method names do not overlap with React methods.', name) : void 0;
  }

  // Disallow defining methods more than once unless explicitly allowed.
  if (isAlreadyDefined) {
    !(specPolicy === 'DEFINE_MANY' || specPolicy === 'DEFINE_MANY_MERGED') ? invariant_1(false, 'ReactClassInterface: You are attempting to define `%s` on your component more than once. This conflict may be due to a mixin.', name) : void 0;
  }
}

/**
 * Mixin helper which handles policy validation and reserved
 * specification keys when building React classes.
 */
function mixSpecIntoComponent(Constructor, spec) {
  if (!spec) {
    {
      var typeofSpec = typeof spec;
      var isMixinValid = typeofSpec === 'object' && spec !== null;

      warning_1(isMixinValid, '%s: You\'re attempting to include a mixin that is either null ' + 'or not an object. Check the mixins included by the component, ' + 'as well as any mixins they include themselves. ' + 'Expected object but got %s.', Constructor.displayName || 'ReactClass', spec === null ? null : typeofSpec);
    }

    return;
  }

  !(typeof spec !== 'function') ? invariant_1(false, 'ReactClass: You\'re attempting to use a component class or function as a mixin. Instead, just use a regular object.') : void 0;
  !!ReactElement_1.isValidElement(spec) ? invariant_1(false, 'ReactClass: You\'re attempting to use a component as a mixin. Instead, just use a regular object.') : void 0;

  var proto = Constructor.prototype;
  var autoBindPairs = proto.__reactAutoBindPairs;

  // By handling mixins before any other properties, we ensure the same
  // chaining order is applied to methods with DEFINE_MANY policy, whether
  // mixins are listed before or after these methods in the spec.
  if (spec.hasOwnProperty(MIXINS_KEY)) {
    RESERVED_SPEC_KEYS.mixins(Constructor, spec.mixins);
  }

  for (var name in spec) {
    if (!spec.hasOwnProperty(name)) {
      continue;
    }

    if (name === MIXINS_KEY) {
      // We have already handled mixins in a special case above.
      continue;
    }

    var property = spec[name];
    var isAlreadyDefined = proto.hasOwnProperty(name);
    validateMethodOverride(isAlreadyDefined, name);

    if (RESERVED_SPEC_KEYS.hasOwnProperty(name)) {
      RESERVED_SPEC_KEYS[name](Constructor, property);
    } else {
      // Setup methods on prototype:
      // The following member methods should not be automatically bound:
      // 1. Expected ReactClass methods (in the "interface").
      // 2. Overridden methods (that were mixed in).
      var isReactClassMethod = ReactClassInterface.hasOwnProperty(name);
      var isFunction = typeof property === 'function';
      var shouldAutoBind = isFunction && !isReactClassMethod && !isAlreadyDefined && spec.autobind !== false;

      if (shouldAutoBind) {
        autoBindPairs.push(name, property);
        proto[name] = property;
      } else {
        if (isAlreadyDefined) {
          var specPolicy = ReactClassInterface[name];

          // These cases should already be caught by validateMethodOverride.
          !(isReactClassMethod && (specPolicy === 'DEFINE_MANY_MERGED' || specPolicy === 'DEFINE_MANY')) ? invariant_1(false, 'ReactClass: Unexpected spec policy %s for key %s when mixing in component specs.', specPolicy, name) : void 0;

          // For methods which are defined more than once, call the existing
          // methods before calling the new property, merging if appropriate.
          if (specPolicy === 'DEFINE_MANY_MERGED') {
            proto[name] = createMergedResultFunction(proto[name], property);
          } else if (specPolicy === 'DEFINE_MANY') {
            proto[name] = createChainedFunction(proto[name], property);
          }
        } else {
          proto[name] = property;
          {
            // Add verbose displayName to the function, which helps when looking
            // at profiling tools.
            if (typeof property === 'function' && spec.displayName) {
              proto[name].displayName = spec.displayName + '_' + name;
            }
          }
        }
      }
    }
  }
}

function mixStaticSpecIntoComponent(Constructor, statics) {
  if (!statics) {
    return;
  }
  for (var name in statics) {
    var property = statics[name];
    if (!statics.hasOwnProperty(name)) {
      continue;
    }

    var isReserved = name in RESERVED_SPEC_KEYS;
    !!isReserved ? invariant_1(false, 'ReactClass: You are attempting to define a reserved property, `%s`, that shouldn\'t be on the "statics" key. Define it as an instance property instead; it will still be accessible on the constructor.', name) : void 0;

    var isInherited = name in Constructor;
    !!isInherited ? invariant_1(false, 'ReactClass: You are attempting to define `%s` on your component more than once. This conflict may be due to a mixin.', name) : void 0;
    Constructor[name] = property;
  }
}

/**
 * Merge two objects, but throw if both contain the same key.
 *
 * @param {object} one The first object, which is mutated.
 * @param {object} two The second object
 * @return {object} one after it has been mutated to contain everything in two.
 */
function mergeIntoWithNoDuplicateKeys(one, two) {
  !(one && two && typeof one === 'object' && typeof two === 'object') ? invariant_1(false, 'mergeIntoWithNoDuplicateKeys(): Cannot merge non-objects.') : void 0;

  for (var key in two) {
    if (two.hasOwnProperty(key)) {
      !(one[key] === undefined) ? invariant_1(false, 'mergeIntoWithNoDuplicateKeys(): Tried to merge two objects with the same key: `%s`. This conflict may be due to a mixin; in particular, this may be caused by two getInitialState() or getDefaultProps() methods returning objects with clashing keys.', key) : void 0;
      one[key] = two[key];
    }
  }
  return one;
}

/**
 * Creates a function that invokes two functions and merges their return values.
 *
 * @param {function} one Function to invoke first.
 * @param {function} two Function to invoke second.
 * @return {function} Function that invokes the two argument functions.
 * @private
 */
function createMergedResultFunction(one, two) {
  return function mergedResult() {
    var a = one.apply(this, arguments);
    var b = two.apply(this, arguments);
    if (a == null) {
      return b;
    } else if (b == null) {
      return a;
    }
    var c = {};
    mergeIntoWithNoDuplicateKeys(c, a);
    mergeIntoWithNoDuplicateKeys(c, b);
    return c;
  };
}

/**
 * Creates a function that invokes two functions and ignores their return vales.
 *
 * @param {function} one Function to invoke first.
 * @param {function} two Function to invoke second.
 * @return {function} Function that invokes the two argument functions.
 * @private
 */
function createChainedFunction(one, two) {
  return function chainedFunction() {
    one.apply(this, arguments);
    two.apply(this, arguments);
  };
}

/**
 * Binds a method to the component.
 *
 * @param {object} component Component whose method is going to be bound.
 * @param {function} method Method to be bound.
 * @return {function} The bound method.
 */
function bindAutoBindMethod(component, method) {
  var boundMethod = method.bind(component);
  {
    boundMethod.__reactBoundContext = component;
    boundMethod.__reactBoundMethod = method;
    boundMethod.__reactBoundArguments = null;
    var componentName = component.constructor.displayName;
    var _bind = boundMethod.bind;
    boundMethod.bind = function (newThis) {
      for (var _len = arguments.length, args = Array(_len > 1 ? _len - 1 : 0), _key = 1; _key < _len; _key++) {
        args[_key - 1] = arguments[_key];
      }

      // User is trying to bind() an autobound method; we effectively will
      // ignore the value of "this" that the user is trying to use, so
      // let's warn.
      if (newThis !== component && newThis !== null) {
        warning_1(false, 'bind(): React component methods may only be bound to the ' + 'component instance. See %s', componentName);
      } else if (!args.length) {
        warning_1(false, 'bind(): You are binding a component method to the component. ' + 'React does this for you automatically in a high-performance ' + 'way, so you can safely remove this call. See %s', componentName);
        return boundMethod;
      }
      var reboundMethod = _bind.apply(boundMethod, arguments);
      reboundMethod.__reactBoundContext = component;
      reboundMethod.__reactBoundMethod = method;
      reboundMethod.__reactBoundArguments = args;
      return reboundMethod;
    };
  }
  return boundMethod;
}

/**
 * Binds all auto-bound methods in a component.
 *
 * @param {object} component Component whose method is going to be bound.
 */
function bindAutoBindMethods(component) {
  var pairs = component.__reactAutoBindPairs;
  for (var i = 0; i < pairs.length; i += 2) {
    var autoBindKey = pairs[i];
    var method = pairs[i + 1];
    component[autoBindKey] = bindAutoBindMethod(component, method);
  }
}

/**
 * Add more to the ReactClass base class. These are all legacy features and
 * therefore not already part of the modern ReactComponent.
 */
var ReactClassMixin = {

  /**
   * TODO: This will be deprecated because state should always keep a consistent
   * type signature and the only use case for this, is to avoid that.
   */
  replaceState: function (newState, callback) {
    this.updater.enqueueReplaceState(this, newState);
    if (callback) {
      this.updater.enqueueCallback(this, callback, 'replaceState');
    }
  },

  /**
   * Checks whether or not this composite component is mounted.
   * @return {boolean} True if mounted, false otherwise.
   * @protected
   * @final
   */
  isMounted: function () {
    return this.updater.isMounted(this);
  }
};

var ReactClassComponent = function () {};
index(ReactClassComponent.prototype, ReactComponent_1.prototype, ReactClassMixin);

var didWarnDeprecated = false;

/**
 * Module for creating composite components.
 *
 * @class ReactClass
 */
var ReactClass = {

  /**
   * Creates a composite component class given a class specification.
   * See https://facebook.github.io/react/docs/top-level-api.html#react.createclass
   *
   * @param {object} spec Class specification (which must define `render`).
   * @return {function} Component constructor function.
   * @public
   */
  createClass: function (spec) {
    {
      warning_1(didWarnDeprecated, '%s: React.createClass is deprecated and will be removed in version 16. ' + 'Use plain JavaScript classes instead. If you\'re not yet ready to ' + 'migrate, create-react-class is available on npm as a ' + 'drop-in replacement.', spec && spec.displayName || 'A Component');
      didWarnDeprecated = true;
    }

    // To keep our warnings more understandable, we'll use a little hack here to
    // ensure that Constructor.name !== 'Constructor'. This makes sure we don't
    // unnecessarily identify a class without displayName as 'Constructor'.
    var Constructor = identity(function (props, context, updater) {
      // This constructor gets overridden by mocks. The argument is used
      // by mocks to assert on what gets mounted.

      {
        warning_1(this instanceof Constructor, 'Something is calling a React component directly. Use a factory or ' + 'JSX instead. See: https://fb.me/react-legacyfactory');
      }

      // Wire up auto-binding
      if (this.__reactAutoBindPairs.length) {
        bindAutoBindMethods(this);
      }

      this.props = props;
      this.context = context;
      this.refs = emptyObject_1;
      this.updater = updater || ReactNoopUpdateQueue_1;

      this.state = null;

      // ReactClasses doesn't have constructors. Instead, they use the
      // getInitialState and componentWillMount methods for initialization.

      var initialState = this.getInitialState ? this.getInitialState() : null;
      {
        // We allow auto-mocks to proceed as if they're returning null.
        if (initialState === undefined && this.getInitialState._isMockFunction) {
          // This is probably bad practice. Consider warning here and
          // deprecating this convenience.
          initialState = null;
        }
      }
      !(typeof initialState === 'object' && !Array.isArray(initialState)) ? invariant_1(false, '%s.getInitialState(): must return an object or null', Constructor.displayName || 'ReactCompositeComponent') : void 0;

      this.state = initialState;
    });
    Constructor.prototype = new ReactClassComponent();
    Constructor.prototype.constructor = Constructor;
    Constructor.prototype.__reactAutoBindPairs = [];

    injectedMixins.forEach(mixSpecIntoComponent.bind(null, Constructor));

    mixSpecIntoComponent(Constructor, spec);

    // Initialize the defaultProps property after all mixins have been merged.
    if (Constructor.getDefaultProps) {
      Constructor.defaultProps = Constructor.getDefaultProps();
    }

    {
      // This is a tag to indicate that the use of these method names is ok,
      // since it's used with createClass. If it's not, then it's likely a
      // mistake so we'll warn you to use the static property, property
      // initializer or constructor respectively.
      if (Constructor.getDefaultProps) {
        Constructor.getDefaultProps.isReactClassApproved = {};
      }
      if (Constructor.prototype.getInitialState) {
        Constructor.prototype.getInitialState.isReactClassApproved = {};
      }
    }

    !Constructor.prototype.render ? invariant_1(false, 'createClass(...): Class specification must implement a `render` method.') : void 0;

    {
      warning_1(!Constructor.prototype.componentShouldUpdate, '%s has a method called ' + 'componentShouldUpdate(). Did you mean shouldComponentUpdate()? ' + 'The name is phrased as a question because the function is ' + 'expected to return a value.', spec.displayName || 'A component');
      warning_1(!Constructor.prototype.componentWillRecieveProps, '%s has a method called ' + 'componentWillRecieveProps(). Did you mean componentWillReceiveProps()?', spec.displayName || 'A component');
    }

    // Reduce time spent doing lookups by setting these on the prototype.
    for (var methodName in ReactClassInterface) {
      if (!Constructor.prototype[methodName]) {
        Constructor.prototype[methodName] = null;
      }
    }

    return Constructor;
  },

  injection: {
    injectMixin: function (mixin) {
      injectedMixins.push(mixin);
    }
  }

};

var ReactClass_1 = ReactClass;

function isNative(fn) {
  // Based on isNative() from Lodash
  var funcToString = Function.prototype.toString;
  var hasOwnProperty = Object.prototype.hasOwnProperty;
  var reIsNative = RegExp('^' + funcToString
  // Take an example native function source for comparison
  .call(hasOwnProperty)
  // Strip regex characters so we can use it for regex
  .replace(/[\\^$.*+?()[\]{}|]/g, '\\$&')
  // Remove hasOwnProperty from the template to make it generic
  .replace(/hasOwnProperty|(function).*?(?=\\\()| for .+?(?=\\\])/g, '$1.*?') + '$');
  try {
    var source = funcToString.call(fn);
    return reIsNative.test(source);
  } catch (err) {
    return false;
  }
}

var canUseCollections =
// Array.from
typeof Array.from === 'function' &&
// Map
typeof Map === 'function' && isNative(Map) &&
// Map.prototype.keys
Map.prototype != null && typeof Map.prototype.keys === 'function' && isNative(Map.prototype.keys) &&
// Set
typeof Set === 'function' && isNative(Set) &&
// Set.prototype.keys
Set.prototype != null && typeof Set.prototype.keys === 'function' && isNative(Set.prototype.keys);

var setItem;
var getItem;
var removeItem;
var getItemIDs;
var addRoot;
var removeRoot;
var getRootIDs;

if (canUseCollections) {
  var itemMap = new Map();
  var rootIDSet = new Set();

  setItem = function (id, item) {
    itemMap.set(id, item);
  };
  getItem = function (id) {
    return itemMap.get(id);
  };
  removeItem = function (id) {
    itemMap['delete'](id);
  };
  getItemIDs = function () {
    return Array.from(itemMap.keys());
  };

  addRoot = function (id) {
    rootIDSet.add(id);
  };
  removeRoot = function (id) {
    rootIDSet['delete'](id);
  };
  getRootIDs = function () {
    return Array.from(rootIDSet.keys());
  };
} else {
  var itemByKey = {};
  var rootByKey = {};

  // Use non-numeric keys to prevent V8 performance issues:
  // https://github.com/facebook/react/pull/7232
  var getKeyFromID = function (id) {
    return '.' + id;
  };
  var getIDFromKey = function (key) {
    return parseInt(key.substr(1), 10);
  };

  setItem = function (id, item) {
    var key = getKeyFromID(id);
    itemByKey[key] = item;
  };
  getItem = function (id) {
    var key = getKeyFromID(id);
    return itemByKey[key];
  };
  removeItem = function (id) {
    var key = getKeyFromID(id);
    delete itemByKey[key];
  };
  getItemIDs = function () {
    return Object.keys(itemByKey).map(getIDFromKey);
  };

  addRoot = function (id) {
    var key = getKeyFromID(id);
    rootByKey[key] = true;
  };
  removeRoot = function (id) {
    var key = getKeyFromID(id);
    delete rootByKey[key];
  };
  getRootIDs = function () {
    return Object.keys(rootByKey).map(getIDFromKey);
  };
}

var unmountedIDs = [];

function purgeDeep(id) {
  var item = getItem(id);
  if (item) {
    var childIDs = item.childIDs;

    removeItem(id);
    childIDs.forEach(purgeDeep);
  }
}

function describeComponentFrame(name, source, ownerName) {
  return '\n    in ' + (name || 'Unknown') + (source ? ' (at ' + source.fileName.replace(/^.*[\\\/]/, '') + ':' + source.lineNumber + ')' : ownerName ? ' (created by ' + ownerName + ')' : '');
}

function getDisplayName(element) {
  if (element == null) {
    return '#empty';
  } else if (typeof element === 'string' || typeof element === 'number') {
    return '#text';
  } else if (typeof element.type === 'string') {
    return element.type;
  } else {
    return element.type.displayName || element.type.name || 'Unknown';
  }
}

function describeID(id) {
  var name = ReactComponentTreeHook.getDisplayName(id);
  var element = ReactComponentTreeHook.getElement(id);
  var ownerID = ReactComponentTreeHook.getOwnerID(id);
  var ownerName;
  if (ownerID) {
    ownerName = ReactComponentTreeHook.getDisplayName(ownerID);
  }
  warning_1(element, 'ReactComponentTreeHook: Missing React element for debugID %s when ' + 'building stack', id);
  return describeComponentFrame(name, element && element._source, ownerName);
}

var ReactComponentTreeHook = {
  onSetChildren: function (id, nextChildIDs) {
    var item = getItem(id);
    !item ? invariant_1(false, 'Item must have been set') : void 0;
    item.childIDs = nextChildIDs;

    for (var i = 0; i < nextChildIDs.length; i++) {
      var nextChildID = nextChildIDs[i];
      var nextChild = getItem(nextChildID);
      !nextChild ? invariant_1(false, 'Expected hook events to fire for the child before its parent includes it in onSetChildren().') : void 0;
      !(nextChild.childIDs != null || typeof nextChild.element !== 'object' || nextChild.element == null) ? invariant_1(false, 'Expected onSetChildren() to fire for a container child before its parent includes it in onSetChildren().') : void 0;
      !nextChild.isMounted ? invariant_1(false, 'Expected onMountComponent() to fire for the child before its parent includes it in onSetChildren().') : void 0;
      if (nextChild.parentID == null) {
        nextChild.parentID = id;
        // TODO: This shouldn't be necessary but mounting a new root during in
        // componentWillMount currently causes not-yet-mounted components to
        // be purged from our tree data so their parent id is missing.
      }
      !(nextChild.parentID === id) ? invariant_1(false, 'Expected onBeforeMountComponent() parent and onSetChildren() to be consistent (%s has parents %s and %s).', nextChildID, nextChild.parentID, id) : void 0;
    }
  },
  onBeforeMountComponent: function (id, element, parentID) {
    var item = {
      element: element,
      parentID: parentID,
      text: null,
      childIDs: [],
      isMounted: false,
      updateCount: 0
    };
    setItem(id, item);
  },
  onBeforeUpdateComponent: function (id, element) {
    var item = getItem(id);
    if (!item || !item.isMounted) {
      // We may end up here as a result of setState() in componentWillUnmount().
      // In this case, ignore the element.
      return;
    }
    item.element = element;
  },
  onMountComponent: function (id) {
    var item = getItem(id);
    !item ? invariant_1(false, 'Item must have been set') : void 0;
    item.isMounted = true;
    var isRoot = item.parentID === 0;
    if (isRoot) {
      addRoot(id);
    }
  },
  onUpdateComponent: function (id) {
    var item = getItem(id);
    if (!item || !item.isMounted) {
      // We may end up here as a result of setState() in componentWillUnmount().
      // In this case, ignore the element.
      return;
    }
    item.updateCount++;
  },
  onUnmountComponent: function (id) {
    var item = getItem(id);
    if (item) {
      // We need to check if it exists.
      // `item` might not exist if it is inside an error boundary, and a sibling
      // error boundary child threw while mounting. Then this instance never
      // got a chance to mount, but it still gets an unmounting event during
      // the error boundary cleanup.
      item.isMounted = false;
      var isRoot = item.parentID === 0;
      if (isRoot) {
        removeRoot(id);
      }
    }
    unmountedIDs.push(id);
  },
  purgeUnmountedComponents: function () {
    if (ReactComponentTreeHook._preventPurging) {
      // Should only be used for testing.
      return;
    }

    for (var i = 0; i < unmountedIDs.length; i++) {
      var id = unmountedIDs[i];
      purgeDeep(id);
    }
    unmountedIDs.length = 0;
  },
  isMounted: function (id) {
    var item = getItem(id);
    return item ? item.isMounted : false;
  },
  getCurrentStackAddendum: function (topElement) {
    var info = '';
    if (topElement) {
      var name = getDisplayName(topElement);
      var owner = topElement._owner;
      info += describeComponentFrame(name, topElement._source, owner && owner.getName());
    }

    var currentOwner = ReactCurrentOwner_1.current;
    var id = currentOwner && currentOwner._debugID;

    info += ReactComponentTreeHook.getStackAddendumByID(id);
    return info;
  },
  getStackAddendumByID: function (id) {
    var info = '';
    while (id) {
      info += describeID(id);
      id = ReactComponentTreeHook.getParentID(id);
    }
    return info;
  },
  getChildIDs: function (id) {
    var item = getItem(id);
    return item ? item.childIDs : [];
  },
  getDisplayName: function (id) {
    var element = ReactComponentTreeHook.getElement(id);
    if (!element) {
      return null;
    }
    return getDisplayName(element);
  },
  getElement: function (id) {
    var item = getItem(id);
    return item ? item.element : null;
  },
  getOwnerID: function (id) {
    var element = ReactComponentTreeHook.getElement(id);
    if (!element || !element._owner) {
      return null;
    }
    return element._owner._debugID;
  },
  getParentID: function (id) {
    var item = getItem(id);
    return item ? item.parentID : null;
  },
  getSource: function (id) {
    var item = getItem(id);
    var element = item ? item.element : null;
    var source = element != null ? element._source : null;
    return source;
  },
  getText: function (id) {
    var element = ReactComponentTreeHook.getElement(id);
    if (typeof element === 'string') {
      return element;
    } else if (typeof element === 'number') {
      return '' + element;
    } else {
      return null;
    }
  },
  getUpdateCount: function (id) {
    var item = getItem(id);
    return item ? item.updateCount : 0;
  },


  getRootIDs: getRootIDs,
  getRegisteredIDs: getItemIDs
};

var ReactComponentTreeHook_1 = ReactComponentTreeHook;

/**
 * Copyright 2013-present, Facebook, Inc.
 * All rights reserved.
 *
 * This source code is licensed under the BSD-style license found in the
 * LICENSE file in the root directory of this source tree. An additional grant
 * of patent rights can be found in the PATENTS file in the same directory.
 *
 * 
 */

var ReactPropTypesSecret = 'SECRET_DO_NOT_PASS_THIS_OR_YOU_WILL_BE_FIRED';

var ReactPropTypesSecret_1 = ReactPropTypesSecret;

var ReactComponentTreeHook$1;

if (typeof process !== 'undefined' && process.env && "development" === 'test') {
  // Temporary hack.
  // Inline requires don't work well with Jest:
  // https://github.com/facebook/react/issues/7240
  // Remove the inline requires when we don't need them anymore:
  // https://github.com/facebook/react/pull/7178
  ReactComponentTreeHook$1 = ReactComponentTreeHook_1;
}

var loggedTypeFailures = {};

/**
 * Assert that the values match with the type specs.
 * Error messages are memorized and will only be shown once.
 *
 * @param {object} typeSpecs Map of name to a ReactPropType
 * @param {object} values Runtime values that need to be type-checked
 * @param {string} location e.g. "prop", "context", "child context"
 * @param {string} componentName Name of the component for error messages.
 * @param {?object} element The React element that is being type-checked
 * @param {?number} debugID The React component instance that is being type-checked
 * @private
 */
function checkReactTypeSpec(typeSpecs, values, location, componentName, element, debugID) {
  for (var typeSpecName in typeSpecs) {
    if (typeSpecs.hasOwnProperty(typeSpecName)) {
      var error;
      // Prop type validation may throw. In case they do, we don't want to
      // fail the render phase where it didn't fail before. So we log it.
      // After these have been cleaned up, we'll let them throw.
      try {
        // This is intentionally an invariant that gets caught. It's the same
        // behavior as without this statement except with a better message.
        !(typeof typeSpecs[typeSpecName] === 'function') ? invariant_1(false, '%s: %s type `%s` is invalid; it must be a function, usually from React.PropTypes.', componentName || 'React class', ReactPropTypeLocationNames_1[location], typeSpecName) : void 0;
        error = typeSpecs[typeSpecName](values, typeSpecName, componentName, location, null, ReactPropTypesSecret_1);
      } catch (ex) {
        error = ex;
      }
      warning_1(!error || error instanceof Error, '%s: type specification of %s `%s` is invalid; the type checker ' + 'function must return `null` or an `Error` but returned a %s. ' + 'You may have forgotten to pass an argument to the type checker ' + 'creator (arrayOf, instanceOf, objectOf, oneOf, oneOfType, and ' + 'shape all require an argument).', componentName || 'React class', ReactPropTypeLocationNames_1[location], typeSpecName, typeof error);
      if (error instanceof Error && !(error.message in loggedTypeFailures)) {
        // Only monitor this failure once because there tends to be a lot of the
        // same error.
        loggedTypeFailures[error.message] = true;

        var componentStackInfo = '';

        {
          if (!ReactComponentTreeHook$1) {
            ReactComponentTreeHook$1 = ReactComponentTreeHook_1;
          }
          if (debugID !== null) {
            componentStackInfo = ReactComponentTreeHook$1.getStackAddendumByID(debugID);
          } else if (element !== null) {
            componentStackInfo = ReactComponentTreeHook$1.getCurrentStackAddendum(element);
          }
        }

        warning_1(false, 'Failed %s type: %s%s', location, error.message, componentStackInfo);
      }
    }
  }
}

var checkReactTypeSpec_1 = checkReactTypeSpec;

function getDeclarationErrorAddendum() {
  if (ReactCurrentOwner_1.current) {
    var name = ReactCurrentOwner_1.current.getName();
    if (name) {
      return ' Check the render method of `' + name + '`.';
    }
  }
  return '';
}

function getSourceInfoErrorAddendum(elementProps) {
  if (elementProps !== null && elementProps !== undefined && elementProps.__source !== undefined) {
    var source = elementProps.__source;
    var fileName = source.fileName.replace(/^.*[\\\/]/, '');
    var lineNumber = source.lineNumber;
    return ' Check your code at ' + fileName + ':' + lineNumber + '.';
  }
  return '';
}

/**
 * Warn if there's no key explicitly set on dynamic arrays of children or
 * object keys are not valid. This allows us to keep track of children between
 * updates.
 */
var ownerHasKeyUseWarning = {};

function getCurrentComponentErrorInfo(parentType) {
  var info = getDeclarationErrorAddendum();

  if (!info) {
    var parentName = typeof parentType === 'string' ? parentType : parentType.displayName || parentType.name;
    if (parentName) {
      info = ' Check the top-level render call using <' + parentName + '>.';
    }
  }
  return info;
}

/**
 * Warn if the element doesn't have an explicit key assigned to it.
 * This element is in an array. The array could grow and shrink or be
 * reordered. All children that haven't already been validated are required to
 * have a "key" property assigned to it. Error statuses are cached so a warning
 * will only be shown once.
 *
 * @internal
 * @param {ReactElement} element Element that requires a key.
 * @param {*} parentType element's parent's type.
 */
function validateExplicitKey(element, parentType) {
  if (!element._store || element._store.validated || element.key != null) {
    return;
  }
  element._store.validated = true;

  var memoizer = ownerHasKeyUseWarning.uniqueKey || (ownerHasKeyUseWarning.uniqueKey = {});

  var currentComponentErrorInfo = getCurrentComponentErrorInfo(parentType);
  if (memoizer[currentComponentErrorInfo]) {
    return;
  }
  memoizer[currentComponentErrorInfo] = true;

  // Usually the current owner is the offender, but if it accepts children as a
  // property, it may be the creator of the child that's responsible for
  // assigning it a key.
  var childOwner = '';
  if (element && element._owner && element._owner !== ReactCurrentOwner_1.current) {
    // Give the component that originally created this child.
    childOwner = ' It was passed a child from ' + element._owner.getName() + '.';
  }

  warning_1(false, 'Each child in an array or iterator should have a unique "key" prop.' + '%s%s See https://fb.me/react-warning-keys for more information.%s', currentComponentErrorInfo, childOwner, ReactComponentTreeHook_1.getCurrentStackAddendum(element));
}

/**
 * Ensure that every element either is passed in a static location, in an
 * array with an explicit keys property defined, or in an object literal
 * with valid key property.
 *
 * @internal
 * @param {ReactNode} node Statically passed child of any type.
 * @param {*} parentType node's parent's type.
 */
function validateChildKeys(node, parentType) {
  if (typeof node !== 'object') {
    return;
  }
  if (Array.isArray(node)) {
    for (var i = 0; i < node.length; i++) {
      var child = node[i];
      if (ReactElement_1.isValidElement(child)) {
        validateExplicitKey(child, parentType);
      }
    }
  } else if (ReactElement_1.isValidElement(node)) {
    // This element was passed in a valid location.
    if (node._store) {
      node._store.validated = true;
    }
  } else if (node) {
    var iteratorFn = getIteratorFn_1(node);
    // Entry iterators provide implicit keys.
    if (iteratorFn) {
      if (iteratorFn !== node.entries) {
        var iterator = iteratorFn.call(node);
        var step;
        while (!(step = iterator.next()).done) {
          if (ReactElement_1.isValidElement(step.value)) {
            validateExplicitKey(step.value, parentType);
          }
        }
      }
    }
  }
}

/**
 * Given an element, validate that its props follow the propTypes definition,
 * provided by the type.
 *
 * @param {ReactElement} element
 */
function validatePropTypes(element) {
  var componentClass = element.type;
  if (typeof componentClass !== 'function') {
    return;
  }
  var name = componentClass.displayName || componentClass.name;
  if (componentClass.propTypes) {
    checkReactTypeSpec_1(componentClass.propTypes, element.props, 'prop', name, element, null);
  }
  if (typeof componentClass.getDefaultProps === 'function') {
    warning_1(componentClass.getDefaultProps.isReactClassApproved, 'getDefaultProps is only used on classic React.createClass ' + 'definitions. Use a static property named `defaultProps` instead.');
  }
}

var ReactElementValidator$2 = {

  createElement: function (type, props, children) {
    var validType = typeof type === 'string' || typeof type === 'function';
    // We warn in this case but don't throw. We expect the element creation to
    // succeed and there will likely be errors in render.
    if (!validType) {
      if (typeof type !== 'function' && typeof type !== 'string') {
        var info = '';
        if (type === undefined || typeof type === 'object' && type !== null && Object.keys(type).length === 0) {
          info += ' You likely forgot to export your component from the file ' + 'it\'s defined in.';
        }

        var sourceInfo = getSourceInfoErrorAddendum(props);
        if (sourceInfo) {
          info += sourceInfo;
        } else {
          info += getDeclarationErrorAddendum();
        }

        info += ReactComponentTreeHook_1.getCurrentStackAddendum();

        warning_1(false, 'React.createElement: type is invalid -- expected a string (for ' + 'built-in components) or a class/function (for composite ' + 'components) but got: %s.%s', type == null ? type : typeof type, info);
      }
    }

    var element = ReactElement_1.createElement.apply(this, arguments);

    // The result can be nullish if a mock or a custom function is used.
    // TODO: Drop this when these are no longer allowed as the type argument.
    if (element == null) {
      return element;
    }

    // Skip key warning if the type isn't valid since our key validation logic
    // doesn't expect a non-string/function type and can throw confusing errors.
    // We don't want exception behavior to differ between dev and prod.
    // (Rendering will throw with a helpful message and as soon as the type is
    // fixed, the key warnings will appear.)
    if (validType) {
      for (var i = 2; i < arguments.length; i++) {
        validateChildKeys(arguments[i], type);
      }
    }

    validatePropTypes(element);

    return element;
  },

  createFactory: function (type) {
    var validatedFactory = ReactElementValidator$2.createElement.bind(null, type);
    // Legacy hook TODO: Warn if this is accessed
    validatedFactory.type = type;

    {
      if (canDefineProperty_1) {
        Object.defineProperty(validatedFactory, 'type', {
          enumerable: false,
          get: function () {
            warning_1(false, 'Factory.type is deprecated. Access the class directly ' + 'before passing it to createFactory.');
            Object.defineProperty(this, 'type', {
              value: type
            });
            return type;
          }
        });
      }
    }

    return validatedFactory;
  },

  cloneElement: function (element, props, children) {
    var newElement = ReactElement_1.cloneElement.apply(this, arguments);
    for (var i = 2; i < arguments.length; i++) {
      validateChildKeys(arguments[i], newElement.type);
    }
    validatePropTypes(newElement);
    return newElement;
  }

};

var ReactElementValidator_1 = ReactElementValidator$2;

var createDOMFactory = ReactElement_1.createFactory;
{
  var ReactElementValidator$1 = ReactElementValidator_1;
  createDOMFactory = ReactElementValidator$1.createFactory;
}

/**
 * Creates a mapping from supported HTML tags to `ReactDOMComponent` classes.
 * This is also accessible via `React.DOM`.
 *
 * @public
 */
var ReactDOMFactories = {
  a: createDOMFactory('a'),
  abbr: createDOMFactory('abbr'),
  address: createDOMFactory('address'),
  area: createDOMFactory('area'),
  article: createDOMFactory('article'),
  aside: createDOMFactory('aside'),
  audio: createDOMFactory('audio'),
  b: createDOMFactory('b'),
  base: createDOMFactory('base'),
  bdi: createDOMFactory('bdi'),
  bdo: createDOMFactory('bdo'),
  big: createDOMFactory('big'),
  blockquote: createDOMFactory('blockquote'),
  body: createDOMFactory('body'),
  br: createDOMFactory('br'),
  button: createDOMFactory('button'),
  canvas: createDOMFactory('canvas'),
  caption: createDOMFactory('caption'),
  cite: createDOMFactory('cite'),
  code: createDOMFactory('code'),
  col: createDOMFactory('col'),
  colgroup: createDOMFactory('colgroup'),
  data: createDOMFactory('data'),
  datalist: createDOMFactory('datalist'),
  dd: createDOMFactory('dd'),
  del: createDOMFactory('del'),
  details: createDOMFactory('details'),
  dfn: createDOMFactory('dfn'),
  dialog: createDOMFactory('dialog'),
  div: createDOMFactory('div'),
  dl: createDOMFactory('dl'),
  dt: createDOMFactory('dt'),
  em: createDOMFactory('em'),
  embed: createDOMFactory('embed'),
  fieldset: createDOMFactory('fieldset'),
  figcaption: createDOMFactory('figcaption'),
  figure: createDOMFactory('figure'),
  footer: createDOMFactory('footer'),
  form: createDOMFactory('form'),
  h1: createDOMFactory('h1'),
  h2: createDOMFactory('h2'),
  h3: createDOMFactory('h3'),
  h4: createDOMFactory('h4'),
  h5: createDOMFactory('h5'),
  h6: createDOMFactory('h6'),
  head: createDOMFactory('head'),
  header: createDOMFactory('header'),
  hgroup: createDOMFactory('hgroup'),
  hr: createDOMFactory('hr'),
  html: createDOMFactory('html'),
  i: createDOMFactory('i'),
  iframe: createDOMFactory('iframe'),
  img: createDOMFactory('img'),
  input: createDOMFactory('input'),
  ins: createDOMFactory('ins'),
  kbd: createDOMFactory('kbd'),
  keygen: createDOMFactory('keygen'),
  label: createDOMFactory('label'),
  legend: createDOMFactory('legend'),
  li: createDOMFactory('li'),
  link: createDOMFactory('link'),
  main: createDOMFactory('main'),
  map: createDOMFactory('map'),
  mark: createDOMFactory('mark'),
  menu: createDOMFactory('menu'),
  menuitem: createDOMFactory('menuitem'),
  meta: createDOMFactory('meta'),
  meter: createDOMFactory('meter'),
  nav: createDOMFactory('nav'),
  noscript: createDOMFactory('noscript'),
  object: createDOMFactory('object'),
  ol: createDOMFactory('ol'),
  optgroup: createDOMFactory('optgroup'),
  option: createDOMFactory('option'),
  output: createDOMFactory('output'),
  p: createDOMFactory('p'),
  param: createDOMFactory('param'),
  picture: createDOMFactory('picture'),
  pre: createDOMFactory('pre'),
  progress: createDOMFactory('progress'),
  q: createDOMFactory('q'),
  rp: createDOMFactory('rp'),
  rt: createDOMFactory('rt'),
  ruby: createDOMFactory('ruby'),
  s: createDOMFactory('s'),
  samp: createDOMFactory('samp'),
  script: createDOMFactory('script'),
  section: createDOMFactory('section'),
  select: createDOMFactory('select'),
  small: createDOMFactory('small'),
  source: createDOMFactory('source'),
  span: createDOMFactory('span'),
  strong: createDOMFactory('strong'),
  style: createDOMFactory('style'),
  sub: createDOMFactory('sub'),
  summary: createDOMFactory('summary'),
  sup: createDOMFactory('sup'),
  table: createDOMFactory('table'),
  tbody: createDOMFactory('tbody'),
  td: createDOMFactory('td'),
  textarea: createDOMFactory('textarea'),
  tfoot: createDOMFactory('tfoot'),
  th: createDOMFactory('th'),
  thead: createDOMFactory('thead'),
  time: createDOMFactory('time'),
  title: createDOMFactory('title'),
  tr: createDOMFactory('tr'),
  track: createDOMFactory('track'),
  u: createDOMFactory('u'),
  ul: createDOMFactory('ul'),
  'var': createDOMFactory('var'),
  video: createDOMFactory('video'),
  wbr: createDOMFactory('wbr'),

  // SVG
  circle: createDOMFactory('circle'),
  clipPath: createDOMFactory('clipPath'),
  defs: createDOMFactory('defs'),
  ellipse: createDOMFactory('ellipse'),
  g: createDOMFactory('g'),
  image: createDOMFactory('image'),
  line: createDOMFactory('line'),
  linearGradient: createDOMFactory('linearGradient'),
  mask: createDOMFactory('mask'),
  path: createDOMFactory('path'),
  pattern: createDOMFactory('pattern'),
  polygon: createDOMFactory('polygon'),
  polyline: createDOMFactory('polyline'),
  radialGradient: createDOMFactory('radialGradient'),
  rect: createDOMFactory('rect'),
  stop: createDOMFactory('stop'),
  svg: createDOMFactory('svg'),
  text: createDOMFactory('text'),
  tspan: createDOMFactory('tspan')
};

var ReactDOMFactories_1 = ReactDOMFactories;

/**
 * Copyright 2013-present, Facebook, Inc.
 * All rights reserved.
 *
 * This source code is licensed under the BSD-style license found in the
 * LICENSE file in the root directory of this source tree. An additional grant
 * of patent rights can be found in the PATENTS file in the same directory.
 */

var ReactPropTypesSecret$2 = 'SECRET_DO_NOT_PASS_THIS_OR_YOU_WILL_BE_FIRED';

var ReactPropTypesSecret_1$2 = ReactPropTypesSecret$2;

{
  var invariant$2 = invariant_1;
  var warning$2 = warning_1;
  var ReactPropTypesSecret$3 = ReactPropTypesSecret_1$2;
  var loggedTypeFailures$1 = {};
}

/**
 * Assert that the values match with the type specs.
 * Error messages are memorized and will only be shown once.
 *
 * @param {object} typeSpecs Map of name to a ReactPropType
 * @param {object} values Runtime values that need to be type-checked
 * @param {string} location e.g. "prop", "context", "child context"
 * @param {string} componentName Name of the component for error messages.
 * @param {?Function} getStack Returns the component stack.
 * @private
 */
function checkPropTypes(typeSpecs, values, location, componentName, getStack) {
  {
    for (var typeSpecName in typeSpecs) {
      if (typeSpecs.hasOwnProperty(typeSpecName)) {
        var error;
        // Prop type validation may throw. In case they do, we don't want to
        // fail the render phase where it didn't fail before. So we log it.
        // After these have been cleaned up, we'll let them throw.
        try {
          // This is intentionally an invariant that gets caught. It's the same
          // behavior as without this statement except with a better message.
          invariant$2(typeof typeSpecs[typeSpecName] === 'function', '%s: %s type `%s` is invalid; it must be a function, usually from ' + 'React.PropTypes.', componentName || 'React class', location, typeSpecName);
          error = typeSpecs[typeSpecName](values, typeSpecName, componentName, location, null, ReactPropTypesSecret$3);
        } catch (ex) {
          error = ex;
        }
        warning$2(!error || error instanceof Error, '%s: type specification of %s `%s` is invalid; the type checker ' + 'function must return `null` or an `Error` but returned a %s. ' + 'You may have forgotten to pass an argument to the type checker ' + 'creator (arrayOf, instanceOf, objectOf, oneOf, oneOfType, and ' + 'shape all require an argument).', componentName || 'React class', location, typeSpecName, typeof error);
        if (error instanceof Error && !(error.message in loggedTypeFailures$1)) {
          // Only monitor this failure once because there tends to be a lot of the
          // same error.
          loggedTypeFailures$1[error.message] = true;

          var stack = getStack ? getStack() : '';

          warning$2(false, 'Failed %s type: %s%s', location, error.message, stack != null ? stack : '');
        }
      }
    }
  }
}

var checkPropTypes_1 = checkPropTypes;

var factoryWithTypeCheckers = function(isValidElement, throwOnDirectAccess) {
  /* global Symbol */
  var ITERATOR_SYMBOL = typeof Symbol === 'function' && Symbol.iterator;
  var FAUX_ITERATOR_SYMBOL = '@@iterator'; // Before Symbol spec.

  /**
   * Returns the iterator method function contained on the iterable object.
   *
   * Be sure to invoke the function with the iterable as context:
   *
   *     var iteratorFn = getIteratorFn(myIterable);
   *     if (iteratorFn) {
   *       var iterator = iteratorFn.call(myIterable);
   *       ...
   *     }
   *
   * @param {?object} maybeIterable
   * @return {?function}
   */
  function getIteratorFn(maybeIterable) {
    var iteratorFn = maybeIterable && (ITERATOR_SYMBOL && maybeIterable[ITERATOR_SYMBOL] || maybeIterable[FAUX_ITERATOR_SYMBOL]);
    if (typeof iteratorFn === 'function') {
      return iteratorFn;
    }
  }

  /**
   * Collection of methods that allow declaration and validation of props that are
   * supplied to React components. Example usage:
   *
   *   var Props = require('ReactPropTypes');
   *   var MyArticle = React.createClass({
   *     propTypes: {
   *       // An optional string prop named "description".
   *       description: Props.string,
   *
   *       // A required enum prop named "category".
   *       category: Props.oneOf(['News','Photos']).isRequired,
   *
   *       // A prop named "dialog" that requires an instance of Dialog.
   *       dialog: Props.instanceOf(Dialog).isRequired
   *     },
   *     render: function() { ... }
   *   });
   *
   * A more formal specification of how these methods are used:
   *
   *   type := array|bool|func|object|number|string|oneOf([...])|instanceOf(...)
   *   decl := ReactPropTypes.{type}(.isRequired)?
   *
   * Each and every declaration produces a function with the same signature. This
   * allows the creation of custom validation functions. For example:
   *
   *  var MyLink = React.createClass({
   *    propTypes: {
   *      // An optional string or URI prop named "href".
   *      href: function(props, propName, componentName) {
   *        var propValue = props[propName];
   *        if (propValue != null && typeof propValue !== 'string' &&
   *            !(propValue instanceof URI)) {
   *          return new Error(
   *            'Expected a string or an URI for ' + propName + ' in ' +
   *            componentName
   *          );
   *        }
   *      }
   *    },
   *    render: function() {...}
   *  });
   *
   * @internal
   */

  var ANONYMOUS = '<<anonymous>>';

  // Important!
  // Keep this list in sync with production version in `./factoryWithThrowingShims.js`.
  var ReactPropTypes = {
    array: createPrimitiveTypeChecker('array'),
    bool: createPrimitiveTypeChecker('boolean'),
    func: createPrimitiveTypeChecker('function'),
    number: createPrimitiveTypeChecker('number'),
    object: createPrimitiveTypeChecker('object'),
    string: createPrimitiveTypeChecker('string'),
    symbol: createPrimitiveTypeChecker('symbol'),

    any: createAnyTypeChecker(),
    arrayOf: createArrayOfTypeChecker,
    element: createElementTypeChecker(),
    instanceOf: createInstanceTypeChecker,
    node: createNodeChecker(),
    objectOf: createObjectOfTypeChecker,
    oneOf: createEnumTypeChecker,
    oneOfType: createUnionTypeChecker,
    shape: createShapeTypeChecker
  };

  /**
   * inlined Object.is polyfill to avoid requiring consumers ship their own
   * https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Object/is
   */
  /*eslint-disable no-self-compare*/
  function is(x, y) {
    // SameValue algorithm
    if (x === y) {
      // Steps 1-5, 7-10
      // Steps 6.b-6.e: +0 != -0
      return x !== 0 || 1 / x === 1 / y;
    } else {
      // Step 6.a: NaN == NaN
      return x !== x && y !== y;
    }
  }
  /*eslint-enable no-self-compare*/

  /**
   * We use an Error-like object for backward compatibility as people may call
   * PropTypes directly and inspect their output. However, we don't use real
   * Errors anymore. We don't inspect their stack anyway, and creating them
   * is prohibitively expensive if they are created too often, such as what
   * happens in oneOfType() for any type before the one that matched.
   */
  function PropTypeError(message) {
    this.message = message;
    this.stack = '';
  }
  // Make `instanceof Error` still work for returned errors.
  PropTypeError.prototype = Error.prototype;

  function createChainableTypeChecker(validate) {
    {
      var manualPropTypeCallCache = {};
      var manualPropTypeWarningCount = 0;
    }
    function checkType(isRequired, props, propName, componentName, location, propFullName, secret) {
      componentName = componentName || ANONYMOUS;
      propFullName = propFullName || propName;

      if (secret !== ReactPropTypesSecret_1$2) {
        if (throwOnDirectAccess) {
          // New behavior only for users of `prop-types` package
          invariant_1(
            false,
            'Calling PropTypes validators directly is not supported by the `prop-types` package. ' +
            'Use `PropTypes.checkPropTypes()` to call them. ' +
            'Read more at http://fb.me/use-check-prop-types'
          );
        } else if ("development" !== 'production' && typeof console !== 'undefined') {
          // Old behavior for people using React.PropTypes
          var cacheKey = componentName + ':' + propName;
          if (
            !manualPropTypeCallCache[cacheKey] &&
            // Avoid spamming the console because they are often not actionable except for lib authors
            manualPropTypeWarningCount < 3
          ) {
            warning_1(
              false,
              'You are manually calling a React.PropTypes validation ' +
              'function for the `%s` prop on `%s`. This is deprecated ' +
              'and will throw in the standalone `prop-types` package. ' +
              'You may be seeing this warning due to a third-party PropTypes ' +
              'library. See https://fb.me/react-warning-dont-call-proptypes ' + 'for details.',
              propFullName,
              componentName
            );
            manualPropTypeCallCache[cacheKey] = true;
            manualPropTypeWarningCount++;
          }
        }
      }
      if (props[propName] == null) {
        if (isRequired) {
          if (props[propName] === null) {
            return new PropTypeError('The ' + location + ' `' + propFullName + '` is marked as required ' + ('in `' + componentName + '`, but its value is `null`.'));
          }
          return new PropTypeError('The ' + location + ' `' + propFullName + '` is marked as required in ' + ('`' + componentName + '`, but its value is `undefined`.'));
        }
        return null;
      } else {
        return validate(props, propName, componentName, location, propFullName);
      }
    }

    var chainedCheckType = checkType.bind(null, false);
    chainedCheckType.isRequired = checkType.bind(null, true);

    return chainedCheckType;
  }

  function createPrimitiveTypeChecker(expectedType) {
    function validate(props, propName, componentName, location, propFullName, secret) {
      var propValue = props[propName];
      var propType = getPropType(propValue);
      if (propType !== expectedType) {
        // `propValue` being instance of, say, date/regexp, pass the 'object'
        // check, but we can offer a more precise error message here rather than
        // 'of type `object`'.
        var preciseType = getPreciseType(propValue);

        return new PropTypeError('Invalid ' + location + ' `' + propFullName + '` of type ' + ('`' + preciseType + '` supplied to `' + componentName + '`, expected ') + ('`' + expectedType + '`.'));
      }
      return null;
    }
    return createChainableTypeChecker(validate);
  }

  function createAnyTypeChecker() {
    return createChainableTypeChecker(emptyFunction_1.thatReturnsNull);
  }

  function createArrayOfTypeChecker(typeChecker) {
    function validate(props, propName, componentName, location, propFullName) {
      if (typeof typeChecker !== 'function') {
        return new PropTypeError('Property `' + propFullName + '` of component `' + componentName + '` has invalid PropType notation inside arrayOf.');
      }
      var propValue = props[propName];
      if (!Array.isArray(propValue)) {
        var propType = getPropType(propValue);
        return new PropTypeError('Invalid ' + location + ' `' + propFullName + '` of type ' + ('`' + propType + '` supplied to `' + componentName + '`, expected an array.'));
      }
      for (var i = 0; i < propValue.length; i++) {
        var error = typeChecker(propValue, i, componentName, location, propFullName + '[' + i + ']', ReactPropTypesSecret_1$2);
        if (error instanceof Error) {
          return error;
        }
      }
      return null;
    }
    return createChainableTypeChecker(validate);
  }

  function createElementTypeChecker() {
    function validate(props, propName, componentName, location, propFullName) {
      var propValue = props[propName];
      if (!isValidElement(propValue)) {
        var propType = getPropType(propValue);
        return new PropTypeError('Invalid ' + location + ' `' + propFullName + '` of type ' + ('`' + propType + '` supplied to `' + componentName + '`, expected a single ReactElement.'));
      }
      return null;
    }
    return createChainableTypeChecker(validate);
  }

  function createInstanceTypeChecker(expectedClass) {
    function validate(props, propName, componentName, location, propFullName) {
      if (!(props[propName] instanceof expectedClass)) {
        var expectedClassName = expectedClass.name || ANONYMOUS;
        var actualClassName = getClassName(props[propName]);
        return new PropTypeError('Invalid ' + location + ' `' + propFullName + '` of type ' + ('`' + actualClassName + '` supplied to `' + componentName + '`, expected ') + ('instance of `' + expectedClassName + '`.'));
      }
      return null;
    }
    return createChainableTypeChecker(validate);
  }

  function createEnumTypeChecker(expectedValues) {
    if (!Array.isArray(expectedValues)) {
      warning_1(false, 'Invalid argument supplied to oneOf, expected an instance of array.');
      return emptyFunction_1.thatReturnsNull;
    }

    function validate(props, propName, componentName, location, propFullName) {
      var propValue = props[propName];
      for (var i = 0; i < expectedValues.length; i++) {
        if (is(propValue, expectedValues[i])) {
          return null;
        }
      }

      var valuesString = JSON.stringify(expectedValues);
      return new PropTypeError('Invalid ' + location + ' `' + propFullName + '` of value `' + propValue + '` ' + ('supplied to `' + componentName + '`, expected one of ' + valuesString + '.'));
    }
    return createChainableTypeChecker(validate);
  }

  function createObjectOfTypeChecker(typeChecker) {
    function validate(props, propName, componentName, location, propFullName) {
      if (typeof typeChecker !== 'function') {
        return new PropTypeError('Property `' + propFullName + '` of component `' + componentName + '` has invalid PropType notation inside objectOf.');
      }
      var propValue = props[propName];
      var propType = getPropType(propValue);
      if (propType !== 'object') {
        return new PropTypeError('Invalid ' + location + ' `' + propFullName + '` of type ' + ('`' + propType + '` supplied to `' + componentName + '`, expected an object.'));
      }
      for (var key in propValue) {
        if (propValue.hasOwnProperty(key)) {
          var error = typeChecker(propValue, key, componentName, location, propFullName + '.' + key, ReactPropTypesSecret_1$2);
          if (error instanceof Error) {
            return error;
          }
        }
      }
      return null;
    }
    return createChainableTypeChecker(validate);
  }

  function createUnionTypeChecker(arrayOfTypeCheckers) {
    if (!Array.isArray(arrayOfTypeCheckers)) {
      warning_1(false, 'Invalid argument supplied to oneOfType, expected an instance of array.');
      return emptyFunction_1.thatReturnsNull;
    }

    for (var i = 0; i < arrayOfTypeCheckers.length; i++) {
      var checker = arrayOfTypeCheckers[i];
      if (typeof checker !== 'function') {
        warning_1(
          false,
          'Invalid argument supplid to oneOfType. Expected an array of check functions, but ' +
          'received %s at index %s.',
          getPostfixForTypeWarning(checker),
          i
        );
        return emptyFunction_1.thatReturnsNull;
      }
    }

    function validate(props, propName, componentName, location, propFullName) {
      for (var i = 0; i < arrayOfTypeCheckers.length; i++) {
        var checker = arrayOfTypeCheckers[i];
        if (checker(props, propName, componentName, location, propFullName, ReactPropTypesSecret_1$2) == null) {
          return null;
        }
      }

      return new PropTypeError('Invalid ' + location + ' `' + propFullName + '` supplied to ' + ('`' + componentName + '`.'));
    }
    return createChainableTypeChecker(validate);
  }

  function createNodeChecker() {
    function validate(props, propName, componentName, location, propFullName) {
      if (!isNode(props[propName])) {
        return new PropTypeError('Invalid ' + location + ' `' + propFullName + '` supplied to ' + ('`' + componentName + '`, expected a ReactNode.'));
      }
      return null;
    }
    return createChainableTypeChecker(validate);
  }

  function createShapeTypeChecker(shapeTypes) {
    function validate(props, propName, componentName, location, propFullName) {
      var propValue = props[propName];
      var propType = getPropType(propValue);
      if (propType !== 'object') {
        return new PropTypeError('Invalid ' + location + ' `' + propFullName + '` of type `' + propType + '` ' + ('supplied to `' + componentName + '`, expected `object`.'));
      }
      for (var key in shapeTypes) {
        var checker = shapeTypes[key];
        if (!checker) {
          continue;
        }
        var error = checker(propValue, key, componentName, location, propFullName + '.' + key, ReactPropTypesSecret_1$2);
        if (error) {
          return error;
        }
      }
      return null;
    }
    return createChainableTypeChecker(validate);
  }

  function isNode(propValue) {
    switch (typeof propValue) {
      case 'number':
      case 'string':
      case 'undefined':
        return true;
      case 'boolean':
        return !propValue;
      case 'object':
        if (Array.isArray(propValue)) {
          return propValue.every(isNode);
        }
        if (propValue === null || isValidElement(propValue)) {
          return true;
        }

        var iteratorFn = getIteratorFn(propValue);
        if (iteratorFn) {
          var iterator = iteratorFn.call(propValue);
          var step;
          if (iteratorFn !== propValue.entries) {
            while (!(step = iterator.next()).done) {
              if (!isNode(step.value)) {
                return false;
              }
            }
          } else {
            // Iterator will provide entry [k,v] tuples rather than values.
            while (!(step = iterator.next()).done) {
              var entry = step.value;
              if (entry) {
                if (!isNode(entry[1])) {
                  return false;
                }
              }
            }
          }
        } else {
          return false;
        }

        return true;
      default:
        return false;
    }
  }

  function isSymbol(propType, propValue) {
    // Native Symbol.
    if (propType === 'symbol') {
      return true;
    }

    // 19.4.3.5 Symbol.prototype[@@toStringTag] === 'Symbol'
    if (propValue['@@toStringTag'] === 'Symbol') {
      return true;
    }

    // Fallback for non-spec compliant Symbols which are polyfilled.
    if (typeof Symbol === 'function' && propValue instanceof Symbol) {
      return true;
    }

    return false;
  }

  // Equivalent of `typeof` but with special handling for array and regexp.
  function getPropType(propValue) {
    var propType = typeof propValue;
    if (Array.isArray(propValue)) {
      return 'array';
    }
    if (propValue instanceof RegExp) {
      // Old webkits (at least until Android 4.0) return 'function' rather than
      // 'object' for typeof a RegExp. We'll normalize this here so that /bla/
      // passes PropTypes.object.
      return 'object';
    }
    if (isSymbol(propType, propValue)) {
      return 'symbol';
    }
    return propType;
  }

  // This handles more types than `getPropType`. Only used for error messages.
  // See `createPrimitiveTypeChecker`.
  function getPreciseType(propValue) {
    if (typeof propValue === 'undefined' || propValue === null) {
      return '' + propValue;
    }
    var propType = getPropType(propValue);
    if (propType === 'object') {
      if (propValue instanceof Date) {
        return 'date';
      } else if (propValue instanceof RegExp) {
        return 'regexp';
      }
    }
    return propType;
  }

  // Returns a string that is postfixed to a warning about an invalid type.
  // For example, "undefined" or "of type array"
  function getPostfixForTypeWarning(value) {
    var type = getPreciseType(value);
    switch (type) {
      case 'array':
      case 'object':
        return 'an ' + type;
      case 'boolean':
      case 'date':
      case 'regexp':
        return 'a ' + type;
      default:
        return type;
    }
  }

  // Returns class name of the object, if any.
  function getClassName(propValue) {
    if (!propValue.constructor || !propValue.constructor.name) {
      return ANONYMOUS;
    }
    return propValue.constructor.name;
  }

  ReactPropTypes.checkPropTypes = checkPropTypes_1;
  ReactPropTypes.PropTypes = ReactPropTypes;

  return ReactPropTypes;
};

var factory_1 = function(isValidElement) {
  // It is still allowed in 15.5.
  var throwOnDirectAccess = false;
  return factoryWithTypeCheckers(isValidElement, throwOnDirectAccess);
};

var isValidElement = ReactElement_1.isValidElement;



var ReactPropTypes = factory_1(isValidElement);

/**
 * Copyright 2013-present, Facebook, Inc.
 * All rights reserved.
 *
 * This source code is licensed under the BSD-style license found in the
 * LICENSE file in the root directory of this source tree. An additional grant
 * of patent rights can be found in the PATENTS file in the same directory.
 *
 */

var ReactVersion = '15.5.4';

function onlyChild(children) {
  !ReactElement_1.isValidElement(children) ? invariant_1(false, 'React.Children.only expected to receive a single React element child.') : void 0;
  return children;
}

var onlyChild_1 = onlyChild;

var createElement = ReactElement_1.createElement;
var createFactory = ReactElement_1.createFactory;
var cloneElement = ReactElement_1.cloneElement;

{
  var canDefineProperty = canDefineProperty_1;
  var ReactElementValidator = ReactElementValidator_1;
  var didWarnPropTypesDeprecated = false;
  createElement = ReactElementValidator.createElement;
  createFactory = ReactElementValidator.createFactory;
  cloneElement = ReactElementValidator.cloneElement;
}

var __spread = index;

{
  var warned = false;
  __spread = function () {
    warning_1(warned, 'React.__spread is deprecated and should not be used. Use ' + 'Object.assign directly or another helper function with similar ' + 'semantics. You may be seeing this warning due to your compiler. ' + 'See https://fb.me/react-spread-deprecation for more details.');
    warned = true;
    return index.apply(null, arguments);
  };
}

var React = {

  // Modern

  Children: {
    map: ReactChildren_1.map,
    forEach: ReactChildren_1.forEach,
    count: ReactChildren_1.count,
    toArray: ReactChildren_1.toArray,
    only: onlyChild_1
  },

  Component: ReactComponent_1,
  PureComponent: ReactPureComponent_1,

  createElement: createElement,
  cloneElement: cloneElement,
  isValidElement: ReactElement_1.isValidElement,

  // Classic

  PropTypes: ReactPropTypes,
  createClass: ReactClass_1.createClass,
  createFactory: createFactory,
  createMixin: function (mixin) {
    // Currently a noop. Will be used to validate and trace mixins.
    return mixin;
  },

  // This looks DOM specific but these are actually isomorphic helpers
  // since they are just generating DOM strings.
  DOM: ReactDOMFactories_1,

  version: ReactVersion,

  // Deprecated hook for JSX spread, don't use this for anything.
  __spread: __spread
};

// TODO: Fix tests so that this deprecation warning doesn't cause failures.
{
  if (canDefineProperty) {
    Object.defineProperty(React, 'PropTypes', {
      get: function () {
        warning_1(didWarnPropTypesDeprecated, 'Accessing PropTypes via the main React package is deprecated. Use ' + 'the prop-types package from npm instead.');
        didWarnPropTypesDeprecated = true;
        return ReactPropTypes;
      }
    });
  }
}

var React_1 = React;

var react$1 = React_1;

var react_1 = react$1.createElement;
var react_2 = react$1.Component;

const types = new Map();
function setType(fullName, cons) {
    types.set(fullName, cons);
}

var FSymbol = {
    reflection: Symbol("reflection"),
};

class NonDeclaredType {
    constructor(kind, definition, generics) {
        this.kind = kind;
        this.definition = definition;
        this.generics = generics;
    }
    Equals(other) {
        if (this.kind === other.kind && this.definition === other.definition) {
            return typeof this.generics === "object"
                ? equalsRecords(this.generics, other.generics)
                : this.generics === other.generics;
        }
        return false;
    }
}
const Any = new NonDeclaredType("Any");
const Unit = new NonDeclaredType("Unit");
function Option(t) {
    return new NonDeclaredType("Option", null, [t]);
}
function Tuple(types) {
    return new NonDeclaredType("Tuple", null, types);
}
function FableFunction(types) {
    return new NonDeclaredType("Function", null, types);
}
function GenericParam(definition) {
    return new NonDeclaredType("GenericParam", definition);
}
function Interface(definition) {
    return new NonDeclaredType("Interface", definition);
}
function makeGeneric(typeDef, genArgs) {
    return new NonDeclaredType("GenericType", typeDef, genArgs);
}

/**
 * Returns the parent if this is a declared generic type or the argument otherwise.
 * Attention: Unlike .NET this doesn't throw an exception if type is not generic.
 */

function extendInfo(cons, info) {
    const parent = Object.getPrototypeOf(cons.prototype);
    if (typeof parent[FSymbol.reflection] === "function") {
        const newInfo = {};
        const parentInfo = parent[FSymbol.reflection]();
        Object.getOwnPropertyNames(info).forEach((k) => {
            const i = info[k];
            if (typeof i === "object") {
                newInfo[k] = Array.isArray(i)
                    ? (parentInfo[k] || []).concat(i)
                    : Object.assign(parentInfo[k] || {}, i);
            }
            else {
                newInfo[k] = i;
            }
        });
        return newInfo;
    }
    return info;
}
function hasInterface(obj, interfaceName) {
    if (interfaceName === "System.Collections.Generic.IEnumerable") {
        return typeof obj[Symbol.iterator] === "function";
    }
    else if (typeof obj[FSymbol.reflection] === "function") {
        const interfaces = obj[FSymbol.reflection]().interfaces;
        return Array.isArray(interfaces) && interfaces.indexOf(interfaceName) > -1;
    }
    return false;
}
/**
 * Returns:
 * - Records: array with names of fields
 * - Classes: array with names of getters
 * - Nulls and unions: empty array
 * - JS Objects: The result of calling Object.getOwnPropertyNames
 */
function getPropertyNames(obj) {
    if (obj == null) {
        return [];
    }
    const propertyMap = typeof obj[FSymbol.reflection] === "function" ? obj[FSymbol.reflection]().properties || [] : obj;
    return Object.getOwnPropertyNames(propertyMap);
}

function toString(obj, quoteStrings = false) {
    function isObject(x) {
        return x !== null && typeof x === "object" && !(x instanceof Number)
            && !(x instanceof String) && !(x instanceof Boolean);
    }
    if (obj == null || typeof obj === "number") {
        return String(obj);
    }
    if (typeof obj === "string") {
        return quoteStrings ? JSON.stringify(obj) : obj;
    }
    if (typeof obj.ToString === "function") {
        return obj.ToString();
    }
    if (hasInterface(obj, "FSharpUnion")) {
        const info = obj[FSymbol.reflection]();
        const uci = info.cases[obj.tag];
        switch (uci.length) {
            case 1:
                return uci[0];
            case 2:
                // For simplicity let's always use parens, in .NET they're ommitted in some cases
                return uci[0] + " (" + toString(obj.data, true) + ")";
            default:
                return uci[0] + " (" + obj.data.map((x) => toString(x, true)).join(",") + ")";
        }
    }
    try {
        return JSON.stringify(obj, (k, v) => {
            return v && v[Symbol.iterator] && !Array.isArray(v) && isObject(v) ? Array.from(v)
                : v && typeof v.ToString === "function" ? toString(v) : v;
        });
    }
    catch (err) {
        // Fallback for objects with circular references
        return "{" + Object.getOwnPropertyNames(obj).map((k) => k + ": " + String(obj[k])).join(", ") + "}";
    }
}
function hash(x) {
    if (x != null && typeof x.GetHashCode === "function") {
        return x.GetHashCode();
    }
    else {
        const s = JSON.stringify(x);
        let h = 5381;
        let i = 0;
        const len = s.length;
        while (i < len) {
            h = (h * 33) ^ s.charCodeAt(i++);
        }
        return h;
    }
}
function equals(x, y) {
    // Optimization if they are referencially equal
    if (x === y) {
        return true;
    }
    else if (x == null) {
        return y == null;
    }
    else if (y == null) {
        return false;
    }
    else if (Object.getPrototypeOf(x) !== Object.getPrototypeOf(y)) {
        return false;
        // Equals override or IEquatable implementation
    }
    else if (typeof x.Equals === "function") {
        return x.Equals(y);
    }
    else if (Array.isArray(x)) {
        if (x.length !== y.length) {
            return false;
        }
        for (let i = 0; i < x.length; i++) {
            if (!equals(x[i], y[i])) {
                return false;
            }
        }
        return true;
    }
    else if (ArrayBuffer.isView(x)) {
        if (x.byteLength !== y.byteLength) {
            return false;
        }
        const dv1 = new DataView(x.buffer);
        const dv2 = new DataView(y.buffer);
        for (let i = 0; i < x.byteLength; i++) {
            if (dv1.getUint8(i) !== dv2.getUint8(i)) {
                return false;
            }
        }
        return true;
    }
    else if (x instanceof Date) {
        return x.getTime() === y.getTime();
    }
    else {
        return false;
    }
}
function comparePrimitives(x, y) {
    return x === y ? 0 : (x < y ? -1 : 1);
}
function compare(x, y) {
    // Optimization if they are referencially equal
    if (x === y) {
        return 0;
    }
    else if (x == null) {
        return y == null ? 0 : -1;
    }
    else if (y == null) {
        return 1; // everything is bigger than null
    }
    else if (Object.getPrototypeOf(x) !== Object.getPrototypeOf(y)) {
        return -1;
        // Some types (see Long.ts) may just implement the function and not the interface
        // else if (hasInterface(x, "System.IComparable"))
    }
    else if (typeof x.CompareTo === "function") {
        return x.CompareTo(y);
    }
    else if (Array.isArray(x)) {
        if (x.length !== y.length) {
            return x.length < y.length ? -1 : 1;
        }
        for (let i = 0, j = 0; i < x.length; i++) {
            j = compare(x[i], y[i]);
            if (j !== 0) {
                return j;
            }
        }
        return 0;
    }
    else if (ArrayBuffer.isView(x)) {
        if (x.byteLength !== y.byteLength) {
            return x.byteLength < y.byteLength ? -1 : 1;
        }
        const dv1 = new DataView(x.buffer);
        const dv2 = new DataView(y.buffer);
        for (let i = 0, b1 = 0, b2 = 0; i < x.byteLength; i++) {
            b1 = dv1.getUint8(i), b2 = dv2.getUint8(i);
            if (b1 < b2) {
                return -1;
            }
            if (b1 > b2) {
                return 1;
            }
        }
        return 0;
    }
    else if (x instanceof Date) {
        const xtime = x.getTime();
        const ytime = y.getTime();
        return xtime === ytime ? 0 : (xtime < ytime ? -1 : 1);
    }
    else if (typeof x === "object") {
        const xhash = hash(x);
        const yhash = hash(y);
        if (xhash === yhash) {
            return equals(x, y) ? 0 : -1;
        }
        else {
            return xhash < yhash ? -1 : 1;
        }
    }
    else {
        return x < y ? -1 : 1;
    }
}
function equalsRecords(x, y) {
    // Optimization if they are referencially equal
    if (x === y) {
        return true;
    }
    else {
        const keys = getPropertyNames(x);
        for (const key of keys) {
            if (!equals(x[key], y[key])) {
                return false;
            }
        }
        return true;
    }
}
function compareRecords(x, y) {
    // Optimization if they are referencially equal
    if (x === y) {
        return 0;
    }
    else {
        const keys = getPropertyNames(x);
        for (const key of keys) {
            const res = compare(x[key], y[key]);
            if (res !== 0) {
                return res;
            }
        }
        return 0;
    }
}
function equalsUnions(x, y) {
    return x === y || (x.tag === y.tag && equals(x.data, y.data));
}
function compareUnions(x, y) {
    if (x === y) {
        return 0;
    }
    else {
        const res = x.tag < y.tag ? -1 : (x.tag > y.tag ? 1 : 0);
        return res !== 0 ? res : compare(x.data, y.data);
    }
}
function createDisposable(f) {
    return {
        Dispose: f,
        [FSymbol.reflection]() { return { interfaces: ["System.IDisposable"] }; },
    };
}
const CaseRules = {
    None: 0,
    LowerFirst: 1,
};
function createObj(fields, caseRule = CaseRules.None) {
    const iter = fields[Symbol.iterator]();
    let cur = iter.next();
    const o = {};
    let casesCache = null;
    while (!cur.done) {
        const value = cur.value;
        if (Array.isArray(value)) {
            o[value[0]] = value[1];
        }
        else {
            casesCache = casesCache || new Map();
            const proto = Object.getPrototypeOf(value);
            let cases = casesCache.get(proto);
            if (cases == null) {
                if (typeof proto[FSymbol.reflection] === "function") {
                    cases = proto[FSymbol.reflection]().cases;
                    casesCache.set(proto, cases);
                }
            }
            const caseInfo = (cases != null) ? cases[value.tag] : null;
            if (cases != null && Array.isArray(caseInfo)) {
                let key = caseInfo[0];
                if (caseRule === CaseRules.LowerFirst) {
                    key = key[0].toLowerCase() + key.substr(1);
                }
                o[key] = caseInfo.length === 1 ? true : value.data;
            }
            else {
                throw new Error("Cannot infer key and value of " + value);
            }
        }
        cur = iter.next();
    }
    return o;
}

function ofArray(args, base) {
    let acc = base || new List$1();
    for (let i = args.length - 1; i >= 0; i--) {
        acc = new List$1(args[i], acc);
    }
    return acc;
}
class List$1 {
    constructor(head, tail) {
        this.head = head;
        this.tail = tail;
    }
    ToString() {
        return "[" + Array.from(this).map((x) => toString(x)).join("; ") + "]";
    }
    Equals(x) {
        // Optimization if they are referencially equal
        if (this === x) {
            return true;
        }
        else {
            const iter1 = this[Symbol.iterator]();
            const iter2 = x[Symbol.iterator]();
            while (true) {
                const cur1 = iter1.next();
                const cur2 = iter2.next();
                if (cur1.done) {
                    return cur2.done ? true : false;
                }
                else if (cur2.done) {
                    return false;
                }
                else if (!equals(cur1.value, cur2.value)) {
                    return false;
                }
            }
        }
    }
    CompareTo(x) {
        // Optimization if they are referencially equal
        if (this === x) {
            return 0;
        }
        else {
            let acc = 0;
            const iter1 = this[Symbol.iterator]();
            const iter2 = x[Symbol.iterator]();
            while (true) {
                const cur1 = iter1.next();
                const cur2 = iter2.next();
                if (cur1.done) {
                    return cur2.done ? acc : -1;
                }
                else if (cur2.done) {
                    return 1;
                }
                else {
                    acc = compare(cur1.value, cur2.value);
                    if (acc !== 0) {
                        return acc;
                    }
                }
            }
        }
    }
    get length() {
        let cur = this;
        let acc = 0;
        while (cur.tail != null) {
            cur = cur.tail;
            acc++;
        }
        return acc;
    }
    [Symbol.iterator]() {
        let cur = this;
        return {
            next: () => {
                const tmp = cur;
                cur = cur.tail;
                return { done: tmp.tail == null, value: tmp.head };
            },
        };
    }
    //   append(ys: List<T>): List<T> {
    //     return append(this, ys);
    //   }
    //   choose<U>(f: (x: T) => U, xs: List<T>): List<U> {
    //     return choose(f, this);
    //   }
    //   collect<U>(f: (x: T) => List<U>): List<U> {
    //     return collect(f, this);
    //   }
    //   filter(f: (x: T) => boolean): List<T> {
    //     return filter(f, this);
    //   }
    //   where(f: (x: T) => boolean): List<T> {
    //     return filter(f, this);
    //   }
    //   map<U>(f: (x: T) => U): List<U> {
    //     return map(f, this);
    //   }
    //   mapIndexed<U>(f: (i: number, x: T) => U): List<U> {
    //     return mapIndexed(f, this);
    //   }
    //   partition(f: (x: T) => boolean): [List<T>, List<T>] {
    //     return partition(f, this) as [List<T>, List<T>];
    //   }
    //   reverse(): List<T> {
    //     return reverse(this);
    //   }
    //   slice(lower: number, upper: number): List<T> {
    //     return slice(lower, upper, this);
    //   }
    [FSymbol.reflection]() {
        return {
            type: "Microsoft.FSharp.Collections.FSharpList",
            interfaces: ["System.IEquatable", "System.IComparable"],
        };
    }
}

class Comparer {
    constructor(f) {
        this.Compare = f || compare;
    }
    [FSymbol.reflection]() {
        return { interfaces: ["System.IComparer"] };
    }
}

function toList(xs) {
    return foldBack$1((x, acc) => new List$1(x, acc), xs, new List$1());
}


function append$1(xs, ys) {
    return delay(() => {
        let firstDone = false;
        const i = xs[Symbol.iterator]();
        let iters = [i, null];
        return unfold(() => {
            let cur;
            if (!firstDone) {
                cur = iters[0].next();
                if (!cur.done) {
                    return [cur.value, iters];
                }
                else {
                    firstDone = true;
                    iters = [null, ys[Symbol.iterator]()];
                }
            }
            cur = iters[1].next();
            return !cur.done ? [cur.value, iters] : null;
        }, iters);
    });
}




function choose$1(f, xs) {
    const trySkipToNext = (iter) => {
        const cur = iter.next();
        if (!cur.done) {
            const y = f(cur.value);
            return y != null ? [y, iter] : trySkipToNext(iter);
        }
        return void 0;
    };
    return delay(() => unfold((iter) => trySkipToNext(iter), xs[Symbol.iterator]()));
}
function compareWith(f, xs, ys) {
    const nonZero = tryFind$1((i) => i !== 0, map2((x, y) => f(x, y), xs, ys));
    return nonZero != null ? nonZero : count(xs) - count(ys);
}
function delay(f) {
    return {
        [Symbol.iterator]: () => f()[Symbol.iterator](),
    };
}
function empty() {
    return unfold(() => void 0);
}









function fold$1(f, acc, xs) {
    if (Array.isArray(xs) || ArrayBuffer.isView(xs)) {
        return xs.reduce(f, acc);
    }
    else {
        let cur;
        for (let i = 0, iter = xs[Symbol.iterator]();; i++) {
            cur = iter.next();
            if (cur.done) {
                break;
            }
            acc = f(acc, cur.value, i);
        }
        return acc;
    }
}
function foldBack$1(f, xs, acc) {
    const arr = Array.isArray(xs) || ArrayBuffer.isView(xs) ? xs : Array.from(xs);
    for (let i = arr.length - 1; i >= 0; i--) {
        acc = f(arr[i], acc, i);
    }
    return acc;
}










function iterate$1(f, xs) {
    fold$1((_, x) => f(x), null, xs);
}






// A export function 'length' method causes problems in JavaScript -- https://github.com/Microsoft/TypeScript/issues/442
function count(xs) {
    return Array.isArray(xs) || ArrayBuffer.isView(xs)
        ? xs.length
        : fold$1((acc, x) => acc + 1, 0, xs);
}
function map$2(f, xs) {
    return delay(() => unfold((iter) => {
        const cur = iter.next();
        return !cur.done ? [f(cur.value), iter] : null;
    }, xs[Symbol.iterator]()));
}

function map2(f, xs, ys) {
    return delay(() => {
        const iter1 = xs[Symbol.iterator]();
        const iter2 = ys[Symbol.iterator]();
        return unfold(() => {
            const cur1 = iter1.next();
            const cur2 = iter2.next();
            return !cur1.done && !cur2.done ? [f(cur1.value, cur2.value), null] : null;
        });
    });
}





















function singleton$1(y) {
    return unfold((x) => x != null ? [x, null] : null, y);
}









function tryFind$1(f, xs, defaultValue) {
    for (let i = 0, iter = xs[Symbol.iterator]();; i++) {
        const cur = iter.next();
        if (cur.done) {
            return defaultValue === void 0 ? null : defaultValue;
        }
        if (f(cur.value, i)) {
            return cur.value;
        }
    }
}









function unfold(f, acc) {
    return {
        [Symbol.iterator]: () => {
            return {
                next: () => {
                    const res = f(acc);
                    if (res != null) {
                        acc = res[1];
                        return { done: false, value: res[0] };
                    }
                    return { done: true };
                },
            };
        },
    };
}

class MapTree {
    constructor(tag, data) {
        this.tag = tag | 0;
        this.data = data;
    }
}
function tree_sizeAux(acc, m) {
    sizeAux: while (true) {
        if (m.tag === 1) {
            return acc + 1 | 0;
        }
        else if (m.tag === 2) {
            acc = tree_sizeAux(acc + 1, m.data[2]);
            m = m.data[3];
            continue sizeAux;
        }
        else {
            return acc | 0;
        }
    }
}
function tree_size(x) {
    return tree_sizeAux(0, x);
}
function tree_empty() {
    return new MapTree(0);
}
function tree_height(_arg1) {
    return _arg1.tag === 1 ? 1 : _arg1.tag === 2 ? _arg1.data[4] : 0;
}
function tree_mk(l, k, v, r) {
    const matchValue = l.tag === 0 ? r.tag === 0 ? 0 : 1 : 1;
    switch (matchValue) {
        case 0:
            return new MapTree(1, [k, v]);
        case 1:
            const hl = tree_height(l) | 0;
            const hr = tree_height(r) | 0;
            const m = (hl < hr ? hr : hl) | 0;
            return new MapTree(2, [k, v, l, r, m + 1]);
    }
    throw new Error("internal error: Map.tree_mk");
}
function tree_rebalance(t1, k, v, t2) {
    const t1h = tree_height(t1);
    const t2h = tree_height(t2);
    if (t2h > t1h + 2) {
        if (t2.tag === 2) {
            if (tree_height(t2.data[2]) > t1h + 1) {
                if (t2.data[2].tag === 2) {
                    return tree_mk(tree_mk(t1, k, v, t2.data[2].data[2]), t2.data[2].data[0], t2.data[2].data[1], tree_mk(t2.data[2].data[3], t2.data[0], t2.data[1], t2.data[3]));
                }
                else {
                    throw new Error("rebalance");
                }
            }
            else {
                return tree_mk(tree_mk(t1, k, v, t2.data[2]), t2.data[0], t2.data[1], t2.data[3]);
            }
        }
        else {
            throw new Error("rebalance");
        }
    }
    else {
        if (t1h > t2h + 2) {
            if (t1.tag === 2) {
                if (tree_height(t1.data[3]) > t2h + 1) {
                    if (t1.data[3].tag === 2) {
                        return tree_mk(tree_mk(t1.data[2], t1.data[0], t1.data[1], t1.data[3].data[2]), t1.data[3].data[0], t1.data[3].data[1], tree_mk(t1.data[3].data[3], k, v, t2));
                    }
                    else {
                        throw new Error("rebalance");
                    }
                }
                else {
                    return tree_mk(t1.data[2], t1.data[0], t1.data[1], tree_mk(t1.data[3], k, v, t2));
                }
            }
            else {
                throw new Error("rebalance");
            }
        }
        else {
            return tree_mk(t1, k, v, t2);
        }
    }
}
function tree_add(comparer, k, v, m) {
    if (m.tag === 1) {
        const c = comparer.Compare(k, m.data[0]);
        if (c < 0) {
            return new MapTree(2, [k, v, new MapTree(0), m, 2]);
        }
        else if (c === 0) {
            return new MapTree(1, [k, v]);
        }
        return new MapTree(2, [k, v, m, new MapTree(0), 2]);
    }
    else if (m.tag === 2) {
        const c = comparer.Compare(k, m.data[0]);
        if (c < 0) {
            return tree_rebalance(tree_add(comparer, k, v, m.data[2]), m.data[0], m.data[1], m.data[3]);
        }
        else if (c === 0) {
            return new MapTree(2, [k, v, m.data[2], m.data[3], m.data[4]]);
        }
        return tree_rebalance(m.data[2], m.data[0], m.data[1], tree_add(comparer, k, v, m.data[3]));
    }
    return new MapTree(1, [k, v]);
}
function tree_find(comparer, k, m) {
    const res = tree_tryFind(comparer, k, m);
    if (res != null) {
        return res;
    }
    throw new Error("key not found");
}
function tree_tryFind(comparer, k, m) {
    tryFind: while (true) {
        if (m.tag === 1) {
            const c = comparer.Compare(k, m.data[0]) | 0;
            if (c === 0) {
                return m.data[1];
            }
            else {
                return null;
            }
        }
        else if (m.tag === 2) {
            const c_1 = comparer.Compare(k, m.data[0]) | 0;
            if (c_1 < 0) {
                comparer = comparer;
                k = k;
                m = m.data[2];
                continue tryFind;
            }
            else if (c_1 === 0) {
                return m.data[1];
            }
            else {
                comparer = comparer;
                k = k;
                m = m.data[3];
                continue tryFind;
            }
        }
        else {
            return null;
        }
    }
}
function tree_spliceOutSuccessor(m) {
    if (m.tag === 1) {
        return [m.data[0], m.data[1], new MapTree(0)];
    }
    else if (m.tag === 2) {
        if (m.data[2].tag === 0) {
            return [m.data[0], m.data[1], m.data[3]];
        }
        else {
            const kvl = tree_spliceOutSuccessor(m.data[2]);
            return [kvl[0], kvl[1], tree_mk(kvl[2], m.data[0], m.data[1], m.data[3])];
        }
    }
    throw new Error("internal error: Map.spliceOutSuccessor");
}
function tree_remove(comparer, k, m) {
    if (m.tag === 1) {
        const c = comparer.Compare(k, m.data[0]);
        if (c === 0) {
            return new MapTree(0);
        }
        else {
            return m;
        }
    }
    else if (m.tag === 2) {
        const c = comparer.Compare(k, m.data[0]);
        if (c < 0) {
            return tree_rebalance(tree_remove(comparer, k, m.data[2]), m.data[0], m.data[1], m.data[3]);
        }
        else if (c === 0) {
            if (m.data[2].tag === 0) {
                return m.data[3];
            }
            else {
                if (m.data[3].tag === 0) {
                    return m.data[2];
                }
                else {
                    const input = tree_spliceOutSuccessor(m.data[3]);
                    return tree_mk(m.data[2], input[0], input[1], input[2]);
                }
            }
        }
        else {
            return tree_rebalance(m.data[2], m.data[0], m.data[1], tree_remove(comparer, k, m.data[3]));
        }
    }
    else {
        return tree_empty();
    }
}
function tree_mem(comparer, k, m) {
    mem: while (true) {
        if (m.tag === 1) {
            return comparer.Compare(k, m.data[0]) === 0;
        }
        else if (m.tag === 2) {
            const c = comparer.Compare(k, m.data[0]) | 0;
            if (c < 0) {
                comparer = comparer;
                k = k;
                m = m.data[2];
                continue mem;
            }
            else if (c === 0) {
                return true;
            }
            else {
                comparer = comparer;
                k = k;
                m = m.data[3];
                continue mem;
            }
        }
        else {
            return false;
        }
    }
}
function tree_mkFromEnumerator(comparer, acc, e) {
    let cur = e.next();
    while (!cur.done) {
        acc = tree_add(comparer, cur.value[0], cur.value[1], acc);
        cur = e.next();
    }
    return acc;
}
// function tree_ofArray(comparer: IComparer<any>, arr: ArrayLike<[any,any]>) {
//   var res = tree_empty();
//   for (var i = 0; i <= arr.length - 1; i++) {
//     res = tree_add(comparer, arr[i][0], arr[i][1], res);
//   }
//   return res;
// }
function tree_ofSeq(comparer, c) {
    const ie = c[Symbol.iterator]();
    return tree_mkFromEnumerator(comparer, tree_empty(), ie);
}
// function tree_copyToArray(s: MapTree, arr: ArrayLike<any>, i: number) {
//   tree_iter((x, y) => { arr[i++] = [x, y]; }, s);
// }
function tree_collapseLHS(stack) {
    if (stack.tail != null) {
        if (stack.head.tag === 1) {
            return stack;
        }
        else if (stack.head.tag === 2) {
            return tree_collapseLHS(ofArray([
                stack.head.data[2],
                new MapTree(1, [stack.head.data[0], stack.head.data[1]]),
                stack.head.data[3],
            ], stack.tail));
        }
        else {
            return tree_collapseLHS(stack.tail);
        }
    }
    else {
        return new List$1();
    }
}
function tree_mkIterator(s) {
    return { stack: tree_collapseLHS(new List$1(s, new List$1())), started: false };
}
function tree_moveNext(i) {
    function current(it) {
        if (it.stack.tail == null) {
            return null;
        }
        else if (it.stack.head.tag === 1) {
            return [it.stack.head.data[0], it.stack.head.data[1]];
        }
        throw new Error("Please report error: Map iterator, unexpected stack for current");
    }
    if (i.started) {
        if (i.stack.tail == null) {
            return { done: true, value: null };
        }
        else {
            if (i.stack.head.tag === 1) {
                i.stack = tree_collapseLHS(i.stack.tail);
                return {
                    done: i.stack.tail == null,
                    value: current(i),
                };
            }
            else {
                throw new Error("Please report error: Map iterator, unexpected stack for moveNext");
            }
        }
    }
    else {
        i.started = true;
        return {
            done: i.stack.tail == null,
            value: current(i),
        };
    }
}
class FableMap {
    /** Do not call, use Map.create instead. */
    constructor() { return; }
    ToString() {
        return "map [" + Array.from(this).map((x) => toString(x)).join("; ") + "]";
    }
    Equals(m2) {
        return this.CompareTo(m2) === 0;
    }
    CompareTo(m2) {
        return this === m2 ? 0 : compareWith((kvp1, kvp2) => {
            const c = this.comparer.Compare(kvp1[0], kvp2[0]);
            return c !== 0 ? c : compare(kvp1[1], kvp2[1]);
        }, this, m2);
    }
    [Symbol.iterator]() {
        const i = tree_mkIterator(this.tree);
        return {
            next: () => tree_moveNext(i),
        };
    }
    entries() {
        return this[Symbol.iterator]();
    }
    keys() {
        return map$2((kv) => kv[0], this);
    }
    values() {
        return map$2((kv) => kv[1], this);
    }
    get(k) {
        return tree_find(this.comparer, k, this.tree);
    }
    has(k) {
        return tree_mem(this.comparer, k, this.tree);
    }
    /** Mutating method */
    set(k, v) {
        this.tree = tree_add(this.comparer, k, v, this.tree);
    }
    /** Mutating method */
    delete(k) {
        // TODO: Is calculating the size twice is more performant than calling tree_mem?
        const oldSize = tree_size(this.tree);
        this.tree = tree_remove(this.comparer, k, this.tree);
        return oldSize > tree_size(this.tree);
    }
    /** Mutating method */
    clear() {
        this.tree = tree_empty();
    }
    get size() {
        return tree_size(this.tree);
    }
    [FSymbol.reflection]() {
        return {
            type: "Microsoft.FSharp.Collections.FSharpMap",
            interfaces: ["System.IEquatable", "System.IComparable", "System.Collections.Generic.IDictionary"],
        };
    }
}
function from(comparer, tree) {
    const map = new FableMap();
    map.tree = tree;
    map.comparer = comparer || new Comparer();
    return map;
}
function create(ie, comparer) {
    comparer = comparer || new Comparer();
    return from(comparer, ie ? tree_ofSeq(comparer, ie) : tree_empty());
}






function tryFind(k, map) {
    return tree_tryFind(map.comparer, k, map.tree);
}

function append(xs, ys) {
    return fold$1((acc, x) => new List$1(x, acc), ys, reverse(xs));
}

function collect(f, xs) {
    return fold$1((acc, x) => append(acc, f(x)), new List$1(), xs);
}
// TODO: should be xs: Iterable<List<T>>
function concat(xs) {
    return collect((x) => x, xs);
}
function filter(f, xs) {
    return reverse(fold$1((acc, x) => f(x) ? new List$1(x, acc) : acc, new List$1(), xs));
}


function map(f, xs) {
    return reverse(fold$1((acc, x) => new List$1(f(x), acc), new List$1(), xs));
}



function reverse(xs) {
    return fold$1((acc, x) => new List$1(x, acc), new List$1(), xs);
}


/* ToDo: instance unzip() */

/* ToDo: instance unzip3() */

const Props = function (__exports) {
  const CSSProp = __exports.CSSProp = class CSSProp {
    constructor(tag, data) {
      this.tag = tag;
      this.data = data;
    }

    [FSymbol.reflection]() {
      return {
        type: "Fable.Helpers.React.Props.CSSProp",
        interfaces: ["FSharpUnion", "System.IEquatable", "Fable.Helpers.React.Props.ICSSProp"],
        cases: [["BoxFlex", "number"], ["BoxFlexGroup", "number"], ["ColumnCount", "number"], ["Flex", Any], ["FlexGrow", "number"], ["FlexShrink", "number"], ["FontWeight", Any], ["LineClamp", "number"], ["LineHeight", Any], ["Opacity", "number"], ["Order", "number"], ["Orphans", "number"], ["Widows", "number"], ["ZIndex", "number"], ["Zoom", "number"], ["FontSize", Any], ["FillOpacity", "number"], ["StrokeOpacity", "number"], ["StrokeWidth", "number"], ["AlignContent", Any], ["AlignItems", Any], ["AlignSelf", Any], ["AlignmentAdjust", Any], ["AlignmentBaseline", Any], ["AnimationDelay", Any], ["AnimationDirection", Any], ["AnimationIterationCount", Any], ["AnimationName", Any], ["AnimationPlayState", Any], ["Appearance", Any], ["BackfaceVisibility", Any], ["BackgroundBlendMode", Any], ["BackgroundColor", Any], ["BackgroundComposite", Any], ["BackgroundImage", Any], ["BackgroundOrigin", Any], ["BackgroundPositionX", Any], ["BackgroundRepeat", Any], ["BaselineShift", Any], ["Behavior", Any], ["Border", Any], ["BorderBottomLeftRadius", Any], ["BorderBottomRightRadius", Any], ["BorderBottomWidth", Any], ["BorderCollapse", Any], ["BorderColor", Any], ["BorderCornerShape", Any], ["BorderImageSource", Any], ["BorderImageWidth", Any], ["BorderLeft", Any], ["BorderLeftColor", Any], ["BorderLeftStyle", Any], ["BorderLeftWidth", Any], ["BorderRight", Any], ["BorderRightColor", Any], ["BorderRightStyle", Any], ["BorderRightWidth", Any], ["BorderSpacing", Any], ["BorderStyle", Any], ["BorderTop", Any], ["BorderTopColor", Any], ["BorderTopLeftRadius", Any], ["BorderTopRightRadius", Any], ["BorderTopStyle", Any], ["BorderTopWidth", Any], ["BorderWidth", Any], ["Bottom", Any], ["BoxAlign", Any], ["BoxDecorationBreak", Any], ["BoxDirection", Any], ["BoxLineProgression", Any], ["BoxLines", Any], ["BoxOrdinalGroup", Any], ["BreakAfter", Any], ["BreakBefore", Any], ["BreakInside", Any], ["Clear", Any], ["Clip", Any], ["ClipRule", Any], ["Color", Any], ["ColumnFill", Any], ["ColumnGap", Any], ["ColumnRule", Any], ["ColumnRuleColor", Any], ["ColumnRuleWidth", Any], ["ColumnSpan", Any], ["ColumnWidth", Any], ["Columns", Any], ["CounterIncrement", Any], ["CounterReset", Any], ["Cue", Any], ["CueAfter", Any], ["Direction", Any], ["Display", Any], ["Fill", Any], ["FillRule", Any], ["Filter", Any], ["FlexAlign", Any], ["FlexBasis", Any], ["FlexDirection", Any], ["FlexFlow", Any], ["FlexItemAlign", Any], ["FlexLinePack", Any], ["FlexOrder", Any], ["FlexWrap", Any], ["Float", Any], ["FlowFrom", Any], ["Font", Any], ["FontFamily", Any], ["FontKerning", Any], ["FontSizeAdjust", Any], ["FontStretch", Any], ["FontStyle", Any], ["FontSynthesis", Any], ["FontVariant", Any], ["FontVariantAlternates", Any], ["GridArea", Any], ["GridColumn", Any], ["GridColumnEnd", Any], ["GridColumnStart", Any], ["GridRow", Any], ["GridRowEnd", Any], ["GridRowPosition", Any], ["GridRowSpan", Any], ["GridTemplateAreas", Any], ["GridTemplateColumns", Any], ["GridTemplateRows", Any], ["Height", Any], ["HyphenateLimitChars", Any], ["HyphenateLimitLines", Any], ["HyphenateLimitZone", Any], ["Hyphens", Any], ["ImeMode", Any], ["JustifyContent", Any], ["LayoutGrid", Any], ["LayoutGridChar", Any], ["LayoutGridLine", Any], ["LayoutGridMode", Any], ["LayoutGridType", Any], ["Left", Any], ["LetterSpacing", Any], ["LineBreak", Any], ["ListStyle", Any], ["ListStyleImage", Any], ["ListStylePosition", Any], ["ListStyleType", Any], ["Margin", Any], ["MarginBottom", Any], ["MarginLeft", Any], ["MarginRight", Any], ["MarginTop", Any], ["MarqueeDirection", Any], ["MarqueeStyle", Any], ["Mask", Any], ["MaskBorder", Any], ["MaskBorderRepeat", Any], ["MaskBorderSlice", Any], ["MaskBorderSource", Any], ["MaskBorderWidth", Any], ["MaskClip", Any], ["MaskOrigin", Any], ["MaxFontSize", Any], ["MaxHeight", Any], ["MaxWidth", Any], ["MinHeight", Any], ["MinWidth", Any], ["Outline", Any], ["OutlineColor", Any], ["OutlineOffset", Any], ["Overflow", Any], ["OverflowStyle", Any], ["OverflowX", Any], ["Padding", Any], ["PaddingBottom", Any], ["PaddingLeft", Any], ["PaddingRight", Any], ["PaddingTop", Any], ["PageBreakAfter", Any], ["PageBreakBefore", Any], ["PageBreakInside", Any], ["Pause", Any], ["PauseAfter", Any], ["PauseBefore", Any], ["Perspective", Any], ["PerspectiveOrigin", Any], ["PointerEvents", Any], ["Position", Any], ["PunctuationTrim", Any], ["Quotes", Any], ["RegionFragment", Any], ["RestAfter", Any], ["RestBefore", Any], ["Right", Any], ["RubyAlign", Any], ["RubyPosition", Any], ["ShapeImageThreshold", Any], ["ShapeInside", Any], ["ShapeMargin", Any], ["ShapeOutside", Any], ["Speak", Any], ["SpeakAs", Any], ["TabSize", Any], ["TableLayout", Any], ["TextAlign", Any], ["TextAlignLast", Any], ["TextDecoration", Any], ["TextDecorationColor", Any], ["TextDecorationLine", Any], ["TextDecorationLineThrough", Any], ["TextDecorationNone", Any], ["TextDecorationOverline", Any], ["TextDecorationSkip", Any], ["TextDecorationStyle", Any], ["TextDecorationUnderline", Any], ["TextEmphasis", Any], ["TextEmphasisColor", Any], ["TextEmphasisStyle", Any], ["TextHeight", Any], ["TextIndent", Any], ["TextJustifyTrim", Any], ["TextKashidaSpace", Any], ["TextLineThrough", Any], ["TextLineThroughColor", Any], ["TextLineThroughMode", Any], ["TextLineThroughStyle", Any], ["TextLineThroughWidth", Any], ["TextOverflow", Any], ["TextOverline", Any], ["TextOverlineColor", Any], ["TextOverlineMode", Any], ["TextOverlineStyle", Any], ["TextOverlineWidth", Any], ["TextRendering", Any], ["TextScript", Any], ["TextShadow", Any], ["TextTransform", Any], ["TextUnderlinePosition", Any], ["TextUnderlineStyle", Any], ["Top", Any], ["TouchAction", Any], ["Transform", Any], ["TransformOrigin", Any], ["TransformOriginZ", Any], ["TransformStyle", Any], ["Transition", Any], ["TransitionDelay", Any], ["TransitionDuration", Any], ["TransitionProperty", Any], ["TransitionTimingFunction", Any], ["UnicodeBidi", Any], ["UnicodeRange", Any], ["UserFocus", Any], ["UserInput", Any], ["VerticalAlign", Any], ["Visibility", Any], ["VoiceBalance", Any], ["VoiceDuration", Any], ["VoiceFamily", Any], ["VoicePitch", Any], ["VoiceRange", Any], ["VoiceRate", Any], ["VoiceStress", Any], ["VoiceVolume", Any], ["WhiteSpace", Any], ["WhiteSpaceTreatment", Any], ["Width", Any], ["WordBreak", Any], ["WordSpacing", Any], ["WordWrap", Any], ["WrapFlow", Any], ["WrapMargin", Any], ["WrapOption", Any], ["WritingMode", Any]]
      };
    }

    Equals(other) {
      return this === other || this.tag === other.tag && equals(this.data, other.data);
    }

  };
  setType("Fable.Helpers.React.Props.CSSProp", CSSProp);
  const Prop = __exports.Prop = class Prop {
    constructor(tag, data) {
      this.tag = tag;
      this.data = data;
    }

    [FSymbol.reflection]() {
      return {
        type: "Fable.Helpers.React.Props.Prop",
        interfaces: ["FSharpUnion", "Fable.Helpers.React.Props.IHTMLProp"],
        cases: [["Key", "string"], ["Ref", FableFunction([Interface("Fable.Import.Browser.Element"), Unit])]]
      };
    }

  };
  setType("Fable.Helpers.React.Props.Prop", Prop);
  const DOMAttr = __exports.DOMAttr = class DOMAttr {
    constructor(tag, data) {
      this.tag = tag;
      this.data = data;
    }

    [FSymbol.reflection]() {
      return {
        type: "Fable.Helpers.React.Props.DOMAttr",
        interfaces: ["FSharpUnion", "Fable.Helpers.React.Props.IHTMLProp"],
        cases: [["DangerouslySetInnerHTML", Any], ["OnCopy", FableFunction([Interface("Fable.Import.React.ClipboardEvent"), Unit])], ["OnCut", FableFunction([Interface("Fable.Import.React.ClipboardEvent"), Unit])], ["OnPaste", FableFunction([Interface("Fable.Import.React.ClipboardEvent"), Unit])], ["OnCompositionEnd", FableFunction([Interface("Fable.Import.React.CompositionEvent"), Unit])], ["OnCompositionStart", FableFunction([Interface("Fable.Import.React.CompositionEvent"), Unit])], ["OnCompositionUpdate", FableFunction([Interface("Fable.Import.React.CompositionEvent"), Unit])], ["OnFocus", FableFunction([Interface("Fable.Import.React.FocusEvent"), Unit])], ["OnBlur", FableFunction([Interface("Fable.Import.React.FocusEvent"), Unit])], ["OnChange", FableFunction([Interface("Fable.Import.React.FormEvent"), Unit])], ["OnInput", FableFunction([Interface("Fable.Import.React.FormEvent"), Unit])], ["OnSubmit", FableFunction([Interface("Fable.Import.React.FormEvent"), Unit])], ["OnLoad", FableFunction([Interface("Fable.Import.React.SyntheticEvent"), Unit])], ["OnError", FableFunction([Interface("Fable.Import.React.SyntheticEvent"), Unit])], ["OnKeyDown", FableFunction([Interface("Fable.Import.React.KeyboardEvent"), Unit])], ["OnKeyPress", FableFunction([Interface("Fable.Import.React.KeyboardEvent"), Unit])], ["OnKeyUp", FableFunction([Interface("Fable.Import.React.KeyboardEvent"), Unit])], ["OnAbort", FableFunction([Interface("Fable.Import.React.SyntheticEvent"), Unit])], ["OnCanPlay", FableFunction([Interface("Fable.Import.React.SyntheticEvent"), Unit])], ["OnCanPlayThrough", FableFunction([Interface("Fable.Import.React.SyntheticEvent"), Unit])], ["OnDurationChange", FableFunction([Interface("Fable.Import.React.SyntheticEvent"), Unit])], ["OnEmptied", FableFunction([Interface("Fable.Import.React.SyntheticEvent"), Unit])], ["OnEncrypted", FableFunction([Interface("Fable.Import.React.SyntheticEvent"), Unit])], ["OnEnded", FableFunction([Interface("Fable.Import.React.SyntheticEvent"), Unit])], ["OnLoadedData", FableFunction([Interface("Fable.Import.React.SyntheticEvent"), Unit])], ["OnLoadedMetadata", FableFunction([Interface("Fable.Import.React.SyntheticEvent"), Unit])], ["OnLoadStart", FableFunction([Interface("Fable.Import.React.SyntheticEvent"), Unit])], ["OnPause", FableFunction([Interface("Fable.Import.React.SyntheticEvent"), Unit])], ["OnPlay", FableFunction([Interface("Fable.Import.React.SyntheticEvent"), Unit])], ["OnPlaying", FableFunction([Interface("Fable.Import.React.SyntheticEvent"), Unit])], ["OnProgress", FableFunction([Interface("Fable.Import.React.SyntheticEvent"), Unit])], ["OnRateChange", FableFunction([Interface("Fable.Import.React.SyntheticEvent"), Unit])], ["OnSeeked", FableFunction([Interface("Fable.Import.React.SyntheticEvent"), Unit])], ["OnSeeking", FableFunction([Interface("Fable.Import.React.SyntheticEvent"), Unit])], ["OnStalled", FableFunction([Interface("Fable.Import.React.SyntheticEvent"), Unit])], ["OnSuspend", FableFunction([Interface("Fable.Import.React.SyntheticEvent"), Unit])], ["OnTimeUpdate", FableFunction([Interface("Fable.Import.React.SyntheticEvent"), Unit])], ["OnVolumeChange", FableFunction([Interface("Fable.Import.React.SyntheticEvent"), Unit])], ["OnWaiting", FableFunction([Interface("Fable.Import.React.SyntheticEvent"), Unit])], ["OnClick", FableFunction([Interface("Fable.Import.React.MouseEvent"), Unit])], ["OnContextMenu", FableFunction([Interface("Fable.Import.React.MouseEvent"), Unit])], ["OnDoubleClick", FableFunction([Interface("Fable.Import.React.MouseEvent"), Unit])], ["OnDrag", FableFunction([Interface("Fable.Import.React.DragEvent"), Unit])], ["OnDragEnd", FableFunction([Interface("Fable.Import.React.DragEvent"), Unit])], ["OnDragEnter", FableFunction([Interface("Fable.Import.React.DragEvent"), Unit])], ["OnDragExit", FableFunction([Interface("Fable.Import.React.DragEvent"), Unit])], ["OnDragLeave", FableFunction([Interface("Fable.Import.React.DragEvent"), Unit])], ["OnDragOver", FableFunction([Interface("Fable.Import.React.DragEvent"), Unit])], ["OnDragStart", FableFunction([Interface("Fable.Import.React.DragEvent"), Unit])], ["OnDrop", FableFunction([Interface("Fable.Import.React.DragEvent"), Unit])], ["OnMouseDown", FableFunction([Interface("Fable.Import.React.MouseEvent"), Unit])], ["OnMouseEnter", FableFunction([Interface("Fable.Import.React.MouseEvent"), Unit])], ["OnMouseLeave", FableFunction([Interface("Fable.Import.React.MouseEvent"), Unit])], ["OnMouseMove", FableFunction([Interface("Fable.Import.React.MouseEvent"), Unit])], ["OnMouseOut", FableFunction([Interface("Fable.Import.React.MouseEvent"), Unit])], ["OnMouseOver", FableFunction([Interface("Fable.Import.React.MouseEvent"), Unit])], ["OnMouseUp", FableFunction([Interface("Fable.Import.React.MouseEvent"), Unit])], ["OnSelect", FableFunction([Interface("Fable.Import.React.SyntheticEvent"), Unit])], ["OnTouchCancel", FableFunction([Interface("Fable.Import.React.TouchEvent"), Unit])], ["OnTouchEnd", FableFunction([Interface("Fable.Import.React.TouchEvent"), Unit])], ["OnTouchMove", FableFunction([Interface("Fable.Import.React.TouchEvent"), Unit])], ["OnTouchStart", FableFunction([Interface("Fable.Import.React.TouchEvent"), Unit])], ["OnScroll", FableFunction([Interface("Fable.Import.React.UIEvent"), Unit])], ["OnWheel", FableFunction([Interface("Fable.Import.React.WheelEvent"), Unit])]]
      };
    }

  };
  setType("Fable.Helpers.React.Props.DOMAttr", DOMAttr);
  const HTMLAttr = __exports.HTMLAttr = class HTMLAttr {
    constructor(tag, data) {
      this.tag = tag;
      this.data = data;
    }

    [FSymbol.reflection]() {
      return {
        type: "Fable.Helpers.React.Props.HTMLAttr",
        interfaces: ["FSharpUnion", "System.IEquatable", "Fable.Helpers.React.Props.IHTMLProp"],
        cases: [["DefaultChecked", "boolean"], ["DefaultValue", Any], ["Accept", "string"], ["AcceptCharset", "string"], ["AccessKey", "string"], ["Action", "string"], ["AllowFullScreen", "boolean"], ["AllowTransparency", "boolean"], ["Alt", "string"], ["aria-haspopup", "boolean"], ["aria-expanded", "boolean"], ["Async", "boolean"], ["AutoComplete", "string"], ["AutoFocus", "boolean"], ["AutoPlay", "boolean"], ["Capture", "boolean"], ["CellPadding", Any], ["CellSpacing", Any], ["CharSet", "string"], ["Challenge", "string"], ["Checked", "boolean"], ["ClassID", "string"], ["ClassName", "string"], ["Cols", "number"], ["ColSpan", "number"], ["Content", "string"], ["ContentEditable", "boolean"], ["ContextMenu", "string"], ["Controls", "boolean"], ["Coords", "string"], ["CrossOrigin", "string"], ["Data", "string"], ["data-toggle", "string"], ["DateTime", "string"], ["Default", "boolean"], ["Defer", "boolean"], ["Dir", "string"], ["Disabled", "boolean"], ["Download", Any], ["Draggable", "boolean"], ["EncType", "string"], ["Form", "string"], ["FormAction", "string"], ["FormEncType", "string"], ["FormMethod", "string"], ["FormNoValidate", "boolean"], ["FormTarget", "string"], ["FrameBorder", Any], ["Headers", "string"], ["Hidden", "boolean"], ["High", "number"], ["Href", "string"], ["HrefLang", "string"], ["HtmlFor", "string"], ["HttpEquiv", "string"], ["Icon", "string"], ["Id", "string"], ["InputMode", "string"], ["Integrity", "string"], ["Is", "string"], ["KeyParams", "string"], ["KeyType", "string"], ["Kind", "string"], ["Label", "string"], ["Lang", "string"], ["List", "string"], ["Loop", "boolean"], ["Low", "number"], ["Manifest", "string"], ["MarginHeight", "number"], ["MarginWidth", "number"], ["Max", Any], ["MaxLength", "number"], ["Media", "string"], ["MediaGroup", "string"], ["Method", "string"], ["Min", Any], ["MinLength", "number"], ["Multiple", "boolean"], ["Muted", "boolean"], ["Name", "string"], ["NoValidate", "boolean"], ["Open", "boolean"], ["Optimum", "number"], ["Pattern", "string"], ["Placeholder", "string"], ["Poster", "string"], ["Preload", "string"], ["RadioGroup", "string"], ["ReadOnly", "boolean"], ["Rel", "string"], ["Required", "boolean"], ["Role", "string"], ["Rows", "number"], ["RowSpan", "number"], ["Sandbox", "string"], ["Scope", "string"], ["Scoped", "boolean"], ["Scrolling", "string"], ["Seamless", "boolean"], ["Selected", "boolean"], ["Shape", "string"], ["Size", "number"], ["Sizes", "string"], ["Span", "number"], ["SpellCheck", "boolean"], ["Src", "string"], ["SrcDoc", "string"], ["SrcLang", "string"], ["SrcSet", "string"], ["Start", "number"], ["Step", Any], ["Summary", "string"], ["TabIndex", "number"], ["Target", "string"], ["Title", "string"], ["Type", "string"], ["UseMap", "string"], ["Value", Any], ["Width", Any], ["Wmode", "string"], ["Wrap", "string"], ["About", "string"], ["Datatype", "string"], ["Inlist", Any], ["Prefix", "string"], ["Property", "string"], ["Resource", "string"], ["Typeof", "string"], ["Vocab", "string"], ["AutoCapitalize", "string"], ["AutoCorrect", "string"], ["AutoSave", "string"], ["ItemProp", "string"], ["ItemScope", "boolean"], ["ItemType", "string"], ["ItemID", "string"], ["ItemRef", "string"], ["Results", "number"], ["Security", "string"], ["Unselectable", "boolean"]]
      };
    }

    Equals(other) {
      return this === other || this.tag === other.tag && equals(this.data, other.data);
    }

  };
  setType("Fable.Helpers.React.Props.HTMLAttr", HTMLAttr);
  const SVGAttr = __exports.SVGAttr = class SVGAttr {
    constructor(tag, data) {
      this.tag = tag;
      this.data = data;
    }

    [FSymbol.reflection]() {
      return {
        type: "Fable.Helpers.React.Props.SVGAttr",
        interfaces: ["FSharpUnion", "System.IEquatable", "System.IComparable", "Fable.Helpers.React.Props.IProp"],
        cases: [["ClipPath", "string"], ["Cx", Any], ["Cy", Any], ["D", "string"], ["Dx", Any], ["Dy", Any], ["Fill", "string"], ["FillOpacity", Any], ["FontFamily", "string"], ["FontSize", Any], ["Fx", Any], ["Fy", Any], ["GradientTransform", "string"], ["GradientUnits", "string"], ["MarkerEnd", "string"], ["MarkerMid", "string"], ["MarkerStart", "string"], ["Offset", Any], ["Opacity", Any], ["PatternContentUnits", "string"], ["PatternUnits", "string"], ["Points", "string"], ["PreserveAspectRatio", "string"], ["R", Any], ["Rx", Any], ["Ry", Any], ["SpreadMethod", "string"], ["StopColor", "string"], ["StopOpacity", Any], ["Stroke", "string"], ["StrokeDasharray", "string"], ["StrokeLinecap", "string"], ["StrokeMiterlimit", "string"], ["StrokeOpacity", Any], ["StrokeWidth", Any], ["TextAnchor", "string"], ["Transform", "string"], ["Version", "string"], ["ViewBox", "string"], ["X1", Any], ["X2", Any], ["X", Any], ["XlinkActuate", "string"], ["XlinkArcrole", "string"], ["XlinkHref", "string"], ["XlinkRole", "string"], ["XlinkShow", "string"], ["XlinkTitle", "string"], ["XlinkType", "string"], ["XmlBase", "string"], ["XmlLang", "string"], ["XmlSpace", "string"], ["Y1", Any], ["Y2", Any], ["Y", Any]]
      };
    }

    Equals(other) {
      return this === other || this.tag === other.tag && equals(this.data, other.data);
    }

    CompareTo(other) {
      return compareUnions(this, other) | 0;
    }

  };
  setType("Fable.Helpers.React.Props.SVGAttr", SVGAttr);
  return __exports;
}({});

function classBaseList(std, classes) {
  return new Props.HTMLAttr(22, (() => {
    const folder = function (complete, _arg1) {
      if (_arg1[1]) {
        return complete + " " + _arg1[0];
      } else {
        return complete;
      }
    };

    return function (list) {
      return fold$1(folder, std, list);
    };
  })()(classes));
}
function classList(classes) {
  return classBaseList("", classes);
}

class Elements {
  constructor(tag, data) {
    this.tag = tag;
    this.data = data;
  }

  [FSymbol.reflection]() {
    return {
      type: "Global.Elements",
      interfaces: ["FSharpUnion", "System.IEquatable", "System.IComparable"],
      cases: [["Button"], ["Icon"], ["Title"], ["Delete"], ["Box"], ["Content"], ["Tag"], ["Image"], ["Progress"], ["Table"], ["Form"]]
    };
  }

  Equals(other) {
    return this === other || this.tag === other.tag && equals(this.data, other.data);
  }

  CompareTo(other) {
    return compareUnions(this, other) | 0;
  }

}
setType("Global.Elements", Elements);
class Page {
  constructor(tag, data) {
    this.tag = tag;
    this.data = data;
  }

  [FSymbol.reflection]() {
    return {
      type: "Global.Page",
      interfaces: ["FSharpUnion", "System.IEquatable", "System.IComparable"],
      cases: [["Home"], ["Element", Elements]]
    };
  }

  Equals(other) {
    return this === other || this.tag === other.tag && equals(this.data, other.data);
  }

  CompareTo(other) {
    return compareUnions(this, other) | 0;
  }

}
setType("Global.Page", Page);
function toHash(page) {
  if (page.tag === 1) {
    if (page.data.tag === 1) {
      return "#elements/icon";
    } else if (page.data.tag === 2) {
      return "#elements/title";
    } else if (page.data.tag === 3) {
      return "#elements/delete";
    } else if (page.data.tag === 4) {
      return "#elements/box";
    } else if (page.data.tag === 5) {
      return "#elements/content";
    } else if (page.data.tag === 6) {
      return "#elements/tag";
    } else if (page.data.tag === 7) {
      return "#elements/image";
    } else if (page.data.tag === 8) {
      return "#elements/progress";
    } else if (page.data.tag === 9) {
      return "#elements/table";
    } else if (page.data.tag === 10) {
      return "#elements/form";
    } else {
      return "#elements/button";
    }
  } else {
    return "#home";
  }
}
function renderMarkdown(str) {
  return react_1("div", {
    dangerouslySetInnerHTML: {
      __html: marked.parse(str)
    }
  });
}
function toList$1(x) {
  return ofArray([x]);
}
function sectionBase(title, docBlocks) {
  return react_1("div", {}, ...new List$1(react_1("div", {
    className: "content"
  }, renderMarkdown(title)), docBlocks));
}
function docBlock(code, children) {
  return react_1("div", {
    className: "columns"
  }, react_1("div", {
    className: "column"
  }, children), react_1("div", {
    className: "column"
  }, renderMarkdown(code)));
}

class StandardSize {
  constructor(isSmall, isMedium, isLarge) {
    this.isSmall = isSmall;
    this.isMedium = isMedium;
    this.isLarge = isLarge;
  }

  [FSymbol.reflection]() {
    return {
      type: "Elmish.Bulma.BulmaClasses.StandardSize",
      interfaces: ["FSharpRecord", "System.IEquatable", "System.IComparable"],
      properties: {
        isSmall: "string",
        isMedium: "string",
        isLarge: "string"
      }
    };
  }

  Equals(other) {
    return equalsRecords(this, other);
  }

  CompareTo(other) {
    return compareRecords(this, other) | 0;
  }

}
setType("Elmish.Bulma.BulmaClasses.StandardSize", StandardSize);
class LevelAndColor {
  constructor(isBlack, isDark, isLight, isWhite, isPrimary, isInfo, isSuccess, isWarning, isDanger) {
    this.isBlack = isBlack;
    this.isDark = isDark;
    this.isLight = isLight;
    this.isWhite = isWhite;
    this.isPrimary = isPrimary;
    this.isInfo = isInfo;
    this.isSuccess = isSuccess;
    this.isWarning = isWarning;
    this.isDanger = isDanger;
  }

  [FSymbol.reflection]() {
    return {
      type: "Elmish.Bulma.BulmaClasses.LevelAndColor",
      interfaces: ["FSharpRecord", "System.IEquatable", "System.IComparable"],
      properties: {
        isBlack: "string",
        isDark: "string",
        isLight: "string",
        isWhite: "string",
        isPrimary: "string",
        isInfo: "string",
        isSuccess: "string",
        isWarning: "string",
        isDanger: "string"
      }
    };
  }

  Equals(other) {
    return equalsRecords(this, other);
  }

  CompareTo(other) {
    return compareRecords(this, other) | 0;
  }

}
setType("Elmish.Bulma.BulmaClasses.LevelAndColor", LevelAndColor);
class Box {
  constructor(container) {
    this.container = container;
  }

  [FSymbol.reflection]() {
    return {
      type: "Elmish.Bulma.BulmaClasses.Box",
      interfaces: ["FSharpRecord", "System.IEquatable", "System.IComparable"],
      properties: {
        container: "string"
      }
    };
  }

  Equals(other) {
    return equalsRecords(this, other);
  }

  CompareTo(other) {
    return compareRecords(this, other) | 0;
  }

}
setType("Elmish.Bulma.BulmaClasses.Box", Box);
class Button {
  constructor(container, size, color, state, styles) {
    this.container = container;
    this.size = size;
    this.color = color;
    this.state = state;
    this.styles = styles;
  }

  [FSymbol.reflection]() {
    return {
      type: "Elmish.Bulma.BulmaClasses.Button",
      interfaces: ["FSharpRecord", "System.IEquatable", "System.IComparable"],
      properties: {
        container: "string",
        size: StandardSize,
        color: LevelAndColor,
        state: ButtonState,
        styles: ButtonStyles
      }
    };
  }

  Equals(other) {
    return equalsRecords(this, other);
  }

  CompareTo(other) {
    return compareRecords(this, other) | 0;
  }

}
setType("Elmish.Bulma.BulmaClasses.Button", Button);
class ButtonState {
  constructor(isHovered, isFocused, isActive, isLoading) {
    this.isHovered = isHovered;
    this.isFocused = isFocused;
    this.isActive = isActive;
    this.isLoading = isLoading;
  }

  [FSymbol.reflection]() {
    return {
      type: "Elmish.Bulma.BulmaClasses.ButtonState",
      interfaces: ["FSharpRecord", "System.IEquatable", "System.IComparable"],
      properties: {
        isHovered: "string",
        isFocused: "string",
        isActive: "string",
        isLoading: "string"
      }
    };
  }

  Equals(other) {
    return equalsRecords(this, other);
  }

  CompareTo(other) {
    return compareRecords(this, other) | 0;
  }

}
setType("Elmish.Bulma.BulmaClasses.ButtonState", ButtonState);
class ButtonStyles {
  constructor(isLink, isOutlined, isInverted) {
    this.isLink = isLink;
    this.isOutlined = isOutlined;
    this.isInverted = isInverted;
  }

  [FSymbol.reflection]() {
    return {
      type: "Elmish.Bulma.BulmaClasses.ButtonStyles",
      interfaces: ["FSharpRecord", "System.IEquatable", "System.IComparable"],
      properties: {
        isLink: "string",
        isOutlined: "string",
        isInverted: "string"
      }
    };
  }

  Equals(other) {
    return equalsRecords(this, other);
  }

  CompareTo(other) {
    return compareRecords(this, other) | 0;
  }

}
setType("Elmish.Bulma.BulmaClasses.ButtonStyles", ButtonStyles);
class Content {
  constructor(container, size) {
    this.container = container;
    this.size = size;
  }

  [FSymbol.reflection]() {
    return {
      type: "Elmish.Bulma.BulmaClasses.Content",
      interfaces: ["FSharpRecord", "System.IEquatable", "System.IComparable"],
      properties: {
        container: "string",
        size: StandardSize
      }
    };
  }

  Equals(other) {
    return equalsRecords(this, other);
  }

  CompareTo(other) {
    return compareRecords(this, other) | 0;
  }

}
setType("Elmish.Bulma.BulmaClasses.Content", Content);
class Control {
  constructor(container, hasIcon, state) {
    this.container = container;
    this.hasIcon = hasIcon;
    this.state = state;
  }

  [FSymbol.reflection]() {
    return {
      type: "Elmish.Bulma.BulmaClasses.Control",
      interfaces: ["FSharpRecord", "System.IEquatable", "System.IComparable"],
      properties: {
        container: "string",
        hasIcon: ControlHasIcon,
        state: ControlState
      }
    };
  }

  Equals(other) {
    return equalsRecords(this, other);
  }

  CompareTo(other) {
    return compareRecords(this, other) | 0;
  }

}
setType("Elmish.Bulma.BulmaClasses.Control", Control);
class ControlHasIcon {
  constructor(left, right) {
    this.left = left;
    this.right = right;
  }

  [FSymbol.reflection]() {
    return {
      type: "Elmish.Bulma.BulmaClasses.ControlHasIcon",
      interfaces: ["FSharpRecord", "System.IEquatable", "System.IComparable"],
      properties: {
        left: "string",
        right: "string"
      }
    };
  }

  Equals(other) {
    return equalsRecords(this, other);
  }

  CompareTo(other) {
    return compareRecords(this, other) | 0;
  }

}
setType("Elmish.Bulma.BulmaClasses.ControlHasIcon", ControlHasIcon);
class ControlState {
  constructor(isLoading) {
    this.isLoading = isLoading;
  }

  [FSymbol.reflection]() {
    return {
      type: "Elmish.Bulma.BulmaClasses.ControlState",
      interfaces: ["FSharpRecord", "System.IEquatable", "System.IComparable"],
      properties: {
        isLoading: "string"
      }
    };
  }

  Equals(other) {
    return equalsRecords(this, other);
  }

  CompareTo(other) {
    return compareRecords(this, other) | 0;
  }

}
setType("Elmish.Bulma.BulmaClasses.ControlState", ControlState);
class Delete {
  constructor(container, size) {
    this.container = container;
    this.size = size;
  }

  [FSymbol.reflection]() {
    return {
      type: "Elmish.Bulma.BulmaClasses.Delete",
      interfaces: ["FSharpRecord", "System.IEquatable", "System.IComparable"],
      properties: {
        container: "string",
        size: StandardSize
      }
    };
  }

  Equals(other) {
    return equalsRecords(this, other);
  }

  CompareTo(other) {
    return compareRecords(this, other) | 0;
  }

}
setType("Elmish.Bulma.BulmaClasses.Delete", Delete);
class Field {
  constructor(container, label, body, hasAddons, isGrouped, layout) {
    this.container = container;
    this.label = label;
    this.body = body;
    this.hasAddons = hasAddons;
    this.isGrouped = isGrouped;
    this.layout = layout;
  }

  [FSymbol.reflection]() {
    return {
      type: "Elmish.Bulma.BulmaClasses.Field",
      interfaces: ["FSharpRecord", "System.IEquatable", "System.IComparable"],
      properties: {
        container: "string",
        label: "string",
        body: "string",
        hasAddons: FieldHasAddons,
        isGrouped: FieldIsGrouped,
        layout: FieldLayout
      }
    };
  }

  Equals(other) {
    return equalsRecords(this, other);
  }

  CompareTo(other) {
    return compareRecords(this, other) | 0;
  }

}
setType("Elmish.Bulma.BulmaClasses.Field", Field);
class FieldHasAddons {
  constructor(left, centered, right, fullWidh) {
    this.left = left;
    this.centered = centered;
    this.right = right;
    this.fullWidh = fullWidh;
  }

  [FSymbol.reflection]() {
    return {
      type: "Elmish.Bulma.BulmaClasses.FieldHasAddons",
      interfaces: ["FSharpRecord", "System.IEquatable", "System.IComparable"],
      properties: {
        left: "string",
        centered: "string",
        right: "string",
        fullWidh: "string"
      }
    };
  }

  Equals(other) {
    return equalsRecords(this, other);
  }

  CompareTo(other) {
    return compareRecords(this, other) | 0;
  }

}
setType("Elmish.Bulma.BulmaClasses.FieldHasAddons", FieldHasAddons);
class FieldIsGrouped {
  constructor(left, centered, right) {
    this.left = left;
    this.centered = centered;
    this.right = right;
  }

  [FSymbol.reflection]() {
    return {
      type: "Elmish.Bulma.BulmaClasses.FieldIsGrouped",
      interfaces: ["FSharpRecord", "System.IEquatable", "System.IComparable"],
      properties: {
        left: "string",
        centered: "string",
        right: "string"
      }
    };
  }

  Equals(other) {
    return equalsRecords(this, other);
  }

  CompareTo(other) {
    return compareRecords(this, other) | 0;
  }

}
setType("Elmish.Bulma.BulmaClasses.FieldIsGrouped", FieldIsGrouped);
class FieldLayout {
  constructor(isHorizontal) {
    this.isHorizontal = isHorizontal;
  }

  [FSymbol.reflection]() {
    return {
      type: "Elmish.Bulma.BulmaClasses.FieldLayout",
      interfaces: ["FSharpRecord", "System.IEquatable", "System.IComparable"],
      properties: {
        isHorizontal: "string"
      }
    };
  }

  Equals(other) {
    return equalsRecords(this, other);
  }

  CompareTo(other) {
    return compareRecords(this, other) | 0;
  }

}
setType("Elmish.Bulma.BulmaClasses.FieldLayout", FieldLayout);
class Icon {
  constructor(container, position, size) {
    this.container = container;
    this.position = position;
    this.size = size;
  }

  [FSymbol.reflection]() {
    return {
      type: "Elmish.Bulma.BulmaClasses.Icon",
      interfaces: ["FSharpRecord", "System.IEquatable", "System.IComparable"],
      properties: {
        container: "string",
        position: IconPosition,
        size: StandardSize
      }
    };
  }

  Equals(other) {
    return equalsRecords(this, other);
  }

  CompareTo(other) {
    return compareRecords(this, other) | 0;
  }

}
setType("Elmish.Bulma.BulmaClasses.Icon", Icon);
class IconPosition {
  constructor(left, right) {
    this.left = left;
    this.right = right;
  }

  [FSymbol.reflection]() {
    return {
      type: "Elmish.Bulma.BulmaClasses.IconPosition",
      interfaces: ["FSharpRecord", "System.IEquatable", "System.IComparable"],
      properties: {
        left: "string",
        right: "string"
      }
    };
  }

  Equals(other) {
    return equalsRecords(this, other);
  }

  CompareTo(other) {
    return compareRecords(this, other) | 0;
  }

}
setType("Elmish.Bulma.BulmaClasses.IconPosition", IconPosition);
class Input {
  constructor(container, display, size, state, color, addon) {
    this.container = container;
    this.display = display;
    this.size = size;
    this.state = state;
    this.color = color;
    this.addon = addon;
  }

  [FSymbol.reflection]() {
    return {
      type: "Elmish.Bulma.BulmaClasses.Input",
      interfaces: ["FSharpRecord", "System.IEquatable", "System.IComparable"],
      properties: {
        container: "string",
        display: InputDisplay,
        size: StandardSize,
        state: InputState,
        color: LevelAndColor,
        addon: InputAddon
      }
    };
  }

  Equals(other) {
    return equalsRecords(this, other);
  }

  CompareTo(other) {
    return compareRecords(this, other) | 0;
  }

}
setType("Elmish.Bulma.BulmaClasses.Input", Input);
class InputDisplay {
  constructor(isInline) {
    this.isInline = isInline;
  }

  [FSymbol.reflection]() {
    return {
      type: "Elmish.Bulma.BulmaClasses.InputDisplay",
      interfaces: ["FSharpRecord", "System.IEquatable", "System.IComparable"],
      properties: {
        isInline: "string"
      }
    };
  }

  Equals(other) {
    return equalsRecords(this, other);
  }

  CompareTo(other) {
    return compareRecords(this, other) | 0;
  }

}
setType("Elmish.Bulma.BulmaClasses.InputDisplay", InputDisplay);
class InputState {
  constructor(isHovered, isFocused, isActive, isLoading) {
    this.isHovered = isHovered;
    this.isFocused = isFocused;
    this.isActive = isActive;
    this.isLoading = isLoading;
  }

  [FSymbol.reflection]() {
    return {
      type: "Elmish.Bulma.BulmaClasses.InputState",
      interfaces: ["FSharpRecord", "System.IEquatable", "System.IComparable"],
      properties: {
        isHovered: "string",
        isFocused: "string",
        isActive: "string",
        isLoading: "string"
      }
    };
  }

  Equals(other) {
    return equalsRecords(this, other);
  }

  CompareTo(other) {
    return compareRecords(this, other) | 0;
  }

}
setType("Elmish.Bulma.BulmaClasses.InputState", InputState);
class InputAddon {
  constructor(isExpanded) {
    this.isExpanded = isExpanded;
  }

  [FSymbol.reflection]() {
    return {
      type: "Elmish.Bulma.BulmaClasses.InputAddon",
      interfaces: ["FSharpRecord", "System.IEquatable", "System.IComparable"],
      properties: {
        isExpanded: "string"
      }
    };
  }

  Equals(other) {
    return equalsRecords(this, other);
  }

  CompareTo(other) {
    return compareRecords(this, other) | 0;
  }

}
setType("Elmish.Bulma.BulmaClasses.InputAddon", InputAddon);
class Image {
  constructor(container, size, ratio) {
    this.container = container;
    this.size = size;
    this.ratio = ratio;
  }

  [FSymbol.reflection]() {
    return {
      type: "Elmish.Bulma.BulmaClasses.Image",
      interfaces: ["FSharpRecord", "System.IEquatable", "System.IComparable"],
      properties: {
        container: "string",
        size: ImageSize,
        ratio: ImageRatio
      }
    };
  }

  Equals(other) {
    return equalsRecords(this, other);
  }

  CompareTo(other) {
    return compareRecords(this, other) | 0;
  }

}
setType("Elmish.Bulma.BulmaClasses.Image", Image);
class ImageSize {
  constructor(is16x16, is24x24, is32x32, is48x48, is64x64, is96x96, is128x128) {
    this.is16x16 = is16x16;
    this.is24x24 = is24x24;
    this.is32x32 = is32x32;
    this.is48x48 = is48x48;
    this.is64x64 = is64x64;
    this.is96x96 = is96x96;
    this.is128x128 = is128x128;
  }

  [FSymbol.reflection]() {
    return {
      type: "Elmish.Bulma.BulmaClasses.ImageSize",
      interfaces: ["FSharpRecord", "System.IEquatable", "System.IComparable"],
      properties: {
        is16x16: "string",
        is24x24: "string",
        is32x32: "string",
        is48x48: "string",
        is64x64: "string",
        is96x96: "string",
        is128x128: "string"
      }
    };
  }

  Equals(other) {
    return equalsRecords(this, other);
  }

  CompareTo(other) {
    return compareRecords(this, other) | 0;
  }

}
setType("Elmish.Bulma.BulmaClasses.ImageSize", ImageSize);
class ImageRatio {
  constructor(isSquare, is1by1, is4by3, is3by2, is16by9, is2by1) {
    this.isSquare = isSquare;
    this.is1by1 = is1by1;
    this.is4by3 = is4by3;
    this.is3by2 = is3by2;
    this.is16by9 = is16by9;
    this.is2by1 = is2by1;
  }

  [FSymbol.reflection]() {
    return {
      type: "Elmish.Bulma.BulmaClasses.ImageRatio",
      interfaces: ["FSharpRecord", "System.IEquatable", "System.IComparable"],
      properties: {
        isSquare: "string",
        is1by1: "string",
        is4by3: "string",
        is3by2: "string",
        is16by9: "string",
        is2by1: "string"
      }
    };
  }

  Equals(other) {
    return equalsRecords(this, other);
  }

  CompareTo(other) {
    return compareRecords(this, other) | 0;
  }

}
setType("Elmish.Bulma.BulmaClasses.ImageRatio", ImageRatio);
class Heading {
  constructor(title, subtitle, size, spacing) {
    this.title = title;
    this.subtitle = subtitle;
    this.size = size;
    this.spacing = spacing;
  }

  [FSymbol.reflection]() {
    return {
      type: "Elmish.Bulma.BulmaClasses.Heading",
      interfaces: ["FSharpRecord", "System.IEquatable", "System.IComparable"],
      properties: {
        title: "string",
        subtitle: "string",
        size: HeadingSize,
        spacing: HeadingSpacing
      }
    };
  }

  Equals(other) {
    return equalsRecords(this, other);
  }

  CompareTo(other) {
    return compareRecords(this, other) | 0;
  }

}
setType("Elmish.Bulma.BulmaClasses.Heading", Heading);
class HeadingSize {
  constructor(is1, is2, is3, is4, is5, is6) {
    this.is1 = is1;
    this.is2 = is2;
    this.is3 = is3;
    this.is4 = is4;
    this.is5 = is5;
    this.is6 = is6;
  }

  [FSymbol.reflection]() {
    return {
      type: "Elmish.Bulma.BulmaClasses.HeadingSize",
      interfaces: ["FSharpRecord", "System.IEquatable", "System.IComparable"],
      properties: {
        is1: "string",
        is2: "string",
        is3: "string",
        is4: "string",
        is5: "string",
        is6: "string"
      }
    };
  }

  Equals(other) {
    return equalsRecords(this, other);
  }

  CompareTo(other) {
    return compareRecords(this, other) | 0;
  }

}
setType("Elmish.Bulma.BulmaClasses.HeadingSize", HeadingSize);
class HeadingSpacing {
  constructor(isNormal) {
    this.isNormal = isNormal;
  }

  [FSymbol.reflection]() {
    return {
      type: "Elmish.Bulma.BulmaClasses.HeadingSpacing",
      interfaces: ["FSharpRecord", "System.IEquatable", "System.IComparable"],
      properties: {
        isNormal: "string"
      }
    };
  }

  Equals(other) {
    return equalsRecords(this, other);
  }

  CompareTo(other) {
    return compareRecords(this, other) | 0;
  }

}
setType("Elmish.Bulma.BulmaClasses.HeadingSpacing", HeadingSpacing);
class Label {
  constructor(container, size) {
    this.container = container;
    this.size = size;
  }

  [FSymbol.reflection]() {
    return {
      type: "Elmish.Bulma.BulmaClasses.Label",
      interfaces: ["FSharpRecord", "System.IEquatable", "System.IComparable"],
      properties: {
        container: "string",
        size: StandardSize
      }
    };
  }

  Equals(other) {
    return equalsRecords(this, other);
  }

  CompareTo(other) {
    return compareRecords(this, other) | 0;
  }

}
setType("Elmish.Bulma.BulmaClasses.Label", Label);
class Progress {
  constructor(container, size, color) {
    this.container = container;
    this.size = size;
    this.color = color;
  }

  [FSymbol.reflection]() {
    return {
      type: "Elmish.Bulma.BulmaClasses.Progress",
      interfaces: ["FSharpRecord", "System.IEquatable", "System.IComparable"],
      properties: {
        container: "string",
        size: StandardSize,
        color: LevelAndColor
      }
    };
  }

  Equals(other) {
    return equalsRecords(this, other);
  }

  CompareTo(other) {
    return compareRecords(this, other) | 0;
  }

}
setType("Elmish.Bulma.BulmaClasses.Progress", Progress);
class Table {
  constructor(container, row, style, spacing) {
    this.container = container;
    this.row = row;
    this.style = style;
    this.spacing = spacing;
  }

  [FSymbol.reflection]() {
    return {
      type: "Elmish.Bulma.BulmaClasses.Table",
      interfaces: ["FSharpRecord", "System.IEquatable", "System.IComparable"],
      properties: {
        container: "string",
        row: TableRow,
        style: TableStyle,
        spacing: TableSpacing
      }
    };
  }

  Equals(other) {
    return equalsRecords(this, other);
  }

  CompareTo(other) {
    return compareRecords(this, other) | 0;
  }

}
setType("Elmish.Bulma.BulmaClasses.Table", Table);
class TableRow {
  constructor(state) {
    this.state = state;
  }

  [FSymbol.reflection]() {
    return {
      type: "Elmish.Bulma.BulmaClasses.TableRow",
      interfaces: ["FSharpRecord", "System.IEquatable", "System.IComparable"],
      properties: {
        state: TableRowState
      }
    };
  }

  Equals(other) {
    return equalsRecords(this, other);
  }

  CompareTo(other) {
    return compareRecords(this, other) | 0;
  }

}
setType("Elmish.Bulma.BulmaClasses.TableRow", TableRow);
class TableRowState {
  constructor(isSelected) {
    this.isSelected = isSelected;
  }

  [FSymbol.reflection]() {
    return {
      type: "Elmish.Bulma.BulmaClasses.TableRowState",
      interfaces: ["FSharpRecord", "System.IEquatable", "System.IComparable"],
      properties: {
        isSelected: "string"
      }
    };
  }

  Equals(other) {
    return equalsRecords(this, other);
  }

  CompareTo(other) {
    return compareRecords(this, other) | 0;
  }

}
setType("Elmish.Bulma.BulmaClasses.TableRowState", TableRowState);
class TableStyle {
  constructor(isBordered, isStripped) {
    this.isBordered = isBordered;
    this.isStripped = isStripped;
  }

  [FSymbol.reflection]() {
    return {
      type: "Elmish.Bulma.BulmaClasses.TableStyle",
      interfaces: ["FSharpRecord", "System.IEquatable", "System.IComparable"],
      properties: {
        isBordered: "string",
        isStripped: "string"
      }
    };
  }

  Equals(other) {
    return equalsRecords(this, other);
  }

  CompareTo(other) {
    return compareRecords(this, other) | 0;
  }

}
setType("Elmish.Bulma.BulmaClasses.TableStyle", TableStyle);
class TableSpacing {
  constructor(isNarrow) {
    this.isNarrow = isNarrow;
  }

  [FSymbol.reflection]() {
    return {
      type: "Elmish.Bulma.BulmaClasses.TableSpacing",
      interfaces: ["FSharpRecord", "System.IEquatable", "System.IComparable"],
      properties: {
        isNarrow: "string"
      }
    };
  }

  Equals(other) {
    return equalsRecords(this, other);
  }

  CompareTo(other) {
    return compareRecords(this, other) | 0;
  }

}
setType("Elmish.Bulma.BulmaClasses.TableSpacing", TableSpacing);
class Tag {
  constructor(container, size, color) {
    this.container = container;
    this.size = size;
    this.color = color;
  }

  [FSymbol.reflection]() {
    return {
      type: "Elmish.Bulma.BulmaClasses.Tag",
      interfaces: ["FSharpRecord", "System.IEquatable", "System.IComparable"],
      properties: {
        container: "string",
        size: TagSize,
        color: LevelAndColor
      }
    };
  }

  Equals(other) {
    return equalsRecords(this, other);
  }

  CompareTo(other) {
    return compareRecords(this, other) | 0;
  }

}
setType("Elmish.Bulma.BulmaClasses.Tag", Tag);
class TagSize {
  constructor(isMedium, isLarge) {
    this.isMedium = isMedium;
    this.isLarge = isLarge;
  }

  [FSymbol.reflection]() {
    return {
      type: "Elmish.Bulma.BulmaClasses.TagSize",
      interfaces: ["FSharpRecord", "System.IEquatable", "System.IComparable"],
      properties: {
        isMedium: "string",
        isLarge: "string"
      }
    };
  }

  Equals(other) {
    return equalsRecords(this, other);
  }

  CompareTo(other) {
    return compareRecords(this, other) | 0;
  }

}
setType("Elmish.Bulma.BulmaClasses.TagSize", TagSize);
class Modifiers {
  constructor(size, color) {
    this.size = size;
    this.color = color;
  }

  [FSymbol.reflection]() {
    return {
      type: "Elmish.Bulma.BulmaClasses.Modifiers",
      interfaces: ["FSharpRecord", "System.IEquatable", "System.IComparable"],
      properties: {
        size: StandardSize,
        color: LevelAndColor
      }
    };
  }

  Equals(other) {
    return equalsRecords(this, other);
  }

  CompareTo(other) {
    return compareRecords(this, other) | 0;
  }

}
setType("Elmish.Bulma.BulmaClasses.Modifiers", Modifiers);
class Bulma {
  constructor(modifiers, box, button, content, control, _delete, field, heading, label, progress, icon, image, input, table, tag) {
    this.modifiers = modifiers;
    this.box = box;
    this.button = button;
    this.content = content;
    this.control = control;
    this.delete = _delete;
    this.field = field;
    this.heading = heading;
    this.label = label;
    this.progress = progress;
    this.icon = icon;
    this.image = image;
    this.input = input;
    this.table = table;
    this.tag = tag;
  }

  [FSymbol.reflection]() {
    return {
      type: "Elmish.Bulma.BulmaClasses.Bulma",
      interfaces: ["FSharpRecord", "System.IEquatable", "System.IComparable"],
      properties: {
        modifiers: Modifiers,
        box: Box,
        button: Button,
        content: Content,
        control: Control,
        delete: Delete,
        field: Field,
        heading: Heading,
        label: Label,
        progress: Progress,
        icon: Icon,
        image: Image,
        input: Input,
        table: Table,
        tag: Tag
      }
    };
  }

  Equals(other) {
    return equalsRecords(this, other);
  }

  CompareTo(other) {
    return compareRecords(this, other) | 0;
  }

}
setType("Elmish.Bulma.BulmaClasses.Bulma", Bulma);
const standardSize = new StandardSize("is-small", "is-medium", "is-large ");
const levelAndColor = new LevelAndColor("is-black", "is-dark", "is-light", "is-white", "is-primary", "is-info", "is-success", "is-warning", "is-danger");
const box = new Box("box");
const button = new Button("button", standardSize, levelAndColor, new ButtonState("is-hovered", "is-focus", "is-active", "is-loading"), new ButtonStyles("is-link", "is-outlined", "is-inverted"));
const content = new Content("content", standardSize);
const control = new Control("control", new ControlHasIcon("has-icons-left", "has-icons-right"), new ControlState("is-loading"));

const _delete = new Delete("delete", standardSize);

const field = new Field("field", "field-label", "field-body", new FieldHasAddons("has-addons", "has-addons-centered", "has-addons-right", "has-addons-fullwidth"), new FieldIsGrouped("is-grouped", "is-grouped-centered", "is-grouped-right"), new FieldLayout("is-horizontal"));
const icon$1 = new Icon("icon", new IconPosition("is-left", "is-right"), standardSize);
const input = new Input("input", new InputDisplay("is-inline"), standardSize, new InputState("is-hovered", "is-focus", "is-active", "is-loading"), levelAndColor, new InputAddon("is-expanded"));
const image = new Image("image", new ImageSize("is-16x16", "is-24x24", "is-32x32", "is-48x48", "is-64x64", "is-96x96", "is-128x128"), new ImageRatio("is-square", "is-1by1", "is-4by3", "is-3by2", "is-16by9", "is-2by1"));
const heading = new Heading("title", "subtitle", new HeadingSize("is-1", "is-2", "is-3", "is-4", "is-5", "is-6"), new HeadingSpacing("is-spaced"));
const label = new Label("label", standardSize);
const progress = new Progress("progress", standardSize, levelAndColor);
const table = new Table("table", new TableRow(new TableRowState("is-selected")), new TableStyle("is-bordered", "is-stripped "), new TableSpacing("is-narrow"));
const tagSize = new TagSize("is-medium", "is-large");
const tag = new Tag("tag", tagSize, levelAndColor);
const bulma = (() => {
  const modifiers = new Modifiers(standardSize, levelAndColor);
  return new Bulma(modifiers, box, button, content, control, _delete, field, heading, label, progress, icon$1, image, input, table, tag);
})();
function op_PlusPlus(str1, str2) {
  return str1 + " " + str2;
}

class ISize {
  constructor(tag$$1, data) {
    this.tag = tag$$1;
    this.data = data;
  }

  [FSymbol.reflection]() {
    return {
      type: "Elmish.Bulma.Common.ISize",
      interfaces: ["FSharpUnion", "System.IEquatable", "System.IComparable"],
      cases: [["IsSmall"], ["IsMedium"], ["IsLarge"], ["Nothing"]]
    };
  }

  Equals(other) {
    return this === other || this.tag === other.tag && equals(this.data, other.data);
  }

  CompareTo(other) {
    return compareUnions(this, other) | 0;
  }

}
setType("Elmish.Bulma.Common.ISize", ISize);
class ILevelAndColor {
  constructor(tag$$1, data) {
    this.tag = tag$$1;
    this.data = data;
  }

  [FSymbol.reflection]() {
    return {
      type: "Elmish.Bulma.Common.ILevelAndColor",
      interfaces: ["FSharpUnion", "System.IEquatable", "System.IComparable"],
      cases: [["IsBlack"], ["IsDark"], ["IsLight"], ["IsWhite"], ["IsPrimary"], ["IsInfo"], ["IsSuccess"], ["IsWarning"], ["IsDanger"], ["Nothing"]]
    };
  }

  Equals(other) {
    return this === other || this.tag === other.tag && equals(this.data, other.data);
  }

  CompareTo(other) {
    return compareUnions(this, other) | 0;
  }

}
setType("Elmish.Bulma.Common.ILevelAndColor", ILevelAndColor);
function ofLevelAndColor(level) {
  if (level.tag === 1) {
    return bulma.modifiers.color.isDark;
  } else if (level.tag === 2) {
    return bulma.modifiers.color.isLight;
  } else if (level.tag === 3) {
    return bulma.modifiers.color.isWhite;
  } else if (level.tag === 4) {
    return bulma.modifiers.color.isPrimary;
  } else if (level.tag === 5) {
    return bulma.modifiers.color.isInfo;
  } else if (level.tag === 6) {
    return bulma.modifiers.color.isSuccess;
  } else if (level.tag === 7) {
    return bulma.modifiers.color.isWarning;
  } else if (level.tag === 8) {
    return bulma.modifiers.color.isDanger;
  } else if (level.tag === 9) {
    return "";
  } else {
    return bulma.modifiers.color.isBlack;
  }
}
function ofSize(size) {
  if (size.tag === 1) {
    return bulma.modifiers.size.isMedium;
  } else if (size.tag === 2) {
    return bulma.modifiers.size.isLarge;
  } else if (size.tag === 3) {
    return "";
  } else {
    return bulma.modifiers.size.isSmall;
  }
}

// TODO verify that this matches the behavior of .NET
const parseRadix10 = /^ *([\+\-]?[0-9]+) *$/;
// TODO verify that this matches the behavior of .NET
const parseRadix16 = /^ *([\+\-]?[0-9a-fA-F]+) *$/;
function isValid(s, radix) {
    if (s != null) {
        if (radix === 16) {
            return parseRadix16.exec(s);
        }
        else if (radix <= 10) {
            return parseRadix10.exec(s);
        }
    }
    return null;
}
// TODO does this perfectly match the .NET behavior ?

// Source: https://github.com/dcodeIO/long.js/blob/master/LICENSE
// tslint:disable:curly
// tslint:disable:member-access
// tslint:disable:member-ordering
class Long {
    /**
     * Constructs a 64 bit two's-complement integer, given its low and high 32 bit values as *signed* integers.
     *  See the from* functions below for more convenient ways of constructing Longs.
     * @param {number} low The low (signed) 32 bits of the long
     * @param {number} high The high (signed) 32 bits of the long
     * @param {boolean=} unsigned Whether unsigned or not, defaults to `false` for signed
     */
    constructor(low, high, unsigned) {
        /**
         * Tests if this Long's value equals the specified's. This is an alias of {@link Long#equals}.
         * @param {!Long|number|string} other Other value
         * @returns {boolean}
         */
        this.eq = this.equals;
        /**
         * Tests if this Long's value differs from the specified's. This is an alias of {@link Long#notEquals}.
         * @param {!Long|number|string} other Other value
         * @returns {boolean}
         */
        this.neq = this.notEquals;
        /**
         * Tests if this Long's value is less than the specified's. This is an alias of {@link Long#lessThan}.
         * @param {!Long|number|string} other Other value
         * @returns {boolean}
         */
        this.lt = this.lessThan;
        /**
         * Tests if this Long's value is less than or equal the specified's.
         * This is an alias of {@link Long#lessThanOrEqual}.
         * @param {!Long|number|string} other Other value
         * @returns {boolean}
         */
        this.lte = this.lessThanOrEqual;
        /**
         * Tests if this Long's value is greater than the specified's. This is an alias of {@link Long#greaterThan}.
         * @param {!Long|number|string} other Other value
         * @returns {boolean}
         */
        this.gt = this.greaterThan;
        /**
         * Tests if this Long's value is greater than or equal the specified's.
         * This is an alias of {@link Long#greaterThanOrEqual}.
         * @param {!Long|number|string} other Other value
         * @returns {boolean}
         */
        this.gte = this.greaterThanOrEqual;
        /**
         * Compares this Long's value with the specified's. This is an alias of {@link Long#compare}.
         * @param {!Long|number|string} other Other value
         * @returns {number} 0 if they are the same, 1 if the this is greater and -1
         *  if the given one is greater
         */
        this.comp = this.compare;
        /**
         * Negates this Long's value. This is an alias of {@link Long#negate}.
         * @returns {!Long} Negated Long
         */
        this.neg = this.negate;
        /**
         * Returns this Long's absolute value. This is an alias of {@link Long#absolute}.
         * @returns {!Long} Absolute Long
         */
        this.abs = this.absolute;
        /**
         * Returns the difference of this and the specified  This is an alias of {@link Long#subtract}.
         * @param {!Long|number|string} subtrahend Subtrahend
         * @returns {!Long} Difference
         */
        this.sub = this.subtract;
        /**
         * Returns the product of this and the specified  This is an alias of {@link Long#multiply}.
         * @param {!Long|number|string} multiplier Multiplier
         * @returns {!Long} Product
         */
        this.mul = this.multiply;
        /**
         * Returns this Long divided by the specified. This is an alias of {@link Long#divide}.
         * @param {!Long|number|string} divisor Divisor
         * @returns {!Long} Quotient
         */
        this.div = this.divide;
        /**
         * Returns this Long modulo the specified. This is an alias of {@link Long#modulo}.
         * @param {!Long|number|string} divisor Divisor
         * @returns {!Long} Remainder
         */
        this.mod = this.modulo;
        /**
         * Returns this Long with bits shifted to the left by the given amount. This is an alias of {@link Long#shiftLeft}.
         * @param {number|!Long} numBits Number of bits
         * @returns {!Long} Shifted Long
         */
        this.shl = this.shiftLeft;
        /**
         * Returns this Long with bits arithmetically shifted to the right by the given amount.
         * This is an alias of {@link Long#shiftRight}.
         * @param {number|!Long} numBits Number of bits
         * @returns {!Long} Shifted Long
         */
        this.shr = this.shiftRight;
        /**
         * Returns this Long with bits logically shifted to the right by the given amount.
         * This is an alias of {@link Long#shiftRightUnsigned}.
         * @param {number|!Long} numBits Number of bits
         * @returns {!Long} Shifted Long
         */
        this.shru = this.shiftRightUnsigned;
        // Aliases for compatibility with Fable
        this.Equals = this.equals;
        this.CompareTo = this.compare;
        this.ToString = this.toString;
        this.low = low | 0;
        this.high = high | 0;
        this.unsigned = !!unsigned;
    }
    /**
     * Converts the Long to a 32 bit integer, assuming it is a 32 bit integer.
     * @returns {number}
     */
    toInt() {
        return this.unsigned ? this.low >>> 0 : this.low;
    }
    /**
     * Converts the Long to a the nearest floating-point representation of this value (double, 53 bit mantissa).
     * @returns {number}
     */
    toNumber() {
        if (this.unsigned)
            return ((this.high >>> 0) * TWO_PWR_32_DBL) + (this.low >>> 0);
        return this.high * TWO_PWR_32_DBL + (this.low >>> 0);
    }
    /**
     * Converts the Long to a string written in the specified radix.
     * @param {number=} radix Radix (2-36), defaults to 10
     * @returns {string}
     * @override
     * @throws {RangeError} If `radix` is out of range
     */
    toString(radix = 10) {
        radix = radix || 10;
        if (radix < 2 || 36 < radix)
            throw RangeError("radix");
        if (this.isZero())
            return "0";
        if (this.isNegative()) {
            if (this.eq(MIN_VALUE)) {
                // We need to change the Long value before it can be negated, so we remove
                // the bottom-most digit in this base and then recurse to do the rest.
                const radixLong = fromNumber(radix);
                const div = this.div(radixLong);
                const rem1 = div.mul(radixLong).sub(this);
                return div.toString(radix) + rem1.toInt().toString(radix);
            }
            else
                return "-" + this.neg().toString(radix);
        }
        // Do several (6) digits each time through the loop, so as to
        // minimize the calls to the very expensive emulated div.
        const radixToPower = fromNumber(pow_dbl(radix, 6), this.unsigned);
        let rem = this;
        let result = "";
        while (true) {
            const remDiv = rem.div(radixToPower);
            const intval = rem.sub(remDiv.mul(radixToPower)).toInt() >>> 0;
            let digits = intval.toString(radix);
            rem = remDiv;
            if (rem.isZero())
                return digits + result;
            else {
                while (digits.length < 6)
                    digits = "0" + digits;
                result = "" + digits + result;
            }
        }
    }
    /**
     * Gets the high 32 bits as a signed integer.
     * @returns {number} Signed high bits
     */
    getHighBits() {
        return this.high;
    }
    /**
     * Gets the high 32 bits as an unsigned integer.
     * @returns {number} Unsigned high bits
     */
    getHighBitsUnsigned() {
        return this.high >>> 0;
    }
    /**
     * Gets the low 32 bits as a signed integer.
     * @returns {number} Signed low bits
     */
    getLowBits() {
        return this.low;
    }
    /**
     * Gets the low 32 bits as an unsigned integer.
     * @returns {number} Unsigned low bits
     */
    getLowBitsUnsigned() {
        return this.low >>> 0;
    }
    /**
     * Gets the number of bits needed to represent the absolute value of this
     * @returns {number}
     */
    getNumBitsAbs() {
        if (this.isNegative())
            return this.eq(MIN_VALUE) ? 64 : this.neg().getNumBitsAbs();
        const val = this.high !== 0 ? this.high : this.low;
        let bit;
        for (bit = 31; bit > 0; bit--)
            if ((val & (1 << bit)) !== 0)
                break;
        return this.high !== 0 ? bit + 33 : bit + 1;
    }
    /**
     * Tests if this Long's value equals zero.
     * @returns {boolean}
     */
    isZero() {
        return this.high === 0 && this.low === 0;
    }
    /**
     * Tests if this Long's value is negative.
     * @returns {boolean}
     */
    isNegative() {
        return !this.unsigned && this.high < 0;
    }
    /**
     * Tests if this Long's value is positive.
     * @returns {boolean}
     */
    isPositive() {
        return this.unsigned || this.high >= 0;
    }
    /**
     * Tests if this Long's value is odd.
     * @returns {boolean}
     */
    isOdd() {
        return (this.low & 1) === 1;
    }
    /**
     * Tests if this Long's value is even.
     * @returns {boolean}
     */
    isEven() {
        return (this.low & 1) === 0;
    }
    /**
     * Tests if this Long's value equals the specified's.
     * @param {!Long|number|string} other Other value
     * @returns {boolean}
     */
    equals(other) {
        if (!isLong(other))
            other = fromValue(other);
        if (this.unsigned !== other.unsigned && (this.high >>> 31) === 1 && (other.high >>> 31) === 1)
            return false;
        return this.high === other.high && this.low === other.low;
    }
    /**
     * Tests if this Long's value differs from the specified's.
     * @param {!Long|number|string} other Other value
     * @returns {boolean}
     */
    notEquals(other) {
        return !this.eq(/* validates */ other);
    }
    /**
     * Tests if this Long's value is less than the specified's.
     * @param {!Long|number|string} other Other value
     * @returns {boolean}
     */
    lessThan(other) {
        return this.comp(/* validates */ other) < 0;
    }
    /**
     * Tests if this Long's value is less than or equal the specified's.
     * @param {!Long|number|string} other Other value
     * @returns {boolean}
     */
    lessThanOrEqual(other) {
        return this.comp(/* validates */ other) <= 0;
    }
    /**
     * Tests if this Long's value is greater than the specified's.
     * @param {!Long|number|string} other Other value
     * @returns {boolean}
     */
    greaterThan(other) {
        return this.comp(/* validates */ other) > 0;
    }
    /**
     * Tests if this Long's value is greater than or equal the specified's.
     * @param {!Long|number|string} other Other value
     * @returns {boolean}
     */
    greaterThanOrEqual(other) {
        return this.comp(/* validates */ other) >= 0;
    }
    /**
     * Compares this Long's value with the specified's.
     * @param {!Long|number|string} other Other value
     * @returns {number} 0 if they are the same, 1 if the this is greater and -1
     *  if the given one is greater
     */
    compare(other) {
        if (!isLong(other))
            other = fromValue(other);
        if (this.eq(other))
            return 0;
        const thisNeg = this.isNegative();
        const otherNeg = other.isNegative();
        if (thisNeg && !otherNeg)
            return -1;
        if (!thisNeg && otherNeg)
            return 1;
        // At this point the sign bits are the same
        if (!this.unsigned)
            return this.sub(other).isNegative() ? -1 : 1;
        // Both are positive if at least one is unsigned
        return (other.high >>> 0) > (this.high >>> 0) ||
            (other.high === this.high && (other.low >>> 0) > (this.low >>> 0)) ? -1 : 1;
    }
    /**
     * Negates this Long's value.
     * @returns {!Long} Negated Long
     */
    negate() {
        if (!this.unsigned && this.eq(MIN_VALUE))
            return MIN_VALUE;
        return this.not().add(ONE);
    }
    /**
     * Returns this Long's absolute value.
     * @returns {!Long} Absolute Long
     */
    absolute() {
        if (!this.unsigned && this.isNegative())
            return this.negate();
        else
            return this;
    }
    /**
     * Returns the sum of this and the specified
     * @param {!Long|number|string} addend Addend
     * @returns {!Long} Sum
     */
    add(addend) {
        if (!isLong(addend))
            addend = fromValue(addend);
        // Divide each number into 4 chunks of 16 bits, and then sum the chunks.
        const a48 = this.high >>> 16;
        const a32 = this.high & 0xFFFF;
        const a16 = this.low >>> 16;
        const a00 = this.low & 0xFFFF;
        const b48 = addend.high >>> 16;
        const b32 = addend.high & 0xFFFF;
        const b16 = addend.low >>> 16;
        const b00 = addend.low & 0xFFFF;
        let c48 = 0;
        let c32 = 0;
        let c16 = 0;
        let c00 = 0;
        c00 += a00 + b00;
        c16 += c00 >>> 16;
        c00 &= 0xFFFF;
        c16 += a16 + b16;
        c32 += c16 >>> 16;
        c16 &= 0xFFFF;
        c32 += a32 + b32;
        c48 += c32 >>> 16;
        c32 &= 0xFFFF;
        c48 += a48 + b48;
        c48 &= 0xFFFF;
        return fromBits((c16 << 16) | c00, (c48 << 16) | c32, this.unsigned);
    }
    /**
     * Returns the difference of this and the specified
     * @param {!Long|number|string} subtrahend Subtrahend
     * @returns {!Long} Difference
     */
    subtract(subtrahend) {
        if (!isLong(subtrahend))
            subtrahend = fromValue(subtrahend);
        return this.add(subtrahend.neg());
    }
    /**
     * Returns the product of this and the specified
     * @param {!Long|number|string} multiplier Multiplier
     * @returns {!Long} Product
     */
    multiply(multiplier) {
        if (this.isZero())
            return ZERO;
        if (!isLong(multiplier))
            multiplier = fromValue(multiplier);
        if (multiplier.isZero())
            return ZERO;
        if (this.eq(MIN_VALUE))
            return multiplier.isOdd() ? MIN_VALUE : ZERO;
        if (multiplier.eq(MIN_VALUE))
            return this.isOdd() ? MIN_VALUE : ZERO;
        if (this.isNegative()) {
            if (multiplier.isNegative())
                return this.neg().mul(multiplier.neg());
            else
                return this.neg().mul(multiplier).neg();
        }
        else if (multiplier.isNegative())
            return this.mul(multiplier.neg()).neg();
        // If both longs are small, use float multiplication
        if (this.lt(TWO_PWR_24) && multiplier.lt(TWO_PWR_24))
            return fromNumber(this.toNumber() * multiplier.toNumber(), this.unsigned);
        // Divide each long into 4 chunks of 16 bits, and then add up 4x4 products.
        // We can skip products that would overflow.
        const a48 = this.high >>> 16;
        const a32 = this.high & 0xFFFF;
        const a16 = this.low >>> 16;
        const a00 = this.low & 0xFFFF;
        const b48 = multiplier.high >>> 16;
        const b32 = multiplier.high & 0xFFFF;
        const b16 = multiplier.low >>> 16;
        const b00 = multiplier.low & 0xFFFF;
        let c48 = 0;
        let c32 = 0;
        let c16 = 0;
        let c00 = 0;
        c00 += a00 * b00;
        c16 += c00 >>> 16;
        c00 &= 0xFFFF;
        c16 += a16 * b00;
        c32 += c16 >>> 16;
        c16 &= 0xFFFF;
        c16 += a00 * b16;
        c32 += c16 >>> 16;
        c16 &= 0xFFFF;
        c32 += a32 * b00;
        c48 += c32 >>> 16;
        c32 &= 0xFFFF;
        c32 += a16 * b16;
        c48 += c32 >>> 16;
        c32 &= 0xFFFF;
        c32 += a00 * b32;
        c48 += c32 >>> 16;
        c32 &= 0xFFFF;
        c48 += a48 * b00 + a32 * b16 + a16 * b32 + a00 * b48;
        c48 &= 0xFFFF;
        return fromBits((c16 << 16) | c00, (c48 << 16) | c32, this.unsigned);
    }
    /**
     * Returns this Long divided by the specified. The result is signed if this Long is signed or
     *  unsigned if this Long is unsigned.
     * @param {!Long|number|string} divisor Divisor
     * @returns {!Long} Quotient
     */
    divide(divisor) {
        if (!isLong(divisor))
            divisor = fromValue(divisor);
        if (divisor.isZero())
            throw Error("division by zero");
        if (this.isZero())
            return this.unsigned ? UZERO : ZERO;
        let rem = ZERO;
        let res = ZERO;
        if (!this.unsigned) {
            // This section is only relevant for signed longs and is derived from the
            // closure library as a whole.
            if (this.eq(MIN_VALUE)) {
                if (divisor.eq(ONE) || divisor.eq(NEG_ONE))
                    return MIN_VALUE; // recall that -MIN_VALUE == MIN_VALUE
                else if (divisor.eq(MIN_VALUE))
                    return ONE;
                else {
                    // At this point, we have |other| >= 2, so |this/other| < |MIN_VALUE|.
                    const halfThis = this.shr(1);
                    const approx = halfThis.div(divisor).shl(1);
                    if (approx.eq(ZERO)) {
                        return divisor.isNegative() ? ONE : NEG_ONE;
                    }
                    else {
                        rem = this.sub(divisor.mul(approx));
                        res = approx.add(rem.div(divisor));
                        return res;
                    }
                }
            }
            else if (divisor.eq(MIN_VALUE))
                return this.unsigned ? UZERO : ZERO;
            if (this.isNegative()) {
                if (divisor.isNegative())
                    return this.neg().div(divisor.neg());
                return this.neg().div(divisor).neg();
            }
            else if (divisor.isNegative())
                return this.div(divisor.neg()).neg();
            res = ZERO;
        }
        else {
            // The algorithm below has not been made for unsigned longs. It's therefore
            // required to take special care of the MSB prior to running it.
            if (!divisor.unsigned)
                divisor = divisor.toUnsigned();
            if (divisor.gt(this))
                return UZERO;
            if (divisor.gt(this.shru(1)))
                return UONE;
            res = UZERO;
        }
        // Repeat the following until the remainder is less than other:  find a
        // floating-point that approximates remainder / other *from below*, add this
        // into the result, and subtract it from the remainder.  It is critical that
        // the approximate value is less than or equal to the real value so that the
        // remainder never becomes negative.
        rem = this;
        while (rem.gte(divisor)) {
            // Approximate the result of division. This may be a little greater or
            // smaller than the actual value.
            let approx = Math.max(1, Math.floor(rem.toNumber() / divisor.toNumber()));
            // We will tweak the approximate result by changing it in the 48-th digit or
            // the smallest non-fractional digit, whichever is larger.
            // tslint:disable-next-line:prefer-const
            // tslint:disable-next-line:semicolon
            const log2 = Math.ceil(Math.log(approx) / Math.LN2);
            const delta = (log2 <= 48) ? 1 : pow_dbl(2, log2 - 48);
            // Decrease the approximation until it is smaller than the remainder.  Note
            // that if it is too large, the product overflows and is negative.
            let approxRes = fromNumber(approx);
            let approxRem = approxRes.mul(divisor);
            while (approxRem.isNegative() || approxRem.gt(rem)) {
                approx -= delta;
                approxRes = fromNumber(approx, this.unsigned);
                approxRem = approxRes.mul(divisor);
            }
            // We know the answer can't be zero... and actually, zero would cause
            // infinite recursion since we would make no progress.
            if (approxRes.isZero())
                approxRes = ONE;
            res = res.add(approxRes);
            rem = rem.sub(approxRem);
        }
        return res;
    }
    /**
     * Returns this Long modulo the specified.
     * @param {!Long|number|string} divisor Divisor
     * @returns {!Long} Remainder
     */
    modulo(divisor) {
        if (!isLong(divisor))
            divisor = fromValue(divisor);
        return this.sub(this.div(divisor).mul(divisor));
    }
    /**
     * Returns the bitwise NOT of this
     * @returns {!Long}
     */
    not() {
        return fromBits(~this.low, ~this.high, this.unsigned);
    }
    /**
     * Returns the bitwise AND of this Long and the specified.
     * @param {!Long|number|string} other Other Long
     * @returns {!Long}
     */
    and(other) {
        if (!isLong(other))
            other = fromValue(other);
        return fromBits(this.low & other.low, this.high & other.high, this.unsigned);
    }
    /**
     * Returns the bitwise OR of this Long and the specified.
     * @param {!Long|number|string} other Other Long
     * @returns {!Long}
     */
    or(other) {
        if (!isLong(other))
            other = fromValue(other);
        return fromBits(this.low | other.low, this.high | other.high, this.unsigned);
    }
    /**
     * Returns the bitwise XOR of this Long and the given one.
     * @param {!Long|number|string} other Other Long
     * @returns {!Long}
     */
    xor(other) {
        if (!isLong(other))
            other = fromValue(other);
        return fromBits(this.low ^ other.low, this.high ^ other.high, this.unsigned);
    }
    /**
     * Returns this Long with bits shifted to the left by the given amount.
     * @param {number|!Long} numBits Number of bits
     * @returns {!Long} Shifted Long
     */
    shiftLeft(numBits) {
        if (isLong(numBits))
            numBits = numBits.toInt();
        numBits = numBits & 63;
        if (numBits === 0)
            return this;
        else if (numBits < 32)
            return fromBits(this.low << numBits, (this.high << numBits) | (this.low >>> (32 - numBits)), this.unsigned);
        else
            return fromBits(0, this.low << (numBits - 32), this.unsigned);
    }
    /**
     * Returns this Long with bits arithmetically shifted to the right by the given amount.
     * @param {number|!Long} numBits Number of bits
     * @returns {!Long} Shifted Long
     */
    shiftRight(numBits) {
        if (isLong(numBits))
            numBits = numBits.toInt();
        numBits = numBits & 63;
        if (numBits === 0)
            return this;
        else if (numBits < 32)
            return fromBits((this.low >>> numBits) | (this.high << (32 - numBits)), this.high >> numBits, this.unsigned);
        else
            return fromBits(this.high >> (numBits - 32), this.high >= 0 ? 0 : -1, this.unsigned);
    }
    /**
     * Returns this Long with bits logically shifted to the right by the given amount.
     * @param {number|!Long} numBits Number of bits
     * @returns {!Long} Shifted Long
     */
    shiftRightUnsigned(numBits) {
        if (isLong(numBits))
            numBits = numBits.toInt();
        numBits = numBits & 63;
        if (numBits === 0)
            return this;
        else {
            const high = this.high;
            if (numBits < 32) {
                const low = this.low;
                return fromBits((low >>> numBits) | (high << (32 - numBits)), high >>> numBits, this.unsigned);
            }
            else if (numBits === 32)
                return fromBits(high, 0, this.unsigned);
            else
                return fromBits(high >>> (numBits - 32), 0, this.unsigned);
        }
    }
    /**
     * Converts this Long to signed.
     * @returns {!Long} Signed long
     */
    toSigned() {
        if (!this.unsigned)
            return this;
        return fromBits(this.low, this.high, false);
    }
    /**
     * Converts this Long to unsigned.
     * @returns {!Long} Unsigned long
     */
    toUnsigned() {
        if (this.unsigned)
            return this;
        return fromBits(this.low, this.high, true);
    }
    /**
     * Converts this Long to its byte representation.
     * @param {boolean=} le Whether little or big endian, defaults to big endian
     * @returns {!Array.<number>} Byte representation
     */
    toBytes(le) {
        return le ? this.toBytesLE() : this.toBytesBE();
    }
    /**
     * Converts this Long to its little endian byte representation.
     * @returns {!Array.<number>} Little endian byte representation
     */
    toBytesLE() {
        const hi = this.high;
        const lo = this.low;
        return [
            lo & 0xff,
            (lo >>> 8) & 0xff,
            (lo >>> 16) & 0xff,
            (lo >>> 24) & 0xff,
            hi & 0xff,
            (hi >>> 8) & 0xff,
            (hi >>> 16) & 0xff,
            (hi >>> 24) & 0xff,
        ];
    }
    /**
     * Converts this Long to its big endian byte representation.
     * @returns {!Array.<number>} Big endian byte representation
     */
    toBytesBE() {
        const hi = this.high;
        const lo = this.low;
        return [
            (hi >>> 24) & 0xff,
            (hi >>> 16) & 0xff,
            (hi >>> 8) & 0xff,
            hi & 0xff,
            (lo >>> 24) & 0xff,
            (lo >>> 16) & 0xff,
            (lo >>> 8) & 0xff,
            lo & 0xff,
        ];
    }
    [FSymbol.reflection]() {
        return {
            type: "System.Int64",
            interfaces: ["FSharpRecord", "System.IComparable"],
            properties: {
                low: "number",
                high: "number",
                unsigned: "boolean",
            },
        };
    }
}
// A cache of the Long representations of small integer values.
const INT_CACHE = {};
// A cache of the Long representations of small unsigned integer values.
const UINT_CACHE = {};
/**
 * Tests if the specified object is a
 * @param {*} obj Object
 * @returns {boolean}
 */
function isLong(obj) {
    return (obj && obj instanceof Long);
}
/**
 * Returns a Long representing the given 32 bit integer value.
 * @param {number} value The 32 bit integer in question
 * @param {boolean=} unsigned Whether unsigned or not, defaults to `false` for signed
 * @returns {!Long} The corresponding Long value
 */
function fromInt(value, unsigned = false) {
    let obj;
    let cachedObj;
    let cache = false;
    if (unsigned) {
        value >>>= 0;
        if (0 <= value && value < 256) {
            cache = true;
            cachedObj = UINT_CACHE[value];
            if (cachedObj)
                return cachedObj;
        }
        obj = fromBits(value, (value | 0) < 0 ? -1 : 0, true);
        if (cache)
            UINT_CACHE[value] = obj;
        return obj;
    }
    else {
        value |= 0;
        if (-128 <= value && value < 128) {
            cache = true;
            cachedObj = INT_CACHE[value];
            if (cachedObj)
                return cachedObj;
        }
        obj = fromBits(value, value < 0 ? -1 : 0, false);
        if (cache)
            INT_CACHE[value] = obj;
        return obj;
    }
}
/**
 * Returns a Long representing the given value, provided that it is a finite number. Otherwise, zero is returned.
 * @param {number} value The number in question
 * @param {boolean=} unsigned Whether unsigned or not, defaults to `false` for signed
 * @returns {!Long} The corresponding Long value
 */
function fromNumber(value, unsigned = false) {
    if (isNaN(value) || !isFinite(value)) {
        // TODO FormatException ?
        throw new Error("Input string was not in a correct format.");
    }
    if (unsigned) {
        if (value < 0)
            return UZERO;
        if (value >= TWO_PWR_64_DBL)
            return MAX_UNSIGNED_VALUE;
    }
    else {
        if (value <= -TWO_PWR_63_DBL)
            return MIN_VALUE;
        if (value + 1 >= TWO_PWR_63_DBL)
            return MAX_VALUE;
    }
    if (value < 0)
        return fromNumber(-value, unsigned).neg();
    return fromBits((value % TWO_PWR_32_DBL) | 0, (value / TWO_PWR_32_DBL) | 0, unsigned);
}
/**
 * Returns a Long representing the 64 bit integer that comes by concatenating the given low and high bits. Each is
 *  assumed to use 32 bits.
 * @param {number} lowBits The low 32 bits
 * @param {number} highBits The high 32 bits
 * @param {boolean=} unsigned Whether unsigned or not, defaults to `false` for signed
 * @returns {!Long} The corresponding Long value
 */
function fromBits(lowBits, highBits, unsigned) {
    return new Long(lowBits, highBits, unsigned);
}
/**
 * @param {number} base
 * @param {number} exponent
 * @returns {number}
 */
const pow_dbl = Math.pow; // Used 4 times (4*8 to 15+4)
/**
 * Returns a Long representation of the given string, written using the specified radix.
 * @param {string} str The textual representation of the Long
 * @param {(boolean|number)=} unsigned Whether unsigned or not, defaults to `false` for signed
 * @param {number=} radix The radix in which the text is written (2-36), defaults to 10
 * @returns {!Long} The corresponding Long value
 */
// Used 4 times (4*8 to 15+4)
function fromString(str, unsigned = false, radix = 10) {
    if (isValid(str, radix) === null) {
        // TODO FormatException ?
        throw new Error("Input string was not in a correct format.");
    }
    if (str.length === 0)
        throw Error("empty string");
    if (str === "NaN" || str === "Infinity" || str === "+Infinity" || str === "-Infinity")
        return ZERO;
    if (typeof unsigned === "number") {
        // For goog.math.long compatibility
        radix = unsigned,
            unsigned = false;
    }
    else {
        unsigned = !!unsigned;
    }
    radix = radix || 10;
    if (radix < 2 || 36 < radix)
        throw RangeError("radix");
    const p = str.indexOf("-");
    if (p > 0)
        throw Error("interior hyphen");
    else if (p === 0) {
        return fromString(str.substring(1), unsigned, radix).neg();
    }
    // Do several (8) digits each time through the loop, so as to
    // minimize the calls to the very expensive emulated div.
    const radixToPower = fromNumber(pow_dbl(radix, 8));
    let result = ZERO;
    for (let i = 0; i < str.length; i += 8) {
        const size = Math.min(8, str.length - i);
        const value = parseInt(str.substring(i, i + size), radix);
        if (size < 8) {
            const power = fromNumber(pow_dbl(radix, size));
            result = result.mul(power).add(fromNumber(value));
        }
        else {
            result = result.mul(radixToPower);
            result = result.add(fromNumber(value));
        }
    }
    result.unsigned = unsigned;
    return result;
}
/**
 * Converts the specified value to a
 * @param {!Long|number|string|!{low: number, high: number, unsigned: boolean}} val Value
 * @returns {!Long}
 */
function fromValue(val) {
    if (val /* is compatible */ instanceof Long)
        return val;
    if (typeof val === "number")
        return fromNumber(val);
    if (typeof val === "string")
        return fromString(val);
    // Throws for non-objects, converts non-instanceof Long:
    return fromBits(val.low, val.high, val.unsigned);
}
// NOTE: the compiler should inline these constant values below and then remove these variables, so there should be
// no runtime penalty for these.
const TWO_PWR_16_DBL = 1 << 16;
const TWO_PWR_24_DBL = 1 << 24;
const TWO_PWR_32_DBL = TWO_PWR_16_DBL * TWO_PWR_16_DBL;
const TWO_PWR_64_DBL = TWO_PWR_32_DBL * TWO_PWR_32_DBL;
const TWO_PWR_63_DBL = TWO_PWR_64_DBL / 2;
const TWO_PWR_24 = fromInt(TWO_PWR_24_DBL);
/**
 * Signed zero.
 * @type {!Long}
 */
const ZERO = fromInt(0);
/**
 * Unsigned zero.
 * @type {!Long}
 */
const UZERO = fromInt(0, true);
/**
 * Signed one.
 * @type {!Long}
 */
const ONE = fromInt(1);
/**
 * Unsigned one.
 * @type {!Long}
 */
const UONE = fromInt(1, true);
/**
 * Signed negative one.
 * @type {!Long}
 */
const NEG_ONE = fromInt(-1);
/**
 * Maximum signed value.
 * @type {!Long}
 */
const MAX_VALUE = fromBits(0xFFFFFFFF | 0, 0x7FFFFFFF | 0, false);
/**
 * Maximum unsigned value.
 * @type {!Long}
 */
const MAX_UNSIGNED_VALUE = fromBits(0xFFFFFFFF | 0, 0xFFFFFFFF | 0, true);
/**
 * Minimum signed value.
 * @type {!Long}
 */
const MIN_VALUE = fromBits(0, 0x80000000 | 0, false);

function parse$1(v, kind) {
    if (kind == null) {
        kind = typeof v === "string" && v.slice(-1) === "Z" ? 1 /* UTC */ : 2 /* Local */;
    }
    const date = (v == null) ? new Date() : new Date(v);
    if (kind === 2 /* Local */) {
        date.kind = kind;
    }
    if (isNaN(date.getTime())) {
        throw new Error("The string is not a valid Date.");
    }
    return date;
}


function now() {
    return parse$1();
}











function millisecond(d) {
    return d.kind === 2 /* Local */ ? d.getMilliseconds() : d.getUTCMilliseconds();
}

// From http://stackoverflow.com/questions/3446170/escape-string-for-use-in-javascript-regex
function escape$1(str) {
    return str.replace(/[\-\[\/\{\}\(\)\*\+\?\.\\\^\$\|]/g, "\\$&");
}

const fsFormatRegExp = /(^|[^%])%([0+ ]*)(-?\d+)?(?:\.(\d+))?(\w)/;




function toHex(value) {
    return value < 0
        ? "ff" + (16777215 - (Math.abs(value) - 1)).toString(16)
        : value.toString(16);
}
function fsFormat(str, ...args) {
    function formatOnce(str2, rep) {
        return str2.replace(fsFormatRegExp, (_, prefix, flags, pad, precision, format) => {
            switch (format) {
                case "f":
                case "F":
                    rep = rep.toFixed(precision || 6);
                    break;
                case "g":
                case "G":
                    rep = rep.toPrecision(precision);
                    break;
                case "e":
                case "E":
                    rep = rep.toExponential(precision);
                    break;
                case "O":
                    rep = toString(rep);
                    break;
                case "A":
                    rep = toString(rep, true);
                    break;
                case "x":
                    rep = toHex(Number(rep));
                    break;
                case "X":
                    rep = toHex(Number(rep)).toUpperCase();
                    break;
            }
            const plusPrefix = flags.indexOf("+") >= 0 && parseInt(rep, 10) >= 0;
            pad = parseInt(pad, 10);
            if (!isNaN(pad)) {
                const ch = pad >= 0 && flags.indexOf("0") >= 0 ? "0" : " ";
                rep = padLeft(rep, Math.abs(pad) - (plusPrefix ? 1 : 0), ch, pad < 0);
            }
            const once = prefix + (plusPrefix ? "+" + rep : rep);
            return once.replace(/%/g, "%%");
        });
    }
    if (args.length === 0) {
        return (cont) => {
            if (fsFormatRegExp.test(str)) {
                return (...args2) => {
                    let strCopy = str;
                    for (const arg of args2) {
                        strCopy = formatOnce(strCopy, arg);
                    }
                    return cont(strCopy.replace(/%%/g, "%"));
                };
            }
            else {
                return cont(str);
            }
        };
    }
    else {
        for (const arg of args) {
            str = formatOnce(str, arg);
        }
        return str.replace(/%%/g, "%");
    }
}






function join(delimiter, xs) {
    let xs2 = xs;
    if (typeof xs === "string") {
        const len = arguments.length;
        xs2 = Array(len - 1);
        for (let key = 1; key < len; key++) {
            xs2[key - 1] = arguments[key];
        }
    }
    else if (!Array.isArray(xs)) {
        xs2 = Array.from(xs);
    }
    return xs2.join(delimiter);
}

function padLeft(str, len, ch, isRight) {
    ch = ch || " ";
    str = String(str);
    len = len - str.length;
    for (let i = 0; i < len; i++) {
        str = isRight ? str + ch : ch + str;
    }
    return str;
}





function split(str, splitters, count, removeEmpty) {
    count = typeof count === "number" ? count : null;
    removeEmpty = typeof removeEmpty === "number" ? removeEmpty : null;
    if (count < 0) {
        throw new Error("Count cannot be less than zero");
    }
    if (count === 0) {
        return [];
    }
    let splitters2 = splitters;
    if (!Array.isArray(splitters)) {
        const len = arguments.length;
        splitters2 = Array(len - 1);
        for (let key = 1; key < len; key++) {
            splitters2[key - 1] = arguments[key];
        }
    }
    splitters2 = splitters2.map((x) => escape$1(x));
    splitters2 = splitters2.length > 0 ? splitters2 : [" "];
    let i = 0;
    const splits = [];
    const reg = new RegExp(splitters2.join("|"), "g");
    while (count == null || count > 1) {
        const m = reg.exec(str);
        if (m === null) {
            break;
        }
        if (!removeEmpty || (m.index - i) > 0) {
            count = count != null ? count - 1 : count;
            splits.push(str.substring(i, m.index));
        }
        i = reg.lastIndex;
    }
    if (!removeEmpty || (str.length - i) > 0) {
        splits.push(str.substring(i));
    }
    return splits;
}

const Types = function (__exports) {
  const IPosition = __exports.IPosition = class IPosition {
    constructor(tag$$1, data) {
      this.tag = tag$$1;
      this.data = data;
    }

    [FSymbol.reflection]() {
      return {
        type: "Elmish.Bulma.Elements.Icon.Types.IPosition",
        interfaces: ["FSharpUnion", "System.IEquatable", "System.IComparable"],
        cases: [["Left"], ["Right"]]
      };
    }

    Equals(other) {
      return this === other || this.tag === other.tag && equals(this.data, other.data);
    }

    CompareTo(other) {
      return compareUnions(this, other) | 0;
    }

  };
  setType("Elmish.Bulma.Elements.Icon.Types.IPosition", IPosition);
  const Option$$1 = __exports.Option = class Option$$1 {
    constructor(tag$$1, data) {
      this.tag = tag$$1;
      this.data = data;
    }

    [FSymbol.reflection]() {
      return {
        type: "Elmish.Bulma.Elements.Icon.Types.Option",
        interfaces: ["FSharpUnion", "System.IEquatable", "System.IComparable"],
        cases: [["Size", ISize], ["Position", IPosition]]
      };
    }

    Equals(other) {
      return this === other || this.tag === other.tag && equals(this.data, other.data);
    }

    CompareTo(other) {
      return compareUnions(this, other) | 0;
    }

  };
  setType("Elmish.Bulma.Elements.Icon.Types.Option", Option$$1);
  const Options = __exports.Options = class Options {
    constructor(size, position) {
      this.Size = size;
      this.Position = position;
    }

    [FSymbol.reflection]() {
      return {
        type: "Elmish.Bulma.Elements.Icon.Types.Options",
        interfaces: ["FSharpRecord", "System.IEquatable", "System.IComparable"],
        properties: {
          Size: Option("string"),
          Position: Option("string")
        }
      };
    }

    Equals(other) {
      return equalsRecords(this, other);
    }

    CompareTo(other) {
      return compareRecords(this, other) | 0;
    }

    static get Empty() {
      return new Options(null, null);
    }

  };
  setType("Elmish.Bulma.Elements.Icon.Types.Options", Options);

  const ofPosition = __exports.ofPosition = function (_arg1) {
    if (_arg1.tag === 1) {
      return bulma.icon.position.right;
    } else {
      return bulma.icon.position.left;
    }
  };

  return __exports;
}({});
const isSmall = new Types.Option(0, new ISize(0));
const isMedium = new Types.Option(0, new ISize(1));
const isLarge = new Types.Option(0, new ISize(2));
const isLeft = new Types.Option(1, new Types.IPosition(0));
const isRight = new Types.Option(1, new Types.IPosition(1));
function icon(options, children) {
  const parseOptions = function (result, option) {
    if (option.tag === 1) {
      const Position = Types.ofPosition(option.data);
      return new Types.Options(result.Size, Position);
    } else {
      return new Types.Options(ofSize(option.data), result.Position);
    }
  };

  const opts = (() => {
    const state = Types.Options.Empty;
    return function (list) {
      return fold$1(parseOptions, state, list);
    };
  })()(options);

  return react_1("span", {
    className: join(" ", new List$1(bulma.icon.container, map(function (x) {
      return x;
    }, filter(function (x_1) {
      return (() => x_1 != null)();
    }, ofArray([opts.Size, opts.Position])))))
  }, ...children);
}

function section(model) {
  return sectionBase(model.text, toList$1(docBlock(model.code, react_1("div", {}, react_1("div", {
    className: "block"
  }, icon(ofArray([isSmall]), ofArray([react_1("i", {
    className: "fa fa-home"
  })])), icon(new List$1(), ofArray([react_1("i", {
    className: "fa fa-home"
  })])), icon(ofArray([isMedium]), ofArray([react_1("i", {
    className: "fa fa-home"
  })])), icon(ofArray([isLarge]), ofArray([react_1("i", {
    className: "fa fa-home"
  })])))))));
}
function root$1(model) {
  return react_1("div", {}, section(model));
}

const Types$1 = function (__exports) {
  const ITitleSize = __exports.ITitleSize = class ITitleSize {
    constructor(tag$$1, data) {
      this.tag = tag$$1;
      this.data = data;
    }

    [FSymbol.reflection]() {
      return {
        type: "Elmish.Bulma.Elements.Heading.Types.ITitleSize",
        interfaces: ["FSharpUnion", "System.IEquatable", "System.IComparable"],
        cases: [["Is1"], ["Is2"], ["Is3"], ["Is4"], ["Is5"], ["Is6"]]
      };
    }

    Equals(other) {
      return this === other || this.tag === other.tag && equals(this.data, other.data);
    }

    CompareTo(other) {
      return compareUnions(this, other) | 0;
    }

  };
  setType("Elmish.Bulma.Elements.Heading.Types.ITitleSize", ITitleSize);
  const ITitleType = __exports.ITitleType = class ITitleType {
    constructor(tag$$1, data) {
      this.tag = tag$$1;
      this.data = data;
    }

    [FSymbol.reflection]() {
      return {
        type: "Elmish.Bulma.Elements.Heading.Types.ITitleType",
        interfaces: ["FSharpUnion", "System.IEquatable", "System.IComparable"],
        cases: [["Title"], ["Subtitle"]]
      };
    }

    Equals(other) {
      return this === other || this.tag === other.tag && equals(this.data, other.data);
    }

    CompareTo(other) {
      return compareUnions(this, other) | 0;
    }

  };
  setType("Elmish.Bulma.Elements.Heading.Types.ITitleType", ITitleType);

  const ofTitleSize = __exports.ofTitleSize = function (titleSize) {
    if (titleSize.tag === 1) {
      return bulma.heading.size.is2;
    } else if (titleSize.tag === 2) {
      return bulma.heading.size.is3;
    } else if (titleSize.tag === 3) {
      return bulma.heading.size.is4;
    } else if (titleSize.tag === 4) {
      return bulma.heading.size.is5;
    } else if (titleSize.tag === 5) {
      return bulma.heading.size.is6;
    } else {
      return bulma.heading.size.is1;
    }
  };

  const ofTitleType = __exports.ofTitleType = function (titleType) {
    if (titleType.tag === 1) {
      return bulma.heading.subtitle;
    } else {
      return bulma.heading.title;
    }
  };

  const Option$$1 = __exports.Option = class Option$$1 {
    constructor(tag$$1, data) {
      this.tag = tag$$1;
      this.data = data;
    }

    [FSymbol.reflection]() {
      return {
        type: "Elmish.Bulma.Elements.Heading.Types.Option",
        interfaces: ["FSharpUnion", "System.IEquatable", "System.IComparable"],
        cases: [["Size", ITitleSize], ["Type", ITitleType], ["IsSpaced"]]
      };
    }

    Equals(other) {
      return this === other || this.tag === other.tag && equals(this.data, other.data);
    }

    CompareTo(other) {
      return compareUnions(this, other) | 0;
    }

  };
  setType("Elmish.Bulma.Elements.Heading.Types.Option", Option$$1);
  const Options = __exports.Options = class Options {
    constructor(titleSize, titleType, isSpaced) {
      this.TitleSize = titleSize;
      this.TitleType = titleType;
      this.IsSpaced = isSpaced;
    }

    [FSymbol.reflection]() {
      return {
        type: "Elmish.Bulma.Elements.Heading.Types.Options",
        interfaces: ["FSharpRecord", "System.IEquatable", "System.IComparable"],
        properties: {
          TitleSize: Option("string"),
          TitleType: "string",
          IsSpaced: "boolean"
        }
      };
    }

    Equals(other) {
      return equalsRecords(this, other);
    }

    CompareTo(other) {
      return compareRecords(this, other) | 0;
    }

    static get Empty() {
      return new Options(null, "", false);
    }

  };
  setType("Elmish.Bulma.Elements.Heading.Types.Options", Options);
  return __exports;
}({});
const isTitle = new Types$1.Option(1, new Types$1.ITitleType(0));
const isSubtitle = new Types$1.Option(1, new Types$1.ITitleType(1));
const is1 = new Types$1.Option(0, new Types$1.ITitleSize(0));
const is2 = new Types$1.Option(0, new Types$1.ITitleSize(1));
const is3 = new Types$1.Option(0, new Types$1.ITitleSize(2));
const is4 = new Types$1.Option(0, new Types$1.ITitleSize(3));
const is5 = new Types$1.Option(0, new Types$1.ITitleSize(4));
const is6 = new Types$1.Option(0, new Types$1.ITitleSize(5));
const isSpaced = new Types$1.Option(2);
function title(element, options, children) {
  const parseOption = function (result, opt) {
    if (opt.tag === 1) {
      const TitleType = Types$1.ofTitleType(opt.data);
      return new Types$1.Options(result.TitleSize, TitleType, result.IsSpaced);
    } else if (opt.tag === 2) {
      return new Types$1.Options(result.TitleSize, result.TitleType, true);
    } else {
      return new Types$1.Options(Types$1.ofTitleSize(opt.data), result.TitleType, result.IsSpaced);
    }
  };

  const opts = (() => {
    const state = Types$1.Options.Empty;
    return function (list) {
      return fold$1(parseOption, state, list);
    };
  })()(options);

  const className = classBaseList(join(" ", new List$1(opts.TitleType, map(function (x) {
    return x;
  }, filter(function (x_1) {
    return (() => x_1 != null)();
  }, ofArray([opts.TitleSize]))))), ofArray([[bulma.heading.spacing.isNormal, opts.IsSpaced]]));
  return element(ofArray([className]), children);
}
function h1(options, children) {
  return title(function (b, c) {
    return react_1("h1", createObj(b, 1), ...c);
  }, options, children);
}

function h3(options, children) {
  return title(function (b, c) {
    return react_1("h3", createObj(b, 1), ...c);
  }, options, children);
}


function h6(options, children) {
  return title(function (b, c) {
    return react_1("h6", createObj(b, 1), ...c);
  }, options, children);
}
function p(options, children) {
  return title(function (b, c) {
    return react_1("p", createObj(b, 1), ...c);
  }, options, children);
}

const Types$2 = function (__exports) {
  const Option$$1 = __exports.Option = class Option$$1 {
    constructor(tag$$1, data) {
      this.tag = tag$$1;
      this.data = data;
    }

    [FSymbol.reflection]() {
      return {
        type: "Elmish.Bulma.Elements.Content.Types.Option",
        interfaces: ["FSharpUnion", "System.IEquatable", "System.IComparable"],
        cases: [["Size", ISize]]
      };
    }

    Equals(other) {
      return this === other || this.tag === other.tag && equals(this.data, other.data);
    }

    CompareTo(other) {
      return compareUnions(this, other) | 0;
    }

  };
  setType("Elmish.Bulma.Elements.Content.Types.Option", Option$$1);
  const Options = __exports.Options = class Options {
    constructor(size) {
      this.Size = size;
    }

    [FSymbol.reflection]() {
      return {
        type: "Elmish.Bulma.Elements.Content.Types.Options",
        interfaces: ["FSharpRecord", "System.IEquatable", "System.IComparable"],
        properties: {
          Size: Option("string")
        }
      };
    }

    Equals(other) {
      return equalsRecords(this, other);
    }

    CompareTo(other) {
      return compareRecords(this, other) | 0;
    }

    static get Empty() {
      return new Options(null);
    }

  };
  setType("Elmish.Bulma.Elements.Content.Types.Options", Options);
  return __exports;
}({});
const isSmall$1 = new Types$2.Option(0, new ISize(0));
const isMedium$1 = new Types$2.Option(0, new ISize(1));
const isLarge$1 = new Types$2.Option(0, new ISize(2));
function content$1(options, children) {
  const parseOption = function (result, opt) {
    return new Types$2.Options(ofSize(opt.data));
  };

  const opts = (() => {
    const state = Types$2.Options.Empty;
    return function (list) {
      return fold$1(parseOption, state, list);
    };
  })()(options);

  return react_1("div", {
    className: join(" ", new List$1(bulma.content.container, map(function (x) {
      return x;
    }, filter(function (x_1) {
      return (() => x_1 != null)();
    }, ofArray([opts.Size])))))
  }, ...children);
}

function sectionType(model) {
  return sectionBase(model.typeText, toList$1(docBlock(model.typeCode, react_1("div", {}, react_1("div", {
    className: "block"
  }, h1(new List$1(), ofArray(["Title"])), react_1("br", {}), h3(ofArray([isSubtitle]), ofArray(["Subtitle"])))))));
}
function sectionSize(model) {
  return sectionBase(model.sizeText, toList$1(docBlock(model.sizeCode, react_1("div", {}, react_1("div", {
    className: "block"
  }, h1(ofArray([isTitle, is1]), ofArray(["Title 1"])), h1(ofArray([isTitle, is2]), ofArray(["Title 2"])), h1(ofArray([isTitle, is3]), ofArray(["Title 3 (Default size)"])), h1(ofArray([isTitle, is4]), ofArray(["Title 4"])), h1(ofArray([isTitle, is5]), ofArray(["Title 5"])), h1(ofArray([isTitle, is6]), ofArray(["Title 6"])), react_1("br", {}), h1(ofArray([isSubtitle, is1]), ofArray(["Subtitle 1"])), h1(ofArray([isSubtitle, is2]), ofArray(["Subtitle 2"])), h1(ofArray([isSubtitle, is3]), ofArray(["Subtitle 3"])), h1(ofArray([isSubtitle, is4]), ofArray(["Subtitle 4"])), h1(ofArray([isSubtitle, is5]), ofArray(["Subtitle 5 (Default size)"])), h1(ofArray([isSubtitle, is6]), ofArray(["Subtitle 6"])))))));
}
function sectionExtra(model) {
  return sectionBase(model.spacedText, toList$1(docBlock(model.spacedCode, react_1("div", {}, react_1("div", {
    className: "block"
  }, "Default behavior", p(ofArray([isTitle, is1]), ofArray(["Title 1"])), p(ofArray([isSubtitle, is3]), ofArray(["Subtitle 3"])), react_1("br", {}), "Behavior when using IsSpaced", p(ofArray([isTitle, is1, isSpaced]), ofArray(["Title 1"])), p(ofArray([isSubtitle, is3]), ofArray(["Subtitle 3"])))))));
}
function root$2(model) {
  return react_1("div", {}, content$1(new List$1(), ofArray([renderMarkdown(model.text)])), react_1("hr", {}), sectionType(model), react_1("hr", {}), sectionSize(model), react_1("hr", {}), sectionExtra(model));
}

const Types$3 = function (__exports) {
  const Option$$1 = __exports.Option = class Option$$1 {
    constructor(tag$$1, data) {
      this.tag = tag$$1;
      this.data = data;
    }

    [FSymbol.reflection]() {
      return {
        type: "Elmish.Bulma.Elements.Delete.Types.Option",
        interfaces: ["FSharpUnion", "System.IEquatable"],
        cases: [["Size", ISize], ["Props", makeGeneric(List$1, {
          T: Interface("Fable.Helpers.React.Props.IHTMLProp")
        })]]
      };
    }

    Equals(other) {
      return this === other || this.tag === other.tag && equals(this.data, other.data);
    }

  };
  setType("Elmish.Bulma.Elements.Delete.Types.Option", Option$$1);
  const Options = __exports.Options = class Options {
    constructor(size, props) {
      this.Size = size;
      this.Props = props;
    }

    [FSymbol.reflection]() {
      return {
        type: "Elmish.Bulma.Elements.Delete.Types.Options",
        interfaces: ["FSharpRecord", "System.IEquatable"],
        properties: {
          Size: Option("string"),
          Props: makeGeneric(List$1, {
            T: Interface("Fable.Helpers.React.Props.IHTMLProp")
          })
        }
      };
    }

    Equals(other) {
      return equalsRecords(this, other);
    }

    static get Empty() {
      return new Options(null, new List$1());
    }

  };
  setType("Elmish.Bulma.Elements.Delete.Types.Options", Options);
  return __exports;
}({});
const isSmall$2 = new Types$3.Option(0, new ISize(0));
const isMedium$2 = new Types$3.Option(0, new ISize(1));
const isLarge$2 = new Types$3.Option(0, new ISize(2));


function _delete$1(options, children) {
  const parseOption = function (result, opt) {
    if (opt.tag === 1) {
      return new Types$3.Options(result.Size, opt.data);
    } else {
      return new Types$3.Options(ofSize(opt.data), result.Props);
    }
  };

  const opts = (() => {
    const state = Types$3.Options.Empty;
    return function (list) {
      return fold$1(parseOption, state, list);
    };
  })()(options);

  return react_1("a", createObj(new List$1(new Props.HTMLAttr(22, join(" ", new List$1(bulma.delete.container, map(function (x) {
    return x;
  }, filter(function (x_1) {
    return (() => x_1 != null)();
  }, ofArray([opts.Size])))))), opts.Props), 1), ...children);
}

function section$1(model) {
  return sectionBase(model.text, toList$1(docBlock(model.code, react_1("div", {}, renderMarkdown("Using `a` elements"), react_1("br", {}), react_1("div", {
    className: "block"
  }, _delete$1(ofArray([isSmall$2]), new List$1()), _delete$1(new List$1(), new List$1()), _delete$1(ofArray([isMedium$2]), new List$1()), _delete$1(ofArray([isLarge$2]), new List$1()))))));
}
function root$3(model) {
  return react_1("div", {}, section$1(model));
}

function box_(children) {
  return react_1("div", {
    className: bulma.box.container
  }, ...children);
}

function section$2(model) {
  return sectionBase(model.text, toList$1(docBlock(model.code, react_1("div", {}, react_1("div", {
    className: "block"
  }, box_(ofArray(["Lorem ipsum dolor sit amet, consectetur adipisicing elit\r\n                , sed do eiusmod tempor incididunt ut labore et dolore\r\n                magna aliqua.\r\n                "])))))));
}
function root$4(model) {
  return react_1("div", {}, section$2(model));
}

function section$3(model) {
  return sectionBase(model.sizeText, toList$1(docBlock(model.sizeCode, react_1("div", {}, react_1("div", {
    className: "block"
  }, content$1(new List$1(), ofArray([react_1("h1", {}, "Hello World"), react_1("p", {}, "Lorem ipsum dolor sit amet, consectetur adipiscing elit.\r\n                  Nulla accumsan, metus ultrices eleifend gravida, nulla nunc varius lectus\r\n                  , nec rutrum justo nibh eu lectus. Ut vulputate semper dui. Fusce erat odio\r\n                  , sollicitudin vel erat vel, interdum mattis neque."), react_1("h2", {}, "Second level"), react_1("p", {}, "Curabitur accumsan turpis pharetra ", react_1("strong", {}, "augue tincidunt"), "blandit. Quisque condimentum maximus mi\r\n                  , sit amet commodo arcu rutrum id. Proin pretium urna vel cursus venenatis.\r\n                  Suspendisse potenti. Etiam mattis sem rhoncus lacus dapibus facilisis.\r\n                  Donec at dignissim dui. Ut et neque nisl."), react_1("ul", {}, react_1("li", {}, "In fermentum leo eu lectus mollis, quis dictum mi aliquet."), react_1("li", {}, "Morbi eu nulla lobortis, lobortis est in, fringilla felis."), react_1("li", {}, "Aliquam nec felis in sapien venenatis viverra fermentum nec lectus."), react_1("li", {}, "Ut non enim metus.")), react_1("p", {}, "Sed sagittis enim ac tortor maximus rutrum.\r\n              Nulla facilisi. Donec mattis vulputate risus in luctus.\r\n                Maecenas vestibulum interdum commodo.")]))), react_1("hr", {}), react_1("div", {
    className: "block"
  }, content$1(ofArray([isSmall$1]), ofArray([react_1("h1", {}, "Hello World"), react_1("p", {}, "Lorem ipsum dolor sit amet, consectetur adipiscing elit.\r\n                  Nulla accumsan, metus ultrices eleifend gravida, nulla nunc varius lectus\r\n                  , nec rutrum justo nibh eu lectus. Ut vulputate semper dui. Fusce erat odio\r\n                  , sollicitudin vel erat vel, interdum mattis neque."), react_1("h2", {}, "Second level"), react_1("p", {}, "Curabitur accumsan turpis pharetra ", react_1("strong", {}, "augue tincidunt"), "blandit. Quisque condimentum maximus mi\r\n                  , sit amet commodo arcu rutrum id. Proin pretium urna vel cursus venenatis.\r\n                  Suspendisse potenti. Etiam mattis sem rhoncus lacus dapibus facilisis.\r\n                  Donec at dignissim dui. Ut et neque nisl."), react_1("ul", {}, react_1("li", {}, "In fermentum leo eu lectus mollis, quis dictum mi aliquet."), react_1("li", {}, "Morbi eu nulla lobortis, lobortis est in, fringilla felis."), react_1("li", {}, "Aliquam nec felis in sapien venenatis viverra fermentum nec lectus."), react_1("li", {}, "Ut non enim metus.")), react_1("p", {}, "Sed sagittis enim ac tortor maximus rutrum.\r\n              Nulla facilisi. Donec mattis vulputate risus in luctus.\r\n                Maecenas vestibulum interdum commodo.")])))))));
}
function root$5(model) {
  return react_1("div", {}, content$1(new List$1(), ofArray([renderMarkdown(model.text)])), react_1("hr", {}), section$3(model));
}

const Types$4 = function (__exports) {
  const ITagSize = __exports.ITagSize = class ITagSize {
    constructor(tag$$1, data) {
      this.tag = tag$$1;
      this.data = data;
    }

    [FSymbol.reflection]() {
      return {
        type: "Elmish.Bulma.Elements.Tag.Types.ITagSize",
        interfaces: ["FSharpUnion", "System.IEquatable", "System.IComparable"],
        cases: [["IsMedium"], ["IsLarge"]]
      };
    }

    Equals(other) {
      return this === other || this.tag === other.tag && equals(this.data, other.data);
    }

    CompareTo(other) {
      return compareUnions(this, other) | 0;
    }

  };
  setType("Elmish.Bulma.Elements.Tag.Types.ITagSize", ITagSize);
  const Option$$1 = __exports.Option = class Option$$1 {
    constructor(tag$$1, data) {
      this.tag = tag$$1;
      this.data = data;
    }

    [FSymbol.reflection]() {
      return {
        type: "Elmish.Bulma.Elements.Tag.Types.Option",
        interfaces: ["FSharpUnion", "System.IEquatable"],
        cases: [["Size", ITagSize], ["Color", ILevelAndColor], ["Props", makeGeneric(List$1, {
          T: Interface("Fable.Helpers.React.Props.IHTMLProp")
        })]]
      };
    }

    Equals(other) {
      return this === other || this.tag === other.tag && equals(this.data, other.data);
    }

  };
  setType("Elmish.Bulma.Elements.Tag.Types.Option", Option$$1);

  const ofTagSize = __exports.ofTagSize = function (size) {
    if (size.tag === 1) {
      return bulma.tag.size.isLarge;
    } else {
      return bulma.tag.size.isMedium;
    }
  };

  const Options = __exports.Options = class Options {
    constructor(size, color, props) {
      this.Size = size;
      this.Color = color;
      this.Props = props;
    }

    [FSymbol.reflection]() {
      return {
        type: "Elmish.Bulma.Elements.Tag.Types.Options",
        interfaces: ["FSharpRecord", "System.IEquatable"],
        properties: {
          Size: Option("string"),
          Color: Option("string"),
          Props: makeGeneric(List$1, {
            T: Interface("Fable.Helpers.React.Props.IHTMLProp")
          })
        }
      };
    }

    Equals(other) {
      return equalsRecords(this, other);
    }

    static get Empty() {
      return new Options(null, null, new List$1());
    }

  };
  setType("Elmish.Bulma.Elements.Tag.Types.Options", Options);
  return __exports;
}({});
const isMedium$3 = new Types$4.Option(0, new Types$4.ITagSize(0));
const isLarge$3 = new Types$4.Option(0, new Types$4.ITagSize(1));
const isBlack = new Types$4.Option(1, new ILevelAndColor(0));
const isDark = new Types$4.Option(1, new ILevelAndColor(1));
const isLight = new Types$4.Option(1, new ILevelAndColor(2));
const isWhite = new Types$4.Option(1, new ILevelAndColor(3));
const isPrimary = new Types$4.Option(1, new ILevelAndColor(4));
const isInfo = new Types$4.Option(1, new ILevelAndColor(5));
const isSuccess = new Types$4.Option(1, new ILevelAndColor(6));
const isWarning = new Types$4.Option(1, new ILevelAndColor(7));
const isDanger = new Types$4.Option(1, new ILevelAndColor(8));

function tag$1(options, children) {
  const parseOption = function (result, opt) {
    if (opt.tag === 1) {
      const Color = ofLevelAndColor(opt.data);
      return new Types$4.Options(result.Size, Color, result.Props);
    } else if (opt.tag === 2) {
      return new Types$4.Options(result.Size, result.Color, opt.data);
    } else {
      return new Types$4.Options(Types$4.ofTagSize(opt.data), result.Color, result.Props);
    }
  };

  const opts = (() => {
    const state = Types$4.Options.Empty;
    return function (list) {
      return fold$1(parseOption, state, list);
    };
  })()(options);

  const className = new Props.HTMLAttr(22, join(" ", new List$1(bulma.tag.container, map(function (x) {
    return x;
  }, filter(function (x_1) {
    return (() => x_1 != null)();
  }, ofArray([opts.Size, opts.Color]))))));
  return react_1("span", createObj(new List$1(className, opts.Props), 1), ...children);
}

function section$4(model) {
  return sectionBase(model.text, toList$1(docBlock(model.code, react_1("div", {}, react_1("div", {
    className: "block"
  }, tag$1(new List$1(), ofArray(["Tag label"])))))));
}
function sectionColor(model) {
  return sectionBase(model.colorText, toList$1(docBlock(model.colorCode, react_1("div", {}, react_1("div", {
    className: "block"
  }, tag$1(ofArray([isBlack]), ofArray(["Black"])), tag$1(ofArray([isDark]), ofArray(["Dark"])), tag$1(ofArray([isLight]), ofArray(["Light"])), tag$1(ofArray([isWhite]), ofArray(["White"])), tag$1(ofArray([isPrimary]), ofArray(["Primary"]))), react_1("br", {}), react_1("div", {
    className: "block"
  }, tag$1(ofArray([isInfo]), ofArray(["Info"])), tag$1(ofArray([isSuccess]), ofArray(["Success"])), tag$1(ofArray([isWarning]), ofArray(["Warning"])), tag$1(ofArray([isDanger]), ofArray(["Danger"])))))));
}
function sectionSize$1(model) {
  return sectionBase(model.sizeText, toList$1(docBlock(model.sizeCode, react_1("div", {}, react_1("div", {
    className: "block"
  }, tag$1(ofArray([isSuccess, isMedium$3]), ofArray(["Medium"])), tag$1(ofArray([isInfo, isLarge$3]), ofArray(["Large"])))))));
}
function root$6(model) {
  return react_1("div", {}, section$4(model), react_1("hr", {}), sectionColor(model), react_1("hr", {}), sectionSize$1(model));
}

const Types$5 = function (__exports) {
  const IImageSize = __exports.IImageSize = class IImageSize {
    constructor(tag$$1, data) {
      this.tag = tag$$1;
      this.data = data;
    }

    [FSymbol.reflection]() {
      return {
        type: "Elmish.Bulma.Elements.Image.Types.IImageSize",
        interfaces: ["FSharpUnion", "System.IEquatable", "System.IComparable"],
        cases: [["Is16x16"], ["Is24x24"], ["Is32x32"], ["Is48x48"], ["Is64x64"], ["Is96x96"], ["Is128x128"]]
      };
    }

    Equals(other) {
      return this === other || this.tag === other.tag && equals(this.data, other.data);
    }

    CompareTo(other) {
      return compareUnions(this, other) | 0;
    }

  };
  setType("Elmish.Bulma.Elements.Image.Types.IImageSize", IImageSize);
  const IImageRatio = __exports.IImageRatio = class IImageRatio {
    constructor(tag$$1, data) {
      this.tag = tag$$1;
      this.data = data;
    }

    [FSymbol.reflection]() {
      return {
        type: "Elmish.Bulma.Elements.Image.Types.IImageRatio",
        interfaces: ["FSharpUnion", "System.IEquatable", "System.IComparable"],
        cases: [["IsSquare"], ["Is1by1"], ["Is4by3"], ["Is3by2"], ["Is16by9"], ["Is2by1"]]
      };
    }

    Equals(other) {
      return this === other || this.tag === other.tag && equals(this.data, other.data);
    }

    CompareTo(other) {
      return compareUnions(this, other) | 0;
    }

  };
  setType("Elmish.Bulma.Elements.Image.Types.IImageRatio", IImageRatio);

  const ofImageSize = __exports.ofImageSize = function (_arg1) {
    if (_arg1.tag === 1) {
      return bulma.image.size.is24x24;
    } else if (_arg1.tag === 2) {
      return bulma.image.size.is32x32;
    } else if (_arg1.tag === 3) {
      return bulma.image.size.is48x48;
    } else if (_arg1.tag === 4) {
      return bulma.image.size.is64x64;
    } else if (_arg1.tag === 5) {
      return bulma.image.size.is96x96;
    } else if (_arg1.tag === 6) {
      return bulma.image.size.is128x128;
    } else {
      return bulma.image.size.is16x16;
    }
  };

  const ofImageRatio = __exports.ofImageRatio = function (_arg1) {
    if (_arg1.tag === 1) {
      return bulma.image.ratio.is1by1;
    } else if (_arg1.tag === 2) {
      return bulma.image.ratio.is4by3;
    } else if (_arg1.tag === 3) {
      return bulma.image.ratio.is3by2;
    } else if (_arg1.tag === 4) {
      return bulma.image.ratio.is16by9;
    } else if (_arg1.tag === 5) {
      return bulma.image.ratio.is2by1;
    } else {
      return bulma.image.ratio.isSquare;
    }
  };

  const Option$$1 = __exports.Option = class Option$$1 {
    constructor(tag$$1, data) {
      this.tag = tag$$1;
      this.data = data;
    }

    [FSymbol.reflection]() {
      return {
        type: "Elmish.Bulma.Elements.Image.Types.Option",
        interfaces: ["FSharpUnion", "System.IEquatable", "System.IComparable"],
        cases: [["Size", IImageSize], ["Ratio", IImageRatio]]
      };
    }

    Equals(other) {
      return this === other || this.tag === other.tag && equals(this.data, other.data);
    }

    CompareTo(other) {
      return compareUnions(this, other) | 0;
    }

  };
  setType("Elmish.Bulma.Elements.Image.Types.Option", Option$$1);
  const Options = __exports.Options = class Options {
    constructor(size, ratio) {
      this.Size = size;
      this.Ratio = ratio;
    }

    [FSymbol.reflection]() {
      return {
        type: "Elmish.Bulma.Elements.Image.Types.Options",
        interfaces: ["FSharpRecord", "System.IEquatable", "System.IComparable"],
        properties: {
          Size: Option("string"),
          Ratio: Option("string")
        }
      };
    }

    Equals(other) {
      return equalsRecords(this, other);
    }

    CompareTo(other) {
      return compareRecords(this, other) | 0;
    }

    static get Empty() {
      return new Options(null, null);
    }

  };
  setType("Elmish.Bulma.Elements.Image.Types.Options", Options);
  return __exports;
}({});
const is16x16 = new Types$5.Option(0, new Types$5.IImageSize(0));
const is24x24 = new Types$5.Option(0, new Types$5.IImageSize(1));
const is32x32 = new Types$5.Option(0, new Types$5.IImageSize(2));
const is48x48 = new Types$5.Option(0, new Types$5.IImageSize(3));
const is64x64 = new Types$5.Option(0, new Types$5.IImageSize(4));
const is96x96 = new Types$5.Option(0, new Types$5.IImageSize(5));
const is128x128 = new Types$5.Option(0, new Types$5.IImageSize(6));
const isSquare = new Types$5.Option(1, new Types$5.IImageRatio(0));
const is1by1 = new Types$5.Option(1, new Types$5.IImageRatio(1));
const is4by3 = new Types$5.Option(1, new Types$5.IImageRatio(2));
const is3by2 = new Types$5.Option(1, new Types$5.IImageRatio(3));
const is16by9 = new Types$5.Option(1, new Types$5.IImageRatio(4));
const is2by1 = new Types$5.Option(1, new Types$5.IImageRatio(5));
function image$1(options, children) {
  const parseOptions = function (result, _arg1) {
    if (_arg1.tag === 1) {
      const Ratio = Types$5.ofImageRatio(_arg1.data);
      return new Types$5.Options(result.Size, Ratio);
    } else {
      return new Types$5.Options(Types$5.ofImageSize(_arg1.data), result.Ratio);
    }
  };

  const opts = (() => {
    const state = Types$5.Options.Empty;
    return function (list) {
      return fold$1(parseOptions, state, list);
    };
  })()(options);

  return react_1("figure", {
    className: join(" ", new List$1(bulma.image.container, map(function (x) {
      return x;
    }, filter(function (x_1) {
      return (() => x_1 != null)();
    }, ofArray([opts.Size, opts.Ratio])))))
  }, ...children);
}

function imageDummy(strSize, imageSize) {
  return react_1("div", {}, h6(ofArray([isSubtitle]), ofArray([strSize + "px"])), image$1(ofArray([imageSize]), ofArray([react_1("img", {
    src: fsFormat("https://dummyimage.com/%s/7a7a7a/fff")(x => x)(strSize)
  })])));
}
function sectionSize$2(model) {
  return sectionBase(model.textSize, toList$1(docBlock(model.codeSize, react_1("div", {}, imageDummy("64x64", is64x64), react_1("hr", {}), imageDummy("128x128", is128x128)))));
}
function sectionRatio(model) {
  return sectionBase(model.textRatio, toList$1(docBlock(model.codeRatio, react_1("div", {}, image$1(ofArray([is2by1]), ofArray([react_1("img", {
    src: "https://dummyimage.com/640x320/7a7a7a/fff"
  })]))))));
}
function root$7(model) {
  return react_1("div", {}, content$1(new List$1(), ofArray([renderMarkdown(model.text)])), react_1("hr", {}), sectionSize$2(model), react_1("hr", {}), sectionRatio(model));
}

const Types$6 = function (__exports) {
  const Option$$1 = __exports.Option = class Option$$1 {
    constructor(tag$$1, data) {
      this.tag = tag$$1;
      this.data = data;
    }

    [FSymbol.reflection]() {
      return {
        type: "Elmish.Bulma.Elements.Progress.Types.Option",
        interfaces: ["FSharpUnion", "System.IEquatable"],
        cases: [["Size", ISize], ["Color", ILevelAndColor], ["Props", makeGeneric(List$1, {
          T: Interface("Fable.Helpers.React.Props.IHTMLProp")
        })]]
      };
    }

    Equals(other) {
      return this === other || this.tag === other.tag && equals(this.data, other.data);
    }

  };
  setType("Elmish.Bulma.Elements.Progress.Types.Option", Option$$1);
  const Options = __exports.Options = class Options {
    constructor(size, color, props) {
      this.Size = size;
      this.Color = color;
      this.Props = props;
    }

    [FSymbol.reflection]() {
      return {
        type: "Elmish.Bulma.Elements.Progress.Types.Options",
        interfaces: ["FSharpRecord", "System.IEquatable"],
        properties: {
          Size: Option("string"),
          Color: Option("string"),
          Props: makeGeneric(List$1, {
            T: Interface("Fable.Helpers.React.Props.IHTMLProp")
          })
        }
      };
    }

    Equals(other) {
      return equalsRecords(this, other);
    }

    static get Empty() {
      return new Options(null, null, new List$1());
    }

  };
  setType("Elmish.Bulma.Elements.Progress.Types.Options", Options);
  return __exports;
}({});
const isSmall$3 = new Types$6.Option(0, new ISize(0));
const isMedium$4 = new Types$6.Option(0, new ISize(1));
const isLarge$4 = new Types$6.Option(0, new ISize(2));
const isBlack$1 = new Types$6.Option(1, new ILevelAndColor(0));
const isDark$1 = new Types$6.Option(1, new ILevelAndColor(1));
const isLight$1 = new Types$6.Option(1, new ILevelAndColor(2));
const isWhite$1 = new Types$6.Option(1, new ILevelAndColor(3));
const isPrimary$1 = new Types$6.Option(1, new ILevelAndColor(4));
const isInfo$1 = new Types$6.Option(1, new ILevelAndColor(5));
const isSuccess$1 = new Types$6.Option(1, new ILevelAndColor(6));
const isWarning$1 = new Types$6.Option(1, new ILevelAndColor(7));
const isDanger$1 = new Types$6.Option(1, new ILevelAndColor(8));
function props$2(props_1) {
  return new Types$6.Option(2, props_1);
}
function progress$1(options, children) {
  const parseOptions = function (result, _arg1) {
    if (_arg1.tag === 1) {
      const Color = ofLevelAndColor(_arg1.data);
      return new Types$6.Options(result.Size, Color, result.Props);
    } else if (_arg1.tag === 2) {
      return new Types$6.Options(result.Size, result.Color, _arg1.data);
    } else {
      return new Types$6.Options(ofSize(_arg1.data), result.Color, result.Props);
    }
  };

  const opts = (() => {
    const state = Types$6.Options.Empty;
    return function (list) {
      return fold$1(parseOptions, state, list);
    };
  })()(options);

  return react_1("progress", createObj(new List$1(new Props.HTMLAttr(22, join(" ", new List$1(bulma.progress.container, map(function (x) {
    return x;
  }, filter(function (x_1) {
    return (() => x_1 != null)();
  }, ofArray([opts.Size, opts.Color])))))), opts.Props), 1), ...children);
}

function section$5(model) {
  return sectionBase(model.text, toList$1(docBlock(model.code, react_1("div", {}, progress$1(ofArray([isSuccess$1, isSmall$3, props$2(ofArray([new Props.HTMLAttr(118, "15"), new Props.HTMLAttr(71, "100")]))]), ofArray(["15%"])), progress$1(ofArray([isPrimary$1, isMedium$4, props$2(ofArray([new Props.HTMLAttr(118, "85"), new Props.HTMLAttr(71, "100")]))]), ofArray(["15%"])), progress$1(ofArray([isDanger$1, isLarge$4, props$2(ofArray([new Props.HTMLAttr(118, "50"), new Props.HTMLAttr(71, "100")]))]), ofArray(["15%"]))))));
}
function root$8(model) {
  return react_1("div", {}, section$5(model));
}

const Types$7 = function (__exports) {
  const TableOption = __exports.TableOption = class TableOption {
    constructor(tag$$1, data) {
      this.tag = tag$$1;
      this.data = data;
    }

    [FSymbol.reflection]() {
      return {
        type: "Elmish.Bulma.Elements.Table.Types.TableOption",
        interfaces: ["FSharpUnion", "System.IEquatable", "System.IComparable"],
        cases: [["IsBordered"], ["IsStripped"], ["IsNarrow"]]
      };
    }

    Equals(other) {
      return this === other || this.tag === other.tag && equals(this.data, other.data);
    }

    CompareTo(other) {
      return compareUnions(this, other) | 0;
    }

  };
  setType("Elmish.Bulma.Elements.Table.Types.TableOption", TableOption);
  const TableOptions = __exports.TableOptions = class TableOptions {
    constructor(isBordered, isStripped, isNarrow) {
      this.IsBordered = isBordered;
      this.IsStripped = isStripped;
      this.IsNarrow = isNarrow;
    }

    [FSymbol.reflection]() {
      return {
        type: "Elmish.Bulma.Elements.Table.Types.TableOptions",
        interfaces: ["FSharpRecord", "System.IEquatable", "System.IComparable"],
        properties: {
          IsBordered: "boolean",
          IsStripped: "boolean",
          IsNarrow: "boolean"
        }
      };
    }

    Equals(other) {
      return equalsRecords(this, other);
    }

    CompareTo(other) {
      return compareRecords(this, other) | 0;
    }

    static get Empty() {
      return new TableOptions(false, false, false);
    }

  };
  setType("Elmish.Bulma.Elements.Table.Types.TableOptions", TableOptions);
  return __exports;
}({});
const isBordered = new Types$7.TableOption(0);
const isStripped = new Types$7.TableOption(1);
const isNarrow = new Types$7.TableOption(2);
function table$1(options, children) {
  const parseOptions = function (result, _arg1) {
    if (_arg1.tag === 1) {
      return new Types$7.TableOptions(result.IsBordered, true, result.IsNarrow);
    } else if (_arg1.tag === 2) {
      return new Types$7.TableOptions(result.IsBordered, result.IsStripped, true);
    } else {
      return new Types$7.TableOptions(true, result.IsStripped, result.IsNarrow);
    }
  };

  const opts = (() => {
    const state = Types$7.TableOptions.Empty;
    return function (list) {
      return fold$1(parseOptions, state, list);
    };
  })()(options);

  return react_1("table", createObj(ofArray([classBaseList(bulma.table.container, ofArray([[bulma.table.style.isBordered, opts.IsBordered], [bulma.table.style.isStripped, opts.IsStripped], [bulma.table.spacing.isNarrow, opts.IsNarrow]]))]), 1), ...children);
}
const Row = function (__exports) {
  const isSelected = __exports.isSelected = new Props.HTMLAttr(22, bulma.table.row.state.isSelected);
  return __exports;
}({});

function sectionGeneral(model) {
  return sectionBase(model.generalText, toList$1(docBlock(model.generalCode, table$1(new List$1(), ofArray([react_1("thead", {}, react_1("tr", {}, react_1("th", {}, "Firstname"), react_1("th", {}, "Surname"), react_1("th", {}, "Birthday"))), react_1("tbody", {}, react_1("tr", {}, react_1("td", {}, "Maxime"), react_1("td", {}, "Mangel"), react_1("td", {}, "28/02/1992")), react_1("tr", createObj(ofArray([Row.isSelected]), 1), react_1("td", {}, "Jane"), react_1("td", {}, "Doe"), react_1("td", {}, "21/07/1987")), react_1("tr", {}, react_1("td", {}, "John"), react_1("td", {}, "Doe"), react_1("td", {}, "11/07/1978")))])))));
}
function sectionStyle(model) {
  return sectionBase(model.styleText, toList$1(docBlock(model.styleCode, table$1(ofArray([isBordered, isNarrow, isStripped]), ofArray([react_1("thead", {}, react_1("tr", {}, react_1("th", {}, "Firstname"), react_1("th", {}, "Surname"), react_1("th", {}, "Birthday"))), react_1("tbody", {}, react_1("tr", {}, react_1("td", {}, "Maxime"), react_1("td", {}, "Mangel"), react_1("td", {}, "28/02/1992")), react_1("tr", createObj(ofArray([Row.isSelected]), 1), react_1("td", {}, "Jane"), react_1("td", {}, "Doe"), react_1("td", {}, "21/07/1987")), react_1("tr", {}, react_1("td", {}, "John"), react_1("td", {}, "Doe"), react_1("td", {}, "11/07/1978")))])))));
}
function root$9(model) {
  return react_1("div", {}, sectionGeneral(model), react_1("hr", {}), sectionStyle(model));
}

const Control$1 = function (__exports) {
  const Types = __exports.Types = function (__exports) {
    const IHasIcon = __exports.IHasIcon = class IHasIcon {
      constructor(tag$$1, data) {
        this.tag = tag$$1;
        this.data = data;
      }

      [FSymbol.reflection]() {
        return {
          type: "Elmish.Bulma.Elements.Form.Control.Types.IHasIcon",
          interfaces: ["FSharpUnion", "System.IEquatable", "System.IComparable"],
          cases: [["Left"], ["Right"]]
        };
      }

      Equals(other) {
        return this === other || this.tag === other.tag && equals(this.data, other.data);
      }

      CompareTo(other) {
        return compareUnions(this, other) | 0;
      }

    };
    setType("Elmish.Bulma.Elements.Form.Control.Types.IHasIcon", IHasIcon);
    const Option$$1 = __exports.Option = class Option$$1 {
      constructor(tag$$1, data) {
        this.tag = tag$$1;
        this.data = data;
      }

      [FSymbol.reflection]() {
        return {
          type: "Elmish.Bulma.Elements.Form.Control.Types.Option",
          interfaces: ["FSharpUnion", "System.IEquatable", "System.IComparable"],
          cases: [["HasIcon", IHasIcon], ["IsLoading"]]
        };
      }

      Equals(other) {
        return this === other || this.tag === other.tag && equals(this.data, other.data);
      }

      CompareTo(other) {
        return compareUnions(this, other) | 0;
      }

    };
    setType("Elmish.Bulma.Elements.Form.Control.Types.Option", Option$$1);
    const Options = __exports.Options = class Options {
      constructor(hasIconLeft, hasIconRight, isLoading) {
        this.HasIconLeft = hasIconLeft;
        this.HasIconRight = hasIconRight;
        this.IsLoading = isLoading;
      }

      [FSymbol.reflection]() {
        return {
          type: "Elmish.Bulma.Elements.Form.Control.Types.Options",
          interfaces: ["FSharpRecord", "System.IEquatable", "System.IComparable"],
          properties: {
            HasIconLeft: Option("string"),
            HasIconRight: Option("string"),
            IsLoading: "boolean"
          }
        };
      }

      Equals(other) {
        return equalsRecords(this, other);
      }

      CompareTo(other) {
        return compareRecords(this, other) | 0;
      }

      static get Empty() {
        return new Options(null, null, false);
      }

    };
    setType("Elmish.Bulma.Elements.Form.Control.Types.Options", Options);

    const ofHasIcon = __exports.ofHasIcon = function (_arg1) {
      if (_arg1.tag === 1) {
        return bulma.control.hasIcon.right;
      } else {
        return bulma.control.hasIcon.left;
      }
    };

    return __exports;
  }({});

  const hasIconLeft = __exports.hasIconLeft = new Types.Option(0, new Types.IHasIcon(0));
  const hasIconRight = __exports.hasIconRight = new Types.Option(0, new Types.IHasIcon(1));
  const isLoading = __exports.isLoading = new Types.Option(1);

  const control$$1 = __exports.control = function (options, children) {
    const parseOptions = function (result, _arg1) {
      if (_arg1.tag === 1) {
        return new Types.Options(result.HasIconLeft, result.HasIconRight, true);
      } else if (_arg1.data.tag === 1) {
        const HasIconRight = bulma.control.hasIcon.right;
        return new Types.Options(result.HasIconLeft, HasIconRight, result.IsLoading);
      } else {
        return new Types.Options(bulma.control.hasIcon.left, result.HasIconRight, result.IsLoading);
      }
    };

    const opts = (() => {
      const state = Types.Options.Empty;
      return function (list) {
        return fold$1(parseOptions, state, list);
      };
    })()(options);

    return react_1("p", createObj(ofArray([classBaseList(join(" ", new List$1(bulma.control.container, map(function (x) {
      return x;
    }, filter(function (x_1) {
      return (() => x_1 != null)();
    }, ofArray([opts.HasIconLeft, opts.HasIconRight]))))), ofArray([[bulma.control.state.isLoading, opts.IsLoading]]))]), 1), ...children);
  };

  return __exports;
}({});
const Label$1 = function (__exports) {
  const Types = __exports.Types = function (__exports) {
    const Option$$1 = __exports.Option = class Option$$1 {
      constructor(tag$$1, data) {
        this.tag = tag$$1;
        this.data = data;
      }

      [FSymbol.reflection]() {
        return {
          type: "Elmish.Bulma.Elements.Form.Label.Types.Option",
          interfaces: ["FSharpUnion", "System.IEquatable", "System.IComparable"],
          cases: [["Size", ISize], ["For", "string"]]
        };
      }

      Equals(other) {
        return this === other || this.tag === other.tag && equals(this.data, other.data);
      }

      CompareTo(other) {
        return compareUnions(this, other) | 0;
      }

    };
    setType("Elmish.Bulma.Elements.Form.Label.Types.Option", Option$$1);
    const Options = __exports.Options = class Options {
      constructor(size, htmlFor) {
        this.Size = size;
        this.HtmlFor = htmlFor;
      }

      [FSymbol.reflection]() {
        return {
          type: "Elmish.Bulma.Elements.Form.Label.Types.Options",
          interfaces: ["FSharpRecord", "System.IEquatable", "System.IComparable"],
          properties: {
            Size: Option("string"),
            HtmlFor: Option("string")
          }
        };
      }

      Equals(other) {
        return equalsRecords(this, other);
      }

      CompareTo(other) {
        return compareRecords(this, other) | 0;
      }

      static get Empty() {
        return new Options(null, null);
      }

    };
    setType("Elmish.Bulma.Elements.Form.Label.Types.Options", Options);
    return __exports;
  }({});

  const isSmall = __exports.isSmall = new Types.Option(0, new ISize(0));
  const isMedium = __exports.isMedium = new Types.Option(0, new ISize(1));
  const isLarge = __exports.isLarge = new Types.Option(0, new ISize(2));

  const htmlFor = __exports.htmlFor = function (id) {
    return new Types.Option(1, id);
  };

  const label$$1 = __exports.label = function (options, children) {
    const parseOptions = function (result, _arg1) {
      if (_arg1.tag === 1) {
        const HtmlFor = _arg1.data;
        return new Types.Options(result.Size, HtmlFor);
      } else {
        return new Types.Options(ofSize(_arg1.data), result.HtmlFor);
      }
    };

    const opts = (() => {
      const state = Types.Options.Empty;
      return function (list) {
        return fold$1(parseOptions, state, list);
      };
    })()(options);

    return react_1("label", createObj(toList(delay(function () {
      return append$1(singleton$1(new Props.HTMLAttr(22, join(" ", new List$1(bulma.label.container, map(function (x) {
        return x;
      }, filter(function (x_1) {
        return (() => x_1 != null)();
      }, ofArray([opts.Size]))))))), delay(function () {
        return (() => opts.HtmlFor != null)() ? singleton$1(new Props.HTMLAttr(53, opts.HtmlFor)) : empty();
      }));
    })), 1), ...children);
  };

  return __exports;
}({});
const Select = function (__exports) {
  const Types = __exports.Types = function (__exports) {
    const Option$$1 = __exports.Option = class Option$$1 {
      constructor(tag$$1, data) {
        this.tag = tag$$1;
        this.data = data;
      }

      [FSymbol.reflection]() {
        return {
          type: "Elmish.Bulma.Elements.Form.Select.Types.Option",
          interfaces: ["FSharpUnion", "System.IEquatable"],
          cases: [["Size", ISize], ["Color", ILevelAndColor], ["Id", "string"], ["Disabled", "boolean"], ["Value", "string"], ["DefaultValue", "string"], ["Placeholder", "string"], ["Props", makeGeneric(List$1, {
            T: Interface("Fable.Helpers.React.Props.IHTMLProp")
          })]]
        };
      }

      Equals(other) {
        return this === other || this.tag === other.tag && equals(this.data, other.data);
      }

    };
    setType("Elmish.Bulma.Elements.Form.Select.Types.Option", Option$$1);
    const Options = __exports.Options = class Options {
      constructor(size, color, id, disabled, value, defaultValue, placeholder, props) {
        this.Size = size;
        this.Color = color;
        this.Id = id;
        this.Disabled = disabled;
        this.Value = value;
        this.DefaultValue = defaultValue;
        this.Placeholder = placeholder;
        this.Props = props;
      }

      [FSymbol.reflection]() {
        return {
          type: "Elmish.Bulma.Elements.Form.Select.Types.Options",
          interfaces: ["FSharpRecord", "System.IEquatable"],
          properties: {
            Size: Option("string"),
            Color: Option("string"),
            Id: Option("string"),
            Disabled: "boolean",
            Value: Option("string"),
            DefaultValue: Option("string"),
            Placeholder: Option("string"),
            Props: makeGeneric(List$1, {
              T: Interface("Fable.Helpers.React.Props.IHTMLProp")
            })
          }
        };
      }

      Equals(other) {
        return equalsRecords(this, other);
      }

      static get Empty() {
        return new Options(null, null, null, false, null, null, null, new List$1());
      }

    };
    setType("Elmish.Bulma.Elements.Form.Select.Types.Options", Options);
    return __exports;
  }({});

  return __exports;
}({});
const Input$1 = function (__exports) {
  const Types = __exports.Types = function (__exports) {
    const IInputType = __exports.IInputType = class IInputType {
      constructor(tag$$1, data) {
        this.tag = tag$$1;
        this.data = data;
      }

      [FSymbol.reflection]() {
        return {
          type: "Elmish.Bulma.Elements.Form.Input.Types.IInputType",
          interfaces: ["FSharpUnion", "System.IEquatable", "System.IComparable"],
          cases: [["Text"], ["Password"], ["DatetimeLocal"], ["Date"], ["Month"], ["Time"], ["Week"], ["Number"], ["Email"], ["Url"], ["Search"], ["Tel"], ["Color"]]
        };
      }

      Equals(other) {
        return this === other || this.tag === other.tag && equals(this.data, other.data);
      }

      CompareTo(other) {
        return compareUnions(this, other) | 0;
      }

    };
    setType("Elmish.Bulma.Elements.Form.Input.Types.IInputType", IInputType);
    const Option$$1 = __exports.Option = class Option$$1 {
      constructor(tag$$1, data) {
        this.tag = tag$$1;
        this.data = data;
      }

      [FSymbol.reflection]() {
        return {
          type: "Elmish.Bulma.Elements.Form.Input.Types.Option",
          interfaces: ["FSharpUnion", "System.IEquatable"],
          cases: [["Size", ISize], ["Type", IInputType], ["Color", ILevelAndColor], ["Id", "string"], ["Disabled", "boolean"], ["Value", "string"], ["DefaultValue", "string"], ["Placeholder", "string"], ["Props", makeGeneric(List$1, {
            T: Interface("Fable.Helpers.React.Props.IHTMLProp")
          })]]
        };
      }

      Equals(other) {
        return this === other || this.tag === other.tag && equals(this.data, other.data);
      }

    };
    setType("Elmish.Bulma.Elements.Form.Input.Types.Option", Option$$1);
    const Options = __exports.Options = class Options {
      constructor(size, type, color, id, disabled, value, defaultValue, placeholder, props) {
        this.Size = size;
        this.Type = type;
        this.Color = color;
        this.Id = id;
        this.Disabled = disabled;
        this.Value = value;
        this.DefaultValue = defaultValue;
        this.Placeholder = placeholder;
        this.Props = props;
      }

      [FSymbol.reflection]() {
        return {
          type: "Elmish.Bulma.Elements.Form.Input.Types.Options",
          interfaces: ["FSharpRecord", "System.IEquatable"],
          properties: {
            Size: Option("string"),
            Type: "string",
            Color: Option("string"),
            Id: Option("string"),
            Disabled: "boolean",
            Value: Option("string"),
            DefaultValue: Option("string"),
            Placeholder: Option("string"),
            Props: makeGeneric(List$1, {
              T: Interface("Fable.Helpers.React.Props.IHTMLProp")
            })
          }
        };
      }

      Equals(other) {
        return equalsRecords(this, other);
      }

      static get Empty() {
        return new Options(null, "", null, null, false, null, null, null, new List$1());
      }

    };
    setType("Elmish.Bulma.Elements.Form.Input.Types.Options", Options);

    const ofType = __exports.ofType = function (_arg1) {
      if (_arg1.tag === 1) {
        return "password";
      } else if (_arg1.tag === 2) {
        return "datetime-local";
      } else if (_arg1.tag === 3) {
        return "date";
      } else if (_arg1.tag === 4) {
        return "month";
      } else if (_arg1.tag === 5) {
        return "time";
      } else if (_arg1.tag === 6) {
        return "week";
      } else if (_arg1.tag === 7) {
        return "number";
      } else if (_arg1.tag === 8) {
        return "email";
      } else if (_arg1.tag === 9) {
        return "url";
      } else if (_arg1.tag === 10) {
        return "search";
      } else if (_arg1.tag === 11) {
        return "tel";
      } else if (_arg1.tag === 12) {
        return "color";
      } else {
        return "text";
      }
    };

    return __exports;
  }({});

  const isSmall_1 = __exports.isSmall = new Types.Option(0, new ISize(0));
  const isMedium_1 = __exports.isMedium = new Types.Option(0, new ISize(1));
  const isLarge_1 = __exports.isLarge = new Types.Option(0, new ISize(2));
  const isBlack = __exports.isBlack = new Types.Option(2, new ILevelAndColor(0));
  const isDark = __exports.isDark = new Types.Option(2, new ILevelAndColor(1));
  const isLight = __exports.isLight = new Types.Option(2, new ILevelAndColor(2));
  const isWhite = __exports.isWhite = new Types.Option(2, new ILevelAndColor(3));
  const isPrimary = __exports.isPrimary = new Types.Option(2, new ILevelAndColor(4));
  const isInfo = __exports.isInfo = new Types.Option(2, new ILevelAndColor(5));
  const isSuccess = __exports.isSuccess = new Types.Option(2, new ILevelAndColor(6));
  const isWarning = __exports.isWarning = new Types.Option(2, new ILevelAndColor(7));
  const isDanger = __exports.isDanger = new Types.Option(2, new ILevelAndColor(8));
  const typeIsText = __exports.typeIsText = new Types.Option(1, new Types.IInputType(0));
  const typeIsSassword = __exports.typeIsSassword = new Types.Option(1, new Types.IInputType(1));
  const typeIsDatetimeLocal = __exports.typeIsDatetimeLocal = new Types.Option(1, new Types.IInputType(2));
  const typeIsDate = __exports.typeIsDate = new Types.Option(1, new Types.IInputType(3));
  const typeIsMonth = __exports.typeIsMonth = new Types.Option(1, new Types.IInputType(4));
  const typeIsTime = __exports.typeIsTime = new Types.Option(1, new Types.IInputType(5));
  const typeIsWeek = __exports.typeIsWeek = new Types.Option(1, new Types.IInputType(6));
  const typeIsNumber = __exports.typeIsNumber = new Types.Option(1, new Types.IInputType(7));
  const typeIsEmail = __exports.typeIsEmail = new Types.Option(1, new Types.IInputType(8));
  const typeIsUrl = __exports.typeIsUrl = new Types.Option(1, new Types.IInputType(9));
  const typeIsSearch = __exports.typeIsSearch = new Types.Option(1, new Types.IInputType(10));
  const typeIsTel = __exports.typeIsTel = new Types.Option(1, new Types.IInputType(11));
  const typeIsColor = __exports.typeIsColor = new Types.Option(1, new Types.IInputType(12));

  const id = __exports.id = function (str) {
    return new Types.Option(3, str);
  };

  const disabled = __exports.disabled = function (value) {
    return new Types.Option(4, value);
  };

  const value = __exports.value = function (v) {
    return new Types.Option(5, v);
  };

  const defaultValue = __exports.defaultValue = function (v) {
    return new Types.Option(6, v);
  };

  const placeholder = __exports.placeholder = function (str) {
    return new Types.Option(7, str);
  };

  const props = __exports.props = function (props_1) {
    return new Types.Option(8, props_1);
  };

  const input$$1 = __exports.input = function (options) {
    const parseOptions = function (result, option) {
      if (option.tag === 1) {
        const Type = Types.ofType(option.data);
        return new Types.Options(result.Size, Type, result.Color, result.Id, result.Disabled, result.Value, result.DefaultValue, result.Placeholder, result.Props);
      } else if (option.tag === 2) {
        const Color = ofLevelAndColor(option.data);
        return new Types.Options(result.Size, result.Type, Color, result.Id, result.Disabled, result.Value, result.DefaultValue, result.Placeholder, result.Props);
      } else if (option.tag === 3) {
        const Id = option.data;
        return new Types.Options(result.Size, result.Type, result.Color, Id, result.Disabled, result.Value, result.DefaultValue, result.Placeholder, result.Props);
      } else if (option.tag === 4) {
        return new Types.Options(result.Size, result.Type, result.Color, result.Id, option.data, result.Value, result.DefaultValue, result.Placeholder, result.Props);
      } else if (option.tag === 5) {
        const Value = option.data;
        return new Types.Options(result.Size, result.Type, result.Color, result.Id, result.Disabled, Value, result.DefaultValue, result.Placeholder, result.Props);
      } else if (option.tag === 6) {
        const DefaultValue = option.data;
        return new Types.Options(result.Size, result.Type, result.Color, result.Id, result.Disabled, result.Value, DefaultValue, result.Placeholder, result.Props);
      } else if (option.tag === 7) {
        const Placeholder = option.data;
        return new Types.Options(result.Size, result.Type, result.Color, result.Id, result.Disabled, result.Value, result.DefaultValue, Placeholder, result.Props);
      } else if (option.tag === 8) {
        return new Types.Options(result.Size, result.Type, result.Color, result.Id, result.Disabled, result.Value, result.DefaultValue, result.Placeholder, option.data);
      } else {
        return new Types.Options(ofSize(option.data), result.Type, result.Color, result.Id, result.Disabled, result.Value, result.DefaultValue, result.Placeholder, result.Props);
      }
    };

    const opts = (() => {
      const state = Types.Options.Empty;
      return function (list) {
        return fold$1(parseOptions, state, list);
      };
    })()(options);

    const className = join(" ", new List$1(bulma.input.container, map(function (x) {
      return x;
    }, filter(function (x_1) {
      return (() => x_1 != null)();
    }, ofArray([opts.Size, opts.Color])))));
    return react_1("input", createObj(append(toList(delay(function () {
      return append$1(singleton$1(new Props.HTMLAttr(22, className)), delay(function () {
        return append$1(singleton$1(new Props.HTMLAttr(37, opts.Disabled)), delay(function () {
          return append$1(singleton$1(new Props.HTMLAttr(116, opts.Type)), delay(function () {
            return append$1((() => opts.Id != null)() ? singleton$1(new Props.HTMLAttr(56, opts.Id)) : empty(), delay(function () {
              return append$1((() => opts.Value != null)() ? singleton$1(new Props.HTMLAttr(118, opts.Value)) : empty(), delay(function () {
                return append$1((() => opts.DefaultValue != null)() ? singleton$1(new Props.HTMLAttr(1, opts.DefaultValue)) : empty(), delay(function () {
                  return (() => opts.Placeholder != null)() ? singleton$1(new Props.HTMLAttr(85, opts.Placeholder)) : empty();
                }));
              }));
            }));
          }));
        }));
      }));
    })), opts.Props), 1));
  };

  const text = __exports.text = function (options) {
    return input$$1(new List$1(new Types.Option(1, new Types.IInputType(0)), options));
  };

  const password = __exports.password = function (options) {
    return input$$1(new List$1(new Types.Option(1, new Types.IInputType(1)), options));
  };

  const datetimeLocal = __exports.datetimeLocal = function (options) {
    return input$$1(new List$1(new Types.Option(1, new Types.IInputType(2)), options));
  };

  const date = __exports.date = function (options) {
    return input$$1(new List$1(new Types.Option(1, new Types.IInputType(3)), options));
  };

  const month = __exports.month = function (options) {
    return input$$1(new List$1(new Types.Option(1, new Types.IInputType(4)), options));
  };

  const time = __exports.time = function (options) {
    return input$$1(new List$1(new Types.Option(1, new Types.IInputType(5)), options));
  };

  const week = __exports.week = function (options) {
    return input$$1(new List$1(new Types.Option(1, new Types.IInputType(6)), options));
  };

  const number = __exports.number = function (options) {
    return input$$1(new List$1(new Types.Option(1, new Types.IInputType(7)), options));
  };

  const email = __exports.email = function (options) {
    return input$$1(new List$1(new Types.Option(1, new Types.IInputType(8)), options));
  };

  const url = __exports.url = function (options) {
    return input$$1(new List$1(new Types.Option(1, new Types.IInputType(9)), options));
  };

  const search = __exports.search = function (options) {
    return input$$1(new List$1(new Types.Option(1, new Types.IInputType(10)), options));
  };

  const tel = __exports.tel = function (options) {
    return input$$1(new List$1(new Types.Option(1, new Types.IInputType(11)), options));
  };

  const color = __exports.color = function (options) {
    return input$$1(new List$1(new Types.Option(1, new Types.IInputType(12)), options));
  };

  return __exports;
}({});
const Field$1 = function (__exports) {
  const Types = __exports.Types = function (__exports) {
    const IHasAddons = __exports.IHasAddons = class IHasAddons {
      constructor(tag$$1, data) {
        this.tag = tag$$1;
        this.data = data;
      }

      [FSymbol.reflection]() {
        return {
          type: "Elmish.Bulma.Elements.Form.Field.Types.IHasAddons",
          interfaces: ["FSharpUnion", "System.IEquatable", "System.IComparable"],
          cases: [["Left"], ["Centered"], ["Right"], ["FullWidth"]]
        };
      }

      Equals(other) {
        return this === other || this.tag === other.tag && equals(this.data, other.data);
      }

      CompareTo(other) {
        return compareUnions(this, other) | 0;
      }

    };
    setType("Elmish.Bulma.Elements.Form.Field.Types.IHasAddons", IHasAddons);
    const IIsGrouped = __exports.IIsGrouped = class IIsGrouped {
      constructor(tag$$1, data) {
        this.tag = tag$$1;
        this.data = data;
      }

      [FSymbol.reflection]() {
        return {
          type: "Elmish.Bulma.Elements.Form.Field.Types.IIsGrouped",
          interfaces: ["FSharpUnion", "System.IEquatable", "System.IComparable"],
          cases: [["Left"], ["Centered"], ["Right"]]
        };
      }

      Equals(other) {
        return this === other || this.tag === other.tag && equals(this.data, other.data);
      }

      CompareTo(other) {
        return compareUnions(this, other) | 0;
      }

    };
    setType("Elmish.Bulma.Elements.Form.Field.Types.IIsGrouped", IIsGrouped);
    const ILayout = __exports.ILayout = class ILayout {
      constructor(tag$$1, data) {
        this.tag = tag$$1;
        this.data = data;
      }

      [FSymbol.reflection]() {
        return {
          type: "Elmish.Bulma.Elements.Form.Field.Types.ILayout",
          interfaces: ["FSharpUnion", "System.IEquatable", "System.IComparable"],
          cases: [["Horizontal"]]
        };
      }

      Equals(other) {
        return this === other || this.tag === other.tag && equals(this.data, other.data);
      }

      CompareTo(other) {
        return compareUnions(this, other) | 0;
      }

    };
    setType("Elmish.Bulma.Elements.Form.Field.Types.ILayout", ILayout);
    const Option$$1 = __exports.Option = class Option$$1 {
      constructor(tag$$1, data) {
        this.tag = tag$$1;
        this.data = data;
      }

      [FSymbol.reflection]() {
        return {
          type: "Elmish.Bulma.Elements.Form.Field.Types.Option",
          interfaces: ["FSharpUnion", "System.IEquatable", "System.IComparable"],
          cases: [["HasAddons", IHasAddons], ["IsGrouped", IIsGrouped], ["Layout", ILayout]]
        };
      }

      Equals(other) {
        return this === other || this.tag === other.tag && equals(this.data, other.data);
      }

      CompareTo(other) {
        return compareUnions(this, other) | 0;
      }

    };
    setType("Elmish.Bulma.Elements.Form.Field.Types.Option", Option$$1);
    const Options = __exports.Options = class Options {
      constructor(hasAddons, isGrouped, layout) {
        this.HasAddons = hasAddons;
        this.IsGrouped = isGrouped;
        this.Layout = layout;
      }

      [FSymbol.reflection]() {
        return {
          type: "Elmish.Bulma.Elements.Form.Field.Types.Options",
          interfaces: ["FSharpRecord", "System.IEquatable", "System.IComparable"],
          properties: {
            HasAddons: Option("string"),
            IsGrouped: Option("string"),
            Layout: Option("string")
          }
        };
      }

      Equals(other) {
        return equalsRecords(this, other);
      }

      CompareTo(other) {
        return compareRecords(this, other) | 0;
      }

      static get Empty() {
        return new Options(null, null, null);
      }

    };
    setType("Elmish.Bulma.Elements.Form.Field.Types.Options", Options);

    const ofHasAddons = __exports.ofHasAddons = function (_arg1) {
      if (_arg1.tag === 1) {
        return op_PlusPlus(bulma.field.hasAddons.left, bulma.field.hasAddons.centered);
      } else if (_arg1.tag === 2) {
        return op_PlusPlus(bulma.field.hasAddons.left, bulma.field.hasAddons.right);
      } else if (_arg1.tag === 3) {
        return op_PlusPlus(bulma.field.hasAddons.left, bulma.field.hasAddons.fullWidh);
      } else {
        return bulma.field.hasAddons.left;
      }
    };

    const ofIsGrouped = __exports.ofIsGrouped = function (_arg1) {
      if (_arg1.tag === 1) {
        return op_PlusPlus(bulma.field.isGrouped.left, bulma.field.isGrouped.centered);
      } else if (_arg1.tag === 2) {
        return op_PlusPlus(bulma.field.isGrouped.left, bulma.field.isGrouped.right);
      } else {
        return bulma.field.isGrouped.left;
      }
    };

    const ofLayout = __exports.ofLayout = function (_arg1) {
      return bulma.field.layout.isHorizontal;
    };

    const FieldLabelOption = __exports.FieldLabelOption = class FieldLabelOption {
      constructor(tag$$1, data) {
        this.tag = tag$$1;
        this.data = data;
      }

      [FSymbol.reflection]() {
        return {
          type: "Elmish.Bulma.Elements.Form.Field.Types.FieldLabelOption",
          interfaces: ["FSharpUnion", "System.IEquatable", "System.IComparable"],
          cases: [["Size", ISize]]
        };
      }

      Equals(other) {
        return this === other || this.tag === other.tag && equals(this.data, other.data);
      }

      CompareTo(other) {
        return compareUnions(this, other) | 0;
      }

    };
    setType("Elmish.Bulma.Elements.Form.Field.Types.FieldLabelOption", FieldLabelOption);
    const FieldLabelOptions = __exports.FieldLabelOptions = class FieldLabelOptions {
      constructor(size) {
        this.Size = size;
      }

      [FSymbol.reflection]() {
        return {
          type: "Elmish.Bulma.Elements.Form.Field.Types.FieldLabelOptions",
          interfaces: ["FSharpRecord", "System.IEquatable", "System.IComparable"],
          properties: {
            Size: Option("string")
          }
        };
      }

      Equals(other) {
        return equalsRecords(this, other);
      }

      CompareTo(other) {
        return compareRecords(this, other) | 0;
      }

      static get Empty() {
        return new FieldLabelOptions(null);
      }

    };
    setType("Elmish.Bulma.Elements.Form.Field.Types.FieldLabelOptions", FieldLabelOptions);
    return __exports;
  }({});

  const hasAddonsLeft = __exports.hasAddonsLeft = new Types.Option(0, new Types.IHasAddons(0));
  const hasAddonsCentered = __exports.hasAddonsCentered = new Types.Option(0, new Types.IHasAddons(1));
  const hasAddonsRight = __exports.hasAddonsRight = new Types.Option(0, new Types.IHasAddons(2));
  const hasAddonsFullWidth = __exports.hasAddonsFullWidth = new Types.Option(0, new Types.IHasAddons(3));
  const isGroupedLeft = __exports.isGroupedLeft = new Types.Option(1, new Types.IIsGrouped(0));
  const isGroupedCentered = __exports.isGroupedCentered = new Types.Option(1, new Types.IIsGrouped(1));
  const isGroupedRight = __exports.isGroupedRight = new Types.Option(1, new Types.IIsGrouped(2));
  const isHorizontal = __exports.isHorizontal = new Types.Option(2, new Types.ILayout(0));

  const field$$1 = __exports.field = function (options, children) {
    const parseOptions = function (result, _arg1) {
      if (_arg1.tag === 1) {
        const IsGrouped = Types.ofIsGrouped(_arg1.data);
        return new Types.Options(result.HasAddons, IsGrouped, result.Layout);
      } else if (_arg1.tag === 2) {
        const Layout = Types.ofLayout(_arg1.data);
        return new Types.Options(result.HasAddons, result.IsGrouped, Layout);
      } else {
        return new Types.Options(Types.ofHasAddons(_arg1.data), result.IsGrouped, result.Layout);
      }
    };

    const opts = (() => {
      const state = Types.Options.Empty;
      return function (list) {
        return fold$1(parseOptions, state, list);
      };
    })()(options);

    const className = join(" ", new List$1(bulma.field.container, map(function (x) {
      return x;
    }, filter(function (x_1) {
      return (() => x_1 != null)();
    }, ofArray([opts.HasAddons, opts.IsGrouped, opts.Layout])))));
    return react_1("div", {
      className: className
    }, ...children);
  };

  const isSmall_2 = __exports.isSmall = new Types.FieldLabelOption(0, new ISize(0));
  const isMedium_2 = __exports.isMedium = new Types.FieldLabelOption(0, new ISize(1));
  const isLarge_2 = __exports.isLarge = new Types.FieldLabelOption(0, new ISize(2));

  const label_1 = __exports.label = function (options, children) {
    const parseOptions = function (result, _arg1) {
      return new Types.FieldLabelOptions(ofSize(_arg1.data));
    };

    const opts = (() => {
      const state = Types.FieldLabelOptions.Empty;
      return function (list) {
        return fold$1(parseOptions, state, list);
      };
    })()(options);

    return react_1("div", {
      className: join(" ", new List$1(bulma.field.label, map(function (x) {
        return x;
      }, filter(function (x_1) {
        return (() => x_1 != null)();
      }, ofArray([opts.Size])))))
    }, ...children);
  };

  const body = __exports.body = function (options, children) {
    return react_1("div", {
      className: bulma.field.body
    }, ...children);
  };

  return __exports;
}({});

const Types$8 = function (__exports) {
  const IState = __exports.IState = class IState {
    constructor(tag$$1, data) {
      this.tag = tag$$1;
      this.data = data;
    }

    [FSymbol.reflection]() {
      return {
        type: "Elmish.Bulma.Elements.Button.Types.IState",
        interfaces: ["FSharpUnion", "System.IEquatable", "System.IComparable"],
        cases: [["IsHovered"], ["IsFocused"], ["IsActive"], ["IsLoading"], ["Nothing"]]
      };
    }

    Equals(other) {
      return this === other || this.tag === other.tag && equals(this.data, other.data);
    }

    CompareTo(other) {
      return compareUnions(this, other) | 0;
    }

  };
  setType("Elmish.Bulma.Elements.Button.Types.IState", IState);
  const Option$$1 = __exports.Option = class Option$$1 {
    constructor(tag$$1, data) {
      this.tag = tag$$1;
      this.data = data;
    }

    [FSymbol.reflection]() {
      return {
        type: "Elmish.Bulma.Elements.Button.Types.Option",
        interfaces: ["FSharpUnion", "System.IEquatable"],
        cases: [["Level", ILevelAndColor], ["Size", ISize], ["IsOutlined"], ["IsInverted"], ["IsLink"], ["State", IState], ["Props", makeGeneric(List$1, {
          T: Interface("Fable.Helpers.React.Props.IHTMLProp")
        })]]
      };
    }

    Equals(other) {
      return this === other || this.tag === other.tag && equals(this.data, other.data);
    }

  };
  setType("Elmish.Bulma.Elements.Button.Types.Option", Option$$1);

  const ofStyles = __exports.ofStyles = function (style) {
    if (style.tag === 2) {
      return bulma.button.styles.isOutlined;
    } else if (style.tag === 3) {
      return bulma.button.styles.isInverted;
    } else if (style.tag === 4) {
      return bulma.button.styles.isLink;
    } else {
      return fsFormat("%A isn't a valid style value")(x => {
        throw new Error(x);
      })(style);
    }
  };

  const ofState = __exports.ofState = function (state) {
    if (state.tag === 0) {
      return bulma.button.state.isHovered;
    } else if (state.tag === 1) {
      return bulma.button.state.isFocused;
    } else if (state.tag === 2) {
      return bulma.button.state.isActive;
    } else if (state.tag === 3) {
      return bulma.button.state.isLoading;
    } else {
      return "";
    }
  };

  const Options = __exports.Options = class Options {
    constructor(level, size, isOutlined, isInverted, isLink, state, props) {
      this.Level = level;
      this.Size = size;
      this.IsOutlined = isOutlined;
      this.IsInverted = isInverted;
      this.IsLink = isLink;
      this.State = state;
      this.Props = props;
    }

    [FSymbol.reflection]() {
      return {
        type: "Elmish.Bulma.Elements.Button.Types.Options",
        interfaces: ["FSharpRecord", "System.IEquatable"],
        properties: {
          Level: Option("string"),
          Size: Option("string"),
          IsOutlined: "boolean",
          IsInverted: "boolean",
          IsLink: "boolean",
          State: Option("string"),
          Props: makeGeneric(List$1, {
            T: Interface("Fable.Helpers.React.Props.IHTMLProp")
          })
        }
      };
    }

    Equals(other) {
      return equalsRecords(this, other);
    }

    static get Empty() {
      return new Options(null, null, false, false, false, null, new List$1());
    }

  };
  setType("Elmish.Bulma.Elements.Button.Types.Options", Options);
  return __exports;
}({});
const isSmall$4 = new Types$8.Option(1, new ISize(0));
const isMedium$5 = new Types$8.Option(1, new ISize(1));
const isLarge$5 = new Types$8.Option(1, new ISize(2));
const isHovered = new Types$8.Option(5, new Types$8.IState(0));
const isFocused = new Types$8.Option(5, new Types$8.IState(1));
const isActive = new Types$8.Option(5, new Types$8.IState(2));
const isLoading = new Types$8.Option(5, new Types$8.IState(3));
const isOutlined = new Types$8.Option(2);
const isInverted = new Types$8.Option(3);
const isLink = new Types$8.Option(4);
const isBlack$2 = new Types$8.Option(0, new ILevelAndColor(0));
const isDark$2 = new Types$8.Option(0, new ILevelAndColor(1));
const isLight$2 = new Types$8.Option(0, new ILevelAndColor(2));
const isWhite$2 = new Types$8.Option(0, new ILevelAndColor(3));
const isPrimary$2 = new Types$8.Option(0, new ILevelAndColor(4));
const isInfo$2 = new Types$8.Option(0, new ILevelAndColor(5));
const isSuccess$2 = new Types$8.Option(0, new ILevelAndColor(6));
const isWarning$2 = new Types$8.Option(0, new ILevelAndColor(7));
const isDanger$2 = new Types$8.Option(0, new ILevelAndColor(8));

function button$1(options, children) {
  const parseOptions = function (options_1, result) {
    if (options_1.tail == null) {
      return result;
    } else {
      return ($var1 => parseOptions(options_1.tail, $var1))(options_1.head.tag === 1 ? (() => {
        const Size = ofSize(options_1.head.data);
        return new Types$8.Options(result.Level, Size, result.IsOutlined, result.IsInverted, result.IsLink, result.State, result.Props);
      })() : options_1.head.tag === 2 ? new Types$8.Options(result.Level, result.Size, true, result.IsInverted, result.IsLink, result.State, result.Props) : options_1.head.tag === 3 ? new Types$8.Options(result.Level, result.Size, result.IsOutlined, true, result.IsLink, result.State, result.Props) : options_1.head.tag === 4 ? new Types$8.Options(result.Level, result.Size, result.IsOutlined, result.IsInverted, true, result.State, result.Props) : options_1.head.tag === 5 ? (() => {
        const State = Types$8.ofState(options_1.head.data);
        return new Types$8.Options(result.Level, result.Size, result.IsOutlined, result.IsInverted, result.IsLink, State, result.Props);
      })() : options_1.head.tag === 6 ? new Types$8.Options(result.Level, result.Size, result.IsOutlined, result.IsInverted, result.IsLink, result.State, options_1.head.data) : new Types$8.Options(ofLevelAndColor(options_1.head.data), result.Size, result.IsOutlined, result.IsInverted, result.IsLink, result.State, result.Props));
    }
  };

  const opts = parseOptions(options, Types$8.Options.Empty);
  return react_1("a", createObj(new List$1(classBaseList(join(" ", new List$1(bulma.button.container, map(function (x) {
    return x;
  }, filter(function (x_1) {
    return (() => x_1 != null)();
  }, ofArray([opts.Level, opts.Size, opts.State]))))), ofArray([[bulma.button.styles.isOutlined, opts.IsOutlined], [bulma.button.styles.isInverted, opts.IsInverted], [bulma.button.styles.isLink, opts.IsLink]])), opts.Props), 1), ...children);
}

function sectionColor$1(model) {
  return sectionBase(model.textColor, toList$1(docBlock(model.codeColor, react_1("div", {}, Field$1.field(new List$1(), ofArray([Label$1.label(new List$1(), ofArray(["Name"])), Control$1.control(new List$1(), ofArray([Input$1.text(ofArray([Input$1.placeholder("Text input")]))]))])), Field$1.field(new List$1(), ofArray([Label$1.label(new List$1(), ofArray(["Username"])), Control$1.control(ofArray([Control$1.hasIconLeft, Control$1.hasIconRight]), ofArray([Input$1.text(ofArray([Input$1.isSuccess, Input$1.placeholder("Text input"), Input$1.value("bulma")])), icon(ofArray([isSmall, isLeft]), ofArray([react_1("i", {
    className: "fa fa-user"
  })])), icon(ofArray([isSmall, isRight]), ofArray([react_1("i", {
    className: "fa fa-check"
  })])), react_1("p", {
    className: "help is-success"
  }, "This username is available")]))])), Field$1.field(new List$1(), ofArray([Label$1.label(new List$1(), ofArray(["Email"])), Control$1.control(ofArray([Control$1.hasIconLeft, Control$1.hasIconRight]), ofArray([Input$1.email(ofArray([Input$1.isDanger, Input$1.placeholder("Email input"), Input$1.value("hello@")])), icon(ofArray([isSmall, isLeft]), ofArray([react_1("i", {
    className: "fa fa-envelope"
  })])), icon(ofArray([isSmall, isRight]), ofArray([react_1("i", {
    className: "fa fa-warning"
  })])), react_1("p", {
    className: "help is-danger"
  }, "This email is invalid")]))]))))));
}
function sectionSize$3(model) {
  return sectionBase(model.textSize, toList$1(docBlock(model.codeSize, react_1("div", {
    className: "block"
  }, button$1(ofArray([isSmall$4]), ofArray(["Small"])), button$1(new List$1(), ofArray(["Normal"])), button$1(ofArray([isMedium$5]), ofArray(["Medium"])), button$1(ofArray([isLarge$5]), ofArray(["Large"]))))));
}
function sectionStyle$1(model) {
  return sectionBase(model.textStyle, map(function (tupledArg) {
    return docBlock(tupledArg[1], tupledArg[0]);
  }, ofArray([[react_1("div", {
    className: "block"
  }, button$1(ofArray([isOutlined]), ofArray(["Outlined"])), button$1(ofArray([isSuccess$2, isOutlined]), ofArray(["Outlined"])), button$1(ofArray([isPrimary$2, isOutlined]), ofArray(["Outlined"])), button$1(ofArray([isInfo$2, isOutlined]), ofArray(["Outlined"])), button$1(ofArray([isDark$2, isOutlined]), ofArray(["Outlined"]))), model.codeStyleOutlined], [react_1("div", {
    className: "block callout is-primary"
  }, button$1(ofArray([isOutlined]), ofArray(["Outlined"])), button$1(ofArray([isSuccess$2, isInverted]), ofArray(["Inverted"])), button$1(ofArray([isPrimary$2, isInverted]), ofArray(["Inverted"])), button$1(ofArray([isInfo$2, isInverted]), ofArray(["Inverted"])), button$1(ofArray([isDark$2, isInverted]), ofArray(["Inverted"]))), model.codeStyleInverted], [react_1("div", {}, react_1("div", {
    className: "block callout is-success"
  }, button$1(ofArray([isOutlined, isInverted]), ofArray(["Invert Outlined"])), button$1(ofArray([isSuccess$2, isOutlined, isInverted]), ofArray(["Invert outlined"])), button$1(ofArray([isPrimary$2, isOutlined, isInverted]), ofArray(["Invert outlined"])))), model.codeStyleInvertOutlined]])));
}
function sectionState(model) {
  return sectionBase(model.textState, toList$1(docBlock(model.codeState, react_1("div", {
    className: "block"
  }, button$1(ofArray([isSuccess$2]), ofArray(["Normal"])), button$1(ofArray([isHovered, isSuccess$2]), ofArray(["Hover"])), button$1(ofArray([isFocused, isSuccess$2]), ofArray(["Hover"])), button$1(ofArray([isActive, isSuccess$2]), ofArray(["Hover"])), button$1(ofArray([isLoading, isSuccess$2]), ofArray(["Hover"]))))));
}
function root$10(model) {
  return react_1("div", {}, sectionColor$1(model), react_1("hr", {}), sectionSize$3(model), react_1("hr", {}), sectionStyle$1(model), react_1("hr", {}), sectionState(model));
}

function sectionColor$2(model) {
  return sectionBase(model.textColor, toList$1(docBlock(model.codeColor, react_1("div", {}, react_1("div", {
    className: "block"
  }, button$1(new List$1(), ofArray(["Button"])), button$1(ofArray([isWhite$2]), ofArray(["White"])), button$1(ofArray([isLight$2]), ofArray(["Light"])), button$1(ofArray([isDark$2]), ofArray(["Dark"])), button$1(ofArray([isBlack$2]), ofArray(["Black"])), button$1(ofArray([isLink]), ofArray(["Link"]))), react_1("div", {
    className: "block"
  }, button$1(ofArray([isPrimary$2]), ofArray(["Primary"])), button$1(ofArray([isInfo$2]), ofArray(["Info"])), button$1(ofArray([isSuccess$2]), ofArray(["Success"])), button$1(ofArray([isWarning$2]), ofArray(["Warning"])), button$1(ofArray([isDanger$2]), ofArray(["Danger"])))))));
}
function sectionSize$4(model) {
  return sectionBase(model.textSize, toList$1(docBlock(model.codeSize, react_1("div", {
    className: "block"
  }, button$1(ofArray([isSmall$4]), ofArray(["Small"])), button$1(new List$1(), ofArray(["Normal"])), button$1(ofArray([isMedium$5]), ofArray(["Medium"])), button$1(ofArray([isLarge$5]), ofArray(["Large"]))))));
}
function sectionStyle$2(model) {
  return sectionBase(model.textStyle, map(function (tupledArg) {
    return docBlock(tupledArg[1], tupledArg[0]);
  }, ofArray([[react_1("div", {
    className: "block"
  }, button$1(ofArray([isOutlined]), ofArray(["Outlined"])), button$1(ofArray([isSuccess$2, isOutlined]), ofArray(["Outlined"])), button$1(ofArray([isPrimary$2, isOutlined]), ofArray(["Outlined"])), button$1(ofArray([isInfo$2, isOutlined]), ofArray(["Outlined"])), button$1(ofArray([isDark$2, isOutlined]), ofArray(["Outlined"]))), model.codeStyleOutlined], [react_1("div", {
    className: "block callout is-primary"
  }, button$1(ofArray([isOutlined]), ofArray(["Outlined"])), button$1(ofArray([isSuccess$2, isInverted]), ofArray(["Inverted"])), button$1(ofArray([isPrimary$2, isInverted]), ofArray(["Inverted"])), button$1(ofArray([isInfo$2, isInverted]), ofArray(["Inverted"])), button$1(ofArray([isDark$2, isInverted]), ofArray(["Inverted"]))), model.codeStyleInverted], [react_1("div", {}, react_1("div", {
    className: "block callout is-success"
  }, button$1(ofArray([isOutlined, isInverted]), ofArray(["Invert Outlined"])), button$1(ofArray([isSuccess$2, isOutlined, isInverted]), ofArray(["Invert outlined"])), button$1(ofArray([isPrimary$2, isOutlined, isInverted]), ofArray(["Invert outlined"])))), model.codeStyleInvertOutlined]])));
}
function sectionState$1(model) {
  return sectionBase(model.textState, toList$1(docBlock(model.codeState, react_1("div", {
    className: "block"
  }, button$1(ofArray([isSuccess$2]), ofArray(["Normal"])), button$1(ofArray([isHovered, isSuccess$2]), ofArray(["Hover"])), button$1(ofArray([isFocused, isSuccess$2]), ofArray(["Hover"])), button$1(ofArray([isActive, isSuccess$2]), ofArray(["Hover"])), button$1(ofArray([isLoading, isSuccess$2]), ofArray(["Hover"]))))));
}
function root$11(model) {
  return react_1("div", {}, sectionColor$2(model), react_1("hr", {}), sectionSize$4(model), react_1("hr", {}), sectionStyle$2(model), react_1("hr", {}), sectionState$1(model));
}

class Msg {
  constructor(tag, data) {
    this.tag = tag;
    this.data = data;
  }

  [FSymbol.reflection]() {
    return {
      type: "Home.Types.Msg",
      interfaces: ["FSharpUnion", "System.IEquatable", "System.IComparable"],
      cases: [["ChangeStr", "string"]]
    };
  }

  Equals(other) {
    return this === other || this.tag === other.tag && equals(this.data, other.data);
  }

  CompareTo(other) {
    return compareUnions(this, other) | 0;
  }

}
setType("Home.Types.Msg", Msg);

function root$12(model, dispatch) {
  return react_1("div", {}, react_1("p", {
    className: "control"
  }, react_1("input", {
    className: "input",
    type: "text",
    placeholder: "Type your name",
    defaultValue: model,
    autoFocus: true,
    onChange: function (ev) {
      dispatch(new Msg(0, ev.target.value));
    }
  })), react_1("br", {}), react_1("span", {}, fsFormat("Hello %s")(x => x)(model)));
}

class Model$1 {
  constructor(textColor, codeColor, textSize, codeSize, textStyle, codeStyleOutlined, codeStyleInverted, codeStyleInvertOutlined, textState, codeState) {
    this.textColor = textColor;
    this.codeColor = codeColor;
    this.textSize = textSize;
    this.codeSize = codeSize;
    this.textStyle = textStyle;
    this.codeStyleOutlined = codeStyleOutlined;
    this.codeStyleInverted = codeStyleInverted;
    this.codeStyleInvertOutlined = codeStyleInvertOutlined;
    this.textState = textState;
    this.codeState = codeState;
  }

  [FSymbol.reflection]() {
    return {
      type: "Elements.Button.Types.Model",
      interfaces: ["FSharpRecord", "System.IEquatable", "System.IComparable"],
      properties: {
        textColor: "string",
        codeColor: "string",
        textSize: "string",
        codeSize: "string",
        textStyle: "string",
        codeStyleOutlined: "string",
        codeStyleInverted: "string",
        codeStyleInvertOutlined: "string",
        textState: "string",
        codeState: "string"
      }
    };
  }

  Equals(other) {
    return equalsRecords(this, other);
  }

  CompareTo(other) {
    return compareRecords(this, other) | 0;
  }

}
setType("Elements.Button.Types.Model", Model$1);

class Model$2 {
  constructor(text, code) {
    this.text = text;
    this.code = code;
  }

  [FSymbol.reflection]() {
    return {
      type: "Elements.Icon.Types.Model",
      interfaces: ["FSharpRecord", "System.IEquatable", "System.IComparable"],
      properties: {
        text: "string",
        code: "string"
      }
    };
  }

  Equals(other) {
    return equalsRecords(this, other);
  }

  CompareTo(other) {
    return compareRecords(this, other) | 0;
  }

}
setType("Elements.Icon.Types.Model", Model$2);

class Model$3 {
  constructor(text, textSize, codeSize, textRatio, codeRatio) {
    this.text = text;
    this.textSize = textSize;
    this.codeSize = codeSize;
    this.textRatio = textRatio;
    this.codeRatio = codeRatio;
  }

  [FSymbol.reflection]() {
    return {
      type: "Elements.Image.Types.Model",
      interfaces: ["FSharpRecord", "System.IEquatable", "System.IComparable"],
      properties: {
        text: "string",
        textSize: "string",
        codeSize: "string",
        textRatio: "string",
        codeRatio: "string"
      }
    };
  }

  Equals(other) {
    return equalsRecords(this, other);
  }

  CompareTo(other) {
    return compareRecords(this, other) | 0;
  }

}
setType("Elements.Image.Types.Model", Model$3);

class Model$4 {
  constructor(text, code) {
    this.text = text;
    this.code = code;
  }

  [FSymbol.reflection]() {
    return {
      type: "Elements.Progress.Types.Model",
      interfaces: ["FSharpRecord", "System.IEquatable", "System.IComparable"],
      properties: {
        text: "string",
        code: "string"
      }
    };
  }

  Equals(other) {
    return equalsRecords(this, other);
  }

  CompareTo(other) {
    return compareRecords(this, other) | 0;
  }

}
setType("Elements.Progress.Types.Model", Model$4);

class Model$5 {
  constructor(generalText, generalCode, styleText, styleCode) {
    this.generalText = generalText;
    this.generalCode = generalCode;
    this.styleText = styleText;
    this.styleCode = styleCode;
  }

  [FSymbol.reflection]() {
    return {
      type: "Elements.Table.Types.Model",
      interfaces: ["FSharpRecord", "System.IEquatable", "System.IComparable"],
      properties: {
        generalText: "string",
        generalCode: "string",
        styleText: "string",
        styleCode: "string"
      }
    };
  }

  Equals(other) {
    return equalsRecords(this, other);
  }

  CompareTo(other) {
    return compareRecords(this, other) | 0;
  }

}
setType("Elements.Table.Types.Model", Model$5);

class Model$6 {
  constructor(textColor, codeColor, textSize, codeSize, textStyle, codeStyleOutlined, codeStyleInverted, codeStyleInvertOutlined, textState, codeState) {
    this.textColor = textColor;
    this.codeColor = codeColor;
    this.textSize = textSize;
    this.codeSize = codeSize;
    this.textStyle = textStyle;
    this.codeStyleOutlined = codeStyleOutlined;
    this.codeStyleInverted = codeStyleInverted;
    this.codeStyleInvertOutlined = codeStyleInvertOutlined;
    this.textState = textState;
    this.codeState = codeState;
  }

  [FSymbol.reflection]() {
    return {
      type: "Elements.Form.Types.Model",
      interfaces: ["FSharpRecord", "System.IEquatable", "System.IComparable"],
      properties: {
        textColor: "string",
        codeColor: "string",
        textSize: "string",
        codeSize: "string",
        textStyle: "string",
        codeStyleOutlined: "string",
        codeStyleInverted: "string",
        codeStyleInvertOutlined: "string",
        textState: "string",
        codeState: "string"
      }
    };
  }

  Equals(other) {
    return equalsRecords(this, other);
  }

  CompareTo(other) {
    return compareRecords(this, other) | 0;
  }

}
setType("Elements.Form.Types.Model", Model$6);

class Model$7 {
  constructor(text, typeText, typeCode, sizeText, sizeCode, spacedText, spacedCode) {
    this.text = text;
    this.typeText = typeText;
    this.typeCode = typeCode;
    this.sizeText = sizeText;
    this.sizeCode = sizeCode;
    this.spacedText = spacedText;
    this.spacedCode = spacedCode;
  }

  [FSymbol.reflection]() {
    return {
      type: "Elements.Title.Types.Model",
      interfaces: ["FSharpRecord", "System.IEquatable", "System.IComparable"],
      properties: {
        text: "string",
        typeText: "string",
        typeCode: "string",
        sizeText: "string",
        sizeCode: "string",
        spacedText: "string",
        spacedCode: "string"
      }
    };
  }

  Equals(other) {
    return equalsRecords(this, other);
  }

  CompareTo(other) {
    return compareRecords(this, other) | 0;
  }

}
setType("Elements.Title.Types.Model", Model$7);

class Model$8 {
  constructor(text, code) {
    this.text = text;
    this.code = code;
  }

  [FSymbol.reflection]() {
    return {
      type: "Elements.Delete.Types.Model",
      interfaces: ["FSharpRecord", "System.IEquatable", "System.IComparable"],
      properties: {
        text: "string",
        code: "string"
      }
    };
  }

  Equals(other) {
    return equalsRecords(this, other);
  }

  CompareTo(other) {
    return compareRecords(this, other) | 0;
  }

}
setType("Elements.Delete.Types.Model", Model$8);

class Model$9 {
  constructor(text, code) {
    this.text = text;
    this.code = code;
  }

  [FSymbol.reflection]() {
    return {
      type: "Elements.Box.Types.Model",
      interfaces: ["FSharpRecord", "System.IEquatable", "System.IComparable"],
      properties: {
        text: "string",
        code: "string"
      }
    };
  }

  Equals(other) {
    return equalsRecords(this, other);
  }

  CompareTo(other) {
    return compareRecords(this, other) | 0;
  }

}
setType("Elements.Box.Types.Model", Model$9);

class Model$10 {
  constructor(text, sizeText, sizeCode) {
    this.text = text;
    this.sizeText = sizeText;
    this.sizeCode = sizeCode;
  }

  [FSymbol.reflection]() {
    return {
      type: "Elements.Content.Types.Model",
      interfaces: ["FSharpRecord", "System.IEquatable", "System.IComparable"],
      properties: {
        text: "string",
        sizeText: "string",
        sizeCode: "string"
      }
    };
  }

  Equals(other) {
    return equalsRecords(this, other);
  }

  CompareTo(other) {
    return compareRecords(this, other) | 0;
  }

}
setType("Elements.Content.Types.Model", Model$10);

class Model$11 {
  constructor(text, code, colorText, colorCode, sizeText, sizeCode) {
    this.text = text;
    this.code = code;
    this.colorText = colorText;
    this.colorCode = colorCode;
    this.sizeText = sizeText;
    this.sizeCode = sizeCode;
  }

  [FSymbol.reflection]() {
    return {
      type: "Elements.Tag.Types.Model",
      interfaces: ["FSharpRecord", "System.IEquatable", "System.IComparable"],
      properties: {
        text: "string",
        code: "string",
        colorText: "string",
        colorCode: "string",
        sizeText: "string",
        sizeCode: "string"
      }
    };
  }

  Equals(other) {
    return equalsRecords(this, other);
  }

  CompareTo(other) {
    return compareRecords(this, other) | 0;
  }

}
setType("Elements.Tag.Types.Model", Model$11);

class Msg$1 {
  constructor(tag, data) {
    this.tag = tag;
    this.data = data;
  }

  [FSymbol.reflection]() {
    return {
      type: "App.Types.Msg",
      interfaces: ["FSharpUnion", "System.IEquatable", "System.IComparable"],
      cases: [["HomeMsg", Msg], ["SendNotification"], ["Test"]]
    };
  }

  Equals(other) {
    return this === other || this.tag === other.tag && equals(this.data, other.data);
  }

  CompareTo(other) {
    return compareUnions(this, other) | 0;
  }

}
setType("App.Types.Msg", Msg$1);
class ElementsModel {
  constructor(button, icon, image, progress, table, form, title, _delete, box, content, tag) {
    this.button = button;
    this.icon = icon;
    this.image = image;
    this.progress = progress;
    this.table = table;
    this.form = form;
    this.title = title;
    this.delete = _delete;
    this.box = box;
    this.content = content;
    this.tag = tag;
  }

  [FSymbol.reflection]() {
    return {
      type: "App.Types.ElementsModel",
      interfaces: ["FSharpRecord", "System.IEquatable", "System.IComparable"],
      properties: {
        button: Model$1,
        icon: Model$2,
        image: Model$3,
        progress: Model$4,
        table: Model$5,
        form: Model$6,
        title: Model$7,
        delete: Model$8,
        box: Model$9,
        content: Model$10,
        tag: Model$11
      }
    };
  }

  Equals(other) {
    return equalsRecords(this, other);
  }

  CompareTo(other) {
    return compareRecords(this, other) | 0;
  }

}
setType("App.Types.ElementsModel", ElementsModel);
class Model {
  constructor(currentPage, home, elements) {
    this.currentPage = currentPage;
    this.home = home;
    this.elements = elements;
  }

  [FSymbol.reflection]() {
    return {
      type: "App.Types.Model",
      interfaces: ["FSharpRecord", "System.IEquatable", "System.IComparable"],
      properties: {
        currentPage: Page,
        home: "string",
        elements: ElementsModel
      }
    };
  }

  Equals(other) {
    return equalsRecords(this, other);
  }

  CompareTo(other) {
    return compareRecords(this, other) | 0;
  }

}
setType("App.Types.Model", Model);

function navButton(classy, href, faClass, txt) {
  return react_1("div", {
    className: "control"
  }, react_1("a", {
    className: fsFormat("button %s")(x => x)(classy),
    href: href
  }, react_1("span", {
    className: "icon"
  }, react_1("i", {
    className: fsFormat("fa %s")(x => x)(faClass)
  })), react_1("span", {}, txt)));
}
const navButtons = react_1("span", {
  className: "nav-item block"
}, navButton("twitter", "https://twitter.com/FableCompiler", "fa-twitter", "Twitter"), navButton("github", "https://github.com/MangelMaxime/Fable.Elmish.Bulma/", "fa-github", "Github"), navButton("github", "https://gitter.im/fable-compiler/Fable", "fa-comments", "Gitter"));
const root$13 = react_1("div", {
  className: "nav"
}, react_1("div", {
  className: "nav-left"
}, react_1("h1", {
  className: "nav-item is-brand title is-4"
}, react_1("img", createObj(ofArray([new Props.HTMLAttr(106, "logo.png"), new Props.HTMLAttr(8, "logo"), ["style", {
  marginRight: "10px"
}]]), 1)), "Fable.Elmish.Bulma")), navButtons);

class Trampoline {
    static get maxTrampolineCallCount() {
        return 2000;
    }
    constructor() {
        this.callCount = 0;
    }
    incrementAndCheck() {
        return this.callCount++ > Trampoline.maxTrampolineCallCount;
    }
    hijack(f) {
        this.callCount = 0;
        setTimeout(f, 0);
    }
}
function protectedCont(f) {
    return (ctx) => {
        if (ctx.cancelToken.isCancelled) {
            ctx.onCancel("cancelled");
        }
        else if (ctx.trampoline.incrementAndCheck()) {
            ctx.trampoline.hijack(() => {
                try {
                    f(ctx);
                }
                catch (err) {
                    ctx.onError(err);
                }
            });
        }
        else {
            try {
                f(ctx);
            }
            catch (err) {
                ctx.onError(err);
            }
        }
    };
}
function protectedBind(computation, binder) {
    return protectedCont((ctx) => {
        computation({
            onSuccess: (x) => {
                try {
                    binder(x)(ctx);
                }
                catch (ex) {
                    ctx.onError(ex);
                }
            },
            onError: ctx.onError,
            onCancel: ctx.onCancel,
            cancelToken: ctx.cancelToken,
            trampoline: ctx.trampoline,
        });
    });
}
function protectedReturn(value) {
    return protectedCont((ctx) => ctx.onSuccess(value));
}
class AsyncBuilder {
    Bind(computation, binder) {
        return protectedBind(computation, binder);
    }
    Combine(computation1, computation2) {
        return this.Bind(computation1, () => computation2);
    }
    Delay(generator) {
        return protectedCont((ctx) => generator()(ctx));
    }
    For(sequence, body) {
        const iter = sequence[Symbol.iterator]();
        let cur = iter.next();
        return this.While(() => !cur.done, this.Delay(() => {
            const res = body(cur.value);
            cur = iter.next();
            return res;
        }));
    }
    Return(value) {
        return protectedReturn(value);
    }
    ReturnFrom(computation) {
        return computation;
    }
    TryFinally(computation, compensation) {
        return protectedCont((ctx) => {
            computation({
                onSuccess: (x) => {
                    compensation();
                    ctx.onSuccess(x);
                },
                onError: (x) => {
                    compensation();
                    ctx.onError(x);
                },
                onCancel: (x) => {
                    compensation();
                    ctx.onCancel(x);
                },
                cancelToken: ctx.cancelToken,
                trampoline: ctx.trampoline,
            });
        });
    }
    TryWith(computation, catchHandler) {
        return protectedCont((ctx) => {
            computation({
                onSuccess: ctx.onSuccess,
                onCancel: ctx.onCancel,
                cancelToken: ctx.cancelToken,
                trampoline: ctx.trampoline,
                onError: (ex) => {
                    try {
                        catchHandler(ex)(ctx);
                    }
                    catch (ex2) {
                        ctx.onError(ex2);
                    }
                },
            });
        });
    }
    Using(resource, binder) {
        return this.TryFinally(binder(resource), () => resource.Dispose());
    }
    While(guard, computation) {
        if (guard()) {
            return this.Bind(computation, () => this.While(guard, computation));
        }
        else {
            return this.Return(void 0);
        }
    }
    Zero() {
        return protectedCont((ctx) => ctx.onSuccess(void 0));
    }
}
const singleton$2 = new AsyncBuilder();

function choice1Of2(v) {
    return new Choice(0, v);
}
function choice2Of2(v) {
    return new Choice(1, v);
}
class Choice {
    constructor(tag, data) {
        this.tag = tag | 0;
        this.data = data;
    }
    get valueIfChoice1() {
        return this.tag === 0 ? this.data : null;
    }
    get valueIfChoice2() {
        return this.tag === 1 ? this.data : null;
    }
    Equals(other) {
        return equalsUnions(this, other);
    }
    CompareTo(other) {
        return compareUnions(this, other);
    }
    [FSymbol.reflection]() {
        return {
            type: "Microsoft.FSharp.Core.FSharpChoice",
            interfaces: ["FSharpUnion", "System.IEquatable", "System.IComparable"],
            cases: [["Choice1Of2", Any], ["Choice2Of2", Any]],
        };
    }
}

function emptyContinuation(x) {
    // NOP
}


const defaultCancellationToken = { isCancelled: false };
function catchAsync(work) {
    return protectedCont((ctx) => {
        work({
            onSuccess: (x) => ctx.onSuccess(choice1Of2(x)),
            onError: (ex) => ctx.onSuccess(choice2Of2(ex)),
            onCancel: ctx.onCancel,
            cancelToken: ctx.cancelToken,
            trampoline: ctx.trampoline,
        });
    });
}
function fromContinuations(f) {
    return protectedCont((ctx) => f([ctx.onSuccess, ctx.onError, ctx.onCancel]));
}



function start(computation, cancellationToken) {
    return startWithContinuations(computation, cancellationToken);
}
function startImmediate(computation, cancellationToken) {
    return start(computation, cancellationToken);
}
function startWithContinuations(computation, continuation, exceptionContinuation, cancellationContinuation, cancelToken) {
    if (typeof continuation !== "function") {
        cancelToken = continuation;
        continuation = null;
    }
    const trampoline = new Trampoline();
    computation({
        onSuccess: continuation ? continuation : emptyContinuation,
        onError: exceptionContinuation ? exceptionContinuation : emptyContinuation,
        onCancel: cancellationContinuation ? cancellationContinuation : emptyContinuation,
        cancelToken: cancelToken ? cancelToken : defaultCancellationToken,
        trampoline,
    });
}

const Cmd = function (__exports) {
  const none = __exports.none = function () {
    return new List$1();
  };

  const ofMsg = __exports.ofMsg = function (msg) {
    return ofArray([function (dispatch) {
      dispatch(msg);
    }]);
  };

  const map$$1 = __exports.map = function (f, cmd) {
    return map(function (g) {
      return $var2 => g(function (dispatch) {
        return $var1 => dispatch(f($var1));
      }($var2));
    }, cmd);
  };

  const batch = __exports.batch = function (cmds) {
    return concat(cmds);
  };

  const ofAsync = __exports.ofAsync = function (task, arg, ofSuccess, ofError) {
    const bind = function (dispatch) {
      return function (builder_) {
        return builder_.Delay(function () {
          return builder_.Bind(catchAsync(task(arg)), function (_arg1) {
            dispatch(_arg1.tag === 1 ? ofError(_arg1.data) : ofSuccess(_arg1.data));
            return builder_.Zero();
          });
        });
      }(singleton$2);
    };

    return ofArray([$var3 => function (arg00) {
      startImmediate(arg00);
    }(bind($var3))]);
  };

  const ofFunc = __exports.ofFunc = function (task, arg, ofSuccess, ofError) {
    const bind = function (dispatch) {
      try {
        return ($var4 => dispatch(ofSuccess($var4)))(task(arg));
      } catch (x) {
        return ($var5 => dispatch(ofError($var5)))(x);
      }
    };

    return ofArray([bind]);
  };

  const performFunc = __exports.performFunc = function (task, arg, ofSuccess) {
    const bind = function (dispatch) {
      try {
        ($var6 => dispatch(ofSuccess($var6)))(task(arg));
      } catch (x) {}
    };

    return ofArray([bind]);
  };

  const attemptFunc = __exports.attemptFunc = function (task, arg, ofError) {
    const bind = function (dispatch) {
      try {
        task(arg);
      } catch (x) {
        ($var7 => dispatch(ofError($var7)))(x);
      }
    };

    return ofArray([bind]);
  };

  const ofSub = __exports.ofSub = function (sub) {
    return ofArray([sub]);
  };

  const ofPromise = __exports.ofPromise = function (task, arg, ofSuccess, ofError) {
    const bind = function (dispatch) {
      task(arg).then($var9 => dispatch(ofSuccess($var9))).catch($var8 => dispatch(ofError($var8)));
    };

    return ofArray([bind]);
  };

  return __exports;
}({});

// TODO: This needs improvement, check namespace for non-custom types?

// tslint:disable:max-line-length


class SetTree {
    constructor(tag, data) {
        this.tag = tag | 0;
        this.data = data;
    }
}
const tree_tolerance = 2;
function tree_countAux(s, acc) {
    countAux: while (true) {
        if (s.tag === 1) {
            return acc + 1 | 0;
        }
        else if (s.tag === 0) {
            return acc | 0;
        }
        else {
            const _var5 = s.data[1];
            acc = tree_countAux(s.data[2], acc + 1);
            s = _var5;
            continue countAux;
        }
    }
}
function tree_count(s) {
    return tree_countAux(s, 0);
}
function tree_SetOne(n) {
    return new SetTree(1, [n]);
}
function tree_SetNode(x, l, r, h) {
    return new SetTree(2, [x, l, r, h]);
}
function tree_height$1(t) {
    return t.tag === 1 ? 1 : t.tag === 2 ? t.data[3] : 0;
}
function tree_mk$1(l, k, r) {
    const matchValue = l.tag === 0 ? r.tag === 0 ? 0 : 1 : 1;
    switch (matchValue) {
        case 0:
            return tree_SetOne(k);
        case 1:
            const hl = tree_height$1(l) | 0;
            const hr = tree_height$1(r) | 0;
            const m = (hl < hr ? hr : hl) | 0;
            return tree_SetNode(k, l, r, m + 1);
    }
    throw new Error("internal error: Set.tree_mk");
}
function tree_rebalance$1(t1, k, t2) {
    const t1h = tree_height$1(t1);
    const t2h = tree_height$1(t2);
    if (t2h > t1h + tree_tolerance) {
        if (t2.tag === 2) {
            if (tree_height$1(t2.data[1]) > t1h + 1) {
                if (t2.data[1].tag === 2) {
                    return tree_mk$1(tree_mk$1(t1, k, t2.data[1].data[1]), t2.data[1].data[0], tree_mk$1(t2.data[1].data[2], t2.data[0], t2.data[2]));
                }
                else {
                    throw new Error("rebalance");
                }
            }
            else {
                return tree_mk$1(tree_mk$1(t1, k, t2.data[1]), t2.data[0], t2.data[2]);
            }
        }
        else {
            throw new Error("rebalance");
        }
    }
    else {
        if (t1h > t2h + tree_tolerance) {
            if (t1.tag === 2) {
                if (tree_height$1(t1.data[2]) > t2h + 1) {
                    if (t1.data[2].tag === 2) {
                        return tree_mk$1(tree_mk$1(t1.data[1], t1.data[0], t1.data[2].data[1]), t1.data[2].data[0], tree_mk$1(t1.data[2].data[2], k, t2));
                    }
                    else {
                        throw new Error("rebalance");
                    }
                }
                else {
                    return tree_mk$1(t1.data[1], t1.data[0], tree_mk$1(t1.data[2], k, t2));
                }
            }
            else {
                throw new Error("rebalance");
            }
        }
        else {
            return tree_mk$1(t1, k, t2);
        }
    }
}
function tree_add$1(comparer, k, t) {
    if (t.tag === 1) {
        const c = comparer.Compare(k, t.data[0]);
        if (c < 0) {
            return tree_SetNode(k, new SetTree(0), t, 2);
        }
        else if (c === 0) {
            return t;
        }
        else {
            return tree_SetNode(k, t, new SetTree(0), 2);
        }
    }
    else if (t.tag === 0) {
        return tree_SetOne(k);
    }
    else {
        const c = comparer.Compare(k, t.data[0]);
        if (c < 0) {
            return tree_rebalance$1(tree_add$1(comparer, k, t.data[1]), t.data[0], t.data[2]);
        }
        else if (c === 0) {
            return t;
        }
        else {
            return tree_rebalance$1(t.data[1], t.data[0], tree_add$1(comparer, k, t.data[2]));
        }
    }
}
function tree_spliceOutSuccessor$1(t) {
    if (t.tag === 1) {
        return [t.data[0], new SetTree(0)];
    }
    else if (t.tag === 2) {
        if (t.data[1].tag === 0) {
            return [t.data[0], t.data[2]];
        }
        else {
            const patternInput = tree_spliceOutSuccessor$1(t.data[1]);
            return [patternInput[0], tree_mk$1(patternInput[1], t.data[0], t.data[2])];
        }
    }
    else {
        throw new Error("internal error: Map.spliceOutSuccessor");
    }
}
function tree_remove$1(comparer, k, t) {
    if (t.tag === 1) {
        const c = comparer.Compare(k, t.data[0]);
        if (c === 0) {
            return new SetTree(0);
        }
        else {
            return t;
        }
    }
    else if (t.tag === 2) {
        const c = comparer.Compare(k, t.data[0]);
        if (c < 0) {
            return tree_rebalance$1(tree_remove$1(comparer, k, t.data[1]), t.data[0], t.data[2]);
        }
        else if (c === 0) {
            const matchValue = [t.data[1], t.data[2]];
            if (matchValue[0].tag === 0) {
                return t.data[2];
            }
            else if (matchValue[1].tag === 0) {
                return t.data[1];
            }
            else {
                const patternInput = tree_spliceOutSuccessor$1(t.data[2]);
                return tree_mk$1(t.data[1], patternInput[0], patternInput[1]);
            }
        }
        else {
            return tree_rebalance$1(t.data[1], t.data[0], tree_remove$1(comparer, k, t.data[2]));
        }
    }
    else {
        return t;
    }
}
function tree_mem$1(comparer, k, t) {
    mem: while (true) {
        if (t.tag === 1) {
            return comparer.Compare(k, t.data[0]) === 0;
        }
        else if (t.tag === 0) {
            return false;
        }
        else {
            const c = comparer.Compare(k, t.data[0]) | 0;
            if (c < 0) {
                comparer = comparer;
                k = k;
                t = t.data[1];
                continue mem;
            }
            else if (c === 0) {
                return true;
            }
            else {
                comparer = comparer;
                k = k;
                t = t.data[2];
                continue mem;
            }
        }
    }
}
function tree_collapseLHS$1(stack) {
    collapseLHS: while (true) {
        if (stack.tail != null) {
            if (stack.head.tag === 1) {
                return stack;
            }
            else if (stack.head.tag === 2) {
                stack = ofArray([stack.head.data[1], tree_SetOne(stack.head.data[0]), stack.head.data[2]], stack.tail);
                continue collapseLHS;
            }
            else {
                stack = stack.tail;
                continue collapseLHS;
            }
        }
        else {
            return new List$1();
        }
    }
}
function tree_mkIterator$1(s) {
    return { stack: tree_collapseLHS$1(new List$1(s, new List$1())), started: false };
}
// function tree_notStarted() {
//   throw new Error("Enumeration not started");
// };
// var alreadyFinished = $exports.alreadyFinished = function () {
//   throw new Error("Enumeration already started");
// };
function tree_moveNext$1(i) {
    function current(it) {
        if (it.stack.tail == null) {
            return null;
        }
        else if (it.stack.head.tag === 1) {
            return it.stack.head.data[0];
        }
        throw new Error("Please report error: Set iterator, unexpected stack for current");
    }
    if (i.started) {
        if (i.stack.tail == null) {
            return { done: true, value: null };
        }
        else {
            if (i.stack.head.tag === 1) {
                i.stack = tree_collapseLHS$1(i.stack.tail);
                return {
                    done: i.stack.tail == null,
                    value: current(i),
                };
            }
            else {
                throw new Error("Please report error: Set iterator, unexpected stack for moveNext");
            }
        }
    }
    else {
        i.started = true;
        return {
            done: i.stack.tail == null,
            value: current(i),
        };
    }
}
function tree_compareStacks(comparer, l1, l2) {
    compareStacks: while (true) {
        const matchValue = l1.tail != null ? l2.tail != null ? l2.head.tag === 1 ? l1.head.tag === 1 ? [4, l1.head.data[0], l2.head.data[0], l1.tail, l2.tail] : l1.head.tag === 2 ? l1.head.data[1].tag === 0 ? [6, l1.head.data[1], l1.head.data[0], l1.head.data[2], l2.head.data[0], l1.tail, l2.tail] : [9, l1.head.data[0], l1.head.data[1], l1.head.data[2], l1.tail] : [10, l2.head.data[0], l2.tail] : l2.head.tag === 2 ? l2.head.data[1].tag === 0 ? l1.head.tag === 1 ? [5, l1.head.data[0], l2.head.data[0], l2.head.data[2], l1.tail, l2.tail] : l1.head.tag === 2 ? l1.head.data[1].tag === 0 ? [7, l1.head.data[0], l1.head.data[2], l2.head.data[0], l2.head.data[2], l1.tail, l2.tail] : [9, l1.head.data[0], l1.head.data[1], l1.head.data[2], l1.tail] : [11, l2.head.data[0], l2.head.data[1], l2.head.data[2], l2.tail] : l1.head.tag === 1 ? [8, l1.head.data[0], l1.tail] : l1.head.tag === 2 ? [9, l1.head.data[0], l1.head.data[1], l1.head.data[2], l1.tail] : [11, l2.head.data[0], l2.head.data[1], l2.head.data[2], l2.tail] : l1.head.tag === 1 ? [8, l1.head.data[0], l1.tail] : l1.head.tag === 2 ? [9, l1.head.data[0], l1.head.data[1], l1.head.data[2], l1.tail] : [3, l1.tail, l2.tail] : [2] : l2.tail != null ? [1] : [0];
        switch (matchValue[0]) {
            case 0:
                return 0;
            case 1:
                return -1;
            case 2:
                return 1;
            case 3:
                comparer = comparer;
                l1 = matchValue[1];
                l2 = matchValue[2];
                continue compareStacks;
            case 4:
                const c = comparer.Compare(matchValue[1], matchValue[2]) | 0;
                if (c !== 0) {
                    return c | 0;
                }
                else {
                    comparer = comparer;
                    l1 = matchValue[3];
                    l2 = matchValue[4];
                    continue compareStacks;
                }
            case 5:
                const c_1 = comparer.Compare(matchValue[1], matchValue[2]) | 0;
                if (c_1 !== 0) {
                    return c_1 | 0;
                }
                else {
                    comparer = comparer;
                    l1 = new List$1(new SetTree(0), matchValue[4]);
                    l2 = new List$1(matchValue[3], matchValue[5]);
                    continue compareStacks;
                }
            case 6:
                const c_2 = comparer.Compare(matchValue[2], matchValue[4]) | 0;
                if (c_2 !== 0) {
                    return c_2 | 0;
                }
                else {
                    comparer = comparer;
                    l1 = new List$1(matchValue[3], matchValue[5]);
                    l2 = new List$1(matchValue[1], matchValue[6]);
                    continue compareStacks;
                }
            case 7:
                const c_3 = comparer.Compare(matchValue[1], matchValue[3]) | 0;
                if (c_3 !== 0) {
                    return c_3 | 0;
                }
                else {
                    comparer = comparer;
                    l1 = new List$1(matchValue[2], matchValue[5]);
                    l2 = new List$1(matchValue[4], matchValue[6]);
                    continue compareStacks;
                }
            case 8:
                comparer = comparer;
                l1 = ofArray([new SetTree(0), tree_SetOne(matchValue[1])], matchValue[2]);
                l2 = l2;
                continue compareStacks;
            case 9:
                comparer = comparer;
                l1 = ofArray([matchValue[2], tree_SetNode(matchValue[1], new SetTree(0), matchValue[3], 0)], matchValue[4]);
                l2 = l2;
                continue compareStacks;
            case 10:
                comparer = comparer;
                l1 = l1;
                l2 = ofArray([new SetTree(0), tree_SetOne(matchValue[1])], matchValue[2]);
                continue compareStacks;
            case 11:
                comparer = comparer;
                l1 = l1;
                l2 = ofArray([matchValue[2], tree_SetNode(matchValue[1], new SetTree(0), matchValue[3], 0)], matchValue[4]);
                continue compareStacks;
        }
    }
}
function tree_compare(comparer, s1, s2) {
    if (s1.tag === 0) {
        return s2.tag === 0 ? 0 : -1;
    }
    else {
        return s2.tag === 0 ? 1 : tree_compareStacks(comparer, ofArray([s1]), ofArray([s2]));
    }
}
class FableSet {
    /** Do not call, use Set.create instead. */
    constructor() { return; }
    ToString() {
        return "set [" + Array.from(this).map((x) => toString(x)).join("; ") + "]";
    }
    Equals(s2) {
        return this.CompareTo(s2) === 0;
    }
    CompareTo(s2) {
        return this === s2 ? 0 : tree_compare(this.comparer, this.tree, s2.tree);
    }
    [Symbol.iterator]() {
        const i = tree_mkIterator$1(this.tree);
        return {
            next: () => tree_moveNext$1(i),
        };
    }
    values() {
        return this[Symbol.iterator]();
    }
    has(v) {
        return tree_mem$1(this.comparer, v, this.tree);
    }
    /** Mutating method */
    add(v) {
        this.tree = tree_add$1(this.comparer, v, this.tree);
        return this;
    }
    /** Mutating method */
    delete(v) {
        // TODO: Is calculating the size twice is more performant than calling tree_mem?
        const oldSize = tree_count(this.tree);
        this.tree = tree_remove$1(this.comparer, v, this.tree);
        return oldSize > tree_count(this.tree);
    }
    /** Mutating method */
    clear() {
        this.tree = new SetTree(0);
    }
    get size() {
        return tree_count(this.tree);
    }
    [FSymbol.reflection]() {
        return {
            type: "Microsoft.FSharp.Collections.FSharpSet",
            interfaces: ["System.IEquatable", "System.IComparable"],
        };
    }
}

// tslint:disable:ban-types
function deflate(v) {
    if (ArrayBuffer.isView(v)) {
        return Array.from(v);
    }
    else if (v != null && typeof v === "object") {
        if (v instanceof List$1 || v instanceof FableSet || v instanceof Set) {
            return Array.from(v);
        }
        else if (v instanceof FableMap || v instanceof Map) {
            let stringKeys = null;
            return fold$1((o, kv) => {
                if (stringKeys === null) {
                    stringKeys = typeof kv[0] === "string";
                }
                o[stringKeys ? kv[0] : toJson(kv[0])] = kv[1];
                return o;
            }, {}, v);
        }
        const reflectionInfo = typeof v[FSymbol.reflection] === "function" ? v[FSymbol.reflection]() : {};
        if (reflectionInfo.properties) {
            return fold$1((o, prop) => {
                return o[prop] = v[prop], o;
            }, {}, Object.getOwnPropertyNames(reflectionInfo.properties));
        }
        else if (reflectionInfo.cases) {
            const caseInfo = reflectionInfo.cases[v.tag];
            const caseName = caseInfo[0];
            const fieldsLength = caseInfo.length - 1;
            if (fieldsLength === 0) {
                return caseName;
            }
            else {
                // Prevent undefined assignment from removing case property; see #611:
                return { [caseName]: (v.data !== void 0 ? v.data : null) };
            }
        }
    }
    return v;
}
function toJson(o) {
    return JSON.stringify(o, (k, v) => deflate(v));
}

class QueueCell {
    constructor(message) {
        this.value = message;
    }
}
class MailboxQueue {
    add(message) {
        const itCell = new QueueCell(message);
        if (this.firstAndLast) {
            this.firstAndLast[1].next = itCell;
            this.firstAndLast = [this.firstAndLast[0], itCell];
        }
        else {
            this.firstAndLast = [itCell, itCell];
        }
    }
    tryGet() {
        if (this.firstAndLast) {
            const value = this.firstAndLast[0].value;
            if (this.firstAndLast[0].next) {
                this.firstAndLast = [this.firstAndLast[0].next, this.firstAndLast[1]];
            }
            else {
                delete this.firstAndLast;
            }
            return value;
        }
        return void 0;
    }
}
class MailboxProcessor {
    constructor(body, cancellationToken$$1) {
        this.body = body;
        this.cancellationToken = cancellationToken$$1 || defaultCancellationToken;
        this.messages = new MailboxQueue();
    }
    __processEvents() {
        if (this.continuation) {
            const value = this.messages.tryGet();
            if (value) {
                const cont = this.continuation;
                delete this.continuation;
                cont(value);
            }
        }
    }
    start() {
        startImmediate(this.body(this), this.cancellationToken);
    }
    receive() {
        return fromContinuations((conts) => {
            if (this.continuation) {
                throw new Error("Receive can only be called once!");
            }
            this.continuation = conts[0];
            this.__processEvents();
        });
    }
    post(message) {
        this.messages.add(message);
        this.__processEvents();
    }
    postAndAsyncReply(buildMessage) {
        let result;
        let continuation;
        function checkCompletion() {
            if (result && continuation) {
                continuation(result);
            }
        }
        const reply = {
            reply: (res) => {
                result = res;
                checkCompletion();
            },
        };
        this.messages.add(buildMessage(reply));
        this.__processEvents();
        return fromContinuations((conts) => {
            continuation = conts[0];
            checkCompletion();
        });
    }
}
function start$1(body, cancellationToken$$1) {
    const mbox = new MailboxProcessor(body, cancellationToken$$1);
    mbox.start();
    return mbox;
}

class Program {
  constructor(init, update, subscribe, view, setState, onError) {
    this.init = init;
    this.update = update;
    this.subscribe = subscribe;
    this.view = view;
    this.setState = setState;
    this.onError = onError;
  }

  [FSymbol.reflection]() {
    return {
      type: "Elmish.Program",
      interfaces: ["FSharpRecord"],
      properties: {
        init: FableFunction([GenericParam("arg"), Tuple([GenericParam("model"), makeGeneric(List$1, {
          T: FableFunction([FableFunction([GenericParam("msg"), Unit]), Unit])
        })])]),
        update: FableFunction([GenericParam("msg"), GenericParam("model"), Tuple([GenericParam("model"), makeGeneric(List$1, {
          T: FableFunction([FableFunction([GenericParam("msg"), Unit]), Unit])
        })])]),
        subscribe: FableFunction([GenericParam("model"), makeGeneric(List$1, {
          T: FableFunction([FableFunction([GenericParam("msg"), Unit]), Unit])
        })]),
        view: FableFunction([GenericParam("model"), FableFunction([GenericParam("msg"), Unit]), GenericParam("view")]),
        setState: FableFunction([GenericParam("model"), FableFunction([GenericParam("msg"), Unit]), Unit]),
        onError: FableFunction([Tuple(["string", Error]), Unit])
      }
    };
  }

}
setType("Elmish.Program", Program);
const ProgramModule = function (__exports) {
  const onError = __exports.onError = function (text, ex) {
    console.error(text, ex);
  };

  const mkProgram = __exports.mkProgram = function (init, update, view) {
    const setState = function (model) {
      return $var2 => function (value) {
        value;
      }(($var1 => view(model, $var1))($var2));
    };

    return new Program(init, update, function (_arg1) {
      return Cmd.none();
    }, view, ($var3, $var4) => setState($var3)($var4), function (tupledArg) {
      onError(tupledArg[0], tupledArg[1]);
    });
  };

  const mkSimple = __exports.mkSimple = function (init, update, view) {
    const init_1 = $var5 => {
      return function (state) {
        return [state, Cmd.none()];
      }(init($var5));
    };

    const update_1 = function (msg) {
      return $var7 => function (state_1) {
        return [state_1, Cmd.none()];
      }(($var6 => update(msg, $var6))($var7));
    };

    const setState = function (model) {
      return $var9 => function (value) {
        value;
      }(($var8 => view(model, $var8))($var9));
    };

    return new Program(init_1, ($var10, $var11) => update_1($var10)($var11), function (_arg1) {
      return Cmd.none();
    }, view, ($var12, $var13) => setState($var12)($var13), function (tupledArg) {
      onError(tupledArg[0], tupledArg[1]);
    });
  };

  const withSubscription = __exports.withSubscription = function (subscribe, program) {
    return new Program(program.init, program.update, subscribe, program.view, program.setState, program.onError);
  };

  const withConsoleTrace = __exports.withConsoleTrace = function (program) {
    const trace = function (text, msg, model) {
      console.log(text, function (o) {
        return function (arg00) {
          return JSON.parse(arg00);
        }(toJson(o));
      }(model), function (o_1) {
        return function (arg00_1) {
          return JSON.parse(arg00_1);
        }(toJson(o_1));
      }(msg));
      return program.update(msg, model);
    };

    const update = ($var14, $var15) => {
      return trace("Updating:", $var14, $var15);
    };

    return new Program(program.init, update, program.subscribe, program.view, program.setState, program.onError);
  };

  const withTrace = __exports.withTrace = function (trace, program) {
    const update = function (msg, model) {
      trace(msg, model);
      return program.update(msg, model);
    };

    return new Program(program.init, update, program.subscribe, program.view, program.setState, program.onError);
  };

  const runWith = __exports.runWith = function (arg, program) {
    const patternInput = program.init(arg);
    const inbox = start$1(function (mb) {
      const loop = function (state) {
        return function (builder_) {
          return builder_.Delay(function () {
            return builder_.Bind(mb.receive(), function (_arg1) {
              return builder_.TryWith(builder_.Delay(function () {
                const patternInput_1 = program.update(_arg1, state);
                program.setState(patternInput_1[0], function (arg00) {
                  mb.post(arg00);
                });
                iterate$1(function (sub) {
                  sub(function (arg00_1) {
                    mb.post(arg00_1);
                  });
                }, patternInput_1[1]);
                return builder_.ReturnFrom(loop(patternInput_1[0]));
              }), function (_arg2) {
                program.onError(["Unable to process a message:", _arg2]);
                return builder_.ReturnFrom(loop(state));
              });
            });
          });
        }(singleton$2);
      };

      return loop(patternInput[0]);
    });
    program.setState(patternInput[0], function (arg00_2) {
      inbox.post(arg00_2);
    });
    iterate$1(function (sub_1) {
      sub_1(function (arg00_3) {
        inbox.post(arg00_3);
      });
    }, append(program.subscribe(patternInput[0]), patternInput[1]));
  };

  const run = __exports.run = function (program) {
    runWith(null, program);
  };

  return __exports;
}({});

/**
 * Copyright (c) 2013-present, Facebook, Inc.
 * All rights reserved.
 *
 * This source code is licensed under the BSD-style license found in the
 * LICENSE file in the root directory of this source tree. An additional grant
 * of patent rights can be found in the PATENTS file in the same directory.
 *
 * 
 */

function checkMask(value, bitmask) {
  return (value & bitmask) === bitmask;
}

var DOMPropertyInjection = {
  /**
   * Mapping from normalized, camelcased property names to a configuration that
   * specifies how the associated DOM property should be accessed or rendered.
   */
  MUST_USE_PROPERTY: 0x1,
  HAS_BOOLEAN_VALUE: 0x4,
  HAS_NUMERIC_VALUE: 0x8,
  HAS_POSITIVE_NUMERIC_VALUE: 0x10 | 0x8,
  HAS_OVERLOADED_BOOLEAN_VALUE: 0x20,

  /**
   * Inject some specialized knowledge about the DOM. This takes a config object
   * with the following properties:
   *
   * isCustomAttribute: function that given an attribute name will return true
   * if it can be inserted into the DOM verbatim. Useful for data-* or aria-*
   * attributes where it's impossible to enumerate all of the possible
   * attribute names,
   *
   * Properties: object mapping DOM property name to one of the
   * DOMPropertyInjection constants or null. If your attribute isn't in here,
   * it won't get written to the DOM.
   *
   * DOMAttributeNames: object mapping React attribute name to the DOM
   * attribute name. Attribute names not specified use the **lowercase**
   * normalized name.
   *
   * DOMAttributeNamespaces: object mapping React attribute name to the DOM
   * attribute namespace URL. (Attribute names not specified use no namespace.)
   *
   * DOMPropertyNames: similar to DOMAttributeNames but for DOM properties.
   * Property names not specified use the normalized name.
   *
   * DOMMutationMethods: Properties that require special mutation methods. If
   * `value` is undefined, the mutation method should unset the property.
   *
   * @param {object} domPropertyConfig the config as described above.
   */
  injectDOMPropertyConfig: function (domPropertyConfig) {
    var Injection = DOMPropertyInjection;
    var Properties = domPropertyConfig.Properties || {};
    var DOMAttributeNamespaces = domPropertyConfig.DOMAttributeNamespaces || {};
    var DOMAttributeNames = domPropertyConfig.DOMAttributeNames || {};
    var DOMPropertyNames = domPropertyConfig.DOMPropertyNames || {};
    var DOMMutationMethods = domPropertyConfig.DOMMutationMethods || {};

    if (domPropertyConfig.isCustomAttribute) {
      DOMProperty._isCustomAttributeFunctions.push(domPropertyConfig.isCustomAttribute);
    }

    for (var propName in Properties) {
      !!DOMProperty.properties.hasOwnProperty(propName) ? invariant_1(false, 'injectDOMPropertyConfig(...): You\'re trying to inject DOM property \'%s\' which has already been injected. You may be accidentally injecting the same DOM property config twice, or you may be injecting two configs that have conflicting property names.', propName) : void 0;

      var lowerCased = propName.toLowerCase();
      var propConfig = Properties[propName];

      var propertyInfo = {
        attributeName: lowerCased,
        attributeNamespace: null,
        propertyName: propName,
        mutationMethod: null,

        mustUseProperty: checkMask(propConfig, Injection.MUST_USE_PROPERTY),
        hasBooleanValue: checkMask(propConfig, Injection.HAS_BOOLEAN_VALUE),
        hasNumericValue: checkMask(propConfig, Injection.HAS_NUMERIC_VALUE),
        hasPositiveNumericValue: checkMask(propConfig, Injection.HAS_POSITIVE_NUMERIC_VALUE),
        hasOverloadedBooleanValue: checkMask(propConfig, Injection.HAS_OVERLOADED_BOOLEAN_VALUE)
      };
      !(propertyInfo.hasBooleanValue + propertyInfo.hasNumericValue + propertyInfo.hasOverloadedBooleanValue <= 1) ? invariant_1(false, 'DOMProperty: Value can be one of boolean, overloaded boolean, or numeric value, but not a combination: %s', propName) : void 0;

      {
        DOMProperty.getPossibleStandardName[lowerCased] = propName;
      }

      if (DOMAttributeNames.hasOwnProperty(propName)) {
        var attributeName = DOMAttributeNames[propName];
        propertyInfo.attributeName = attributeName;
        {
          DOMProperty.getPossibleStandardName[attributeName] = propName;
        }
      }

      if (DOMAttributeNamespaces.hasOwnProperty(propName)) {
        propertyInfo.attributeNamespace = DOMAttributeNamespaces[propName];
      }

      if (DOMPropertyNames.hasOwnProperty(propName)) {
        propertyInfo.propertyName = DOMPropertyNames[propName];
      }

      if (DOMMutationMethods.hasOwnProperty(propName)) {
        propertyInfo.mutationMethod = DOMMutationMethods[propName];
      }

      DOMProperty.properties[propName] = propertyInfo;
    }
  }
};

/* eslint-disable max-len */
var ATTRIBUTE_NAME_START_CHAR = ':A-Z_a-z\\u00C0-\\u00D6\\u00D8-\\u00F6\\u00F8-\\u02FF\\u0370-\\u037D\\u037F-\\u1FFF\\u200C-\\u200D\\u2070-\\u218F\\u2C00-\\u2FEF\\u3001-\\uD7FF\\uF900-\\uFDCF\\uFDF0-\\uFFFD';
/* eslint-enable max-len */

/**
 * DOMProperty exports lookup objects that can be used like functions:
 *
 *   > DOMProperty.isValid['id']
 *   true
 *   > DOMProperty.isValid['foobar']
 *   undefined
 *
 * Although this may be confusing, it performs better in general.
 *
 * @see http://jsperf.com/key-exists
 * @see http://jsperf.com/key-missing
 */
var DOMProperty = {

  ID_ATTRIBUTE_NAME: 'data-reactid',
  ROOT_ATTRIBUTE_NAME: 'data-reactroot',

  ATTRIBUTE_NAME_START_CHAR: ATTRIBUTE_NAME_START_CHAR,
  ATTRIBUTE_NAME_CHAR: ATTRIBUTE_NAME_START_CHAR + '\\-.0-9\\u00B7\\u0300-\\u036F\\u203F-\\u2040',

  /**
   * Map from property "standard name" to an object with info about how to set
   * the property in the DOM. Each object contains:
   *
   * attributeName:
   *   Used when rendering markup or with `*Attribute()`.
   * attributeNamespace
   * propertyName:
   *   Used on DOM node instances. (This includes properties that mutate due to
   *   external factors.)
   * mutationMethod:
   *   If non-null, used instead of the property or `setAttribute()` after
   *   initial render.
   * mustUseProperty:
   *   Whether the property must be accessed and mutated as an object property.
   * hasBooleanValue:
   *   Whether the property should be removed when set to a falsey value.
   * hasNumericValue:
   *   Whether the property must be numeric or parse as a numeric and should be
   *   removed when set to a falsey value.
   * hasPositiveNumericValue:
   *   Whether the property must be positive numeric or parse as a positive
   *   numeric and should be removed when set to a falsey value.
   * hasOverloadedBooleanValue:
   *   Whether the property can be used as a flag as well as with a value.
   *   Removed when strictly equal to false; present without a value when
   *   strictly equal to true; present with a value otherwise.
   */
  properties: {},

  /**
   * Mapping from lowercase property names to the properly cased version, used
   * to warn in the case of missing properties. Available only in __DEV__.
   *
   * autofocus is predefined, because adding it to the property whitelist
   * causes unintended side effects.
   *
   * @type {Object}
   */
  getPossibleStandardName: { autofocus: 'autoFocus' },

  /**
   * All of the isCustomAttribute() functions that have been injected.
   */
  _isCustomAttributeFunctions: [],

  /**
   * Checks whether a property name is a custom attribute.
   * @method
   */
  isCustomAttribute: function (attributeName) {
    for (var i = 0; i < DOMProperty._isCustomAttributeFunctions.length; i++) {
      var isCustomAttributeFn = DOMProperty._isCustomAttributeFunctions[i];
      if (isCustomAttributeFn(attributeName)) {
        return true;
      }
    }
    return false;
  },

  injection: DOMPropertyInjection
};

var DOMProperty_1 = DOMProperty;

/**
 * Copyright 2015-present, Facebook, Inc.
 * All rights reserved.
 *
 * This source code is licensed under the BSD-style license found in the
 * LICENSE file in the root directory of this source tree. An additional grant
 * of patent rights can be found in the PATENTS file in the same directory.
 *
 */

var ReactDOMComponentFlags = {
  hasCachedChildNodes: 1 << 0
};

var ReactDOMComponentFlags_1 = ReactDOMComponentFlags;

var ATTR_NAME = DOMProperty_1.ID_ATTRIBUTE_NAME;
var Flags = ReactDOMComponentFlags_1;

var internalInstanceKey = '__reactInternalInstance$' + Math.random().toString(36).slice(2);

/**
 * Check if a given node should be cached.
 */
function shouldPrecacheNode(node, nodeID) {
  return node.nodeType === 1 && node.getAttribute(ATTR_NAME) === String(nodeID) || node.nodeType === 8 && node.nodeValue === ' react-text: ' + nodeID + ' ' || node.nodeType === 8 && node.nodeValue === ' react-empty: ' + nodeID + ' ';
}

/**
 * Drill down (through composites and empty components) until we get a host or
 * host text component.
 *
 * This is pretty polymorphic but unavoidable with the current structure we have
 * for `_renderedChildren`.
 */
function getRenderedHostOrTextFromComponent(component) {
  var rendered;
  while (rendered = component._renderedComponent) {
    component = rendered;
  }
  return component;
}

/**
 * Populate `_hostNode` on the rendered host/text component with the given
 * DOM node. The passed `inst` can be a composite.
 */
function precacheNode(inst, node) {
  var hostInst = getRenderedHostOrTextFromComponent(inst);
  hostInst._hostNode = node;
  node[internalInstanceKey] = hostInst;
}

function uncacheNode(inst) {
  var node = inst._hostNode;
  if (node) {
    delete node[internalInstanceKey];
    inst._hostNode = null;
  }
}

/**
 * Populate `_hostNode` on each child of `inst`, assuming that the children
 * match up with the DOM (element) children of `node`.
 *
 * We cache entire levels at once to avoid an n^2 problem where we access the
 * children of a node sequentially and have to walk from the start to our target
 * node every time.
 *
 * Since we update `_renderedChildren` and the actual DOM at (slightly)
 * different times, we could race here and see a newer `_renderedChildren` than
 * the DOM nodes we see. To avoid this, ReactMultiChild calls
 * `prepareToManageChildren` before we change `_renderedChildren`, at which
 * time the container's child nodes are always cached (until it unmounts).
 */
function precacheChildNodes(inst, node) {
  if (inst._flags & Flags.hasCachedChildNodes) {
    return;
  }
  var children = inst._renderedChildren;
  var childNode = node.firstChild;
  outer: for (var name in children) {
    if (!children.hasOwnProperty(name)) {
      continue;
    }
    var childInst = children[name];
    var childID = getRenderedHostOrTextFromComponent(childInst)._domID;
    if (childID === 0) {
      // We're currently unmounting this child in ReactMultiChild; skip it.
      continue;
    }
    // We assume the child nodes are in the same order as the child instances.
    for (; childNode !== null; childNode = childNode.nextSibling) {
      if (shouldPrecacheNode(childNode, childID)) {
        precacheNode(childInst, childNode);
        continue outer;
      }
    }
    // We reached the end of the DOM children without finding an ID match.
    invariant_1(false, 'Unable to find element with ID %s.', childID);
  }
  inst._flags |= Flags.hasCachedChildNodes;
}

/**
 * Given a DOM node, return the closest ReactDOMComponent or
 * ReactDOMTextComponent instance ancestor.
 */
function getClosestInstanceFromNode(node) {
  if (node[internalInstanceKey]) {
    return node[internalInstanceKey];
  }

  // Walk up the tree until we find an ancestor whose instance we have cached.
  var parents = [];
  while (!node[internalInstanceKey]) {
    parents.push(node);
    if (node.parentNode) {
      node = node.parentNode;
    } else {
      // Top of the tree. This node must not be part of a React tree (or is
      // unmounted, potentially).
      return null;
    }
  }

  var closest;
  var inst;
  for (; node && (inst = node[internalInstanceKey]); node = parents.pop()) {
    closest = inst;
    if (parents.length) {
      precacheChildNodes(inst, node);
    }
  }

  return closest;
}

/**
 * Given a DOM node, return the ReactDOMComponent or ReactDOMTextComponent
 * instance, or null if the node was not rendered by this React.
 */
function getInstanceFromNode(node) {
  var inst = getClosestInstanceFromNode(node);
  if (inst != null && inst._hostNode === node) {
    return inst;
  } else {
    return null;
  }
}

/**
 * Given a ReactDOMComponent or ReactDOMTextComponent, return the corresponding
 * DOM node.
 */
function getNodeFromInstance(inst) {
  // Without this first invariant, passing a non-DOM-component triggers the next
  // invariant for a missing parent, which is super confusing.
  !(inst._hostNode !== undefined) ? invariant_1(false, 'getNodeFromInstance: Invalid argument.') : void 0;

  if (inst._hostNode) {
    return inst._hostNode;
  }

  // Walk up the tree until we find an ancestor whose DOM node we have cached.
  var parents = [];
  while (!inst._hostNode) {
    parents.push(inst);
    !inst._hostParent ? invariant_1(false, 'React DOM tree root should always have a node reference.') : void 0;
    inst = inst._hostParent;
  }

  // Now parents contains each ancestor that does *not* have a cached native
  // node, and `inst` is the deepest ancestor that does.
  for (; parents.length; inst = parents.pop()) {
    precacheChildNodes(inst, inst._hostNode);
  }

  return inst._hostNode;
}

var ReactDOMComponentTree = {
  getClosestInstanceFromNode: getClosestInstanceFromNode,
  getInstanceFromNode: getInstanceFromNode,
  getNodeFromInstance: getNodeFromInstance,
  precacheChildNodes: precacheChildNodes,
  precacheNode: precacheNode,
  uncacheNode: uncacheNode
};

var ReactDOMComponentTree_1 = ReactDOMComponentTree;

/**
 * Copyright 2013-present, Facebook, Inc.
 * All rights reserved.
 *
 * This source code is licensed under the BSD-style license found in the
 * LICENSE file in the root directory of this source tree. An additional grant
 * of patent rights can be found in the PATENTS file in the same directory.
 *
 */

var ARIADOMPropertyConfig = {
  Properties: {
    // Global States and Properties
    'aria-current': 0, // state
    'aria-details': 0,
    'aria-disabled': 0, // state
    'aria-hidden': 0, // state
    'aria-invalid': 0, // state
    'aria-keyshortcuts': 0,
    'aria-label': 0,
    'aria-roledescription': 0,
    // Widget Attributes
    'aria-autocomplete': 0,
    'aria-checked': 0,
    'aria-expanded': 0,
    'aria-haspopup': 0,
    'aria-level': 0,
    'aria-modal': 0,
    'aria-multiline': 0,
    'aria-multiselectable': 0,
    'aria-orientation': 0,
    'aria-placeholder': 0,
    'aria-pressed': 0,
    'aria-readonly': 0,
    'aria-required': 0,
    'aria-selected': 0,
    'aria-sort': 0,
    'aria-valuemax': 0,
    'aria-valuemin': 0,
    'aria-valuenow': 0,
    'aria-valuetext': 0,
    // Live Region Attributes
    'aria-atomic': 0,
    'aria-busy': 0,
    'aria-live': 0,
    'aria-relevant': 0,
    // Drag-and-Drop Attributes
    'aria-dropeffect': 0,
    'aria-grabbed': 0,
    // Relationship Attributes
    'aria-activedescendant': 0,
    'aria-colcount': 0,
    'aria-colindex': 0,
    'aria-colspan': 0,
    'aria-controls': 0,
    'aria-describedby': 0,
    'aria-errormessage': 0,
    'aria-flowto': 0,
    'aria-labelledby': 0,
    'aria-owns': 0,
    'aria-posinset': 0,
    'aria-rowcount': 0,
    'aria-rowindex': 0,
    'aria-rowspan': 0,
    'aria-setsize': 0
  },
  DOMAttributeNames: {},
  DOMPropertyNames: {}
};

var ARIADOMPropertyConfig_1 = ARIADOMPropertyConfig;

var eventPluginOrder = null;

/**
 * Injectable mapping from names to event plugin modules.
 */
var namesToPlugins = {};

/**
 * Recomputes the plugin list using the injected plugins and plugin ordering.
 *
 * @private
 */
function recomputePluginOrdering() {
  if (!eventPluginOrder) {
    // Wait until an `eventPluginOrder` is injected.
    return;
  }
  for (var pluginName in namesToPlugins) {
    var pluginModule = namesToPlugins[pluginName];
    var pluginIndex = eventPluginOrder.indexOf(pluginName);
    !(pluginIndex > -1) ? invariant_1(false, 'EventPluginRegistry: Cannot inject event plugins that do not exist in the plugin ordering, `%s`.', pluginName) : void 0;
    if (EventPluginRegistry.plugins[pluginIndex]) {
      continue;
    }
    !pluginModule.extractEvents ? invariant_1(false, 'EventPluginRegistry: Event plugins must implement an `extractEvents` method, but `%s` does not.', pluginName) : void 0;
    EventPluginRegistry.plugins[pluginIndex] = pluginModule;
    var publishedEvents = pluginModule.eventTypes;
    for (var eventName in publishedEvents) {
      !publishEventForPlugin(publishedEvents[eventName], pluginModule, eventName) ? invariant_1(false, 'EventPluginRegistry: Failed to publish event `%s` for plugin `%s`.', eventName, pluginName) : void 0;
    }
  }
}

/**
 * Publishes an event so that it can be dispatched by the supplied plugin.
 *
 * @param {object} dispatchConfig Dispatch configuration for the event.
 * @param {object} PluginModule Plugin publishing the event.
 * @return {boolean} True if the event was successfully published.
 * @private
 */
function publishEventForPlugin(dispatchConfig, pluginModule, eventName) {
  !!EventPluginRegistry.eventNameDispatchConfigs.hasOwnProperty(eventName) ? invariant_1(false, 'EventPluginHub: More than one plugin attempted to publish the same event name, `%s`.', eventName) : void 0;
  EventPluginRegistry.eventNameDispatchConfigs[eventName] = dispatchConfig;

  var phasedRegistrationNames = dispatchConfig.phasedRegistrationNames;
  if (phasedRegistrationNames) {
    for (var phaseName in phasedRegistrationNames) {
      if (phasedRegistrationNames.hasOwnProperty(phaseName)) {
        var phasedRegistrationName = phasedRegistrationNames[phaseName];
        publishRegistrationName(phasedRegistrationName, pluginModule, eventName);
      }
    }
    return true;
  } else if (dispatchConfig.registrationName) {
    publishRegistrationName(dispatchConfig.registrationName, pluginModule, eventName);
    return true;
  }
  return false;
}

/**
 * Publishes a registration name that is used to identify dispatched events and
 * can be used with `EventPluginHub.putListener` to register listeners.
 *
 * @param {string} registrationName Registration name to add.
 * @param {object} PluginModule Plugin publishing the event.
 * @private
 */
function publishRegistrationName(registrationName, pluginModule, eventName) {
  !!EventPluginRegistry.registrationNameModules[registrationName] ? invariant_1(false, 'EventPluginHub: More than one plugin attempted to publish the same registration name, `%s`.', registrationName) : void 0;
  EventPluginRegistry.registrationNameModules[registrationName] = pluginModule;
  EventPluginRegistry.registrationNameDependencies[registrationName] = pluginModule.eventTypes[eventName].dependencies;

  {
    var lowerCasedName = registrationName.toLowerCase();
    EventPluginRegistry.possibleRegistrationNames[lowerCasedName] = registrationName;

    if (registrationName === 'onDoubleClick') {
      EventPluginRegistry.possibleRegistrationNames.ondblclick = registrationName;
    }
  }
}

/**
 * Registers plugins so that they can extract and dispatch events.
 *
 * @see {EventPluginHub}
 */
var EventPluginRegistry = {

  /**
   * Ordered list of injected plugins.
   */
  plugins: [],

  /**
   * Mapping from event name to dispatch config
   */
  eventNameDispatchConfigs: {},

  /**
   * Mapping from registration name to plugin module
   */
  registrationNameModules: {},

  /**
   * Mapping from registration name to event name
   */
  registrationNameDependencies: {},

  /**
   * Mapping from lowercase registration names to the properly cased version,
   * used to warn in the case of missing event handlers. Available
   * only in __DEV__.
   * @type {Object}
   */
  possibleRegistrationNames: {},
  // Trust the developer to only use possibleRegistrationNames in __DEV__

  /**
   * Injects an ordering of plugins (by plugin name). This allows the ordering
   * to be decoupled from injection of the actual plugins so that ordering is
   * always deterministic regardless of packaging, on-the-fly injection, etc.
   *
   * @param {array} InjectedEventPluginOrder
   * @internal
   * @see {EventPluginHub.injection.injectEventPluginOrder}
   */
  injectEventPluginOrder: function (injectedEventPluginOrder) {
    !!eventPluginOrder ? invariant_1(false, 'EventPluginRegistry: Cannot inject event plugin ordering more than once. You are likely trying to load more than one copy of React.') : void 0;
    // Clone the ordering so it cannot be dynamically mutated.
    eventPluginOrder = Array.prototype.slice.call(injectedEventPluginOrder);
    recomputePluginOrdering();
  },

  /**
   * Injects plugins to be used by `EventPluginHub`. The plugin names must be
   * in the ordering injected by `injectEventPluginOrder`.
   *
   * Plugins can be injected as part of page initialization or on-the-fly.
   *
   * @param {object} injectedNamesToPlugins Map from names to plugin modules.
   * @internal
   * @see {EventPluginHub.injection.injectEventPluginsByName}
   */
  injectEventPluginsByName: function (injectedNamesToPlugins) {
    var isOrderingDirty = false;
    for (var pluginName in injectedNamesToPlugins) {
      if (!injectedNamesToPlugins.hasOwnProperty(pluginName)) {
        continue;
      }
      var pluginModule = injectedNamesToPlugins[pluginName];
      if (!namesToPlugins.hasOwnProperty(pluginName) || namesToPlugins[pluginName] !== pluginModule) {
        !!namesToPlugins[pluginName] ? invariant_1(false, 'EventPluginRegistry: Cannot inject two different event plugins using the same name, `%s`.', pluginName) : void 0;
        namesToPlugins[pluginName] = pluginModule;
        isOrderingDirty = true;
      }
    }
    if (isOrderingDirty) {
      recomputePluginOrdering();
    }
  },

  /**
   * Looks up the plugin for the supplied event.
   *
   * @param {object} event A synthetic event.
   * @return {?object} The plugin that created the supplied event.
   * @internal
   */
  getPluginModuleForEvent: function (event) {
    var dispatchConfig = event.dispatchConfig;
    if (dispatchConfig.registrationName) {
      return EventPluginRegistry.registrationNameModules[dispatchConfig.registrationName] || null;
    }
    if (dispatchConfig.phasedRegistrationNames !== undefined) {
      // pulling phasedRegistrationNames out of dispatchConfig helps Flow see
      // that it is not undefined.
      var phasedRegistrationNames = dispatchConfig.phasedRegistrationNames;

      for (var phase in phasedRegistrationNames) {
        if (!phasedRegistrationNames.hasOwnProperty(phase)) {
          continue;
        }
        var pluginModule = EventPluginRegistry.registrationNameModules[phasedRegistrationNames[phase]];
        if (pluginModule) {
          return pluginModule;
        }
      }
    }
    return null;
  },

  /**
   * Exposed for unit testing.
   * @private
   */
  _resetEventPlugins: function () {
    eventPluginOrder = null;
    for (var pluginName in namesToPlugins) {
      if (namesToPlugins.hasOwnProperty(pluginName)) {
        delete namesToPlugins[pluginName];
      }
    }
    EventPluginRegistry.plugins.length = 0;

    var eventNameDispatchConfigs = EventPluginRegistry.eventNameDispatchConfigs;
    for (var eventName in eventNameDispatchConfigs) {
      if (eventNameDispatchConfigs.hasOwnProperty(eventName)) {
        delete eventNameDispatchConfigs[eventName];
      }
    }

    var registrationNameModules = EventPluginRegistry.registrationNameModules;
    for (var registrationName in registrationNameModules) {
      if (registrationNameModules.hasOwnProperty(registrationName)) {
        delete registrationNameModules[registrationName];
      }
    }

    {
      var possibleRegistrationNames = EventPluginRegistry.possibleRegistrationNames;
      for (var lowerCasedName in possibleRegistrationNames) {
        if (possibleRegistrationNames.hasOwnProperty(lowerCasedName)) {
          delete possibleRegistrationNames[lowerCasedName];
        }
      }
    }
  }

};

var EventPluginRegistry_1 = EventPluginRegistry;

/**
 * Copyright 2013-present, Facebook, Inc.
 * All rights reserved.
 *
 * This source code is licensed under the BSD-style license found in the
 * LICENSE file in the root directory of this source tree. An additional grant
 * of patent rights can be found in the PATENTS file in the same directory.
 *
 * 
 */

var caughtError = null;

/**
 * Call a function while guarding against errors that happens within it.
 *
 * @param {String} name of the guard to use for logging or debugging
 * @param {Function} func The function to invoke
 * @param {*} a First argument
 * @param {*} b Second argument
 */
function invokeGuardedCallback(name, func, a) {
  try {
    func(a);
  } catch (x) {
    if (caughtError === null) {
      caughtError = x;
    }
  }
}

var ReactErrorUtils = {
  invokeGuardedCallback: invokeGuardedCallback,

  /**
   * Invoked by ReactTestUtils.Simulate so that any errors thrown by the event
   * handler are sure to be rethrown by rethrowCaughtError.
   */
  invokeGuardedCallbackWithCatch: invokeGuardedCallback,

  /**
   * During execution of guarded functions we will capture the first error which
   * we will rethrow to be handled by the top level error handler.
   */
  rethrowCaughtError: function () {
    if (caughtError) {
      var error = caughtError;
      caughtError = null;
      throw error;
    }
  }
};

{
  /**
   * To help development we can get better devtools integration by simulating a
   * real browser event.
   */
  if (typeof window !== 'undefined' && typeof window.dispatchEvent === 'function' && typeof document !== 'undefined' && typeof document.createEvent === 'function') {
    var fakeNode = document.createElement('react');
    ReactErrorUtils.invokeGuardedCallback = function (name, func, a) {
      var boundFunc = func.bind(null, a);
      var evtType = 'react-' + name;
      fakeNode.addEventListener(evtType, boundFunc, false);
      var evt = document.createEvent('Event');
      evt.initEvent(evtType, false, false);
      fakeNode.dispatchEvent(evt);
      fakeNode.removeEventListener(evtType, boundFunc, false);
    };
  }
}

var ReactErrorUtils_1 = ReactErrorUtils;

var ComponentTree;
var TreeTraversal;
var injection = {
  injectComponentTree: function (Injected) {
    ComponentTree = Injected;
    {
      warning_1(Injected && Injected.getNodeFromInstance && Injected.getInstanceFromNode, 'EventPluginUtils.injection.injectComponentTree(...): Injected ' + 'module is missing getNodeFromInstance or getInstanceFromNode.');
    }
  },
  injectTreeTraversal: function (Injected) {
    TreeTraversal = Injected;
    {
      warning_1(Injected && Injected.isAncestor && Injected.getLowestCommonAncestor, 'EventPluginUtils.injection.injectTreeTraversal(...): Injected ' + 'module is missing isAncestor or getLowestCommonAncestor.');
    }
  }
};

function isEndish(topLevelType) {
  return topLevelType === 'topMouseUp' || topLevelType === 'topTouchEnd' || topLevelType === 'topTouchCancel';
}

function isMoveish(topLevelType) {
  return topLevelType === 'topMouseMove' || topLevelType === 'topTouchMove';
}
function isStartish(topLevelType) {
  return topLevelType === 'topMouseDown' || topLevelType === 'topTouchStart';
}

var validateEventDispatches;
{
  validateEventDispatches = function (event) {
    var dispatchListeners = event._dispatchListeners;
    var dispatchInstances = event._dispatchInstances;

    var listenersIsArr = Array.isArray(dispatchListeners);
    var listenersLen = listenersIsArr ? dispatchListeners.length : dispatchListeners ? 1 : 0;

    var instancesIsArr = Array.isArray(dispatchInstances);
    var instancesLen = instancesIsArr ? dispatchInstances.length : dispatchInstances ? 1 : 0;

    warning_1(instancesIsArr === listenersIsArr && instancesLen === listenersLen, 'EventPluginUtils: Invalid `event`.');
  };
}

/**
 * Dispatch the event to the listener.
 * @param {SyntheticEvent} event SyntheticEvent to handle
 * @param {boolean} simulated If the event is simulated (changes exn behavior)
 * @param {function} listener Application-level callback
 * @param {*} inst Internal component instance
 */
function executeDispatch(event, simulated, listener, inst) {
  var type = event.type || 'unknown-event';
  event.currentTarget = EventPluginUtils.getNodeFromInstance(inst);
  if (simulated) {
    ReactErrorUtils_1.invokeGuardedCallbackWithCatch(type, listener, event);
  } else {
    ReactErrorUtils_1.invokeGuardedCallback(type, listener, event);
  }
  event.currentTarget = null;
}

/**
 * Standard/simple iteration through an event's collected dispatches.
 */
function executeDispatchesInOrder(event, simulated) {
  var dispatchListeners = event._dispatchListeners;
  var dispatchInstances = event._dispatchInstances;
  {
    validateEventDispatches(event);
  }
  if (Array.isArray(dispatchListeners)) {
    for (var i = 0; i < dispatchListeners.length; i++) {
      if (event.isPropagationStopped()) {
        break;
      }
      // Listeners and Instances are two parallel arrays that are always in sync.
      executeDispatch(event, simulated, dispatchListeners[i], dispatchInstances[i]);
    }
  } else if (dispatchListeners) {
    executeDispatch(event, simulated, dispatchListeners, dispatchInstances);
  }
  event._dispatchListeners = null;
  event._dispatchInstances = null;
}

/**
 * Standard/simple iteration through an event's collected dispatches, but stops
 * at the first dispatch execution returning true, and returns that id.
 *
 * @return {?string} id of the first dispatch execution who's listener returns
 * true, or null if no listener returned true.
 */
function executeDispatchesInOrderStopAtTrueImpl(event) {
  var dispatchListeners = event._dispatchListeners;
  var dispatchInstances = event._dispatchInstances;
  {
    validateEventDispatches(event);
  }
  if (Array.isArray(dispatchListeners)) {
    for (var i = 0; i < dispatchListeners.length; i++) {
      if (event.isPropagationStopped()) {
        break;
      }
      // Listeners and Instances are two parallel arrays that are always in sync.
      if (dispatchListeners[i](event, dispatchInstances[i])) {
        return dispatchInstances[i];
      }
    }
  } else if (dispatchListeners) {
    if (dispatchListeners(event, dispatchInstances)) {
      return dispatchInstances;
    }
  }
  return null;
}

/**
 * @see executeDispatchesInOrderStopAtTrueImpl
 */
function executeDispatchesInOrderStopAtTrue(event) {
  var ret = executeDispatchesInOrderStopAtTrueImpl(event);
  event._dispatchInstances = null;
  event._dispatchListeners = null;
  return ret;
}

/**
 * Execution of a "direct" dispatch - there must be at most one dispatch
 * accumulated on the event or it is considered an error. It doesn't really make
 * sense for an event with multiple dispatches (bubbled) to keep track of the
 * return values at each dispatch execution, but it does tend to make sense when
 * dealing with "direct" dispatches.
 *
 * @return {*} The return value of executing the single dispatch.
 */
function executeDirectDispatch(event) {
  {
    validateEventDispatches(event);
  }
  var dispatchListener = event._dispatchListeners;
  var dispatchInstance = event._dispatchInstances;
  !!Array.isArray(dispatchListener) ? invariant_1(false, 'executeDirectDispatch(...): Invalid `event`.') : void 0;
  event.currentTarget = dispatchListener ? EventPluginUtils.getNodeFromInstance(dispatchInstance) : null;
  var res = dispatchListener ? dispatchListener(event) : null;
  event.currentTarget = null;
  event._dispatchListeners = null;
  event._dispatchInstances = null;
  return res;
}

/**
 * @param {SyntheticEvent} event
 * @return {boolean} True iff number of dispatches accumulated is greater than 0.
 */
function hasDispatches(event) {
  return !!event._dispatchListeners;
}

/**
 * General utilities that are useful in creating custom Event Plugins.
 */
var EventPluginUtils = {
  isEndish: isEndish,
  isMoveish: isMoveish,
  isStartish: isStartish,

  executeDirectDispatch: executeDirectDispatch,
  executeDispatchesInOrder: executeDispatchesInOrder,
  executeDispatchesInOrderStopAtTrue: executeDispatchesInOrderStopAtTrue,
  hasDispatches: hasDispatches,

  getInstanceFromNode: function (node) {
    return ComponentTree.getInstanceFromNode(node);
  },
  getNodeFromInstance: function (node) {
    return ComponentTree.getNodeFromInstance(node);
  },
  isAncestor: function (a, b) {
    return TreeTraversal.isAncestor(a, b);
  },
  getLowestCommonAncestor: function (a, b) {
    return TreeTraversal.getLowestCommonAncestor(a, b);
  },
  getParentInstance: function (inst) {
    return TreeTraversal.getParentInstance(inst);
  },
  traverseTwoPhase: function (target, fn, arg) {
    return TreeTraversal.traverseTwoPhase(target, fn, arg);
  },
  traverseEnterLeave: function (from, to, fn, argFrom, argTo) {
    return TreeTraversal.traverseEnterLeave(from, to, fn, argFrom, argTo);
  },

  injection: injection
};

var EventPluginUtils_1 = EventPluginUtils;

function accumulateInto(current, next) {
  !(next != null) ? invariant_1(false, 'accumulateInto(...): Accumulated items must not be null or undefined.') : void 0;

  if (current == null) {
    return next;
  }

  // Both are not empty. Warning: Never call x.concat(y) when you are not
  // certain that x is an Array (x could be a string with concat method).
  if (Array.isArray(current)) {
    if (Array.isArray(next)) {
      current.push.apply(current, next);
      return current;
    }
    current.push(next);
    return current;
  }

  if (Array.isArray(next)) {
    // A bit too dangerous to mutate `next`.
    return [current].concat(next);
  }

  return [current, next];
}

var accumulateInto_1 = accumulateInto;

/**
 * Copyright 2013-present, Facebook, Inc.
 * All rights reserved.
 *
 * This source code is licensed under the BSD-style license found in the
 * LICENSE file in the root directory of this source tree. An additional grant
 * of patent rights can be found in the PATENTS file in the same directory.
 *
 * 
 */

function forEachAccumulated(arr, cb, scope) {
  if (Array.isArray(arr)) {
    arr.forEach(cb, scope);
  } else if (arr) {
    cb.call(scope, arr);
  }
}

var forEachAccumulated_1 = forEachAccumulated;

var listenerBank = {};

/**
 * Internal queue of events that have accumulated their dispatches and are
 * waiting to have their dispatches executed.
 */
var eventQueue = null;

/**
 * Dispatches an event and releases it back into the pool, unless persistent.
 *
 * @param {?object} event Synthetic event to be dispatched.
 * @param {boolean} simulated If the event is simulated (changes exn behavior)
 * @private
 */
var executeDispatchesAndRelease = function (event, simulated) {
  if (event) {
    EventPluginUtils_1.executeDispatchesInOrder(event, simulated);

    if (!event.isPersistent()) {
      event.constructor.release(event);
    }
  }
};
var executeDispatchesAndReleaseSimulated = function (e) {
  return executeDispatchesAndRelease(e, true);
};
var executeDispatchesAndReleaseTopLevel = function (e) {
  return executeDispatchesAndRelease(e, false);
};

var getDictionaryKey = function (inst) {
  // Prevents V8 performance issue:
  // https://github.com/facebook/react/pull/7232
  return '.' + inst._rootNodeID;
};

function isInteractive(tag) {
  return tag === 'button' || tag === 'input' || tag === 'select' || tag === 'textarea';
}

function shouldPreventMouseEvent(name, type, props) {
  switch (name) {
    case 'onClick':
    case 'onClickCapture':
    case 'onDoubleClick':
    case 'onDoubleClickCapture':
    case 'onMouseDown':
    case 'onMouseDownCapture':
    case 'onMouseMove':
    case 'onMouseMoveCapture':
    case 'onMouseUp':
    case 'onMouseUpCapture':
      return !!(props.disabled && isInteractive(type));
    default:
      return false;
  }
}

/**
 * This is a unified interface for event plugins to be installed and configured.
 *
 * Event plugins can implement the following properties:
 *
 *   `extractEvents` {function(string, DOMEventTarget, string, object): *}
 *     Required. When a top-level event is fired, this method is expected to
 *     extract synthetic events that will in turn be queued and dispatched.
 *
 *   `eventTypes` {object}
 *     Optional, plugins that fire events must publish a mapping of registration
 *     names that are used to register listeners. Values of this mapping must
 *     be objects that contain `registrationName` or `phasedRegistrationNames`.
 *
 *   `executeDispatch` {function(object, function, string)}
 *     Optional, allows plugins to override how an event gets dispatched. By
 *     default, the listener is simply invoked.
 *
 * Each plugin that is injected into `EventsPluginHub` is immediately operable.
 *
 * @public
 */
var EventPluginHub = {

  /**
   * Methods for injecting dependencies.
   */
  injection: {

    /**
     * @param {array} InjectedEventPluginOrder
     * @public
     */
    injectEventPluginOrder: EventPluginRegistry_1.injectEventPluginOrder,

    /**
     * @param {object} injectedNamesToPlugins Map from names to plugin modules.
     */
    injectEventPluginsByName: EventPluginRegistry_1.injectEventPluginsByName

  },

  /**
   * Stores `listener` at `listenerBank[registrationName][key]`. Is idempotent.
   *
   * @param {object} inst The instance, which is the source of events.
   * @param {string} registrationName Name of listener (e.g. `onClick`).
   * @param {function} listener The callback to store.
   */
  putListener: function (inst, registrationName, listener) {
    !(typeof listener === 'function') ? invariant_1(false, 'Expected %s listener to be a function, instead got type %s', registrationName, typeof listener) : void 0;

    var key = getDictionaryKey(inst);
    var bankForRegistrationName = listenerBank[registrationName] || (listenerBank[registrationName] = {});
    bankForRegistrationName[key] = listener;

    var PluginModule = EventPluginRegistry_1.registrationNameModules[registrationName];
    if (PluginModule && PluginModule.didPutListener) {
      PluginModule.didPutListener(inst, registrationName, listener);
    }
  },

  /**
   * @param {object} inst The instance, which is the source of events.
   * @param {string} registrationName Name of listener (e.g. `onClick`).
   * @return {?function} The stored callback.
   */
  getListener: function (inst, registrationName) {
    // TODO: shouldPreventMouseEvent is DOM-specific and definitely should not
    // live here; needs to be moved to a better place soon
    var bankForRegistrationName = listenerBank[registrationName];
    if (shouldPreventMouseEvent(registrationName, inst._currentElement.type, inst._currentElement.props)) {
      return null;
    }
    var key = getDictionaryKey(inst);
    return bankForRegistrationName && bankForRegistrationName[key];
  },

  /**
   * Deletes a listener from the registration bank.
   *
   * @param {object} inst The instance, which is the source of events.
   * @param {string} registrationName Name of listener (e.g. `onClick`).
   */
  deleteListener: function (inst, registrationName) {
    var PluginModule = EventPluginRegistry_1.registrationNameModules[registrationName];
    if (PluginModule && PluginModule.willDeleteListener) {
      PluginModule.willDeleteListener(inst, registrationName);
    }

    var bankForRegistrationName = listenerBank[registrationName];
    // TODO: This should never be null -- when is it?
    if (bankForRegistrationName) {
      var key = getDictionaryKey(inst);
      delete bankForRegistrationName[key];
    }
  },

  /**
   * Deletes all listeners for the DOM element with the supplied ID.
   *
   * @param {object} inst The instance, which is the source of events.
   */
  deleteAllListeners: function (inst) {
    var key = getDictionaryKey(inst);
    for (var registrationName in listenerBank) {
      if (!listenerBank.hasOwnProperty(registrationName)) {
        continue;
      }

      if (!listenerBank[registrationName][key]) {
        continue;
      }

      var PluginModule = EventPluginRegistry_1.registrationNameModules[registrationName];
      if (PluginModule && PluginModule.willDeleteListener) {
        PluginModule.willDeleteListener(inst, registrationName);
      }

      delete listenerBank[registrationName][key];
    }
  },

  /**
   * Allows registered plugins an opportunity to extract events from top-level
   * native browser events.
   *
   * @return {*} An accumulation of synthetic events.
   * @internal
   */
  extractEvents: function (topLevelType, targetInst, nativeEvent, nativeEventTarget) {
    var events;
    var plugins = EventPluginRegistry_1.plugins;
    for (var i = 0; i < plugins.length; i++) {
      // Not every plugin in the ordering may be loaded at runtime.
      var possiblePlugin = plugins[i];
      if (possiblePlugin) {
        var extractedEvents = possiblePlugin.extractEvents(topLevelType, targetInst, nativeEvent, nativeEventTarget);
        if (extractedEvents) {
          events = accumulateInto_1(events, extractedEvents);
        }
      }
    }
    return events;
  },

  /**
   * Enqueues a synthetic event that should be dispatched when
   * `processEventQueue` is invoked.
   *
   * @param {*} events An accumulation of synthetic events.
   * @internal
   */
  enqueueEvents: function (events) {
    if (events) {
      eventQueue = accumulateInto_1(eventQueue, events);
    }
  },

  /**
   * Dispatches all synthetic events on the event queue.
   *
   * @internal
   */
  processEventQueue: function (simulated) {
    // Set `eventQueue` to null before processing it so that we can tell if more
    // events get enqueued while processing.
    var processingEventQueue = eventQueue;
    eventQueue = null;
    if (simulated) {
      forEachAccumulated_1(processingEventQueue, executeDispatchesAndReleaseSimulated);
    } else {
      forEachAccumulated_1(processingEventQueue, executeDispatchesAndReleaseTopLevel);
    }
    !!eventQueue ? invariant_1(false, 'processEventQueue(): Additional events were enqueued while processing an event queue. Support for this has not yet been implemented.') : void 0;
    // This would be a good time to rethrow if any of the event handlers threw.
    ReactErrorUtils_1.rethrowCaughtError();
  },

  /**
   * These are needed for tests only. Do not use!
   */
  __purge: function () {
    listenerBank = {};
  },

  __getListenerBank: function () {
    return listenerBank;
  }

};

var EventPluginHub_1 = EventPluginHub;

var getListener = EventPluginHub_1.getListener;

/**
 * Some event types have a notion of different registration names for different
 * "phases" of propagation. This finds listeners by a given phase.
 */
function listenerAtPhase(inst, event, propagationPhase) {
  var registrationName = event.dispatchConfig.phasedRegistrationNames[propagationPhase];
  return getListener(inst, registrationName);
}

/**
 * Tags a `SyntheticEvent` with dispatched listeners. Creating this function
 * here, allows us to not have to bind or create functions for each event.
 * Mutating the event's members allows us to not have to create a wrapping
 * "dispatch" object that pairs the event with the listener.
 */
function accumulateDirectionalDispatches(inst, phase, event) {
  {
    warning_1(inst, 'Dispatching inst must not be null');
  }
  var listener = listenerAtPhase(inst, event, phase);
  if (listener) {
    event._dispatchListeners = accumulateInto_1(event._dispatchListeners, listener);
    event._dispatchInstances = accumulateInto_1(event._dispatchInstances, inst);
  }
}

/**
 * Collect dispatches (must be entirely collected before dispatching - see unit
 * tests). Lazily allocate the array to conserve memory.  We must loop through
 * each event and perform the traversal for each one. We cannot perform a
 * single traversal for the entire collection of events because each event may
 * have a different target.
 */
function accumulateTwoPhaseDispatchesSingle(event) {
  if (event && event.dispatchConfig.phasedRegistrationNames) {
    EventPluginUtils_1.traverseTwoPhase(event._targetInst, accumulateDirectionalDispatches, event);
  }
}

/**
 * Same as `accumulateTwoPhaseDispatchesSingle`, but skips over the targetID.
 */
function accumulateTwoPhaseDispatchesSingleSkipTarget(event) {
  if (event && event.dispatchConfig.phasedRegistrationNames) {
    var targetInst = event._targetInst;
    var parentInst = targetInst ? EventPluginUtils_1.getParentInstance(targetInst) : null;
    EventPluginUtils_1.traverseTwoPhase(parentInst, accumulateDirectionalDispatches, event);
  }
}

/**
 * Accumulates without regard to direction, does not look for phased
 * registration names. Same as `accumulateDirectDispatchesSingle` but without
 * requiring that the `dispatchMarker` be the same as the dispatched ID.
 */
function accumulateDispatches(inst, ignoredDirection, event) {
  if (event && event.dispatchConfig.registrationName) {
    var registrationName = event.dispatchConfig.registrationName;
    var listener = getListener(inst, registrationName);
    if (listener) {
      event._dispatchListeners = accumulateInto_1(event._dispatchListeners, listener);
      event._dispatchInstances = accumulateInto_1(event._dispatchInstances, inst);
    }
  }
}

/**
 * Accumulates dispatches on an `SyntheticEvent`, but only for the
 * `dispatchMarker`.
 * @param {SyntheticEvent} event
 */
function accumulateDirectDispatchesSingle(event) {
  if (event && event.dispatchConfig.registrationName) {
    accumulateDispatches(event._targetInst, null, event);
  }
}

function accumulateTwoPhaseDispatches(events) {
  forEachAccumulated_1(events, accumulateTwoPhaseDispatchesSingle);
}

function accumulateTwoPhaseDispatchesSkipTarget(events) {
  forEachAccumulated_1(events, accumulateTwoPhaseDispatchesSingleSkipTarget);
}

function accumulateEnterLeaveDispatches(leave, enter, from, to) {
  EventPluginUtils_1.traverseEnterLeave(from, to, accumulateDispatches, leave, enter);
}

function accumulateDirectDispatches(events) {
  forEachAccumulated_1(events, accumulateDirectDispatchesSingle);
}

/**
 * A small set of propagation patterns, each of which will accept a small amount
 * of information, and generate a set of "dispatch ready event objects" - which
 * are sets of events that have already been annotated with a set of dispatched
 * listener functions/ids. The API is designed this way to discourage these
 * propagation strategies from actually executing the dispatches, since we
 * always want to collect the entire set of dispatches before executing event a
 * single one.
 *
 * @constructor EventPropagators
 */
var EventPropagators = {
  accumulateTwoPhaseDispatches: accumulateTwoPhaseDispatches,
  accumulateTwoPhaseDispatchesSkipTarget: accumulateTwoPhaseDispatchesSkipTarget,
  accumulateDirectDispatches: accumulateDirectDispatches,
  accumulateEnterLeaveDispatches: accumulateEnterLeaveDispatches
};

var EventPropagators_1 = EventPropagators;

/**
 * Copyright (c) 2013-present, Facebook, Inc.
 * All rights reserved.
 *
 * This source code is licensed under the BSD-style license found in the
 * LICENSE file in the root directory of this source tree. An additional grant
 * of patent rights can be found in the PATENTS file in the same directory.
 *
 */

var canUseDOM = !!(typeof window !== 'undefined' && window.document && window.document.createElement);

/**
 * Simple, lightweight module assisting with the detection and context of
 * Worker. Helps avoid circular dependencies and allows code to reason about
 * whether or not they are in a Worker, even if they never include the main
 * `ReactWorker` dependency.
 */
var ExecutionEnvironment$1 = {

  canUseDOM: canUseDOM,

  canUseWorkers: typeof Worker !== 'undefined',

  canUseEventListeners: canUseDOM && !!(window.addEventListener || window.attachEvent),

  canUseViewport: canUseDOM && !!window.screen,

  isInWorker: !canUseDOM // For now, this is true - might change in the future.

};

var ExecutionEnvironment_1 = ExecutionEnvironment$1;

var oneArgumentPooler$1 = function (copyFieldsFrom) {
  var Klass = this;
  if (Klass.instancePool.length) {
    var instance = Klass.instancePool.pop();
    Klass.call(instance, copyFieldsFrom);
    return instance;
  } else {
    return new Klass(copyFieldsFrom);
  }
};

var twoArgumentPooler$2 = function (a1, a2) {
  var Klass = this;
  if (Klass.instancePool.length) {
    var instance = Klass.instancePool.pop();
    Klass.call(instance, a1, a2);
    return instance;
  } else {
    return new Klass(a1, a2);
  }
};

var threeArgumentPooler$1 = function (a1, a2, a3) {
  var Klass = this;
  if (Klass.instancePool.length) {
    var instance = Klass.instancePool.pop();
    Klass.call(instance, a1, a2, a3);
    return instance;
  } else {
    return new Klass(a1, a2, a3);
  }
};

var fourArgumentPooler$2 = function (a1, a2, a3, a4) {
  var Klass = this;
  if (Klass.instancePool.length) {
    var instance = Klass.instancePool.pop();
    Klass.call(instance, a1, a2, a3, a4);
    return instance;
  } else {
    return new Klass(a1, a2, a3, a4);
  }
};

var standardReleaser$1 = function (instance) {
  var Klass = this;
  !(instance instanceof Klass) ? invariant_1(false, 'Trying to release an instance into a pool of a different type.') : void 0;
  instance.destructor();
  if (Klass.instancePool.length < Klass.poolSize) {
    Klass.instancePool.push(instance);
  }
};

var DEFAULT_POOL_SIZE$1 = 10;
var DEFAULT_POOLER$1 = oneArgumentPooler$1;

/**
 * Augments `CopyConstructor` to be a poolable class, augmenting only the class
 * itself (statically) not adding any prototypical fields. Any CopyConstructor
 * you give this may have a `poolSize` property, and will look for a
 * prototypical `destructor` on instances.
 *
 * @param {Function} CopyConstructor Constructor that can be used to reset.
 * @param {Function} pooler Customizable pooler.
 */
var addPoolingTo$1 = function (CopyConstructor, pooler) {
  // Casting as any so that flow ignores the actual implementation and trusts
  // it to match the type we declared
  var NewKlass = CopyConstructor;
  NewKlass.instancePool = [];
  NewKlass.getPooled = pooler || DEFAULT_POOLER$1;
  if (!NewKlass.poolSize) {
    NewKlass.poolSize = DEFAULT_POOL_SIZE$1;
  }
  NewKlass.release = standardReleaser$1;
  return NewKlass;
};

var PooledClass$2 = {
  addPoolingTo: addPoolingTo$1,
  oneArgumentPooler: oneArgumentPooler$1,
  twoArgumentPooler: twoArgumentPooler$2,
  threeArgumentPooler: threeArgumentPooler$1,
  fourArgumentPooler: fourArgumentPooler$2
};

var PooledClass_1$2 = PooledClass$2;

var contentKey = null;

/**
 * Gets the key used to access text content on a DOM node.
 *
 * @return {?string} Key used to access text content.
 * @internal
 */
function getTextContentAccessor() {
  if (!contentKey && ExecutionEnvironment_1.canUseDOM) {
    // Prefer textContent to innerText because many browsers support both but
    // SVG <text> elements don't support innerText even when <div> does.
    contentKey = 'textContent' in document.documentElement ? 'textContent' : 'innerText';
  }
  return contentKey;
}

var getTextContentAccessor_1 = getTextContentAccessor;

function FallbackCompositionState(root) {
  this._root = root;
  this._startText = this.getText();
  this._fallbackText = null;
}

index(FallbackCompositionState.prototype, {
  destructor: function () {
    this._root = null;
    this._startText = null;
    this._fallbackText = null;
  },

  /**
   * Get current text of input.
   *
   * @return {string}
   */
  getText: function () {
    if ('value' in this._root) {
      return this._root.value;
    }
    return this._root[getTextContentAccessor_1()];
  },

  /**
   * Determine the differing substring between the initially stored
   * text content and the current content.
   *
   * @return {string}
   */
  getData: function () {
    if (this._fallbackText) {
      return this._fallbackText;
    }

    var start;
    var startValue = this._startText;
    var startLength = startValue.length;
    var end;
    var endValue = this.getText();
    var endLength = endValue.length;

    for (start = 0; start < startLength; start++) {
      if (startValue[start] !== endValue[start]) {
        break;
      }
    }

    var minEnd = startLength - start;
    for (end = 1; end <= minEnd; end++) {
      if (startValue[startLength - end] !== endValue[endLength - end]) {
        break;
      }
    }

    var sliceTail = end > 1 ? 1 - end : undefined;
    this._fallbackText = endValue.slice(start, sliceTail);
    return this._fallbackText;
  }
});

PooledClass_1$2.addPoolingTo(FallbackCompositionState);

var FallbackCompositionState_1 = FallbackCompositionState;

var didWarnForAddedNewProperty = false;
var isProxySupported = typeof Proxy === 'function';

var shouldBeReleasedProperties = ['dispatchConfig', '_targetInst', 'nativeEvent', 'isDefaultPrevented', 'isPropagationStopped', '_dispatchListeners', '_dispatchInstances'];

/**
 * @interface Event
 * @see http://www.w3.org/TR/DOM-Level-3-Events/
 */
var EventInterface = {
  type: null,
  target: null,
  // currentTarget is set when dispatching; no use in copying it here
  currentTarget: emptyFunction_1.thatReturnsNull,
  eventPhase: null,
  bubbles: null,
  cancelable: null,
  timeStamp: function (event) {
    return event.timeStamp || Date.now();
  },
  defaultPrevented: null,
  isTrusted: null
};

/**
 * Synthetic events are dispatched by event plugins, typically in response to a
 * top-level event delegation handler.
 *
 * These systems should generally use pooling to reduce the frequency of garbage
 * collection. The system should check `isPersistent` to determine whether the
 * event should be released into the pool after being dispatched. Users that
 * need a persisted event should invoke `persist`.
 *
 * Synthetic events (and subclasses) implement the DOM Level 3 Events API by
 * normalizing browser quirks. Subclasses do not necessarily have to implement a
 * DOM interface; custom application-specific events can also subclass this.
 *
 * @param {object} dispatchConfig Configuration used to dispatch this event.
 * @param {*} targetInst Marker identifying the event target.
 * @param {object} nativeEvent Native browser event.
 * @param {DOMEventTarget} nativeEventTarget Target node.
 */
function SyntheticEvent(dispatchConfig, targetInst, nativeEvent, nativeEventTarget) {
  {
    // these have a getter/setter for warnings
    delete this.nativeEvent;
    delete this.preventDefault;
    delete this.stopPropagation;
  }

  this.dispatchConfig = dispatchConfig;
  this._targetInst = targetInst;
  this.nativeEvent = nativeEvent;

  var Interface = this.constructor.Interface;
  for (var propName in Interface) {
    if (!Interface.hasOwnProperty(propName)) {
      continue;
    }
    {
      delete this[propName]; // this has a getter/setter for warnings
    }
    var normalize = Interface[propName];
    if (normalize) {
      this[propName] = normalize(nativeEvent);
    } else {
      if (propName === 'target') {
        this.target = nativeEventTarget;
      } else {
        this[propName] = nativeEvent[propName];
      }
    }
  }

  var defaultPrevented = nativeEvent.defaultPrevented != null ? nativeEvent.defaultPrevented : nativeEvent.returnValue === false;
  if (defaultPrevented) {
    this.isDefaultPrevented = emptyFunction_1.thatReturnsTrue;
  } else {
    this.isDefaultPrevented = emptyFunction_1.thatReturnsFalse;
  }
  this.isPropagationStopped = emptyFunction_1.thatReturnsFalse;
  return this;
}

index(SyntheticEvent.prototype, {

  preventDefault: function () {
    this.defaultPrevented = true;
    var event = this.nativeEvent;
    if (!event) {
      return;
    }

    if (event.preventDefault) {
      event.preventDefault();
    } else if (typeof event.returnValue !== 'unknown') {
      // eslint-disable-line valid-typeof
      event.returnValue = false;
    }
    this.isDefaultPrevented = emptyFunction_1.thatReturnsTrue;
  },

  stopPropagation: function () {
    var event = this.nativeEvent;
    if (!event) {
      return;
    }

    if (event.stopPropagation) {
      event.stopPropagation();
    } else if (typeof event.cancelBubble !== 'unknown') {
      // eslint-disable-line valid-typeof
      // The ChangeEventPlugin registers a "propertychange" event for
      // IE. This event does not support bubbling or cancelling, and
      // any references to cancelBubble throw "Member not found".  A
      // typeof check of "unknown" circumvents this issue (and is also
      // IE specific).
      event.cancelBubble = true;
    }

    this.isPropagationStopped = emptyFunction_1.thatReturnsTrue;
  },

  /**
   * We release all dispatched `SyntheticEvent`s after each event loop, adding
   * them back into the pool. This allows a way to hold onto a reference that
   * won't be added back into the pool.
   */
  persist: function () {
    this.isPersistent = emptyFunction_1.thatReturnsTrue;
  },

  /**
   * Checks if this event should be released back into the pool.
   *
   * @return {boolean} True if this should not be released, false otherwise.
   */
  isPersistent: emptyFunction_1.thatReturnsFalse,

  /**
   * `PooledClass` looks for `destructor` on each instance it releases.
   */
  destructor: function () {
    var Interface = this.constructor.Interface;
    for (var propName in Interface) {
      {
        Object.defineProperty(this, propName, getPooledWarningPropertyDefinition(propName, Interface[propName]));
      }
    }
    for (var i = 0; i < shouldBeReleasedProperties.length; i++) {
      this[shouldBeReleasedProperties[i]] = null;
    }
    {
      Object.defineProperty(this, 'nativeEvent', getPooledWarningPropertyDefinition('nativeEvent', null));
      Object.defineProperty(this, 'preventDefault', getPooledWarningPropertyDefinition('preventDefault', emptyFunction_1));
      Object.defineProperty(this, 'stopPropagation', getPooledWarningPropertyDefinition('stopPropagation', emptyFunction_1));
    }
  }

});

SyntheticEvent.Interface = EventInterface;

{
  if (isProxySupported) {
    /*eslint-disable no-func-assign */
    SyntheticEvent = new Proxy(SyntheticEvent, {
      construct: function (target, args) {
        return this.apply(target, Object.create(target.prototype), args);
      },
      apply: function (constructor, that, args) {
        return new Proxy(constructor.apply(that, args), {
          set: function (target, prop, value) {
            if (prop !== 'isPersistent' && !target.constructor.Interface.hasOwnProperty(prop) && shouldBeReleasedProperties.indexOf(prop) === -1) {
              warning_1(didWarnForAddedNewProperty || target.isPersistent(), 'This synthetic event is reused for performance reasons. If you\'re ' + 'seeing this, you\'re adding a new property in the synthetic event object. ' + 'The property is never released. See ' + 'https://fb.me/react-event-pooling for more information.');
              didWarnForAddedNewProperty = true;
            }
            target[prop] = value;
            return true;
          }
        });
      }
    });
    /*eslint-enable no-func-assign */
  }
}
/**
 * Helper to reduce boilerplate when creating subclasses.
 *
 * @param {function} Class
 * @param {?object} Interface
 */
SyntheticEvent.augmentClass = function (Class, Interface) {
  var Super = this;

  var E = function () {};
  E.prototype = Super.prototype;
  var prototype = new E();

  index(prototype, Class.prototype);
  Class.prototype = prototype;
  Class.prototype.constructor = Class;

  Class.Interface = index({}, Super.Interface, Interface);
  Class.augmentClass = Super.augmentClass;

  PooledClass_1$2.addPoolingTo(Class, PooledClass_1$2.fourArgumentPooler);
};

PooledClass_1$2.addPoolingTo(SyntheticEvent, PooledClass_1$2.fourArgumentPooler);

var SyntheticEvent_1 = SyntheticEvent;

/**
  * Helper to nullify syntheticEvent instance properties when destructing
  *
  * @param {object} SyntheticEvent
  * @param {String} propName
  * @return {object} defineProperty object
  */
function getPooledWarningPropertyDefinition(propName, getVal) {
  var isFunction = typeof getVal === 'function';
  return {
    configurable: true,
    set: set,
    get: get
  };

  function set(val) {
    var action = isFunction ? 'setting the method' : 'setting the property';
    warn(action, 'This is effectively a no-op');
    return val;
  }

  function get() {
    var action = isFunction ? 'accessing the method' : 'accessing the property';
    var result = isFunction ? 'This is a no-op function' : 'This is set to null';
    warn(action, result);
    return getVal;
  }

  function warn(action, result) {
    var warningCondition = false;
    warning_1(warningCondition, 'This synthetic event is reused for performance reasons. If you\'re seeing this, ' + 'you\'re %s `%s` on a released/nullified synthetic event. %s. ' + 'If you must keep the original synthetic event around, use event.persist(). ' + 'See https://fb.me/react-event-pooling for more information.', action, propName, result);
  }
}

var CompositionEventInterface = {
  data: null
};

/**
 * @param {object} dispatchConfig Configuration used to dispatch this event.
 * @param {string} dispatchMarker Marker identifying the event target.
 * @param {object} nativeEvent Native browser event.
 * @extends {SyntheticUIEvent}
 */
function SyntheticCompositionEvent(dispatchConfig, dispatchMarker, nativeEvent, nativeEventTarget) {
  return SyntheticEvent_1.call(this, dispatchConfig, dispatchMarker, nativeEvent, nativeEventTarget);
}

SyntheticEvent_1.augmentClass(SyntheticCompositionEvent, CompositionEventInterface);

var SyntheticCompositionEvent_1 = SyntheticCompositionEvent;

var InputEventInterface = {
  data: null
};

/**
 * @param {object} dispatchConfig Configuration used to dispatch this event.
 * @param {string} dispatchMarker Marker identifying the event target.
 * @param {object} nativeEvent Native browser event.
 * @extends {SyntheticUIEvent}
 */
function SyntheticInputEvent(dispatchConfig, dispatchMarker, nativeEvent, nativeEventTarget) {
  return SyntheticEvent_1.call(this, dispatchConfig, dispatchMarker, nativeEvent, nativeEventTarget);
}

SyntheticEvent_1.augmentClass(SyntheticInputEvent, InputEventInterface);

var SyntheticInputEvent_1 = SyntheticInputEvent;

var END_KEYCODES = [9, 13, 27, 32]; // Tab, Return, Esc, Space
var START_KEYCODE = 229;

var canUseCompositionEvent = ExecutionEnvironment_1.canUseDOM && 'CompositionEvent' in window;

var documentMode = null;
if (ExecutionEnvironment_1.canUseDOM && 'documentMode' in document) {
  documentMode = document.documentMode;
}

// Webkit offers a very useful `textInput` event that can be used to
// directly represent `beforeInput`. The IE `textinput` event is not as
// useful, so we don't use it.
var canUseTextInputEvent = ExecutionEnvironment_1.canUseDOM && 'TextEvent' in window && !documentMode && !isPresto();

// In IE9+, we have access to composition events, but the data supplied
// by the native compositionend event may be incorrect. Japanese ideographic
// spaces, for instance (\u3000) are not recorded correctly.
var useFallbackCompositionData = ExecutionEnvironment_1.canUseDOM && (!canUseCompositionEvent || documentMode && documentMode > 8 && documentMode <= 11);

/**
 * Opera <= 12 includes TextEvent in window, but does not fire
 * text input events. Rely on keypress instead.
 */
function isPresto() {
  var opera = window.opera;
  return typeof opera === 'object' && typeof opera.version === 'function' && parseInt(opera.version(), 10) <= 12;
}

var SPACEBAR_CODE = 32;
var SPACEBAR_CHAR = String.fromCharCode(SPACEBAR_CODE);

// Events and their corresponding property names.
var eventTypes = {
  beforeInput: {
    phasedRegistrationNames: {
      bubbled: 'onBeforeInput',
      captured: 'onBeforeInputCapture'
    },
    dependencies: ['topCompositionEnd', 'topKeyPress', 'topTextInput', 'topPaste']
  },
  compositionEnd: {
    phasedRegistrationNames: {
      bubbled: 'onCompositionEnd',
      captured: 'onCompositionEndCapture'
    },
    dependencies: ['topBlur', 'topCompositionEnd', 'topKeyDown', 'topKeyPress', 'topKeyUp', 'topMouseDown']
  },
  compositionStart: {
    phasedRegistrationNames: {
      bubbled: 'onCompositionStart',
      captured: 'onCompositionStartCapture'
    },
    dependencies: ['topBlur', 'topCompositionStart', 'topKeyDown', 'topKeyPress', 'topKeyUp', 'topMouseDown']
  },
  compositionUpdate: {
    phasedRegistrationNames: {
      bubbled: 'onCompositionUpdate',
      captured: 'onCompositionUpdateCapture'
    },
    dependencies: ['topBlur', 'topCompositionUpdate', 'topKeyDown', 'topKeyPress', 'topKeyUp', 'topMouseDown']
  }
};

// Track whether we've ever handled a keypress on the space key.
var hasSpaceKeypress = false;

/**
 * Return whether a native keypress event is assumed to be a command.
 * This is required because Firefox fires `keypress` events for key commands
 * (cut, copy, select-all, etc.) even though no character is inserted.
 */
function isKeypressCommand(nativeEvent) {
  return (nativeEvent.ctrlKey || nativeEvent.altKey || nativeEvent.metaKey) &&
  // ctrlKey && altKey is equivalent to AltGr, and is not a command.
  !(nativeEvent.ctrlKey && nativeEvent.altKey);
}

/**
 * Translate native top level events into event types.
 *
 * @param {string} topLevelType
 * @return {object}
 */
function getCompositionEventType(topLevelType) {
  switch (topLevelType) {
    case 'topCompositionStart':
      return eventTypes.compositionStart;
    case 'topCompositionEnd':
      return eventTypes.compositionEnd;
    case 'topCompositionUpdate':
      return eventTypes.compositionUpdate;
  }
}

/**
 * Does our fallback best-guess model think this event signifies that
 * composition has begun?
 *
 * @param {string} topLevelType
 * @param {object} nativeEvent
 * @return {boolean}
 */
function isFallbackCompositionStart(topLevelType, nativeEvent) {
  return topLevelType === 'topKeyDown' && nativeEvent.keyCode === START_KEYCODE;
}

/**
 * Does our fallback mode think that this event is the end of composition?
 *
 * @param {string} topLevelType
 * @param {object} nativeEvent
 * @return {boolean}
 */
function isFallbackCompositionEnd(topLevelType, nativeEvent) {
  switch (topLevelType) {
    case 'topKeyUp':
      // Command keys insert or clear IME input.
      return END_KEYCODES.indexOf(nativeEvent.keyCode) !== -1;
    case 'topKeyDown':
      // Expect IME keyCode on each keydown. If we get any other
      // code we must have exited earlier.
      return nativeEvent.keyCode !== START_KEYCODE;
    case 'topKeyPress':
    case 'topMouseDown':
    case 'topBlur':
      // Events are not possible without cancelling IME.
      return true;
    default:
      return false;
  }
}

/**
 * Google Input Tools provides composition data via a CustomEvent,
 * with the `data` property populated in the `detail` object. If this
 * is available on the event object, use it. If not, this is a plain
 * composition event and we have nothing special to extract.
 *
 * @param {object} nativeEvent
 * @return {?string}
 */
function getDataFromCustomEvent(nativeEvent) {
  var detail = nativeEvent.detail;
  if (typeof detail === 'object' && 'data' in detail) {
    return detail.data;
  }
  return null;
}

// Track the current IME composition fallback object, if any.
var currentComposition = null;

/**
 * @return {?object} A SyntheticCompositionEvent.
 */
function extractCompositionEvent(topLevelType, targetInst, nativeEvent, nativeEventTarget) {
  var eventType;
  var fallbackData;

  if (canUseCompositionEvent) {
    eventType = getCompositionEventType(topLevelType);
  } else if (!currentComposition) {
    if (isFallbackCompositionStart(topLevelType, nativeEvent)) {
      eventType = eventTypes.compositionStart;
    }
  } else if (isFallbackCompositionEnd(topLevelType, nativeEvent)) {
    eventType = eventTypes.compositionEnd;
  }

  if (!eventType) {
    return null;
  }

  if (useFallbackCompositionData) {
    // The current composition is stored statically and must not be
    // overwritten while composition continues.
    if (!currentComposition && eventType === eventTypes.compositionStart) {
      currentComposition = FallbackCompositionState_1.getPooled(nativeEventTarget);
    } else if (eventType === eventTypes.compositionEnd) {
      if (currentComposition) {
        fallbackData = currentComposition.getData();
      }
    }
  }

  var event = SyntheticCompositionEvent_1.getPooled(eventType, targetInst, nativeEvent, nativeEventTarget);

  if (fallbackData) {
    // Inject data generated from fallback path into the synthetic event.
    // This matches the property of native CompositionEventInterface.
    event.data = fallbackData;
  } else {
    var customData = getDataFromCustomEvent(nativeEvent);
    if (customData !== null) {
      event.data = customData;
    }
  }

  EventPropagators_1.accumulateTwoPhaseDispatches(event);
  return event;
}

/**
 * @param {string} topLevelType Record from `EventConstants`.
 * @param {object} nativeEvent Native browser event.
 * @return {?string} The string corresponding to this `beforeInput` event.
 */
function getNativeBeforeInputChars(topLevelType, nativeEvent) {
  switch (topLevelType) {
    case 'topCompositionEnd':
      return getDataFromCustomEvent(nativeEvent);
    case 'topKeyPress':
      /**
       * If native `textInput` events are available, our goal is to make
       * use of them. However, there is a special case: the spacebar key.
       * In Webkit, preventing default on a spacebar `textInput` event
       * cancels character insertion, but it *also* causes the browser
       * to fall back to its default spacebar behavior of scrolling the
       * page.
       *
       * Tracking at:
       * https://code.google.com/p/chromium/issues/detail?id=355103
       *
       * To avoid this issue, use the keypress event as if no `textInput`
       * event is available.
       */
      var which = nativeEvent.which;
      if (which !== SPACEBAR_CODE) {
        return null;
      }

      hasSpaceKeypress = true;
      return SPACEBAR_CHAR;

    case 'topTextInput':
      // Record the characters to be added to the DOM.
      var chars = nativeEvent.data;

      // If it's a spacebar character, assume that we have already handled
      // it at the keypress level and bail immediately. Android Chrome
      // doesn't give us keycodes, so we need to blacklist it.
      if (chars === SPACEBAR_CHAR && hasSpaceKeypress) {
        return null;
      }

      return chars;

    default:
      // For other native event types, do nothing.
      return null;
  }
}

/**
 * For browsers that do not provide the `textInput` event, extract the
 * appropriate string to use for SyntheticInputEvent.
 *
 * @param {string} topLevelType Record from `EventConstants`.
 * @param {object} nativeEvent Native browser event.
 * @return {?string} The fallback string for this `beforeInput` event.
 */
function getFallbackBeforeInputChars(topLevelType, nativeEvent) {
  // If we are currently composing (IME) and using a fallback to do so,
  // try to extract the composed characters from the fallback object.
  // If composition event is available, we extract a string only at
  // compositionevent, otherwise extract it at fallback events.
  if (currentComposition) {
    if (topLevelType === 'topCompositionEnd' || !canUseCompositionEvent && isFallbackCompositionEnd(topLevelType, nativeEvent)) {
      var chars = currentComposition.getData();
      FallbackCompositionState_1.release(currentComposition);
      currentComposition = null;
      return chars;
    }
    return null;
  }

  switch (topLevelType) {
    case 'topPaste':
      // If a paste event occurs after a keypress, throw out the input
      // chars. Paste events should not lead to BeforeInput events.
      return null;
    case 'topKeyPress':
      /**
       * As of v27, Firefox may fire keypress events even when no character
       * will be inserted. A few possibilities:
       *
       * - `which` is `0`. Arrow keys, Esc key, etc.
       *
       * - `which` is the pressed key code, but no char is available.
       *   Ex: 'AltGr + d` in Polish. There is no modified character for
       *   this key combination and no character is inserted into the
       *   document, but FF fires the keypress for char code `100` anyway.
       *   No `input` event will occur.
       *
       * - `which` is the pressed key code, but a command combination is
       *   being used. Ex: `Cmd+C`. No character is inserted, and no
       *   `input` event will occur.
       */
      if (nativeEvent.which && !isKeypressCommand(nativeEvent)) {
        return String.fromCharCode(nativeEvent.which);
      }
      return null;
    case 'topCompositionEnd':
      return useFallbackCompositionData ? null : nativeEvent.data;
    default:
      return null;
  }
}

/**
 * Extract a SyntheticInputEvent for `beforeInput`, based on either native
 * `textInput` or fallback behavior.
 *
 * @return {?object} A SyntheticInputEvent.
 */
function extractBeforeInputEvent(topLevelType, targetInst, nativeEvent, nativeEventTarget) {
  var chars;

  if (canUseTextInputEvent) {
    chars = getNativeBeforeInputChars(topLevelType, nativeEvent);
  } else {
    chars = getFallbackBeforeInputChars(topLevelType, nativeEvent);
  }

  // If no characters are being inserted, no BeforeInput event should
  // be fired.
  if (!chars) {
    return null;
  }

  var event = SyntheticInputEvent_1.getPooled(eventTypes.beforeInput, targetInst, nativeEvent, nativeEventTarget);

  event.data = chars;
  EventPropagators_1.accumulateTwoPhaseDispatches(event);
  return event;
}

/**
 * Create an `onBeforeInput` event to match
 * http://www.w3.org/TR/2013/WD-DOM-Level-3-Events-20131105/#events-inputevents.
 *
 * This event plugin is based on the native `textInput` event
 * available in Chrome, Safari, Opera, and IE. This event fires after
 * `onKeyPress` and `onCompositionEnd`, but before `onInput`.
 *
 * `beforeInput` is spec'd but not implemented in any browsers, and
 * the `input` event does not provide any useful information about what has
 * actually been added, contrary to the spec. Thus, `textInput` is the best
 * available event to identify the characters that have actually been inserted
 * into the target node.
 *
 * This plugin is also responsible for emitting `composition` events, thus
 * allowing us to share composition fallback code for both `beforeInput` and
 * `composition` event types.
 */
var BeforeInputEventPlugin = {

  eventTypes: eventTypes,

  extractEvents: function (topLevelType, targetInst, nativeEvent, nativeEventTarget) {
    return [extractCompositionEvent(topLevelType, targetInst, nativeEvent, nativeEventTarget), extractBeforeInputEvent(topLevelType, targetInst, nativeEvent, nativeEventTarget)];
  }
};

var BeforeInputEventPlugin_1 = BeforeInputEventPlugin;

function _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError("Cannot call a class as a function"); } }





/**
 * A specialized pseudo-event module to help keep track of components waiting to
 * be notified when their DOM representations are available for use.
 *
 * This implements `PooledClass`, so you should never need to instantiate this.
 * Instead, use `CallbackQueue.getPooled()`.
 *
 * @class ReactMountReady
 * @implements PooledClass
 * @internal
 */

var CallbackQueue = function () {
  function CallbackQueue(arg) {
    _classCallCheck(this, CallbackQueue);

    this._callbacks = null;
    this._contexts = null;
    this._arg = arg;
  }

  /**
   * Enqueues a callback to be invoked when `notifyAll` is invoked.
   *
   * @param {function} callback Invoked when `notifyAll` is invoked.
   * @param {?object} context Context to call `callback` with.
   * @internal
   */


  CallbackQueue.prototype.enqueue = function enqueue(callback, context) {
    this._callbacks = this._callbacks || [];
    this._callbacks.push(callback);
    this._contexts = this._contexts || [];
    this._contexts.push(context);
  };

  /**
   * Invokes all enqueued callbacks and clears the queue. This is invoked after
   * the DOM representation of a component has been created or updated.
   *
   * @internal
   */


  CallbackQueue.prototype.notifyAll = function notifyAll() {
    var callbacks = this._callbacks;
    var contexts = this._contexts;
    var arg = this._arg;
    if (callbacks && contexts) {
      !(callbacks.length === contexts.length) ? invariant_1(false, 'Mismatched list of contexts in callback queue') : void 0;
      this._callbacks = null;
      this._contexts = null;
      for (var i = 0; i < callbacks.length; i++) {
        callbacks[i].call(contexts[i], arg);
      }
      callbacks.length = 0;
      contexts.length = 0;
    }
  };

  CallbackQueue.prototype.checkpoint = function checkpoint() {
    return this._callbacks ? this._callbacks.length : 0;
  };

  CallbackQueue.prototype.rollback = function rollback(len) {
    if (this._callbacks && this._contexts) {
      this._callbacks.length = len;
      this._contexts.length = len;
    }
  };

  /**
   * Resets the internal queue.
   *
   * @internal
   */


  CallbackQueue.prototype.reset = function reset() {
    this._callbacks = null;
    this._contexts = null;
  };

  /**
   * `PooledClass` looks for this.
   */


  CallbackQueue.prototype.destructor = function destructor() {
    this.reset();
  };

  return CallbackQueue;
}();

var CallbackQueue_1 = PooledClass_1$2.addPoolingTo(CallbackQueue);

/**
 * Copyright 2013-present, Facebook, Inc.
 * All rights reserved.
 *
 * This source code is licensed under the BSD-style license found in the
 * LICENSE file in the root directory of this source tree. An additional grant
 * of patent rights can be found in the PATENTS file in the same directory.
 *
 * 
 */

var ReactFeatureFlags = {
  // When true, call console.time() before and .timeEnd() after each top-level
  // render (both initial renders and updates). Useful when looking at prod-mode
  // timeline profiles in Chrome, for example.
  logTopLevelRenders: false
};

var ReactFeatureFlags_1 = ReactFeatureFlags;

function isValidOwner(object) {
  return !!(object && typeof object.attachRef === 'function' && typeof object.detachRef === 'function');
}

/**
 * ReactOwners are capable of storing references to owned components.
 *
 * All components are capable of //being// referenced by owner components, but
 * only ReactOwner components are capable of //referencing// owned components.
 * The named reference is known as a "ref".
 *
 * Refs are available when mounted and updated during reconciliation.
 *
 *   var MyComponent = React.createClass({
 *     render: function() {
 *       return (
 *         <div onClick={this.handleClick}>
 *           <CustomComponent ref="custom" />
 *         </div>
 *       );
 *     },
 *     handleClick: function() {
 *       this.refs.custom.handleClick();
 *     },
 *     componentDidMount: function() {
 *       this.refs.custom.initialize();
 *     }
 *   });
 *
 * Refs should rarely be used. When refs are used, they should only be done to
 * control data that is not handled by React's data flow.
 *
 * @class ReactOwner
 */
var ReactOwner = {
  /**
   * Adds a component by ref to an owner component.
   *
   * @param {ReactComponent} component Component to reference.
   * @param {string} ref Name by which to refer to the component.
   * @param {ReactOwner} owner Component on which to record the ref.
   * @final
   * @internal
   */
  addComponentAsRefTo: function (component, ref, owner) {
    !isValidOwner(owner) ? invariant_1(false, 'addComponentAsRefTo(...): Only a ReactOwner can have refs. You might be adding a ref to a component that was not created inside a component\'s `render` method, or you have multiple copies of React loaded (details: https://fb.me/react-refs-must-have-owner).') : void 0;
    owner.attachRef(ref, component);
  },

  /**
   * Removes a component by ref from an owner component.
   *
   * @param {ReactComponent} component Component to dereference.
   * @param {string} ref Name of the ref to remove.
   * @param {ReactOwner} owner Component on which the ref is recorded.
   * @final
   * @internal
   */
  removeComponentAsRefFrom: function (component, ref, owner) {
    !isValidOwner(owner) ? invariant_1(false, 'removeComponentAsRefFrom(...): Only a ReactOwner can have refs. You might be removing a ref to a component that was not created inside a component\'s `render` method, or you have multiple copies of React loaded (details: https://fb.me/react-refs-must-have-owner).') : void 0;
    var ownerPublicInstance = owner.getPublicInstance();
    // Check that `component`'s owner is still alive and that `component` is still the current ref
    // because we do not want to detach the ref if another component stole it.
    if (ownerPublicInstance && ownerPublicInstance.refs[ref] === component.getPublicInstance()) {
      owner.detachRef(ref);
    }
  }

};

var ReactOwner_1 = ReactOwner;

var ReactRef = {};

function attachRef(ref, component, owner) {
  if (typeof ref === 'function') {
    ref(component.getPublicInstance());
  } else {
    // Legacy ref
    ReactOwner_1.addComponentAsRefTo(component, ref, owner);
  }
}

function detachRef(ref, component, owner) {
  if (typeof ref === 'function') {
    ref(null);
  } else {
    // Legacy ref
    ReactOwner_1.removeComponentAsRefFrom(component, ref, owner);
  }
}

ReactRef.attachRefs = function (instance, element) {
  if (element === null || typeof element !== 'object') {
    return;
  }
  var ref = element.ref;
  if (ref != null) {
    attachRef(ref, instance, element._owner);
  }
};

ReactRef.shouldUpdateRefs = function (prevElement, nextElement) {
  // If either the owner or a `ref` has changed, make sure the newest owner
  // has stored a reference to `this`, and the previous owner (if different)
  // has forgotten the reference to `this`. We use the element instead
  // of the public this.props because the post processing cannot determine
  // a ref. The ref conceptually lives on the element.

  // TODO: Should this even be possible? The owner cannot change because
  // it's forbidden by shouldUpdateReactComponent. The ref can change
  // if you swap the keys of but not the refs. Reconsider where this check
  // is made. It probably belongs where the key checking and
  // instantiateReactComponent is done.

  var prevRef = null;
  var prevOwner = null;
  if (prevElement !== null && typeof prevElement === 'object') {
    prevRef = prevElement.ref;
    prevOwner = prevElement._owner;
  }

  var nextRef = null;
  var nextOwner = null;
  if (nextElement !== null && typeof nextElement === 'object') {
    nextRef = nextElement.ref;
    nextOwner = nextElement._owner;
  }

  return prevRef !== nextRef ||
  // If owner changes but we have an unchanged function ref, don't update refs
  typeof nextRef === 'string' && nextOwner !== prevOwner;
};

ReactRef.detachRefs = function (instance, element) {
  if (element === null || typeof element !== 'object') {
    return;
  }
  var ref = element.ref;
  if (ref != null) {
    detachRef(ref, instance, element._owner);
  }
};

var ReactRef_1 = ReactRef;

{
  var processingChildContext = false;

  var warnInvalidSetState = function () {
    warning_1(!processingChildContext, 'setState(...): Cannot call setState() inside getChildContext()');
  };
}

var ReactInvalidSetStateWarningHook = {
  onBeginProcessingChildContext: function () {
    processingChildContext = true;
  },
  onEndProcessingChildContext: function () {
    processingChildContext = false;
  },
  onSetState: function () {
    warnInvalidSetState();
  }
};

var ReactInvalidSetStateWarningHook_1 = ReactInvalidSetStateWarningHook;

/**
 * Copyright 2016-present, Facebook, Inc.
 * All rights reserved.
 *
 * This source code is licensed under the BSD-style license found in the
 * LICENSE file in the root directory of this source tree. An additional grant
 * of patent rights can be found in the PATENTS file in the same directory.
 *
 * 
 */

var history$1 = [];

var ReactHostOperationHistoryHook = {
  onHostOperation: function (operation) {
    history$1.push(operation);
  },
  clearHistory: function () {
    if (ReactHostOperationHistoryHook._preventClearing) {
      // Should only be used for tests.
      return;
    }

    history$1 = [];
  },
  getHistory: function () {
    return history$1;
  }
};

var ReactHostOperationHistoryHook_1 = ReactHostOperationHistoryHook;

var performance$1;

if (ExecutionEnvironment_1.canUseDOM) {
  performance$1 = window.performance || window.msPerformance || window.webkitPerformance;
}

var performance_1 = performance$1 || {};

var performanceNow;

/**
 * Detect if we can use `window.performance.now()` and gracefully fallback to
 * `Date.now()` if it doesn't exist. We need to support Firefox < 15 for now
 * because of Facebook's testing infrastructure.
 */
if (performance_1.now) {
  performanceNow = function performanceNow() {
    return performance_1.now();
  };
} else {
  performanceNow = function performanceNow() {
    return Date.now();
  };
}

var performanceNow_1 = performanceNow;

var hooks = [];
var didHookThrowForEvent = {};

function callHook(event, fn, context, arg1, arg2, arg3, arg4, arg5) {
  try {
    fn.call(context, arg1, arg2, arg3, arg4, arg5);
  } catch (e) {
    warning_1(didHookThrowForEvent[event], 'Exception thrown by hook while handling %s: %s', event, e + '\n' + e.stack);
    didHookThrowForEvent[event] = true;
  }
}

function emitEvent(event, arg1, arg2, arg3, arg4, arg5) {
  for (var i = 0; i < hooks.length; i++) {
    var hook = hooks[i];
    var fn = hook[event];
    if (fn) {
      callHook(event, fn, hook, arg1, arg2, arg3, arg4, arg5);
    }
  }
}

var isProfiling = false;
var flushHistory = [];
var lifeCycleTimerStack = [];
var currentFlushNesting = 0;
var currentFlushMeasurements = [];
var currentFlushStartTime = 0;
var currentTimerDebugID = null;
var currentTimerStartTime = 0;
var currentTimerNestedFlushDuration = 0;
var currentTimerType = null;

var lifeCycleTimerHasWarned = false;

function clearHistory() {
  ReactComponentTreeHook_1.purgeUnmountedComponents();
  ReactHostOperationHistoryHook_1.clearHistory();
}

function getTreeSnapshot(registeredIDs) {
  return registeredIDs.reduce(function (tree, id) {
    var ownerID = ReactComponentTreeHook_1.getOwnerID(id);
    var parentID = ReactComponentTreeHook_1.getParentID(id);
    tree[id] = {
      displayName: ReactComponentTreeHook_1.getDisplayName(id),
      text: ReactComponentTreeHook_1.getText(id),
      updateCount: ReactComponentTreeHook_1.getUpdateCount(id),
      childIDs: ReactComponentTreeHook_1.getChildIDs(id),
      // Text nodes don't have owners but this is close enough.
      ownerID: ownerID || parentID && ReactComponentTreeHook_1.getOwnerID(parentID) || 0,
      parentID: parentID
    };
    return tree;
  }, {});
}

function resetMeasurements() {
  var previousStartTime = currentFlushStartTime;
  var previousMeasurements = currentFlushMeasurements;
  var previousOperations = ReactHostOperationHistoryHook_1.getHistory();

  if (currentFlushNesting === 0) {
    currentFlushStartTime = 0;
    currentFlushMeasurements = [];
    clearHistory();
    return;
  }

  if (previousMeasurements.length || previousOperations.length) {
    var registeredIDs = ReactComponentTreeHook_1.getRegisteredIDs();
    flushHistory.push({
      duration: performanceNow_1() - previousStartTime,
      measurements: previousMeasurements || [],
      operations: previousOperations || [],
      treeSnapshot: getTreeSnapshot(registeredIDs)
    });
  }

  clearHistory();
  currentFlushStartTime = performanceNow_1();
  currentFlushMeasurements = [];
}

function checkDebugID(debugID) {
  var allowRoot = arguments.length > 1 && arguments[1] !== undefined ? arguments[1] : false;

  if (allowRoot && debugID === 0) {
    return;
  }
  if (!debugID) {
    warning_1(false, 'ReactDebugTool: debugID may not be empty.');
  }
}

function beginLifeCycleTimer(debugID, timerType) {
  if (currentFlushNesting === 0) {
    return;
  }
  if (currentTimerType && !lifeCycleTimerHasWarned) {
    warning_1(false, 'There is an internal error in the React performance measurement code. ' + 'Did not expect %s timer to start while %s timer is still in ' + 'progress for %s instance.', timerType, currentTimerType || 'no', debugID === currentTimerDebugID ? 'the same' : 'another');
    lifeCycleTimerHasWarned = true;
  }
  currentTimerStartTime = performanceNow_1();
  currentTimerNestedFlushDuration = 0;
  currentTimerDebugID = debugID;
  currentTimerType = timerType;
}

function endLifeCycleTimer(debugID, timerType) {
  if (currentFlushNesting === 0) {
    return;
  }
  if (currentTimerType !== timerType && !lifeCycleTimerHasWarned) {
    warning_1(false, 'There is an internal error in the React performance measurement code. ' + 'We did not expect %s timer to stop while %s timer is still in ' + 'progress for %s instance. Please report this as a bug in React.', timerType, currentTimerType || 'no', debugID === currentTimerDebugID ? 'the same' : 'another');
    lifeCycleTimerHasWarned = true;
  }
  if (isProfiling) {
    currentFlushMeasurements.push({
      timerType: timerType,
      instanceID: debugID,
      duration: performanceNow_1() - currentTimerStartTime - currentTimerNestedFlushDuration
    });
  }
  currentTimerStartTime = 0;
  currentTimerNestedFlushDuration = 0;
  currentTimerDebugID = null;
  currentTimerType = null;
}

function pauseCurrentLifeCycleTimer() {
  var currentTimer = {
    startTime: currentTimerStartTime,
    nestedFlushStartTime: performanceNow_1(),
    debugID: currentTimerDebugID,
    timerType: currentTimerType
  };
  lifeCycleTimerStack.push(currentTimer);
  currentTimerStartTime = 0;
  currentTimerNestedFlushDuration = 0;
  currentTimerDebugID = null;
  currentTimerType = null;
}

function resumeCurrentLifeCycleTimer() {
  var _lifeCycleTimerStack$ = lifeCycleTimerStack.pop(),
      startTime = _lifeCycleTimerStack$.startTime,
      nestedFlushStartTime = _lifeCycleTimerStack$.nestedFlushStartTime,
      debugID = _lifeCycleTimerStack$.debugID,
      timerType = _lifeCycleTimerStack$.timerType;

  var nestedFlushDuration = performanceNow_1() - nestedFlushStartTime;
  currentTimerStartTime = startTime;
  currentTimerNestedFlushDuration += nestedFlushDuration;
  currentTimerDebugID = debugID;
  currentTimerType = timerType;
}

var lastMarkTimeStamp = 0;
var canUsePerformanceMeasure = typeof performance !== 'undefined' && typeof performance.mark === 'function' && typeof performance.clearMarks === 'function' && typeof performance.measure === 'function' && typeof performance.clearMeasures === 'function';

function shouldMark(debugID) {
  if (!isProfiling || !canUsePerformanceMeasure) {
    return false;
  }
  var element = ReactComponentTreeHook_1.getElement(debugID);
  if (element == null || typeof element !== 'object') {
    return false;
  }
  var isHostElement = typeof element.type === 'string';
  if (isHostElement) {
    return false;
  }
  return true;
}

function markBegin(debugID, markType) {
  if (!shouldMark(debugID)) {
    return;
  }

  var markName = debugID + '::' + markType;
  lastMarkTimeStamp = performanceNow_1();
  performance.mark(markName);
}

function markEnd(debugID, markType) {
  if (!shouldMark(debugID)) {
    return;
  }

  var markName = debugID + '::' + markType;
  var displayName = ReactComponentTreeHook_1.getDisplayName(debugID) || 'Unknown';

  // Chrome has an issue of dropping markers recorded too fast:
  // https://bugs.chromium.org/p/chromium/issues/detail?id=640652
  // To work around this, we will not report very small measurements.
  // I determined the magic number by tweaking it back and forth.
  // 0.05ms was enough to prevent the issue, but I set it to 0.1ms to be safe.
  // When the bug is fixed, we can `measure()` unconditionally if we want to.
  var timeStamp = performanceNow_1();
  if (timeStamp - lastMarkTimeStamp > 0.1) {
    var measurementName = displayName + ' [' + markType + ']';
    performance.measure(measurementName, markName);
  }

  performance.clearMarks(markName);
  performance.clearMeasures(measurementName);
}

var ReactDebugTool$1 = {
  addHook: function (hook) {
    hooks.push(hook);
  },
  removeHook: function (hook) {
    for (var i = 0; i < hooks.length; i++) {
      if (hooks[i] === hook) {
        hooks.splice(i, 1);
        i--;
      }
    }
  },
  isProfiling: function () {
    return isProfiling;
  },
  beginProfiling: function () {
    if (isProfiling) {
      return;
    }

    isProfiling = true;
    flushHistory.length = 0;
    resetMeasurements();
    ReactDebugTool$1.addHook(ReactHostOperationHistoryHook_1);
  },
  endProfiling: function () {
    if (!isProfiling) {
      return;
    }

    isProfiling = false;
    resetMeasurements();
    ReactDebugTool$1.removeHook(ReactHostOperationHistoryHook_1);
  },
  getFlushHistory: function () {
    return flushHistory;
  },
  onBeginFlush: function () {
    currentFlushNesting++;
    resetMeasurements();
    pauseCurrentLifeCycleTimer();
    emitEvent('onBeginFlush');
  },
  onEndFlush: function () {
    resetMeasurements();
    currentFlushNesting--;
    resumeCurrentLifeCycleTimer();
    emitEvent('onEndFlush');
  },
  onBeginLifeCycleTimer: function (debugID, timerType) {
    checkDebugID(debugID);
    emitEvent('onBeginLifeCycleTimer', debugID, timerType);
    markBegin(debugID, timerType);
    beginLifeCycleTimer(debugID, timerType);
  },
  onEndLifeCycleTimer: function (debugID, timerType) {
    checkDebugID(debugID);
    endLifeCycleTimer(debugID, timerType);
    markEnd(debugID, timerType);
    emitEvent('onEndLifeCycleTimer', debugID, timerType);
  },
  onBeginProcessingChildContext: function () {
    emitEvent('onBeginProcessingChildContext');
  },
  onEndProcessingChildContext: function () {
    emitEvent('onEndProcessingChildContext');
  },
  onHostOperation: function (operation) {
    checkDebugID(operation.instanceID);
    emitEvent('onHostOperation', operation);
  },
  onSetState: function () {
    emitEvent('onSetState');
  },
  onSetChildren: function (debugID, childDebugIDs) {
    checkDebugID(debugID);
    childDebugIDs.forEach(checkDebugID);
    emitEvent('onSetChildren', debugID, childDebugIDs);
  },
  onBeforeMountComponent: function (debugID, element, parentDebugID) {
    checkDebugID(debugID);
    checkDebugID(parentDebugID, true);
    emitEvent('onBeforeMountComponent', debugID, element, parentDebugID);
    markBegin(debugID, 'mount');
  },
  onMountComponent: function (debugID) {
    checkDebugID(debugID);
    markEnd(debugID, 'mount');
    emitEvent('onMountComponent', debugID);
  },
  onBeforeUpdateComponent: function (debugID, element) {
    checkDebugID(debugID);
    emitEvent('onBeforeUpdateComponent', debugID, element);
    markBegin(debugID, 'update');
  },
  onUpdateComponent: function (debugID) {
    checkDebugID(debugID);
    markEnd(debugID, 'update');
    emitEvent('onUpdateComponent', debugID);
  },
  onBeforeUnmountComponent: function (debugID) {
    checkDebugID(debugID);
    emitEvent('onBeforeUnmountComponent', debugID);
    markBegin(debugID, 'unmount');
  },
  onUnmountComponent: function (debugID) {
    checkDebugID(debugID);
    markEnd(debugID, 'unmount');
    emitEvent('onUnmountComponent', debugID);
  },
  onTestEvent: function () {
    emitEvent('onTestEvent');
  }
};

// TODO remove these when RN/www gets updated
ReactDebugTool$1.addDevtool = ReactDebugTool$1.addHook;
ReactDebugTool$1.removeDevtool = ReactDebugTool$1.removeHook;

ReactDebugTool$1.addHook(ReactInvalidSetStateWarningHook_1);
ReactDebugTool$1.addHook(ReactComponentTreeHook_1);
var url = ExecutionEnvironment_1.canUseDOM && window.location.href || '';
if (/[?&]react_perf\b/.test(url)) {
  ReactDebugTool$1.beginProfiling();
}

var ReactDebugTool_1 = ReactDebugTool$1;

var debugTool = null;

{
  var ReactDebugTool = ReactDebugTool_1;
  debugTool = ReactDebugTool;
}

var ReactInstrumentation$1 = { debugTool: debugTool };

function attachRefs() {
  ReactRef_1.attachRefs(this, this._currentElement);
}

var ReactReconciler = {

  /**
   * Initializes the component, renders markup, and registers event listeners.
   *
   * @param {ReactComponent} internalInstance
   * @param {ReactReconcileTransaction|ReactServerRenderingTransaction} transaction
   * @param {?object} the containing host component instance
   * @param {?object} info about the host container
   * @return {?string} Rendered markup to be inserted into the DOM.
   * @final
   * @internal
   */
  mountComponent: function (internalInstance, transaction, hostParent, hostContainerInfo, context, parentDebugID // 0 in production and for roots
  ) {
    {
      if (internalInstance._debugID !== 0) {
        ReactInstrumentation$1.debugTool.onBeforeMountComponent(internalInstance._debugID, internalInstance._currentElement, parentDebugID);
      }
    }
    var markup = internalInstance.mountComponent(transaction, hostParent, hostContainerInfo, context, parentDebugID);
    if (internalInstance._currentElement && internalInstance._currentElement.ref != null) {
      transaction.getReactMountReady().enqueue(attachRefs, internalInstance);
    }
    {
      if (internalInstance._debugID !== 0) {
        ReactInstrumentation$1.debugTool.onMountComponent(internalInstance._debugID);
      }
    }
    return markup;
  },

  /**
   * Returns a value that can be passed to
   * ReactComponentEnvironment.replaceNodeWithMarkup.
   */
  getHostNode: function (internalInstance) {
    return internalInstance.getHostNode();
  },

  /**
   * Releases any resources allocated by `mountComponent`.
   *
   * @final
   * @internal
   */
  unmountComponent: function (internalInstance, safely) {
    {
      if (internalInstance._debugID !== 0) {
        ReactInstrumentation$1.debugTool.onBeforeUnmountComponent(internalInstance._debugID);
      }
    }
    ReactRef_1.detachRefs(internalInstance, internalInstance._currentElement);
    internalInstance.unmountComponent(safely);
    {
      if (internalInstance._debugID !== 0) {
        ReactInstrumentation$1.debugTool.onUnmountComponent(internalInstance._debugID);
      }
    }
  },

  /**
   * Update a component using a new element.
   *
   * @param {ReactComponent} internalInstance
   * @param {ReactElement} nextElement
   * @param {ReactReconcileTransaction} transaction
   * @param {object} context
   * @internal
   */
  receiveComponent: function (internalInstance, nextElement, transaction, context) {
    var prevElement = internalInstance._currentElement;

    if (nextElement === prevElement && context === internalInstance._context) {
      // Since elements are immutable after the owner is rendered,
      // we can do a cheap identity compare here to determine if this is a
      // superfluous reconcile. It's possible for state to be mutable but such
      // change should trigger an update of the owner which would recreate
      // the element. We explicitly check for the existence of an owner since
      // it's possible for an element created outside a composite to be
      // deeply mutated and reused.

      // TODO: Bailing out early is just a perf optimization right?
      // TODO: Removing the return statement should affect correctness?
      return;
    }

    {
      if (internalInstance._debugID !== 0) {
        ReactInstrumentation$1.debugTool.onBeforeUpdateComponent(internalInstance._debugID, nextElement);
      }
    }

    var refsChanged = ReactRef_1.shouldUpdateRefs(prevElement, nextElement);

    if (refsChanged) {
      ReactRef_1.detachRefs(internalInstance, prevElement);
    }

    internalInstance.receiveComponent(nextElement, transaction, context);

    if (refsChanged && internalInstance._currentElement && internalInstance._currentElement.ref != null) {
      transaction.getReactMountReady().enqueue(attachRefs, internalInstance);
    }

    {
      if (internalInstance._debugID !== 0) {
        ReactInstrumentation$1.debugTool.onUpdateComponent(internalInstance._debugID);
      }
    }
  },

  /**
   * Flush any dirty changes in a component.
   *
   * @param {ReactComponent} internalInstance
   * @param {ReactReconcileTransaction} transaction
   * @internal
   */
  performUpdateIfNecessary: function (internalInstance, transaction, updateBatchNumber) {
    if (internalInstance._updateBatchNumber !== updateBatchNumber) {
      // The component's enqueued batch number should always be the current
      // batch or the following one.
      warning_1(internalInstance._updateBatchNumber == null || internalInstance._updateBatchNumber === updateBatchNumber + 1, 'performUpdateIfNecessary: Unexpected batch number (current %s, ' + 'pending %s)', updateBatchNumber, internalInstance._updateBatchNumber);
      return;
    }
    {
      if (internalInstance._debugID !== 0) {
        ReactInstrumentation$1.debugTool.onBeforeUpdateComponent(internalInstance._debugID, internalInstance._currentElement);
      }
    }
    internalInstance.performUpdateIfNecessary(transaction);
    {
      if (internalInstance._debugID !== 0) {
        ReactInstrumentation$1.debugTool.onUpdateComponent(internalInstance._debugID);
      }
    }
  }

};

var ReactReconciler_1 = ReactReconciler;

var OBSERVED_ERROR = {};

/**
 * `Transaction` creates a black box that is able to wrap any method such that
 * certain invariants are maintained before and after the method is invoked
 * (Even if an exception is thrown while invoking the wrapped method). Whoever
 * instantiates a transaction can provide enforcers of the invariants at
 * creation time. The `Transaction` class itself will supply one additional
 * automatic invariant for you - the invariant that any transaction instance
 * should not be run while it is already being run. You would typically create a
 * single instance of a `Transaction` for reuse multiple times, that potentially
 * is used to wrap several different methods. Wrappers are extremely simple -
 * they only require implementing two methods.
 *
 * <pre>
 *                       wrappers (injected at creation time)
 *                                      +        +
 *                                      |        |
 *                    +-----------------|--------|--------------+
 *                    |                 v        |              |
 *                    |      +---------------+   |              |
 *                    |   +--|    wrapper1   |---|----+         |
 *                    |   |  +---------------+   v    |         |
 *                    |   |          +-------------+  |         |
 *                    |   |     +----|   wrapper2  |--------+   |
 *                    |   |     |    +-------------+  |     |   |
 *                    |   |     |                     |     |   |
 *                    |   v     v                     v     v   | wrapper
 *                    | +---+ +---+   +---------+   +---+ +---+ | invariants
 * perform(anyMethod) | |   | |   |   |         |   |   | |   | | maintained
 * +----------------->|-|---|-|---|-->|anyMethod|---|---|-|---|-|-------->
 *                    | |   | |   |   |         |   |   | |   | |
 *                    | |   | |   |   |         |   |   | |   | |
 *                    | |   | |   |   |         |   |   | |   | |
 *                    | +---+ +---+   +---------+   +---+ +---+ |
 *                    |  initialize                    close    |
 *                    +-----------------------------------------+
 * </pre>
 *
 * Use cases:
 * - Preserving the input selection ranges before/after reconciliation.
 *   Restoring selection even in the event of an unexpected error.
 * - Deactivating events while rearranging the DOM, preventing blurs/focuses,
 *   while guaranteeing that afterwards, the event system is reactivated.
 * - Flushing a queue of collected DOM mutations to the main UI thread after a
 *   reconciliation takes place in a worker thread.
 * - Invoking any collected `componentDidUpdate` callbacks after rendering new
 *   content.
 * - (Future use case): Wrapping particular flushes of the `ReactWorker` queue
 *   to preserve the `scrollTop` (an automatic scroll aware DOM).
 * - (Future use case): Layout calculations before and after DOM updates.
 *
 * Transactional plugin API:
 * - A module that has an `initialize` method that returns any precomputation.
 * - and a `close` method that accepts the precomputation. `close` is invoked
 *   when the wrapped process is completed, or has failed.
 *
 * @param {Array<TransactionalWrapper>} transactionWrapper Wrapper modules
 * that implement `initialize` and `close`.
 * @return {Transaction} Single transaction for reuse in thread.
 *
 * @class Transaction
 */
var TransactionImpl = {
  /**
   * Sets up this instance so that it is prepared for collecting metrics. Does
   * so such that this setup method may be used on an instance that is already
   * initialized, in a way that does not consume additional memory upon reuse.
   * That can be useful if you decide to make your subclass of this mixin a
   * "PooledClass".
   */
  reinitializeTransaction: function () {
    this.transactionWrappers = this.getTransactionWrappers();
    if (this.wrapperInitData) {
      this.wrapperInitData.length = 0;
    } else {
      this.wrapperInitData = [];
    }
    this._isInTransaction = false;
  },

  _isInTransaction: false,

  /**
   * @abstract
   * @return {Array<TransactionWrapper>} Array of transaction wrappers.
   */
  getTransactionWrappers: null,

  isInTransaction: function () {
    return !!this._isInTransaction;
  },

  /**
   * Executes the function within a safety window. Use this for the top level
   * methods that result in large amounts of computation/mutations that would
   * need to be safety checked. The optional arguments helps prevent the need
   * to bind in many cases.
   *
   * @param {function} method Member of scope to call.
   * @param {Object} scope Scope to invoke from.
   * @param {Object?=} a Argument to pass to the method.
   * @param {Object?=} b Argument to pass to the method.
   * @param {Object?=} c Argument to pass to the method.
   * @param {Object?=} d Argument to pass to the method.
   * @param {Object?=} e Argument to pass to the method.
   * @param {Object?=} f Argument to pass to the method.
   *
   * @return {*} Return value from `method`.
   */
  perform: function (method, scope, a, b, c, d, e, f) {
    !!this.isInTransaction() ? invariant_1(false, 'Transaction.perform(...): Cannot initialize a transaction when there is already an outstanding transaction.') : void 0;
    var errorThrown;
    var ret;
    try {
      this._isInTransaction = true;
      // Catching errors makes debugging more difficult, so we start with
      // errorThrown set to true before setting it to false after calling
      // close -- if it's still set to true in the finally block, it means
      // one of these calls threw.
      errorThrown = true;
      this.initializeAll(0);
      ret = method.call(scope, a, b, c, d, e, f);
      errorThrown = false;
    } finally {
      try {
        if (errorThrown) {
          // If `method` throws, prefer to show that stack trace over any thrown
          // by invoking `closeAll`.
          try {
            this.closeAll(0);
          } catch (err) {}
        } else {
          // Since `method` didn't throw, we don't want to silence the exception
          // here.
          this.closeAll(0);
        }
      } finally {
        this._isInTransaction = false;
      }
    }
    return ret;
  },

  initializeAll: function (startIndex) {
    var transactionWrappers = this.transactionWrappers;
    for (var i = startIndex; i < transactionWrappers.length; i++) {
      var wrapper = transactionWrappers[i];
      try {
        // Catching errors makes debugging more difficult, so we start with the
        // OBSERVED_ERROR state before overwriting it with the real return value
        // of initialize -- if it's still set to OBSERVED_ERROR in the finally
        // block, it means wrapper.initialize threw.
        this.wrapperInitData[i] = OBSERVED_ERROR;
        this.wrapperInitData[i] = wrapper.initialize ? wrapper.initialize.call(this) : null;
      } finally {
        if (this.wrapperInitData[i] === OBSERVED_ERROR) {
          // The initializer for wrapper i threw an error; initialize the
          // remaining wrappers but silence any exceptions from them to ensure
          // that the first error is the one to bubble up.
          try {
            this.initializeAll(i + 1);
          } catch (err) {}
        }
      }
    }
  },

  /**
   * Invokes each of `this.transactionWrappers.close[i]` functions, passing into
   * them the respective return values of `this.transactionWrappers.init[i]`
   * (`close`rs that correspond to initializers that failed will not be
   * invoked).
   */
  closeAll: function (startIndex) {
    !this.isInTransaction() ? invariant_1(false, 'Transaction.closeAll(): Cannot close transaction when none are open.') : void 0;
    var transactionWrappers = this.transactionWrappers;
    for (var i = startIndex; i < transactionWrappers.length; i++) {
      var wrapper = transactionWrappers[i];
      var initData = this.wrapperInitData[i];
      var errorThrown;
      try {
        // Catching errors makes debugging more difficult, so we start with
        // errorThrown set to true before setting it to false after calling
        // close -- if it's still set to true in the finally block, it means
        // wrapper.close threw.
        errorThrown = true;
        if (initData !== OBSERVED_ERROR && wrapper.close) {
          wrapper.close.call(this, initData);
        }
        errorThrown = false;
      } finally {
        if (errorThrown) {
          // The closer for wrapper i threw an error; close the remaining
          // wrappers but silence any exceptions from them to ensure that the
          // first error is the one to bubble up.
          try {
            this.closeAll(i + 1);
          } catch (e) {}
        }
      }
    }
    this.wrapperInitData.length = 0;
  }
};

var Transaction = TransactionImpl;

var dirtyComponents = [];
var updateBatchNumber = 0;
var asapCallbackQueue = CallbackQueue_1.getPooled();
var asapEnqueued = false;

var batchingStrategy = null;

function ensureInjected() {
  !(ReactUpdates.ReactReconcileTransaction && batchingStrategy) ? invariant_1(false, 'ReactUpdates: must inject a reconcile transaction class and batching strategy') : void 0;
}

var NESTED_UPDATES = {
  initialize: function () {
    this.dirtyComponentsLength = dirtyComponents.length;
  },
  close: function () {
    if (this.dirtyComponentsLength !== dirtyComponents.length) {
      // Additional updates were enqueued by componentDidUpdate handlers or
      // similar; before our own UPDATE_QUEUEING wrapper closes, we want to run
      // these new updates so that if A's componentDidUpdate calls setState on
      // B, B will update before the callback A's updater provided when calling
      // setState.
      dirtyComponents.splice(0, this.dirtyComponentsLength);
      flushBatchedUpdates();
    } else {
      dirtyComponents.length = 0;
    }
  }
};

var UPDATE_QUEUEING = {
  initialize: function () {
    this.callbackQueue.reset();
  },
  close: function () {
    this.callbackQueue.notifyAll();
  }
};

var TRANSACTION_WRAPPERS = [NESTED_UPDATES, UPDATE_QUEUEING];

function ReactUpdatesFlushTransaction() {
  this.reinitializeTransaction();
  this.dirtyComponentsLength = null;
  this.callbackQueue = CallbackQueue_1.getPooled();
  this.reconcileTransaction = ReactUpdates.ReactReconcileTransaction.getPooled(
  /* useCreateElement */true);
}

index(ReactUpdatesFlushTransaction.prototype, Transaction, {
  getTransactionWrappers: function () {
    return TRANSACTION_WRAPPERS;
  },

  destructor: function () {
    this.dirtyComponentsLength = null;
    CallbackQueue_1.release(this.callbackQueue);
    this.callbackQueue = null;
    ReactUpdates.ReactReconcileTransaction.release(this.reconcileTransaction);
    this.reconcileTransaction = null;
  },

  perform: function (method, scope, a) {
    // Essentially calls `this.reconcileTransaction.perform(method, scope, a)`
    // with this transaction's wrappers around it.
    return Transaction.perform.call(this, this.reconcileTransaction.perform, this.reconcileTransaction, method, scope, a);
  }
});

PooledClass_1$2.addPoolingTo(ReactUpdatesFlushTransaction);

function batchedUpdates(callback, a, b, c, d, e) {
  ensureInjected();
  return batchingStrategy.batchedUpdates(callback, a, b, c, d, e);
}

/**
 * Array comparator for ReactComponents by mount ordering.
 *
 * @param {ReactComponent} c1 first component you're comparing
 * @param {ReactComponent} c2 second component you're comparing
 * @return {number} Return value usable by Array.prototype.sort().
 */
function mountOrderComparator(c1, c2) {
  return c1._mountOrder - c2._mountOrder;
}

function runBatchedUpdates(transaction) {
  var len = transaction.dirtyComponentsLength;
  !(len === dirtyComponents.length) ? invariant_1(false, 'Expected flush transaction\'s stored dirty-components length (%s) to match dirty-components array length (%s).', len, dirtyComponents.length) : void 0;

  // Since reconciling a component higher in the owner hierarchy usually (not
  // always -- see shouldComponentUpdate()) will reconcile children, reconcile
  // them before their children by sorting the array.
  dirtyComponents.sort(mountOrderComparator);

  // Any updates enqueued while reconciling must be performed after this entire
  // batch. Otherwise, if dirtyComponents is [A, B] where A has children B and
  // C, B could update twice in a single batch if C's render enqueues an update
  // to B (since B would have already updated, we should skip it, and the only
  // way we can know to do so is by checking the batch counter).
  updateBatchNumber++;

  for (var i = 0; i < len; i++) {
    // If a component is unmounted before pending changes apply, it will still
    // be here, but we assume that it has cleared its _pendingCallbacks and
    // that performUpdateIfNecessary is a noop.
    var component = dirtyComponents[i];

    // If performUpdateIfNecessary happens to enqueue any new updates, we
    // shouldn't execute the callbacks until the next render happens, so
    // stash the callbacks first
    var callbacks = component._pendingCallbacks;
    component._pendingCallbacks = null;

    var markerName;
    if (ReactFeatureFlags_1.logTopLevelRenders) {
      var namedComponent = component;
      // Duck type TopLevelWrapper. This is probably always true.
      if (component._currentElement.type.isReactTopLevelWrapper) {
        namedComponent = component._renderedComponent;
      }
      markerName = 'React update: ' + namedComponent.getName();
      console.time(markerName);
    }

    ReactReconciler_1.performUpdateIfNecessary(component, transaction.reconcileTransaction, updateBatchNumber);

    if (markerName) {
      console.timeEnd(markerName);
    }

    if (callbacks) {
      for (var j = 0; j < callbacks.length; j++) {
        transaction.callbackQueue.enqueue(callbacks[j], component.getPublicInstance());
      }
    }
  }
}

var flushBatchedUpdates = function () {
  // ReactUpdatesFlushTransaction's wrappers will clear the dirtyComponents
  // array and perform any updates enqueued by mount-ready handlers (i.e.,
  // componentDidUpdate) but we need to check here too in order to catch
  // updates enqueued by setState callbacks and asap calls.
  while (dirtyComponents.length || asapEnqueued) {
    if (dirtyComponents.length) {
      var transaction = ReactUpdatesFlushTransaction.getPooled();
      transaction.perform(runBatchedUpdates, null, transaction);
      ReactUpdatesFlushTransaction.release(transaction);
    }

    if (asapEnqueued) {
      asapEnqueued = false;
      var queue = asapCallbackQueue;
      asapCallbackQueue = CallbackQueue_1.getPooled();
      queue.notifyAll();
      CallbackQueue_1.release(queue);
    }
  }
};

/**
 * Mark a component as needing a rerender, adding an optional callback to a
 * list of functions which will be executed once the rerender occurs.
 */
function enqueueUpdate(component) {
  ensureInjected();

  // Various parts of our code (such as ReactCompositeComponent's
  // _renderValidatedComponent) assume that calls to render aren't nested;
  // verify that that's the case. (This is called by each top-level update
  // function, like setState, forceUpdate, etc.; creation and
  // destruction of top-level components is guarded in ReactMount.)

  if (!batchingStrategy.isBatchingUpdates) {
    batchingStrategy.batchedUpdates(enqueueUpdate, component);
    return;
  }

  dirtyComponents.push(component);
  if (component._updateBatchNumber == null) {
    component._updateBatchNumber = updateBatchNumber + 1;
  }
}

/**
 * Enqueue a callback to be run at the end of the current batching cycle. Throws
 * if no updates are currently being performed.
 */
function asap(callback, context) {
  !batchingStrategy.isBatchingUpdates ? invariant_1(false, 'ReactUpdates.asap: Can\'t enqueue an asap callback in a context whereupdates are not being batched.') : void 0;
  asapCallbackQueue.enqueue(callback, context);
  asapEnqueued = true;
}

var ReactUpdatesInjection = {
  injectReconcileTransaction: function (ReconcileTransaction) {
    !ReconcileTransaction ? invariant_1(false, 'ReactUpdates: must provide a reconcile transaction class') : void 0;
    ReactUpdates.ReactReconcileTransaction = ReconcileTransaction;
  },

  injectBatchingStrategy: function (_batchingStrategy) {
    !_batchingStrategy ? invariant_1(false, 'ReactUpdates: must provide a batching strategy') : void 0;
    !(typeof _batchingStrategy.batchedUpdates === 'function') ? invariant_1(false, 'ReactUpdates: must provide a batchedUpdates() function') : void 0;
    !(typeof _batchingStrategy.isBatchingUpdates === 'boolean') ? invariant_1(false, 'ReactUpdates: must provide an isBatchingUpdates boolean attribute') : void 0;
    batchingStrategy = _batchingStrategy;
  }
};

var ReactUpdates = {
  /**
   * React references `ReactReconcileTransaction` using this property in order
   * to allow dependency injection.
   *
   * @internal
   */
  ReactReconcileTransaction: null,

  batchedUpdates: batchedUpdates,
  enqueueUpdate: enqueueUpdate,
  flushBatchedUpdates: flushBatchedUpdates,
  injection: ReactUpdatesInjection,
  asap: asap
};

var ReactUpdates_1 = ReactUpdates;

/**
 * Copyright 2013-present, Facebook, Inc.
 * All rights reserved.
 *
 * This source code is licensed under the BSD-style license found in the
 * LICENSE file in the root directory of this source tree. An additional grant
 * of patent rights can be found in the PATENTS file in the same directory.
 *
 */

function getEventTarget(nativeEvent) {
  var target = nativeEvent.target || nativeEvent.srcElement || window;

  // Normalize SVG <use> element events #4963
  if (target.correspondingUseElement) {
    target = target.correspondingUseElement;
  }

  // Safari may fire events on text nodes (Node.TEXT_NODE is 3).
  // @see http://www.quirksmode.org/js/events_properties.html
  return target.nodeType === 3 ? target.parentNode : target;
}

var getEventTarget_1 = getEventTarget;

var useHasFeature;
if (ExecutionEnvironment_1.canUseDOM) {
  useHasFeature = document.implementation && document.implementation.hasFeature &&
  // always returns true in newer browsers as per the standard.
  // @see http://dom.spec.whatwg.org/#dom-domimplementation-hasfeature
  document.implementation.hasFeature('', '') !== true;
}

/**
 * Checks if an event is supported in the current execution environment.
 *
 * NOTE: This will not work correctly for non-generic events such as `change`,
 * `reset`, `load`, `error`, and `select`.
 *
 * Borrows from Modernizr.
 *
 * @param {string} eventNameSuffix Event name, e.g. "click".
 * @param {?boolean} capture Check if the capture phase is supported.
 * @return {boolean} True if the event is supported.
 * @internal
 * @license Modernizr 3.0.0pre (Custom Build) | MIT
 */
function isEventSupported(eventNameSuffix, capture) {
  if (!ExecutionEnvironment_1.canUseDOM || capture && !('addEventListener' in document)) {
    return false;
  }

  var eventName = 'on' + eventNameSuffix;
  var isSupported = eventName in document;

  if (!isSupported) {
    var element = document.createElement('div');
    element.setAttribute(eventName, 'return;');
    isSupported = typeof element[eventName] === 'function';
  }

  if (!isSupported && useHasFeature && eventNameSuffix === 'wheel') {
    // This is the only way to test support for the `wheel` event in IE9+.
    isSupported = document.implementation.hasFeature('Events.wheel', '3.0');
  }

  return isSupported;
}

var isEventSupported_1 = isEventSupported;

/**
 * Copyright 2013-present, Facebook, Inc.
 * All rights reserved.
 *
 * This source code is licensed under the BSD-style license found in the
 * LICENSE file in the root directory of this source tree. An additional grant
 * of patent rights can be found in the PATENTS file in the same directory.
 *
 * 
 */

var supportedInputTypes = {
  'color': true,
  'date': true,
  'datetime': true,
  'datetime-local': true,
  'email': true,
  'month': true,
  'number': true,
  'password': true,
  'range': true,
  'search': true,
  'tel': true,
  'text': true,
  'time': true,
  'url': true,
  'week': true
};

function isTextInputElement(elem) {
  var nodeName = elem && elem.nodeName && elem.nodeName.toLowerCase();

  if (nodeName === 'input') {
    return !!supportedInputTypes[elem.type];
  }

  if (nodeName === 'textarea') {
    return true;
  }

  return false;
}

var isTextInputElement_1 = isTextInputElement;

var eventTypes$1 = {
  change: {
    phasedRegistrationNames: {
      bubbled: 'onChange',
      captured: 'onChangeCapture'
    },
    dependencies: ['topBlur', 'topChange', 'topClick', 'topFocus', 'topInput', 'topKeyDown', 'topKeyUp', 'topSelectionChange']
  }
};

/**
 * For IE shims
 */
var activeElement = null;
var activeElementInst = null;
var activeElementValue = null;
var activeElementValueProp = null;

/**
 * SECTION: handle `change` event
 */
function shouldUseChangeEvent(elem) {
  var nodeName = elem.nodeName && elem.nodeName.toLowerCase();
  return nodeName === 'select' || nodeName === 'input' && elem.type === 'file';
}

var doesChangeEventBubble = false;
if (ExecutionEnvironment_1.canUseDOM) {
  // See `handleChange` comment below
  doesChangeEventBubble = isEventSupported_1('change') && (!document.documentMode || document.documentMode > 8);
}

function manualDispatchChangeEvent(nativeEvent) {
  var event = SyntheticEvent_1.getPooled(eventTypes$1.change, activeElementInst, nativeEvent, getEventTarget_1(nativeEvent));
  EventPropagators_1.accumulateTwoPhaseDispatches(event);

  // If change and propertychange bubbled, we'd just bind to it like all the
  // other events and have it go through ReactBrowserEventEmitter. Since it
  // doesn't, we manually listen for the events and so we have to enqueue and
  // process the abstract event manually.
  //
  // Batching is necessary here in order to ensure that all event handlers run
  // before the next rerender (including event handlers attached to ancestor
  // elements instead of directly on the input). Without this, controlled
  // components don't work properly in conjunction with event bubbling because
  // the component is rerendered and the value reverted before all the event
  // handlers can run. See https://github.com/facebook/react/issues/708.
  ReactUpdates_1.batchedUpdates(runEventInBatch, event);
}

function runEventInBatch(event) {
  EventPluginHub_1.enqueueEvents(event);
  EventPluginHub_1.processEventQueue(false);
}

function startWatchingForChangeEventIE8(target, targetInst) {
  activeElement = target;
  activeElementInst = targetInst;
  activeElement.attachEvent('onchange', manualDispatchChangeEvent);
}

function stopWatchingForChangeEventIE8() {
  if (!activeElement) {
    return;
  }
  activeElement.detachEvent('onchange', manualDispatchChangeEvent);
  activeElement = null;
  activeElementInst = null;
}

function getTargetInstForChangeEvent(topLevelType, targetInst) {
  if (topLevelType === 'topChange') {
    return targetInst;
  }
}
function handleEventsForChangeEventIE8(topLevelType, target, targetInst) {
  if (topLevelType === 'topFocus') {
    // stopWatching() should be a noop here but we call it just in case we
    // missed a blur event somehow.
    stopWatchingForChangeEventIE8();
    startWatchingForChangeEventIE8(target, targetInst);
  } else if (topLevelType === 'topBlur') {
    stopWatchingForChangeEventIE8();
  }
}

/**
 * SECTION: handle `input` event
 */
var isInputEventSupported = false;
if (ExecutionEnvironment_1.canUseDOM) {
  // IE9 claims to support the input event but fails to trigger it when
  // deleting text, so we ignore its input events.
  // IE10+ fire input events to often, such when a placeholder
  // changes or when an input with a placeholder is focused.
  isInputEventSupported = isEventSupported_1('input') && (!document.documentMode || document.documentMode > 11);
}

/**
 * (For IE <=11) Replacement getter/setter for the `value` property that gets
 * set on the active element.
 */
var newValueProp = {
  get: function () {
    return activeElementValueProp.get.call(this);
  },
  set: function (val) {
    // Cast to a string so we can do equality checks.
    activeElementValue = '' + val;
    activeElementValueProp.set.call(this, val);
  }
};

/**
 * (For IE <=11) Starts tracking propertychange events on the passed-in element
 * and override the value property so that we can distinguish user events from
 * value changes in JS.
 */
function startWatchingForValueChange(target, targetInst) {
  activeElement = target;
  activeElementInst = targetInst;
  activeElementValue = target.value;
  activeElementValueProp = Object.getOwnPropertyDescriptor(target.constructor.prototype, 'value');

  // Not guarded in a canDefineProperty check: IE8 supports defineProperty only
  // on DOM elements
  Object.defineProperty(activeElement, 'value', newValueProp);
  if (activeElement.attachEvent) {
    activeElement.attachEvent('onpropertychange', handlePropertyChange);
  } else {
    activeElement.addEventListener('propertychange', handlePropertyChange, false);
  }
}

/**
 * (For IE <=11) Removes the event listeners from the currently-tracked element,
 * if any exists.
 */
function stopWatchingForValueChange() {
  if (!activeElement) {
    return;
  }

  // delete restores the original property definition
  delete activeElement.value;

  if (activeElement.detachEvent) {
    activeElement.detachEvent('onpropertychange', handlePropertyChange);
  } else {
    activeElement.removeEventListener('propertychange', handlePropertyChange, false);
  }

  activeElement = null;
  activeElementInst = null;
  activeElementValue = null;
  activeElementValueProp = null;
}

/**
 * (For IE <=11) Handles a propertychange event, sending a `change` event if
 * the value of the active element has changed.
 */
function handlePropertyChange(nativeEvent) {
  if (nativeEvent.propertyName !== 'value') {
    return;
  }
  var value = nativeEvent.srcElement.value;
  if (value === activeElementValue) {
    return;
  }
  activeElementValue = value;

  manualDispatchChangeEvent(nativeEvent);
}

/**
 * If a `change` event should be fired, returns the target's ID.
 */
function getTargetInstForInputEvent(topLevelType, targetInst) {
  if (topLevelType === 'topInput') {
    // In modern browsers (i.e., not IE8 or IE9), the input event is exactly
    // what we want so fall through here and trigger an abstract event
    return targetInst;
  }
}

function handleEventsForInputEventIE(topLevelType, target, targetInst) {
  if (topLevelType === 'topFocus') {
    // In IE8, we can capture almost all .value changes by adding a
    // propertychange handler and looking for events with propertyName
    // equal to 'value'
    // In IE9-11, propertychange fires for most input events but is buggy and
    // doesn't fire when text is deleted, but conveniently, selectionchange
    // appears to fire in all of the remaining cases so we catch those and
    // forward the event if the value has changed
    // In either case, we don't want to call the event handler if the value
    // is changed from JS so we redefine a setter for `.value` that updates
    // our activeElementValue variable, allowing us to ignore those changes
    //
    // stopWatching() should be a noop here but we call it just in case we
    // missed a blur event somehow.
    stopWatchingForValueChange();
    startWatchingForValueChange(target, targetInst);
  } else if (topLevelType === 'topBlur') {
    stopWatchingForValueChange();
  }
}

// For IE8 and IE9.
function getTargetInstForInputEventIE(topLevelType, targetInst) {
  if (topLevelType === 'topSelectionChange' || topLevelType === 'topKeyUp' || topLevelType === 'topKeyDown') {
    // On the selectionchange event, the target is just document which isn't
    // helpful for us so just check activeElement instead.
    //
    // 99% of the time, keydown and keyup aren't necessary. IE8 fails to fire
    // propertychange on the first input event after setting `value` from a
    // script and fires only keydown, keypress, keyup. Catching keyup usually
    // gets it and catching keydown lets us fire an event for the first
    // keystroke if user does a key repeat (it'll be a little delayed: right
    // before the second keystroke). Other input methods (e.g., paste) seem to
    // fire selectionchange normally.
    if (activeElement && activeElement.value !== activeElementValue) {
      activeElementValue = activeElement.value;
      return activeElementInst;
    }
  }
}

/**
 * SECTION: handle `click` event
 */
function shouldUseClickEvent(elem) {
  // Use the `click` event to detect changes to checkbox and radio inputs.
  // This approach works across all browsers, whereas `change` does not fire
  // until `blur` in IE8.
  return elem.nodeName && elem.nodeName.toLowerCase() === 'input' && (elem.type === 'checkbox' || elem.type === 'radio');
}

function getTargetInstForClickEvent(topLevelType, targetInst) {
  if (topLevelType === 'topClick') {
    return targetInst;
  }
}

function handleControlledInputBlur(inst, node) {
  // TODO: In IE, inst is occasionally null. Why?
  if (inst == null) {
    return;
  }

  // Fiber and ReactDOM keep wrapper state in separate places
  var state = inst._wrapperState || node._wrapperState;

  if (!state || !state.controlled || node.type !== 'number') {
    return;
  }

  // If controlled, assign the value attribute to the current value on blur
  var value = '' + node.value;
  if (node.getAttribute('value') !== value) {
    node.setAttribute('value', value);
  }
}

/**
 * This plugin creates an `onChange` event that normalizes change events
 * across form elements. This event fires at a time when it's possible to
 * change the element's value without seeing a flicker.
 *
 * Supported elements are:
 * - input (see `isTextInputElement`)
 * - textarea
 * - select
 */
var ChangeEventPlugin = {

  eventTypes: eventTypes$1,

  extractEvents: function (topLevelType, targetInst, nativeEvent, nativeEventTarget) {
    var targetNode = targetInst ? ReactDOMComponentTree_1.getNodeFromInstance(targetInst) : window;

    var getTargetInstFunc, handleEventFunc;
    if (shouldUseChangeEvent(targetNode)) {
      if (doesChangeEventBubble) {
        getTargetInstFunc = getTargetInstForChangeEvent;
      } else {
        handleEventFunc = handleEventsForChangeEventIE8;
      }
    } else if (isTextInputElement_1(targetNode)) {
      if (isInputEventSupported) {
        getTargetInstFunc = getTargetInstForInputEvent;
      } else {
        getTargetInstFunc = getTargetInstForInputEventIE;
        handleEventFunc = handleEventsForInputEventIE;
      }
    } else if (shouldUseClickEvent(targetNode)) {
      getTargetInstFunc = getTargetInstForClickEvent;
    }

    if (getTargetInstFunc) {
      var inst = getTargetInstFunc(topLevelType, targetInst);
      if (inst) {
        var event = SyntheticEvent_1.getPooled(eventTypes$1.change, inst, nativeEvent, nativeEventTarget);
        event.type = 'change';
        EventPropagators_1.accumulateTwoPhaseDispatches(event);
        return event;
      }
    }

    if (handleEventFunc) {
      handleEventFunc(topLevelType, targetNode, targetInst);
    }

    // When blurring, set the value attribute for number inputs
    if (topLevelType === 'topBlur') {
      handleControlledInputBlur(targetInst, targetNode);
    }
  }

};

var ChangeEventPlugin_1 = ChangeEventPlugin;

/**
 * Copyright 2013-present, Facebook, Inc.
 * All rights reserved.
 *
 * This source code is licensed under the BSD-style license found in the
 * LICENSE file in the root directory of this source tree. An additional grant
 * of patent rights can be found in the PATENTS file in the same directory.
 *
 */

var DefaultEventPluginOrder = ['ResponderEventPlugin', 'SimpleEventPlugin', 'TapEventPlugin', 'EnterLeaveEventPlugin', 'ChangeEventPlugin', 'SelectEventPlugin', 'BeforeInputEventPlugin'];

var DefaultEventPluginOrder_1 = DefaultEventPluginOrder;

var UIEventInterface = {
  view: function (event) {
    if (event.view) {
      return event.view;
    }

    var target = getEventTarget_1(event);
    if (target.window === target) {
      // target is a window object
      return target;
    }

    var doc = target.ownerDocument;
    // TODO: Figure out why `ownerDocument` is sometimes undefined in IE8.
    if (doc) {
      return doc.defaultView || doc.parentWindow;
    } else {
      return window;
    }
  },
  detail: function (event) {
    return event.detail || 0;
  }
};

/**
 * @param {object} dispatchConfig Configuration used to dispatch this event.
 * @param {string} dispatchMarker Marker identifying the event target.
 * @param {object} nativeEvent Native browser event.
 * @extends {SyntheticEvent}
 */
function SyntheticUIEvent(dispatchConfig, dispatchMarker, nativeEvent, nativeEventTarget) {
  return SyntheticEvent_1.call(this, dispatchConfig, dispatchMarker, nativeEvent, nativeEventTarget);
}

SyntheticEvent_1.augmentClass(SyntheticUIEvent, UIEventInterface);

var SyntheticUIEvent_1 = SyntheticUIEvent;

/**
 * Copyright 2013-present, Facebook, Inc.
 * All rights reserved.
 *
 * This source code is licensed under the BSD-style license found in the
 * LICENSE file in the root directory of this source tree. An additional grant
 * of patent rights can be found in the PATENTS file in the same directory.
 *
 */

var ViewportMetrics = {

  currentScrollLeft: 0,

  currentScrollTop: 0,

  refreshScrollValues: function (scrollPosition) {
    ViewportMetrics.currentScrollLeft = scrollPosition.x;
    ViewportMetrics.currentScrollTop = scrollPosition.y;
  }

};

var ViewportMetrics_1 = ViewportMetrics;

/**
 * Copyright 2013-present, Facebook, Inc.
 * All rights reserved.
 *
 * This source code is licensed under the BSD-style license found in the
 * LICENSE file in the root directory of this source tree. An additional grant
 * of patent rights can be found in the PATENTS file in the same directory.
 *
 */

var modifierKeyToProp = {
  'Alt': 'altKey',
  'Control': 'ctrlKey',
  'Meta': 'metaKey',
  'Shift': 'shiftKey'
};

// IE8 does not implement getModifierState so we simply map it to the only
// modifier keys exposed by the event itself, does not support Lock-keys.
// Currently, all major browsers except Chrome seems to support Lock-keys.
function modifierStateGetter(keyArg) {
  var syntheticEvent = this;
  var nativeEvent = syntheticEvent.nativeEvent;
  if (nativeEvent.getModifierState) {
    return nativeEvent.getModifierState(keyArg);
  }
  var keyProp = modifierKeyToProp[keyArg];
  return keyProp ? !!nativeEvent[keyProp] : false;
}

function getEventModifierState(nativeEvent) {
  return modifierStateGetter;
}

var getEventModifierState_1 = getEventModifierState;

var MouseEventInterface = {
  screenX: null,
  screenY: null,
  clientX: null,
  clientY: null,
  ctrlKey: null,
  shiftKey: null,
  altKey: null,
  metaKey: null,
  getModifierState: getEventModifierState_1,
  button: function (event) {
    // Webkit, Firefox, IE9+
    // which:  1 2 3
    // button: 0 1 2 (standard)
    var button = event.button;
    if ('which' in event) {
      return button;
    }
    // IE<9
    // which:  undefined
    // button: 0 0 0
    // button: 1 4 2 (onmouseup)
    return button === 2 ? 2 : button === 4 ? 1 : 0;
  },
  buttons: null,
  relatedTarget: function (event) {
    return event.relatedTarget || (event.fromElement === event.srcElement ? event.toElement : event.fromElement);
  },
  // "Proprietary" Interface.
  pageX: function (event) {
    return 'pageX' in event ? event.pageX : event.clientX + ViewportMetrics_1.currentScrollLeft;
  },
  pageY: function (event) {
    return 'pageY' in event ? event.pageY : event.clientY + ViewportMetrics_1.currentScrollTop;
  }
};

/**
 * @param {object} dispatchConfig Configuration used to dispatch this event.
 * @param {string} dispatchMarker Marker identifying the event target.
 * @param {object} nativeEvent Native browser event.
 * @extends {SyntheticUIEvent}
 */
function SyntheticMouseEvent(dispatchConfig, dispatchMarker, nativeEvent, nativeEventTarget) {
  return SyntheticUIEvent_1.call(this, dispatchConfig, dispatchMarker, nativeEvent, nativeEventTarget);
}

SyntheticUIEvent_1.augmentClass(SyntheticMouseEvent, MouseEventInterface);

var SyntheticMouseEvent_1 = SyntheticMouseEvent;

var eventTypes$2 = {
  mouseEnter: {
    registrationName: 'onMouseEnter',
    dependencies: ['topMouseOut', 'topMouseOver']
  },
  mouseLeave: {
    registrationName: 'onMouseLeave',
    dependencies: ['topMouseOut', 'topMouseOver']
  }
};

var EnterLeaveEventPlugin = {

  eventTypes: eventTypes$2,

  /**
   * For almost every interaction we care about, there will be both a top-level
   * `mouseover` and `mouseout` event that occurs. Only use `mouseout` so that
   * we do not extract duplicate events. However, moving the mouse into the
   * browser from outside will not fire a `mouseout` event. In this case, we use
   * the `mouseover` top-level event.
   */
  extractEvents: function (topLevelType, targetInst, nativeEvent, nativeEventTarget) {
    if (topLevelType === 'topMouseOver' && (nativeEvent.relatedTarget || nativeEvent.fromElement)) {
      return null;
    }
    if (topLevelType !== 'topMouseOut' && topLevelType !== 'topMouseOver') {
      // Must not be a mouse in or mouse out - ignoring.
      return null;
    }

    var win;
    if (nativeEventTarget.window === nativeEventTarget) {
      // `nativeEventTarget` is probably a window object.
      win = nativeEventTarget;
    } else {
      // TODO: Figure out why `ownerDocument` is sometimes undefined in IE8.
      var doc = nativeEventTarget.ownerDocument;
      if (doc) {
        win = doc.defaultView || doc.parentWindow;
      } else {
        win = window;
      }
    }

    var from;
    var to;
    if (topLevelType === 'topMouseOut') {
      from = targetInst;
      var related = nativeEvent.relatedTarget || nativeEvent.toElement;
      to = related ? ReactDOMComponentTree_1.getClosestInstanceFromNode(related) : null;
    } else {
      // Moving to a node from outside the window.
      from = null;
      to = targetInst;
    }

    if (from === to) {
      // Nothing pertains to our managed components.
      return null;
    }

    var fromNode = from == null ? win : ReactDOMComponentTree_1.getNodeFromInstance(from);
    var toNode = to == null ? win : ReactDOMComponentTree_1.getNodeFromInstance(to);

    var leave = SyntheticMouseEvent_1.getPooled(eventTypes$2.mouseLeave, from, nativeEvent, nativeEventTarget);
    leave.type = 'mouseleave';
    leave.target = fromNode;
    leave.relatedTarget = toNode;

    var enter = SyntheticMouseEvent_1.getPooled(eventTypes$2.mouseEnter, to, nativeEvent, nativeEventTarget);
    enter.type = 'mouseenter';
    enter.target = toNode;
    enter.relatedTarget = fromNode;

    EventPropagators_1.accumulateEnterLeaveDispatches(leave, enter, from, to);

    return [leave, enter];
  }

};

var EnterLeaveEventPlugin_1 = EnterLeaveEventPlugin;

var MUST_USE_PROPERTY = DOMProperty_1.injection.MUST_USE_PROPERTY;
var HAS_BOOLEAN_VALUE = DOMProperty_1.injection.HAS_BOOLEAN_VALUE;
var HAS_NUMERIC_VALUE = DOMProperty_1.injection.HAS_NUMERIC_VALUE;
var HAS_POSITIVE_NUMERIC_VALUE = DOMProperty_1.injection.HAS_POSITIVE_NUMERIC_VALUE;
var HAS_OVERLOADED_BOOLEAN_VALUE = DOMProperty_1.injection.HAS_OVERLOADED_BOOLEAN_VALUE;

var HTMLDOMPropertyConfig = {
  isCustomAttribute: RegExp.prototype.test.bind(new RegExp('^(data|aria)-[' + DOMProperty_1.ATTRIBUTE_NAME_CHAR + ']*$')),
  Properties: {
    /**
     * Standard Properties
     */
    accept: 0,
    acceptCharset: 0,
    accessKey: 0,
    action: 0,
    allowFullScreen: HAS_BOOLEAN_VALUE,
    allowTransparency: 0,
    alt: 0,
    // specifies target context for links with `preload` type
    as: 0,
    async: HAS_BOOLEAN_VALUE,
    autoComplete: 0,
    // autoFocus is polyfilled/normalized by AutoFocusUtils
    // autoFocus: HAS_BOOLEAN_VALUE,
    autoPlay: HAS_BOOLEAN_VALUE,
    capture: HAS_BOOLEAN_VALUE,
    cellPadding: 0,
    cellSpacing: 0,
    charSet: 0,
    challenge: 0,
    checked: MUST_USE_PROPERTY | HAS_BOOLEAN_VALUE,
    cite: 0,
    classID: 0,
    className: 0,
    cols: HAS_POSITIVE_NUMERIC_VALUE,
    colSpan: 0,
    content: 0,
    contentEditable: 0,
    contextMenu: 0,
    controls: HAS_BOOLEAN_VALUE,
    coords: 0,
    crossOrigin: 0,
    data: 0, // For `<object />` acts as `src`.
    dateTime: 0,
    'default': HAS_BOOLEAN_VALUE,
    defer: HAS_BOOLEAN_VALUE,
    dir: 0,
    disabled: HAS_BOOLEAN_VALUE,
    download: HAS_OVERLOADED_BOOLEAN_VALUE,
    draggable: 0,
    encType: 0,
    form: 0,
    formAction: 0,
    formEncType: 0,
    formMethod: 0,
    formNoValidate: HAS_BOOLEAN_VALUE,
    formTarget: 0,
    frameBorder: 0,
    headers: 0,
    height: 0,
    hidden: HAS_BOOLEAN_VALUE,
    high: 0,
    href: 0,
    hrefLang: 0,
    htmlFor: 0,
    httpEquiv: 0,
    icon: 0,
    id: 0,
    inputMode: 0,
    integrity: 0,
    is: 0,
    keyParams: 0,
    keyType: 0,
    kind: 0,
    label: 0,
    lang: 0,
    list: 0,
    loop: HAS_BOOLEAN_VALUE,
    low: 0,
    manifest: 0,
    marginHeight: 0,
    marginWidth: 0,
    max: 0,
    maxLength: 0,
    media: 0,
    mediaGroup: 0,
    method: 0,
    min: 0,
    minLength: 0,
    // Caution; `option.selected` is not updated if `select.multiple` is
    // disabled with `removeAttribute`.
    multiple: MUST_USE_PROPERTY | HAS_BOOLEAN_VALUE,
    muted: MUST_USE_PROPERTY | HAS_BOOLEAN_VALUE,
    name: 0,
    nonce: 0,
    noValidate: HAS_BOOLEAN_VALUE,
    open: HAS_BOOLEAN_VALUE,
    optimum: 0,
    pattern: 0,
    placeholder: 0,
    playsInline: HAS_BOOLEAN_VALUE,
    poster: 0,
    preload: 0,
    profile: 0,
    radioGroup: 0,
    readOnly: HAS_BOOLEAN_VALUE,
    referrerPolicy: 0,
    rel: 0,
    required: HAS_BOOLEAN_VALUE,
    reversed: HAS_BOOLEAN_VALUE,
    role: 0,
    rows: HAS_POSITIVE_NUMERIC_VALUE,
    rowSpan: HAS_NUMERIC_VALUE,
    sandbox: 0,
    scope: 0,
    scoped: HAS_BOOLEAN_VALUE,
    scrolling: 0,
    seamless: HAS_BOOLEAN_VALUE,
    selected: MUST_USE_PROPERTY | HAS_BOOLEAN_VALUE,
    shape: 0,
    size: HAS_POSITIVE_NUMERIC_VALUE,
    sizes: 0,
    span: HAS_POSITIVE_NUMERIC_VALUE,
    spellCheck: 0,
    src: 0,
    srcDoc: 0,
    srcLang: 0,
    srcSet: 0,
    start: HAS_NUMERIC_VALUE,
    step: 0,
    style: 0,
    summary: 0,
    tabIndex: 0,
    target: 0,
    title: 0,
    // Setting .type throws on non-<input> tags
    type: 0,
    useMap: 0,
    value: 0,
    width: 0,
    wmode: 0,
    wrap: 0,

    /**
     * RDFa Properties
     */
    about: 0,
    datatype: 0,
    inlist: 0,
    prefix: 0,
    // property is also supported for OpenGraph in meta tags.
    property: 0,
    resource: 0,
    'typeof': 0,
    vocab: 0,

    /**
     * Non-standard Properties
     */
    // autoCapitalize and autoCorrect are supported in Mobile Safari for
    // keyboard hints.
    autoCapitalize: 0,
    autoCorrect: 0,
    // autoSave allows WebKit/Blink to persist values of input fields on page reloads
    autoSave: 0,
    // color is for Safari mask-icon link
    color: 0,
    // itemProp, itemScope, itemType are for
    // Microdata support. See http://schema.org/docs/gs.html
    itemProp: 0,
    itemScope: HAS_BOOLEAN_VALUE,
    itemType: 0,
    // itemID and itemRef are for Microdata support as well but
    // only specified in the WHATWG spec document. See
    // https://html.spec.whatwg.org/multipage/microdata.html#microdata-dom-api
    itemID: 0,
    itemRef: 0,
    // results show looking glass icon and recent searches on input
    // search fields in WebKit/Blink
    results: 0,
    // IE-only attribute that specifies security restrictions on an iframe
    // as an alternative to the sandbox attribute on IE<10
    security: 0,
    // IE-only attribute that controls focus behavior
    unselectable: 0
  },
  DOMAttributeNames: {
    acceptCharset: 'accept-charset',
    className: 'class',
    htmlFor: 'for',
    httpEquiv: 'http-equiv'
  },
  DOMPropertyNames: {},
  DOMMutationMethods: {
    value: function (node, value) {
      if (value == null) {
        return node.removeAttribute('value');
      }

      // Number inputs get special treatment due to some edge cases in
      // Chrome. Let everything else assign the value attribute as normal.
      // https://github.com/facebook/react/issues/7253#issuecomment-236074326
      if (node.type !== 'number' || node.hasAttribute('value') === false) {
        node.setAttribute('value', '' + value);
      } else if (node.validity && !node.validity.badInput && node.ownerDocument.activeElement !== node) {
        // Don't assign an attribute if validation reports bad
        // input. Chrome will clear the value. Additionally, don't
        // operate on inputs that have focus, otherwise Chrome might
        // strip off trailing decimal places and cause the user's
        // cursor position to jump to the beginning of the input.
        //
        // In ReactDOMInput, we have an onBlur event that will trigger
        // this function again when focus is lost.
        node.setAttribute('value', '' + value);
      }
    }
  }
};

var HTMLDOMPropertyConfig_1 = HTMLDOMPropertyConfig;

/**
 * Copyright 2013-present, Facebook, Inc.
 * All rights reserved.
 *
 * This source code is licensed under the BSD-style license found in the
 * LICENSE file in the root directory of this source tree. An additional grant
 * of patent rights can be found in the PATENTS file in the same directory.
 *
 */

var DOMNamespaces = {
  html: 'http://www.w3.org/1999/xhtml',
  mathml: 'http://www.w3.org/1998/Math/MathML',
  svg: 'http://www.w3.org/2000/svg'
};

var DOMNamespaces_1 = DOMNamespaces;

/**
 * Copyright 2013-present, Facebook, Inc.
 * All rights reserved.
 *
 * This source code is licensed under the BSD-style license found in the
 * LICENSE file in the root directory of this source tree. An additional grant
 * of patent rights can be found in the PATENTS file in the same directory.
 *
 */

/* globals MSApp */

var createMicrosoftUnsafeLocalFunction = function (func) {
  if (typeof MSApp !== 'undefined' && MSApp.execUnsafeLocalFunction) {
    return function (arg0, arg1, arg2, arg3) {
      MSApp.execUnsafeLocalFunction(function () {
        return func(arg0, arg1, arg2, arg3);
      });
    };
  } else {
    return func;
  }
};

var createMicrosoftUnsafeLocalFunction_1 = createMicrosoftUnsafeLocalFunction;

var WHITESPACE_TEST = /^[ \r\n\t\f]/;
var NONVISIBLE_TEST = /<(!--|link|noscript|meta|script|style)[ \r\n\t\f\/>]/;



// SVG temp container for IE lacking innerHTML
var reusableSVGContainer;

/**
 * Set the innerHTML property of a node, ensuring that whitespace is preserved
 * even in IE8.
 *
 * @param {DOMElement} node
 * @param {string} html
 * @internal
 */
var setInnerHTML = createMicrosoftUnsafeLocalFunction_1(function (node, html) {
  // IE does not have innerHTML for SVG nodes, so instead we inject the
  // new markup in a temp node and then move the child nodes across into
  // the target node
  if (node.namespaceURI === DOMNamespaces_1.svg && !('innerHTML' in node)) {
    reusableSVGContainer = reusableSVGContainer || document.createElement('div');
    reusableSVGContainer.innerHTML = '<svg>' + html + '</svg>';
    var svgNode = reusableSVGContainer.firstChild;
    while (svgNode.firstChild) {
      node.appendChild(svgNode.firstChild);
    }
  } else {
    node.innerHTML = html;
  }
});

if (ExecutionEnvironment_1.canUseDOM) {
  // IE8: When updating a just created node with innerHTML only leading
  // whitespace is removed. When updating an existing node with innerHTML
  // whitespace in root TextNodes is also collapsed.
  // @see quirksmode.org/bugreports/archives/2004/11/innerhtml_and_t.html

  // Feature detection; only IE8 is known to behave improperly like this.
  var testElement = document.createElement('div');
  testElement.innerHTML = ' ';
  if (testElement.innerHTML === '') {
    setInnerHTML = function (node, html) {
      // Magic theory: IE8 supposedly differentiates between added and updated
      // nodes when processing innerHTML, innerHTML on updated nodes suffers
      // from worse whitespace behavior. Re-adding a node like this triggers
      // the initial and more favorable whitespace behavior.
      // TODO: What to do on a detached node?
      if (node.parentNode) {
        node.parentNode.replaceChild(node, node);
      }

      // We also implement a workaround for non-visible tags disappearing into
      // thin air on IE8, this only happens if there is no visible text
      // in-front of the non-visible tags. Piggyback on the whitespace fix
      // and simply check if any non-visible tags appear in the source.
      if (WHITESPACE_TEST.test(html) || html[0] === '<' && NONVISIBLE_TEST.test(html)) {
        // Recover leading whitespace by temporarily prepending any character.
        // \uFEFF has the potential advantage of being zero-width/invisible.
        // UglifyJS drops U+FEFF chars when parsing, so use String.fromCharCode
        // in hopes that this is preserved even if "\uFEFF" is transformed to
        // the actual Unicode character (by Babel, for example).
        // https://github.com/mishoo/UglifyJS2/blob/v2.4.20/lib/parse.js#L216
        node.innerHTML = String.fromCharCode(0xFEFF) + html;

        // deleteData leaves an empty `TextNode` which offsets the index of all
        // children. Definitely want to avoid this.
        var textNode = node.firstChild;
        if (textNode.data.length === 1) {
          node.removeChild(textNode);
        } else {
          textNode.deleteData(0, 1);
        }
      } else {
        node.innerHTML = html;
      }
    };
  }
  testElement = null;
}

var setInnerHTML_1 = setInnerHTML;

/**
 * Copyright 2016-present, Facebook, Inc.
 * All rights reserved.
 *
 * This source code is licensed under the BSD-style license found in the
 * LICENSE file in the root directory of this source tree. An additional grant
 * of patent rights can be found in the PATENTS file in the same directory.
 *
 * Based on the escape-html library, which is used under the MIT License below:
 *
 * Copyright (c) 2012-2013 TJ Holowaychuk
 * Copyright (c) 2015 Andreas Lubbe
 * Copyright (c) 2015 Tiancheng "Timothy" Gu
 *
 * Permission is hereby granted, free of charge, to any person obtaining
 * a copy of this software and associated documentation files (the
 * 'Software'), to deal in the Software without restriction, including
 * without limitation the rights to use, copy, modify, merge, publish,
 * distribute, sublicense, and/or sell copies of the Software, and to
 * permit persons to whom the Software is furnished to do so, subject to
 * the following conditions:
 *
 * The above copyright notice and this permission notice shall be
 * included in all copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED 'AS IS', WITHOUT WARRANTY OF ANY KIND,
 * EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
 * MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
 * IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY
 * CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT,
 * TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE
 * SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
 *
 */

var matchHtmlRegExp = /["'&<>]/;

/**
 * Escape special characters in the given string of html.
 *
 * @param  {string} string The string to escape for inserting into HTML
 * @return {string}
 * @public
 */

function escapeHtml(string) {
  var str = '' + string;
  var match = matchHtmlRegExp.exec(str);

  if (!match) {
    return str;
  }

  var escape;
  var html = '';
  var index = 0;
  var lastIndex = 0;

  for (index = match.index; index < str.length; index++) {
    switch (str.charCodeAt(index)) {
      case 34:
        // "
        escape = '&quot;';
        break;
      case 38:
        // &
        escape = '&amp;';
        break;
      case 39:
        // '
        escape = '&#x27;'; // modified from escape-html; used to be '&#39'
        break;
      case 60:
        // <
        escape = '&lt;';
        break;
      case 62:
        // >
        escape = '&gt;';
        break;
      default:
        continue;
    }

    if (lastIndex !== index) {
      html += str.substring(lastIndex, index);
    }

    lastIndex = index + 1;
    html += escape;
  }

  return lastIndex !== index ? html + str.substring(lastIndex, index) : html;
}
// end code copied and modified from escape-html


/**
 * Escapes text to prevent scripting attacks.
 *
 * @param {*} text Text value to escape.
 * @return {string} An escaped string.
 */
function escapeTextContentForBrowser(text) {
  if (typeof text === 'boolean' || typeof text === 'number') {
    // this shortcircuit helps perf for types that we know will never have
    // special characters, especially given that this function is used often
    // for numeric dom ids.
    return '' + text;
  }
  return escapeHtml(text);
}

var escapeTextContentForBrowser_1 = escapeTextContentForBrowser;

var setTextContent = function (node, text) {
  if (text) {
    var firstChild = node.firstChild;

    if (firstChild && firstChild === node.lastChild && firstChild.nodeType === 3) {
      firstChild.nodeValue = text;
      return;
    }
  }
  node.textContent = text;
};

if (ExecutionEnvironment_1.canUseDOM) {
  if (!('textContent' in document.documentElement)) {
    setTextContent = function (node, text) {
      if (node.nodeType === 3) {
        node.nodeValue = text;
        return;
      }
      setInnerHTML_1(node, escapeTextContentForBrowser_1(text));
    };
  }
}

var setTextContent_1 = setTextContent;

var ELEMENT_NODE_TYPE = 1;
var DOCUMENT_FRAGMENT_NODE_TYPE = 11;

/**
 * In IE (8-11) and Edge, appending nodes with no children is dramatically
 * faster than appending a full subtree, so we essentially queue up the
 * .appendChild calls here and apply them so each node is added to its parent
 * before any children are added.
 *
 * In other browsers, doing so is slower or neutral compared to the other order
 * (in Firefox, twice as slow) so we only do this inversion in IE.
 *
 * See https://github.com/spicyj/innerhtml-vs-createelement-vs-clonenode.
 */
var enableLazy = typeof document !== 'undefined' && typeof document.documentMode === 'number' || typeof navigator !== 'undefined' && typeof navigator.userAgent === 'string' && /\bEdge\/\d/.test(navigator.userAgent);

function insertTreeChildren(tree) {
  if (!enableLazy) {
    return;
  }
  var node = tree.node;
  var children = tree.children;
  if (children.length) {
    for (var i = 0; i < children.length; i++) {
      insertTreeBefore(node, children[i], null);
    }
  } else if (tree.html != null) {
    setInnerHTML_1(node, tree.html);
  } else if (tree.text != null) {
    setTextContent_1(node, tree.text);
  }
}

var insertTreeBefore = createMicrosoftUnsafeLocalFunction_1(function (parentNode, tree, referenceNode) {
  // DocumentFragments aren't actually part of the DOM after insertion so
  // appending children won't update the DOM. We need to ensure the fragment
  // is properly populated first, breaking out of our lazy approach for just
  // this level. Also, some <object> plugins (like Flash Player) will read
  // <param> nodes immediately upon insertion into the DOM, so <object>
  // must also be populated prior to insertion into the DOM.
  if (tree.node.nodeType === DOCUMENT_FRAGMENT_NODE_TYPE || tree.node.nodeType === ELEMENT_NODE_TYPE && tree.node.nodeName.toLowerCase() === 'object' && (tree.node.namespaceURI == null || tree.node.namespaceURI === DOMNamespaces_1.html)) {
    insertTreeChildren(tree);
    parentNode.insertBefore(tree.node, referenceNode);
  } else {
    parentNode.insertBefore(tree.node, referenceNode);
    insertTreeChildren(tree);
  }
});

function replaceChildWithTree(oldNode, newTree) {
  oldNode.parentNode.replaceChild(newTree.node, oldNode);
  insertTreeChildren(newTree);
}

function queueChild(parentTree, childTree) {
  if (enableLazy) {
    parentTree.children.push(childTree);
  } else {
    parentTree.node.appendChild(childTree.node);
  }
}

function queueHTML(tree, html) {
  if (enableLazy) {
    tree.html = html;
  } else {
    setInnerHTML_1(tree.node, html);
  }
}

function queueText(tree, text) {
  if (enableLazy) {
    tree.text = text;
  } else {
    setTextContent_1(tree.node, text);
  }
}

function toString$1() {
  return this.node.nodeName;
}

function DOMLazyTree(node) {
  return {
    node: node,
    children: [],
    html: null,
    text: null,
    toString: toString$1
  };
}

DOMLazyTree.insertTreeBefore = insertTreeBefore;
DOMLazyTree.replaceChildWithTree = replaceChildWithTree;
DOMLazyTree.queueChild = queueChild;
DOMLazyTree.queueHTML = queueHTML;
DOMLazyTree.queueText = queueText;

var DOMLazyTree_1 = DOMLazyTree;

function toArray$1(obj) {
  var length = obj.length;

  // Some browsers builtin objects can report typeof 'function' (e.g. NodeList
  // in old versions of Safari).
  !(!Array.isArray(obj) && (typeof obj === 'object' || typeof obj === 'function')) ? invariant_1(false, 'toArray: Array-like object expected') : void 0;

  !(typeof length === 'number') ? invariant_1(false, 'toArray: Object needs a length property') : void 0;

  !(length === 0 || length - 1 in obj) ? invariant_1(false, 'toArray: Object should have keys for indices') : void 0;

  !(typeof obj.callee !== 'function') ? invariant_1(false, 'toArray: Object can\'t be `arguments`. Use rest params ' + '(function(...args) {}) or Array.from() instead.') : void 0;

  // Old IE doesn't give collections access to hasOwnProperty. Assume inputs
  // without method will throw during the slice call and skip straight to the
  // fallback.
  if (obj.hasOwnProperty) {
    try {
      return Array.prototype.slice.call(obj);
    } catch (e) {
      // IE < 9 does not support Array#slice on collections objects
    }
  }

  // Fall back to copying key by key. This assumes all keys have a value,
  // so will not preserve sparsely populated inputs.
  var ret = Array(length);
  for (var ii = 0; ii < length; ii++) {
    ret[ii] = obj[ii];
  }
  return ret;
}

/**
 * Perform a heuristic test to determine if an object is "array-like".
 *
 *   A monk asked Joshu, a Zen master, "Has a dog Buddha nature?"
 *   Joshu replied: "Mu."
 *
 * This function determines if its argument has "array nature": it returns
 * true if the argument is an actual array, an `arguments' object, or an
 * HTMLCollection (e.g. node.childNodes or node.getElementsByTagName()).
 *
 * It will return false for other array-like objects like Filelist.
 *
 * @param {*} obj
 * @return {boolean}
 */
function hasArrayNature(obj) {
  return (
    // not null/false
    !!obj && (
    // arrays are objects, NodeLists are functions in Safari
    typeof obj == 'object' || typeof obj == 'function') &&
    // quacks like an array
    'length' in obj &&
    // not window
    !('setInterval' in obj) &&
    // no DOM node should be considered an array-like
    // a 'select' element has 'length' and 'item' properties on IE8
    typeof obj.nodeType != 'number' && (
    // a real array
    Array.isArray(obj) ||
    // arguments
    'callee' in obj ||
    // HTMLCollection/NodeList
    'item' in obj)
  );
}

/**
 * Ensure that the argument is an array by wrapping it in an array if it is not.
 * Creates a copy of the argument if it is already an array.
 *
 * This is mostly useful idiomatically:
 *
 *   var createArrayFromMixed = require('createArrayFromMixed');
 *
 *   function takesOneOrMoreThings(things) {
 *     things = createArrayFromMixed(things);
 *     ...
 *   }
 *
 * This allows you to treat `things' as an array, but accept scalars in the API.
 *
 * If you need to convert an array-like object, like `arguments`, into an array
 * use toArray instead.
 *
 * @param {*} obj
 * @return {array}
 */
function createArrayFromMixed(obj) {
  if (!hasArrayNature(obj)) {
    return [obj];
  } else if (Array.isArray(obj)) {
    return obj.slice();
  } else {
    return toArray$1(obj);
  }
}

var createArrayFromMixed_1 = createArrayFromMixed;

var dummyNode$1 = ExecutionEnvironment_1.canUseDOM ? document.createElement('div') : null;

/**
 * Some browsers cannot use `innerHTML` to render certain elements standalone,
 * so we wrap them, render the wrapped nodes, then extract the desired node.
 *
 * In IE8, certain elements cannot render alone, so wrap all elements ('*').
 */

var shouldWrap = {};

var selectWrap = [1, '<select multiple="true">', '</select>'];
var tableWrap = [1, '<table>', '</table>'];
var trWrap = [3, '<table><tbody><tr>', '</tr></tbody></table>'];

var svgWrap = [1, '<svg xmlns="http://www.w3.org/2000/svg">', '</svg>'];

var markupWrap = {
  '*': [1, '?<div>', '</div>'],

  'area': [1, '<map>', '</map>'],
  'col': [2, '<table><tbody></tbody><colgroup>', '</colgroup></table>'],
  'legend': [1, '<fieldset>', '</fieldset>'],
  'param': [1, '<object>', '</object>'],
  'tr': [2, '<table><tbody>', '</tbody></table>'],

  'optgroup': selectWrap,
  'option': selectWrap,

  'caption': tableWrap,
  'colgroup': tableWrap,
  'tbody': tableWrap,
  'tfoot': tableWrap,
  'thead': tableWrap,

  'td': trWrap,
  'th': trWrap
};

// Initialize the SVG elements since we know they'll always need to be wrapped
// consistently. If they are created inside a <div> they will be initialized in
// the wrong namespace (and will not display).
var svgElements = ['circle', 'clipPath', 'defs', 'ellipse', 'g', 'image', 'line', 'linearGradient', 'mask', 'path', 'pattern', 'polygon', 'polyline', 'radialGradient', 'rect', 'stop', 'text', 'tspan'];
svgElements.forEach(function (nodeName) {
  markupWrap[nodeName] = svgWrap;
  shouldWrap[nodeName] = true;
});

/**
 * Gets the markup wrap configuration for the supplied `nodeName`.
 *
 * NOTE: This lazily detects which wraps are necessary for the current browser.
 *
 * @param {string} nodeName Lowercase `nodeName`.
 * @return {?array} Markup wrap configuration, if applicable.
 */
function getMarkupWrap(nodeName) {
  !!!dummyNode$1 ? invariant_1(false, 'Markup wrapping node not initialized') : void 0;
  if (!markupWrap.hasOwnProperty(nodeName)) {
    nodeName = '*';
  }
  if (!shouldWrap.hasOwnProperty(nodeName)) {
    if (nodeName === '*') {
      dummyNode$1.innerHTML = '<link />';
    } else {
      dummyNode$1.innerHTML = '<' + nodeName + '></' + nodeName + '>';
    }
    shouldWrap[nodeName] = !dummyNode$1.firstChild;
  }
  return shouldWrap[nodeName] ? markupWrap[nodeName] : null;
}

var getMarkupWrap_1 = getMarkupWrap;

var dummyNode = ExecutionEnvironment_1.canUseDOM ? document.createElement('div') : null;

/**
 * Pattern used by `getNodeName`.
 */
var nodeNamePattern = /^\s*<(\w+)/;

/**
 * Extracts the `nodeName` of the first element in a string of markup.
 *
 * @param {string} markup String of markup.
 * @return {?string} Node name of the supplied markup.
 */
function getNodeName(markup) {
  var nodeNameMatch = markup.match(nodeNamePattern);
  return nodeNameMatch && nodeNameMatch[1].toLowerCase();
}

/**
 * Creates an array containing the nodes rendered from the supplied markup. The
 * optionally supplied `handleScript` function will be invoked once for each
 * <script> element that is rendered. If no `handleScript` function is supplied,
 * an exception is thrown if any <script> elements are rendered.
 *
 * @param {string} markup A string of valid HTML markup.
 * @param {?function} handleScript Invoked once for each rendered <script>.
 * @return {array<DOMElement|DOMTextNode>} An array of rendered nodes.
 */
function createNodesFromMarkup(markup, handleScript) {
  var node = dummyNode;
  !!!dummyNode ? invariant_1(false, 'createNodesFromMarkup dummy not initialized') : void 0;
  var nodeName = getNodeName(markup);

  var wrap = nodeName && getMarkupWrap_1(nodeName);
  if (wrap) {
    node.innerHTML = wrap[1] + markup + wrap[2];

    var wrapDepth = wrap[0];
    while (wrapDepth--) {
      node = node.lastChild;
    }
  } else {
    node.innerHTML = markup;
  }

  var scripts = node.getElementsByTagName('script');
  if (scripts.length) {
    !handleScript ? invariant_1(false, 'createNodesFromMarkup(...): Unexpected <script> element rendered.') : void 0;
    createArrayFromMixed_1(scripts).forEach(handleScript);
  }

  var nodes = Array.from(node.childNodes);
  while (node.lastChild) {
    node.removeChild(node.lastChild);
  }
  return nodes;
}

var createNodesFromMarkup_1 = createNodesFromMarkup;

var Danger = {

  /**
   * Replaces a node with a string of markup at its current position within its
   * parent. The markup must render into a single root node.
   *
   * @param {DOMElement} oldChild Child node to replace.
   * @param {string} markup Markup to render in place of the child node.
   * @internal
   */
  dangerouslyReplaceNodeWithMarkup: function (oldChild, markup) {
    !ExecutionEnvironment_1.canUseDOM ? invariant_1(false, 'dangerouslyReplaceNodeWithMarkup(...): Cannot render markup in a worker thread. Make sure `window` and `document` are available globally before requiring React when unit testing or use ReactDOMServer.renderToString() for server rendering.') : void 0;
    !markup ? invariant_1(false, 'dangerouslyReplaceNodeWithMarkup(...): Missing markup.') : void 0;
    !(oldChild.nodeName !== 'HTML') ? invariant_1(false, 'dangerouslyReplaceNodeWithMarkup(...): Cannot replace markup of the <html> node. This is because browser quirks make this unreliable and/or slow. If you want to render to the root you must use server rendering. See ReactDOMServer.renderToString().') : void 0;

    if (typeof markup === 'string') {
      var newChild = createNodesFromMarkup_1(markup, emptyFunction_1)[0];
      oldChild.parentNode.replaceChild(newChild, oldChild);
    } else {
      DOMLazyTree_1.replaceChildWithTree(oldChild, markup);
    }
  }

};

var Danger_1 = Danger;

function getNodeAfter(parentNode, node) {
  // Special case for text components, which return [open, close] comments
  // from getHostNode.
  if (Array.isArray(node)) {
    node = node[1];
  }
  return node ? node.nextSibling : parentNode.firstChild;
}

/**
 * Inserts `childNode` as a child of `parentNode` at the `index`.
 *
 * @param {DOMElement} parentNode Parent node in which to insert.
 * @param {DOMElement} childNode Child node to insert.
 * @param {number} index Index at which to insert the child.
 * @internal
 */
var insertChildAt = createMicrosoftUnsafeLocalFunction_1(function (parentNode, childNode, referenceNode) {
  // We rely exclusively on `insertBefore(node, null)` instead of also using
  // `appendChild(node)`. (Using `undefined` is not allowed by all browsers so
  // we are careful to use `null`.)
  parentNode.insertBefore(childNode, referenceNode);
});

function insertLazyTreeChildAt(parentNode, childTree, referenceNode) {
  DOMLazyTree_1.insertTreeBefore(parentNode, childTree, referenceNode);
}

function moveChild(parentNode, childNode, referenceNode) {
  if (Array.isArray(childNode)) {
    moveDelimitedText(parentNode, childNode[0], childNode[1], referenceNode);
  } else {
    insertChildAt(parentNode, childNode, referenceNode);
  }
}

function removeChild(parentNode, childNode) {
  if (Array.isArray(childNode)) {
    var closingComment = childNode[1];
    childNode = childNode[0];
    removeDelimitedText(parentNode, childNode, closingComment);
    parentNode.removeChild(closingComment);
  }
  parentNode.removeChild(childNode);
}

function moveDelimitedText(parentNode, openingComment, closingComment, referenceNode) {
  var node = openingComment;
  while (true) {
    var nextNode = node.nextSibling;
    insertChildAt(parentNode, node, referenceNode);
    if (node === closingComment) {
      break;
    }
    node = nextNode;
  }
}

function removeDelimitedText(parentNode, startNode, closingComment) {
  while (true) {
    var node = startNode.nextSibling;
    if (node === closingComment) {
      // The closing comment is removed by ReactMultiChild.
      break;
    } else {
      parentNode.removeChild(node);
    }
  }
}

function replaceDelimitedText(openingComment, closingComment, stringText) {
  var parentNode = openingComment.parentNode;
  var nodeAfterComment = openingComment.nextSibling;
  if (nodeAfterComment === closingComment) {
    // There are no text nodes between the opening and closing comments; insert
    // a new one if stringText isn't empty.
    if (stringText) {
      insertChildAt(parentNode, document.createTextNode(stringText), nodeAfterComment);
    }
  } else {
    if (stringText) {
      // Set the text content of the first node after the opening comment, and
      // remove all following nodes up until the closing comment.
      setTextContent_1(nodeAfterComment, stringText);
      removeDelimitedText(parentNode, nodeAfterComment, closingComment);
    } else {
      removeDelimitedText(parentNode, openingComment, closingComment);
    }
  }

  {
    ReactInstrumentation$1.debugTool.onHostOperation({
      instanceID: ReactDOMComponentTree_1.getInstanceFromNode(openingComment)._debugID,
      type: 'replace text',
      payload: stringText
    });
  }
}

var dangerouslyReplaceNodeWithMarkup = Danger_1.dangerouslyReplaceNodeWithMarkup;
{
  dangerouslyReplaceNodeWithMarkup = function (oldChild, markup, prevInstance) {
    Danger_1.dangerouslyReplaceNodeWithMarkup(oldChild, markup);
    if (prevInstance._debugID !== 0) {
      ReactInstrumentation$1.debugTool.onHostOperation({
        instanceID: prevInstance._debugID,
        type: 'replace with',
        payload: markup.toString()
      });
    } else {
      var nextInstance = ReactDOMComponentTree_1.getInstanceFromNode(markup.node);
      if (nextInstance._debugID !== 0) {
        ReactInstrumentation$1.debugTool.onHostOperation({
          instanceID: nextInstance._debugID,
          type: 'mount',
          payload: markup.toString()
        });
      }
    }
  };
}

/**
 * Operations for updating with DOM children.
 */
var DOMChildrenOperations = {

  dangerouslyReplaceNodeWithMarkup: dangerouslyReplaceNodeWithMarkup,

  replaceDelimitedText: replaceDelimitedText,

  /**
   * Updates a component's children by processing a series of updates. The
   * update configurations are each expected to have a `parentNode` property.
   *
   * @param {array<object>} updates List of update configurations.
   * @internal
   */
  processUpdates: function (parentNode, updates) {
    {
      var parentNodeDebugID = ReactDOMComponentTree_1.getInstanceFromNode(parentNode)._debugID;
    }

    for (var k = 0; k < updates.length; k++) {
      var update = updates[k];
      switch (update.type) {
        case 'INSERT_MARKUP':
          insertLazyTreeChildAt(parentNode, update.content, getNodeAfter(parentNode, update.afterNode));
          {
            ReactInstrumentation$1.debugTool.onHostOperation({
              instanceID: parentNodeDebugID,
              type: 'insert child',
              payload: { toIndex: update.toIndex, content: update.content.toString() }
            });
          }
          break;
        case 'MOVE_EXISTING':
          moveChild(parentNode, update.fromNode, getNodeAfter(parentNode, update.afterNode));
          {
            ReactInstrumentation$1.debugTool.onHostOperation({
              instanceID: parentNodeDebugID,
              type: 'move child',
              payload: { fromIndex: update.fromIndex, toIndex: update.toIndex }
            });
          }
          break;
        case 'SET_MARKUP':
          setInnerHTML_1(parentNode, update.content);
          {
            ReactInstrumentation$1.debugTool.onHostOperation({
              instanceID: parentNodeDebugID,
              type: 'replace children',
              payload: update.content.toString()
            });
          }
          break;
        case 'TEXT_CONTENT':
          setTextContent_1(parentNode, update.content);
          {
            ReactInstrumentation$1.debugTool.onHostOperation({
              instanceID: parentNodeDebugID,
              type: 'replace text',
              payload: update.content.toString()
            });
          }
          break;
        case 'REMOVE_NODE':
          removeChild(parentNode, update.fromNode);
          {
            ReactInstrumentation$1.debugTool.onHostOperation({
              instanceID: parentNodeDebugID,
              type: 'remove child',
              payload: { fromIndex: update.fromIndex }
            });
          }
          break;
      }
    }
  }

};

var DOMChildrenOperations_1 = DOMChildrenOperations;

var ReactDOMIDOperations = {

  /**
   * Updates a component's children by processing a series of updates.
   *
   * @param {array<object>} updates List of update configurations.
   * @internal
   */
  dangerouslyProcessChildrenUpdates: function (parentInst, updates) {
    var node = ReactDOMComponentTree_1.getNodeFromInstance(parentInst);
    DOMChildrenOperations_1.processUpdates(node, updates);
  }
};

var ReactDOMIDOperations_1 = ReactDOMIDOperations;

var ReactComponentBrowserEnvironment = {

  processChildrenUpdates: ReactDOMIDOperations_1.dangerouslyProcessChildrenUpdates,

  replaceNodeWithMarkup: DOMChildrenOperations_1.dangerouslyReplaceNodeWithMarkup

};

var ReactComponentBrowserEnvironment_1 = ReactComponentBrowserEnvironment;

/**
 * Copyright (c) 2013-present, Facebook, Inc.
 * All rights reserved.
 *
 * This source code is licensed under the BSD-style license found in the
 * LICENSE file in the root directory of this source tree. An additional grant
 * of patent rights can be found in the PATENTS file in the same directory.
 *
 */

function focusNode(node) {
  // IE8 can throw "Can't move focus to the control because it is invisible,
  // not enabled, or of a type that does not accept the focus." for all kinds of
  // reasons that are too expensive and fragile to test.
  try {
    node.focus();
  } catch (e) {}
}

var focusNode_1 = focusNode;

var AutoFocusUtils = {
  focusDOMComponent: function () {
    focusNode_1(ReactDOMComponentTree_1.getNodeFromInstance(this));
  }
};

var AutoFocusUtils_1 = AutoFocusUtils;

/**
 * Copyright 2013-present, Facebook, Inc.
 * All rights reserved.
 *
 * This source code is licensed under the BSD-style license found in the
 * LICENSE file in the root directory of this source tree. An additional grant
 * of patent rights can be found in the PATENTS file in the same directory.
 *
 */

var isUnitlessNumber = {
  animationIterationCount: true,
  borderImageOutset: true,
  borderImageSlice: true,
  borderImageWidth: true,
  boxFlex: true,
  boxFlexGroup: true,
  boxOrdinalGroup: true,
  columnCount: true,
  flex: true,
  flexGrow: true,
  flexPositive: true,
  flexShrink: true,
  flexNegative: true,
  flexOrder: true,
  gridRow: true,
  gridColumn: true,
  fontWeight: true,
  lineClamp: true,
  lineHeight: true,
  opacity: true,
  order: true,
  orphans: true,
  tabSize: true,
  widows: true,
  zIndex: true,
  zoom: true,

  // SVG-related properties
  fillOpacity: true,
  floodOpacity: true,
  stopOpacity: true,
  strokeDasharray: true,
  strokeDashoffset: true,
  strokeMiterlimit: true,
  strokeOpacity: true,
  strokeWidth: true
};

/**
 * @param {string} prefix vendor-specific prefix, eg: Webkit
 * @param {string} key style name, eg: transitionDuration
 * @return {string} style name prefixed with `prefix`, properly camelCased, eg:
 * WebkitTransitionDuration
 */
function prefixKey(prefix, key) {
  return prefix + key.charAt(0).toUpperCase() + key.substring(1);
}

/**
 * Support style names that may come passed in prefixed by adding permutations
 * of vendor prefixes.
 */
var prefixes = ['Webkit', 'ms', 'Moz', 'O'];

// Using Object.keys here, or else the vanilla for-in loop makes IE8 go into an
// infinite loop, because it iterates over the newly added props too.
Object.keys(isUnitlessNumber).forEach(function (prop) {
  prefixes.forEach(function (prefix) {
    isUnitlessNumber[prefixKey(prefix, prop)] = isUnitlessNumber[prop];
  });
});

/**
 * Most style properties can be unset by doing .style[prop] = '' but IE8
 * doesn't like doing that with shorthand properties so for the properties that
 * IE8 breaks on, which are listed here, we instead unset each of the
 * individual properties. See http://bugs.jquery.com/ticket/12385.
 * The 4-value 'clock' properties like margin, padding, border-width seem to
 * behave without any problems. Curiously, list-style works too without any
 * special prodding.
 */
var shorthandPropertyExpansions = {
  background: {
    backgroundAttachment: true,
    backgroundColor: true,
    backgroundImage: true,
    backgroundPositionX: true,
    backgroundPositionY: true,
    backgroundRepeat: true
  },
  backgroundPosition: {
    backgroundPositionX: true,
    backgroundPositionY: true
  },
  border: {
    borderWidth: true,
    borderStyle: true,
    borderColor: true
  },
  borderBottom: {
    borderBottomWidth: true,
    borderBottomStyle: true,
    borderBottomColor: true
  },
  borderLeft: {
    borderLeftWidth: true,
    borderLeftStyle: true,
    borderLeftColor: true
  },
  borderRight: {
    borderRightWidth: true,
    borderRightStyle: true,
    borderRightColor: true
  },
  borderTop: {
    borderTopWidth: true,
    borderTopStyle: true,
    borderTopColor: true
  },
  font: {
    fontStyle: true,
    fontVariant: true,
    fontWeight: true,
    fontSize: true,
    lineHeight: true,
    fontFamily: true
  },
  outline: {
    outlineWidth: true,
    outlineStyle: true,
    outlineColor: true
  }
};

var CSSProperty = {
  isUnitlessNumber: isUnitlessNumber,
  shorthandPropertyExpansions: shorthandPropertyExpansions
};

var CSSProperty_1 = CSSProperty;

var _hyphenPattern = /-(.)/g;

/**
 * Camelcases a hyphenated string, for example:
 *
 *   > camelize('background-color')
 *   < "backgroundColor"
 *
 * @param {string} string
 * @return {string}
 */
function camelize(string) {
  return string.replace(_hyphenPattern, function (_, character) {
    return character.toUpperCase();
  });
}

var camelize_1 = camelize;

var msPattern = /^-ms-/;

/**
 * Camelcases a hyphenated CSS property name, for example:
 *
 *   > camelizeStyleName('background-color')
 *   < "backgroundColor"
 *   > camelizeStyleName('-moz-transition')
 *   < "MozTransition"
 *   > camelizeStyleName('-ms-transition')
 *   < "msTransition"
 *
 * As Andi Smith suggests
 * (http://www.andismith.com/blog/2012/02/modernizr-prefixed/), an `-ms` prefix
 * is converted to lowercase `ms`.
 *
 * @param {string} string
 * @return {string}
 */
function camelizeStyleName(string) {
  return camelize_1(string.replace(msPattern, 'ms-'));
}

var camelizeStyleName_1 = camelizeStyleName;

var isUnitlessNumber$1 = CSSProperty_1.isUnitlessNumber;
var styleWarnings = {};

/**
 * Convert a value into the proper css writable value. The style name `name`
 * should be logical (no hyphens), as specified
 * in `CSSProperty.isUnitlessNumber`.
 *
 * @param {string} name CSS property name such as `topMargin`.
 * @param {*} value CSS property value such as `10px`.
 * @param {ReactDOMComponent} component
 * @return {string} Normalized style value with dimensions applied.
 */
function dangerousStyleValue(name, value, component) {
  // Note that we've removed escapeTextForBrowser() calls here since the
  // whole string will be escaped when the attribute is injected into
  // the markup. If you provide unsafe user data here they can inject
  // arbitrary CSS which may be problematic (I couldn't repro this):
  // https://www.owasp.org/index.php/XSS_Filter_Evasion_Cheat_Sheet
  // http://www.thespanner.co.uk/2007/11/26/ultimate-xss-css-injection/
  // This is not an XSS hole but instead a potential CSS injection issue
  // which has lead to a greater discussion about how we're going to
  // trust URLs moving forward. See #2115901

  var isEmpty = value == null || typeof value === 'boolean' || value === '';
  if (isEmpty) {
    return '';
  }

  var isNonNumeric = isNaN(value);
  if (isNonNumeric || value === 0 || isUnitlessNumber$1.hasOwnProperty(name) && isUnitlessNumber$1[name]) {
    return '' + value; // cast to string
  }

  if (typeof value === 'string') {
    {
      // Allow '0' to pass through without warning. 0 is already special and
      // doesn't require units, so we don't need to warn about it.
      if (component && value !== '0') {
        var owner = component._currentElement._owner;
        var ownerName = owner ? owner.getName() : null;
        if (ownerName && !styleWarnings[ownerName]) {
          styleWarnings[ownerName] = {};
        }
        var warned = false;
        if (ownerName) {
          var warnings = styleWarnings[ownerName];
          warned = warnings[name];
          if (!warned) {
            warnings[name] = true;
          }
        }
        if (!warned) {
          warning_1(false, 'a `%s` tag (owner: `%s`) was passed a numeric string value ' + 'for CSS property `%s` (value: `%s`) which will be treated ' + 'as a unitless number in a future version of React.', component._currentElement.type, ownerName || 'unknown', name, value);
        }
      }
    }
    value = value.trim();
  }
  return value + 'px';
}

var dangerousStyleValue_1 = dangerousStyleValue;

var _uppercasePattern = /([A-Z])/g;

/**
 * Hyphenates a camelcased string, for example:
 *
 *   > hyphenate('backgroundColor')
 *   < "background-color"
 *
 * For CSS style names, use `hyphenateStyleName` instead which works properly
 * with all vendor prefixes, including `ms`.
 *
 * @param {string} string
 * @return {string}
 */
function hyphenate(string) {
  return string.replace(_uppercasePattern, '-$1').toLowerCase();
}

var hyphenate_1 = hyphenate;

var msPattern$1 = /^ms-/;

/**
 * Hyphenates a camelcased CSS property name, for example:
 *
 *   > hyphenateStyleName('backgroundColor')
 *   < "background-color"
 *   > hyphenateStyleName('MozTransition')
 *   < "-moz-transition"
 *   > hyphenateStyleName('msTransition')
 *   < "-ms-transition"
 *
 * As Modernizr suggests (http://modernizr.com/docs/#prefixed), an `ms` prefix
 * is converted to `-ms-`.
 *
 * @param {string} string
 * @return {string}
 */
function hyphenateStyleName(string) {
  return hyphenate_1(string).replace(msPattern$1, '-ms-');
}

var hyphenateStyleName_1 = hyphenateStyleName;

/**
 * Copyright (c) 2013-present, Facebook, Inc.
 * All rights reserved.
 *
 * This source code is licensed under the BSD-style license found in the
 * LICENSE file in the root directory of this source tree. An additional grant
 * of patent rights can be found in the PATENTS file in the same directory.
 *
 * 
 * @typechecks static-only
 */

function memoizeStringOnly(callback) {
  var cache = {};
  return function (string) {
    if (!cache.hasOwnProperty(string)) {
      cache[string] = callback.call(this, string);
    }
    return cache[string];
  };
}

var memoizeStringOnly_1 = memoizeStringOnly;

var processStyleName = memoizeStringOnly_1(function (styleName) {
  return hyphenateStyleName_1(styleName);
});

var hasShorthandPropertyBug = false;
var styleFloatAccessor = 'cssFloat';
if (ExecutionEnvironment_1.canUseDOM) {
  var tempStyle = document.createElement('div').style;
  try {
    // IE8 throws "Invalid argument." if resetting shorthand style properties.
    tempStyle.font = '';
  } catch (e) {
    hasShorthandPropertyBug = true;
  }
  // IE8 only supports accessing cssFloat (standard) as styleFloat
  if (document.documentElement.style.cssFloat === undefined) {
    styleFloatAccessor = 'styleFloat';
  }
}

{
  // 'msTransform' is correct, but the other prefixes should be capitalized
  var badVendoredStyleNamePattern = /^(?:webkit|moz|o)[A-Z]/;

  // style values shouldn't contain a semicolon
  var badStyleValueWithSemicolonPattern = /;\s*$/;

  var warnedStyleNames = {};
  var warnedStyleValues = {};
  var warnedForNaNValue = false;

  var warnHyphenatedStyleName = function (name, owner) {
    if (warnedStyleNames.hasOwnProperty(name) && warnedStyleNames[name]) {
      return;
    }

    warnedStyleNames[name] = true;
    warning_1(false, 'Unsupported style property %s. Did you mean %s?%s', name, camelizeStyleName_1(name), checkRenderMessage(owner));
  };

  var warnBadVendoredStyleName = function (name, owner) {
    if (warnedStyleNames.hasOwnProperty(name) && warnedStyleNames[name]) {
      return;
    }

    warnedStyleNames[name] = true;
    warning_1(false, 'Unsupported vendor-prefixed style property %s. Did you mean %s?%s', name, name.charAt(0).toUpperCase() + name.slice(1), checkRenderMessage(owner));
  };

  var warnStyleValueWithSemicolon = function (name, value, owner) {
    if (warnedStyleValues.hasOwnProperty(value) && warnedStyleValues[value]) {
      return;
    }

    warnedStyleValues[value] = true;
    warning_1(false, 'Style property values shouldn\'t contain a semicolon.%s ' + 'Try "%s: %s" instead.', checkRenderMessage(owner), name, value.replace(badStyleValueWithSemicolonPattern, ''));
  };

  var warnStyleValueIsNaN = function (name, value, owner) {
    if (warnedForNaNValue) {
      return;
    }

    warnedForNaNValue = true;
    warning_1(false, '`NaN` is an invalid value for the `%s` css style property.%s', name, checkRenderMessage(owner));
  };

  var checkRenderMessage = function (owner) {
    if (owner) {
      var name = owner.getName();
      if (name) {
        return ' Check the render method of `' + name + '`.';
      }
    }
    return '';
  };

  /**
   * @param {string} name
   * @param {*} value
   * @param {ReactDOMComponent} component
   */
  var warnValidStyle = function (name, value, component) {
    var owner;
    if (component) {
      owner = component._currentElement._owner;
    }
    if (name.indexOf('-') > -1) {
      warnHyphenatedStyleName(name, owner);
    } else if (badVendoredStyleNamePattern.test(name)) {
      warnBadVendoredStyleName(name, owner);
    } else if (badStyleValueWithSemicolonPattern.test(value)) {
      warnStyleValueWithSemicolon(name, value, owner);
    }

    if (typeof value === 'number' && isNaN(value)) {
      warnStyleValueIsNaN(name, value, owner);
    }
  };
}

/**
 * Operations for dealing with CSS properties.
 */
var CSSPropertyOperations = {

  /**
   * Serializes a mapping of style properties for use as inline styles:
   *
   *   > createMarkupForStyles({width: '200px', height: 0})
   *   "width:200px;height:0;"
   *
   * Undefined values are ignored so that declarative programming is easier.
   * The result should be HTML-escaped before insertion into the DOM.
   *
   * @param {object} styles
   * @param {ReactDOMComponent} component
   * @return {?string}
   */
  createMarkupForStyles: function (styles, component) {
    var serialized = '';
    for (var styleName in styles) {
      if (!styles.hasOwnProperty(styleName)) {
        continue;
      }
      var styleValue = styles[styleName];
      {
        warnValidStyle(styleName, styleValue, component);
      }
      if (styleValue != null) {
        serialized += processStyleName(styleName) + ':';
        serialized += dangerousStyleValue_1(styleName, styleValue, component) + ';';
      }
    }
    return serialized || null;
  },

  /**
   * Sets the value for multiple styles on a node.  If a value is specified as
   * '' (empty string), the corresponding style property will be unset.
   *
   * @param {DOMElement} node
   * @param {object} styles
   * @param {ReactDOMComponent} component
   */
  setValueForStyles: function (node, styles, component) {
    {
      ReactInstrumentation$1.debugTool.onHostOperation({
        instanceID: component._debugID,
        type: 'update styles',
        payload: styles
      });
    }

    var style = node.style;
    for (var styleName in styles) {
      if (!styles.hasOwnProperty(styleName)) {
        continue;
      }
      {
        warnValidStyle(styleName, styles[styleName], component);
      }
      var styleValue = dangerousStyleValue_1(styleName, styles[styleName], component);
      if (styleName === 'float' || styleName === 'cssFloat') {
        styleName = styleFloatAccessor;
      }
      if (styleValue) {
        style[styleName] = styleValue;
      } else {
        var expansion = hasShorthandPropertyBug && CSSProperty_1.shorthandPropertyExpansions[styleName];
        if (expansion) {
          // Shorthand property that IE8 won't like unsetting, so unset each
          // component to placate it
          for (var individualStyleName in expansion) {
            style[individualStyleName] = '';
          }
        } else {
          style[styleName] = '';
        }
      }
    }
  }

};

var CSSPropertyOperations_1 = CSSPropertyOperations;

function quoteAttributeValueForBrowser(value) {
  return '"' + escapeTextContentForBrowser_1(value) + '"';
}

var quoteAttributeValueForBrowser_1 = quoteAttributeValueForBrowser;

var VALID_ATTRIBUTE_NAME_REGEX = new RegExp('^[' + DOMProperty_1.ATTRIBUTE_NAME_START_CHAR + '][' + DOMProperty_1.ATTRIBUTE_NAME_CHAR + ']*$');
var illegalAttributeNameCache = {};
var validatedAttributeNameCache = {};

function isAttributeNameSafe(attributeName) {
  if (validatedAttributeNameCache.hasOwnProperty(attributeName)) {
    return true;
  }
  if (illegalAttributeNameCache.hasOwnProperty(attributeName)) {
    return false;
  }
  if (VALID_ATTRIBUTE_NAME_REGEX.test(attributeName)) {
    validatedAttributeNameCache[attributeName] = true;
    return true;
  }
  illegalAttributeNameCache[attributeName] = true;
  warning_1(false, 'Invalid attribute name: `%s`', attributeName);
  return false;
}

function shouldIgnoreValue(propertyInfo, value) {
  return value == null || propertyInfo.hasBooleanValue && !value || propertyInfo.hasNumericValue && isNaN(value) || propertyInfo.hasPositiveNumericValue && value < 1 || propertyInfo.hasOverloadedBooleanValue && value === false;
}

/**
 * Operations for dealing with DOM properties.
 */
var DOMPropertyOperations = {

  /**
   * Creates markup for the ID property.
   *
   * @param {string} id Unescaped ID.
   * @return {string} Markup string.
   */
  createMarkupForID: function (id) {
    return DOMProperty_1.ID_ATTRIBUTE_NAME + '=' + quoteAttributeValueForBrowser_1(id);
  },

  setAttributeForID: function (node, id) {
    node.setAttribute(DOMProperty_1.ID_ATTRIBUTE_NAME, id);
  },

  createMarkupForRoot: function () {
    return DOMProperty_1.ROOT_ATTRIBUTE_NAME + '=""';
  },

  setAttributeForRoot: function (node) {
    node.setAttribute(DOMProperty_1.ROOT_ATTRIBUTE_NAME, '');
  },

  /**
   * Creates markup for a property.
   *
   * @param {string} name
   * @param {*} value
   * @return {?string} Markup string, or null if the property was invalid.
   */
  createMarkupForProperty: function (name, value) {
    var propertyInfo = DOMProperty_1.properties.hasOwnProperty(name) ? DOMProperty_1.properties[name] : null;
    if (propertyInfo) {
      if (shouldIgnoreValue(propertyInfo, value)) {
        return '';
      }
      var attributeName = propertyInfo.attributeName;
      if (propertyInfo.hasBooleanValue || propertyInfo.hasOverloadedBooleanValue && value === true) {
        return attributeName + '=""';
      }
      return attributeName + '=' + quoteAttributeValueForBrowser_1(value);
    } else if (DOMProperty_1.isCustomAttribute(name)) {
      if (value == null) {
        return '';
      }
      return name + '=' + quoteAttributeValueForBrowser_1(value);
    }
    return null;
  },

  /**
   * Creates markup for a custom property.
   *
   * @param {string} name
   * @param {*} value
   * @return {string} Markup string, or empty string if the property was invalid.
   */
  createMarkupForCustomAttribute: function (name, value) {
    if (!isAttributeNameSafe(name) || value == null) {
      return '';
    }
    return name + '=' + quoteAttributeValueForBrowser_1(value);
  },

  /**
   * Sets the value for a property on a node.
   *
   * @param {DOMElement} node
   * @param {string} name
   * @param {*} value
   */
  setValueForProperty: function (node, name, value) {
    var propertyInfo = DOMProperty_1.properties.hasOwnProperty(name) ? DOMProperty_1.properties[name] : null;
    if (propertyInfo) {
      var mutationMethod = propertyInfo.mutationMethod;
      if (mutationMethod) {
        mutationMethod(node, value);
      } else if (shouldIgnoreValue(propertyInfo, value)) {
        this.deleteValueForProperty(node, name);
        return;
      } else if (propertyInfo.mustUseProperty) {
        // Contrary to `setAttribute`, object properties are properly
        // `toString`ed by IE8/9.
        node[propertyInfo.propertyName] = value;
      } else {
        var attributeName = propertyInfo.attributeName;
        var namespace = propertyInfo.attributeNamespace;
        // `setAttribute` with objects becomes only `[object]` in IE8/9,
        // ('' + value) makes it output the correct toString()-value.
        if (namespace) {
          node.setAttributeNS(namespace, attributeName, '' + value);
        } else if (propertyInfo.hasBooleanValue || propertyInfo.hasOverloadedBooleanValue && value === true) {
          node.setAttribute(attributeName, '');
        } else {
          node.setAttribute(attributeName, '' + value);
        }
      }
    } else if (DOMProperty_1.isCustomAttribute(name)) {
      DOMPropertyOperations.setValueForAttribute(node, name, value);
      return;
    }

    {
      var payload = {};
      payload[name] = value;
      ReactInstrumentation$1.debugTool.onHostOperation({
        instanceID: ReactDOMComponentTree_1.getInstanceFromNode(node)._debugID,
        type: 'update attribute',
        payload: payload
      });
    }
  },

  setValueForAttribute: function (node, name, value) {
    if (!isAttributeNameSafe(name)) {
      return;
    }
    if (value == null) {
      node.removeAttribute(name);
    } else {
      node.setAttribute(name, '' + value);
    }

    {
      var payload = {};
      payload[name] = value;
      ReactInstrumentation$1.debugTool.onHostOperation({
        instanceID: ReactDOMComponentTree_1.getInstanceFromNode(node)._debugID,
        type: 'update attribute',
        payload: payload
      });
    }
  },

  /**
   * Deletes an attributes from a node.
   *
   * @param {DOMElement} node
   * @param {string} name
   */
  deleteValueForAttribute: function (node, name) {
    node.removeAttribute(name);
    {
      ReactInstrumentation$1.debugTool.onHostOperation({
        instanceID: ReactDOMComponentTree_1.getInstanceFromNode(node)._debugID,
        type: 'remove attribute',
        payload: name
      });
    }
  },

  /**
   * Deletes the value for a property on a node.
   *
   * @param {DOMElement} node
   * @param {string} name
   */
  deleteValueForProperty: function (node, name) {
    var propertyInfo = DOMProperty_1.properties.hasOwnProperty(name) ? DOMProperty_1.properties[name] : null;
    if (propertyInfo) {
      var mutationMethod = propertyInfo.mutationMethod;
      if (mutationMethod) {
        mutationMethod(node, undefined);
      } else if (propertyInfo.mustUseProperty) {
        var propName = propertyInfo.propertyName;
        if (propertyInfo.hasBooleanValue) {
          node[propName] = false;
        } else {
          node[propName] = '';
        }
      } else {
        node.removeAttribute(propertyInfo.attributeName);
      }
    } else if (DOMProperty_1.isCustomAttribute(name)) {
      node.removeAttribute(name);
    }

    {
      ReactInstrumentation$1.debugTool.onHostOperation({
        instanceID: ReactDOMComponentTree_1.getInstanceFromNode(node)._debugID,
        type: 'remove attribute',
        payload: name
      });
    }
  }

};

var DOMPropertyOperations_1 = DOMPropertyOperations;

function runEventQueueInBatch(events) {
  EventPluginHub_1.enqueueEvents(events);
  EventPluginHub_1.processEventQueue(false);
}

var ReactEventEmitterMixin = {

  /**
   * Streams a fired top-level event to `EventPluginHub` where plugins have the
   * opportunity to create `ReactEvent`s to be dispatched.
   */
  handleTopLevel: function (topLevelType, targetInst, nativeEvent, nativeEventTarget) {
    var events = EventPluginHub_1.extractEvents(topLevelType, targetInst, nativeEvent, nativeEventTarget);
    runEventQueueInBatch(events);
  }
};

var ReactEventEmitterMixin_1 = ReactEventEmitterMixin;

function makePrefixMap(styleProp, eventName) {
  var prefixes = {};

  prefixes[styleProp.toLowerCase()] = eventName.toLowerCase();
  prefixes['Webkit' + styleProp] = 'webkit' + eventName;
  prefixes['Moz' + styleProp] = 'moz' + eventName;
  prefixes['ms' + styleProp] = 'MS' + eventName;
  prefixes['O' + styleProp] = 'o' + eventName.toLowerCase();

  return prefixes;
}

/**
 * A list of event names to a configurable list of vendor prefixes.
 */
var vendorPrefixes = {
  animationend: makePrefixMap('Animation', 'AnimationEnd'),
  animationiteration: makePrefixMap('Animation', 'AnimationIteration'),
  animationstart: makePrefixMap('Animation', 'AnimationStart'),
  transitionend: makePrefixMap('Transition', 'TransitionEnd')
};

/**
 * Event names that have already been detected and prefixed (if applicable).
 */
var prefixedEventNames = {};

/**
 * Element to check for prefixes on.
 */
var style = {};

/**
 * Bootstrap if a DOM exists.
 */
if (ExecutionEnvironment_1.canUseDOM) {
  style = document.createElement('div').style;

  // On some platforms, in particular some releases of Android 4.x,
  // the un-prefixed "animation" and "transition" properties are defined on the
  // style object but the events that fire will still be prefixed, so we need
  // to check if the un-prefixed events are usable, and if not remove them from the map.
  if (!('AnimationEvent' in window)) {
    delete vendorPrefixes.animationend.animation;
    delete vendorPrefixes.animationiteration.animation;
    delete vendorPrefixes.animationstart.animation;
  }

  // Same as above
  if (!('TransitionEvent' in window)) {
    delete vendorPrefixes.transitionend.transition;
  }
}

/**
 * Attempts to determine the correct vendor prefixed event name.
 *
 * @param {string} eventName
 * @returns {string}
 */
function getVendorPrefixedEventName(eventName) {
  if (prefixedEventNames[eventName]) {
    return prefixedEventNames[eventName];
  } else if (!vendorPrefixes[eventName]) {
    return eventName;
  }

  var prefixMap = vendorPrefixes[eventName];

  for (var styleProp in prefixMap) {
    if (prefixMap.hasOwnProperty(styleProp) && styleProp in style) {
      return prefixedEventNames[eventName] = prefixMap[styleProp];
    }
  }

  return '';
}

var getVendorPrefixedEventName_1 = getVendorPrefixedEventName;

var hasEventPageXY;
var alreadyListeningTo = {};
var isMonitoringScrollValue = false;
var reactTopListenersCounter = 0;

// For events like 'submit' which don't consistently bubble (which we trap at a
// lower node than `document`), binding at `document` would cause duplicate
// events so we don't include them here
var topEventMapping = {
  topAbort: 'abort',
  topAnimationEnd: getVendorPrefixedEventName_1('animationend') || 'animationend',
  topAnimationIteration: getVendorPrefixedEventName_1('animationiteration') || 'animationiteration',
  topAnimationStart: getVendorPrefixedEventName_1('animationstart') || 'animationstart',
  topBlur: 'blur',
  topCanPlay: 'canplay',
  topCanPlayThrough: 'canplaythrough',
  topChange: 'change',
  topClick: 'click',
  topCompositionEnd: 'compositionend',
  topCompositionStart: 'compositionstart',
  topCompositionUpdate: 'compositionupdate',
  topContextMenu: 'contextmenu',
  topCopy: 'copy',
  topCut: 'cut',
  topDoubleClick: 'dblclick',
  topDrag: 'drag',
  topDragEnd: 'dragend',
  topDragEnter: 'dragenter',
  topDragExit: 'dragexit',
  topDragLeave: 'dragleave',
  topDragOver: 'dragover',
  topDragStart: 'dragstart',
  topDrop: 'drop',
  topDurationChange: 'durationchange',
  topEmptied: 'emptied',
  topEncrypted: 'encrypted',
  topEnded: 'ended',
  topError: 'error',
  topFocus: 'focus',
  topInput: 'input',
  topKeyDown: 'keydown',
  topKeyPress: 'keypress',
  topKeyUp: 'keyup',
  topLoadedData: 'loadeddata',
  topLoadedMetadata: 'loadedmetadata',
  topLoadStart: 'loadstart',
  topMouseDown: 'mousedown',
  topMouseMove: 'mousemove',
  topMouseOut: 'mouseout',
  topMouseOver: 'mouseover',
  topMouseUp: 'mouseup',
  topPaste: 'paste',
  topPause: 'pause',
  topPlay: 'play',
  topPlaying: 'playing',
  topProgress: 'progress',
  topRateChange: 'ratechange',
  topScroll: 'scroll',
  topSeeked: 'seeked',
  topSeeking: 'seeking',
  topSelectionChange: 'selectionchange',
  topStalled: 'stalled',
  topSuspend: 'suspend',
  topTextInput: 'textInput',
  topTimeUpdate: 'timeupdate',
  topTouchCancel: 'touchcancel',
  topTouchEnd: 'touchend',
  topTouchMove: 'touchmove',
  topTouchStart: 'touchstart',
  topTransitionEnd: getVendorPrefixedEventName_1('transitionend') || 'transitionend',
  topVolumeChange: 'volumechange',
  topWaiting: 'waiting',
  topWheel: 'wheel'
};

/**
 * To ensure no conflicts with other potential React instances on the page
 */
var topListenersIDKey = '_reactListenersID' + String(Math.random()).slice(2);

function getListeningForDocument(mountAt) {
  // In IE8, `mountAt` is a host object and doesn't have `hasOwnProperty`
  // directly.
  if (!Object.prototype.hasOwnProperty.call(mountAt, topListenersIDKey)) {
    mountAt[topListenersIDKey] = reactTopListenersCounter++;
    alreadyListeningTo[mountAt[topListenersIDKey]] = {};
  }
  return alreadyListeningTo[mountAt[topListenersIDKey]];
}

/**
 * `ReactBrowserEventEmitter` is used to attach top-level event listeners. For
 * example:
 *
 *   EventPluginHub.putListener('myID', 'onClick', myFunction);
 *
 * This would allocate a "registration" of `('onClick', myFunction)` on 'myID'.
 *
 * @internal
 */
var ReactBrowserEventEmitter = index({}, ReactEventEmitterMixin_1, {

  /**
   * Injectable event backend
   */
  ReactEventListener: null,

  injection: {
    /**
     * @param {object} ReactEventListener
     */
    injectReactEventListener: function (ReactEventListener) {
      ReactEventListener.setHandleTopLevel(ReactBrowserEventEmitter.handleTopLevel);
      ReactBrowserEventEmitter.ReactEventListener = ReactEventListener;
    }
  },

  /**
   * Sets whether or not any created callbacks should be enabled.
   *
   * @param {boolean} enabled True if callbacks should be enabled.
   */
  setEnabled: function (enabled) {
    if (ReactBrowserEventEmitter.ReactEventListener) {
      ReactBrowserEventEmitter.ReactEventListener.setEnabled(enabled);
    }
  },

  /**
   * @return {boolean} True if callbacks are enabled.
   */
  isEnabled: function () {
    return !!(ReactBrowserEventEmitter.ReactEventListener && ReactBrowserEventEmitter.ReactEventListener.isEnabled());
  },

  /**
   * We listen for bubbled touch events on the document object.
   *
   * Firefox v8.01 (and possibly others) exhibited strange behavior when
   * mounting `onmousemove` events at some node that was not the document
   * element. The symptoms were that if your mouse is not moving over something
   * contained within that mount point (for example on the background) the
   * top-level listeners for `onmousemove` won't be called. However, if you
   * register the `mousemove` on the document object, then it will of course
   * catch all `mousemove`s. This along with iOS quirks, justifies restricting
   * top-level listeners to the document object only, at least for these
   * movement types of events and possibly all events.
   *
   * @see http://www.quirksmode.org/blog/archives/2010/09/click_event_del.html
   *
   * Also, `keyup`/`keypress`/`keydown` do not bubble to the window on IE, but
   * they bubble to document.
   *
   * @param {string} registrationName Name of listener (e.g. `onClick`).
   * @param {object} contentDocumentHandle Document which owns the container
   */
  listenTo: function (registrationName, contentDocumentHandle) {
    var mountAt = contentDocumentHandle;
    var isListening = getListeningForDocument(mountAt);
    var dependencies = EventPluginRegistry_1.registrationNameDependencies[registrationName];

    for (var i = 0; i < dependencies.length; i++) {
      var dependency = dependencies[i];
      if (!(isListening.hasOwnProperty(dependency) && isListening[dependency])) {
        if (dependency === 'topWheel') {
          if (isEventSupported_1('wheel')) {
            ReactBrowserEventEmitter.ReactEventListener.trapBubbledEvent('topWheel', 'wheel', mountAt);
          } else if (isEventSupported_1('mousewheel')) {
            ReactBrowserEventEmitter.ReactEventListener.trapBubbledEvent('topWheel', 'mousewheel', mountAt);
          } else {
            // Firefox needs to capture a different mouse scroll event.
            // @see http://www.quirksmode.org/dom/events/tests/scroll.html
            ReactBrowserEventEmitter.ReactEventListener.trapBubbledEvent('topWheel', 'DOMMouseScroll', mountAt);
          }
        } else if (dependency === 'topScroll') {

          if (isEventSupported_1('scroll', true)) {
            ReactBrowserEventEmitter.ReactEventListener.trapCapturedEvent('topScroll', 'scroll', mountAt);
          } else {
            ReactBrowserEventEmitter.ReactEventListener.trapBubbledEvent('topScroll', 'scroll', ReactBrowserEventEmitter.ReactEventListener.WINDOW_HANDLE);
          }
        } else if (dependency === 'topFocus' || dependency === 'topBlur') {

          if (isEventSupported_1('focus', true)) {
            ReactBrowserEventEmitter.ReactEventListener.trapCapturedEvent('topFocus', 'focus', mountAt);
            ReactBrowserEventEmitter.ReactEventListener.trapCapturedEvent('topBlur', 'blur', mountAt);
          } else if (isEventSupported_1('focusin')) {
            // IE has `focusin` and `focusout` events which bubble.
            // @see http://www.quirksmode.org/blog/archives/2008/04/delegating_the.html
            ReactBrowserEventEmitter.ReactEventListener.trapBubbledEvent('topFocus', 'focusin', mountAt);
            ReactBrowserEventEmitter.ReactEventListener.trapBubbledEvent('topBlur', 'focusout', mountAt);
          }

          // to make sure blur and focus event listeners are only attached once
          isListening.topBlur = true;
          isListening.topFocus = true;
        } else if (topEventMapping.hasOwnProperty(dependency)) {
          ReactBrowserEventEmitter.ReactEventListener.trapBubbledEvent(dependency, topEventMapping[dependency], mountAt);
        }

        isListening[dependency] = true;
      }
    }
  },

  trapBubbledEvent: function (topLevelType, handlerBaseName, handle) {
    return ReactBrowserEventEmitter.ReactEventListener.trapBubbledEvent(topLevelType, handlerBaseName, handle);
  },

  trapCapturedEvent: function (topLevelType, handlerBaseName, handle) {
    return ReactBrowserEventEmitter.ReactEventListener.trapCapturedEvent(topLevelType, handlerBaseName, handle);
  },

  /**
   * Protect against document.createEvent() returning null
   * Some popup blocker extensions appear to do this:
   * https://github.com/facebook/react/issues/6887
   */
  supportsEventPageXY: function () {
    if (!document.createEvent) {
      return false;
    }
    var ev = document.createEvent('MouseEvent');
    return ev != null && 'pageX' in ev;
  },

  /**
   * Listens to window scroll and resize events. We cache scroll values so that
   * application code can access them without triggering reflows.
   *
   * ViewportMetrics is only used by SyntheticMouse/TouchEvent and only when
   * pageX/pageY isn't supported (legacy browsers).
   *
   * NOTE: Scroll events do not bubble.
   *
   * @see http://www.quirksmode.org/dom/events/scroll.html
   */
  ensureScrollValueMonitoring: function () {
    if (hasEventPageXY === undefined) {
      hasEventPageXY = ReactBrowserEventEmitter.supportsEventPageXY();
    }
    if (!hasEventPageXY && !isMonitoringScrollValue) {
      var refresh = ViewportMetrics_1.refreshScrollValues;
      ReactBrowserEventEmitter.ReactEventListener.monitorScrollValue(refresh);
      isMonitoringScrollValue = true;
    }
  }

});

var ReactBrowserEventEmitter_1 = ReactBrowserEventEmitter;

/**
 * Copyright 2013-present, Facebook, Inc.
 * All rights reserved.
 *
 * This source code is licensed under the BSD-style license found in the
 * LICENSE file in the root directory of this source tree. An additional grant
 * of patent rights can be found in the PATENTS file in the same directory.
 *
 * 
 */

var ReactPropTypesSecret$4 = 'SECRET_DO_NOT_PASS_THIS_OR_YOU_WILL_BE_FIRED';

var ReactPropTypesSecret_1$4 = ReactPropTypesSecret$4;

var PropTypes = factory_1(React_1.isValidElement);




var hasReadOnlyValue = {
  'button': true,
  'checkbox': true,
  'image': true,
  'hidden': true,
  'radio': true,
  'reset': true,
  'submit': true
};

function _assertSingleLink(inputProps) {
  !(inputProps.checkedLink == null || inputProps.valueLink == null) ? invariant_1(false, 'Cannot provide a checkedLink and a valueLink. If you want to use checkedLink, you probably don\'t want to use valueLink and vice versa.') : void 0;
}
function _assertValueLink(inputProps) {
  _assertSingleLink(inputProps);
  !(inputProps.value == null && inputProps.onChange == null) ? invariant_1(false, 'Cannot provide a valueLink and a value or onChange event. If you want to use value or onChange, you probably don\'t want to use valueLink.') : void 0;
}

function _assertCheckedLink(inputProps) {
  _assertSingleLink(inputProps);
  !(inputProps.checked == null && inputProps.onChange == null) ? invariant_1(false, 'Cannot provide a checkedLink and a checked property or onChange event. If you want to use checked or onChange, you probably don\'t want to use checkedLink') : void 0;
}

var propTypes = {
  value: function (props, propName, componentName) {
    if (!props[propName] || hasReadOnlyValue[props.type] || props.onChange || props.readOnly || props.disabled) {
      return null;
    }
    return new Error('You provided a `value` prop to a form field without an ' + '`onChange` handler. This will render a read-only field. If ' + 'the field should be mutable use `defaultValue`. Otherwise, ' + 'set either `onChange` or `readOnly`.');
  },
  checked: function (props, propName, componentName) {
    if (!props[propName] || props.onChange || props.readOnly || props.disabled) {
      return null;
    }
    return new Error('You provided a `checked` prop to a form field without an ' + '`onChange` handler. This will render a read-only field. If ' + 'the field should be mutable use `defaultChecked`. Otherwise, ' + 'set either `onChange` or `readOnly`.');
  },
  onChange: PropTypes.func
};

var loggedTypeFailures$2 = {};
function getDeclarationErrorAddendum$2(owner) {
  if (owner) {
    var name = owner.getName();
    if (name) {
      return ' Check the render method of `' + name + '`.';
    }
  }
  return '';
}

/**
 * Provide a linked `value` attribute for controlled forms. You should not use
 * this outside of the ReactDOM controlled form components.
 */
var LinkedValueUtils = {
  checkPropTypes: function (tagName, props, owner) {
    for (var propName in propTypes) {
      if (propTypes.hasOwnProperty(propName)) {
        var error = propTypes[propName](props, propName, tagName, 'prop', null, ReactPropTypesSecret_1$4);
      }
      if (error instanceof Error && !(error.message in loggedTypeFailures$2)) {
        // Only monitor this failure once because there tends to be a lot of the
        // same error.
        loggedTypeFailures$2[error.message] = true;

        var addendum = getDeclarationErrorAddendum$2(owner);
        warning_1(false, 'Failed form propType: %s%s', error.message, addendum);
      }
    }
  },

  /**
   * @param {object} inputProps Props for form component
   * @return {*} current value of the input either from value prop or link.
   */
  getValue: function (inputProps) {
    if (inputProps.valueLink) {
      _assertValueLink(inputProps);
      return inputProps.valueLink.value;
    }
    return inputProps.value;
  },

  /**
   * @param {object} inputProps Props for form component
   * @return {*} current checked status of the input either from checked prop
   *             or link.
   */
  getChecked: function (inputProps) {
    if (inputProps.checkedLink) {
      _assertCheckedLink(inputProps);
      return inputProps.checkedLink.value;
    }
    return inputProps.checked;
  },

  /**
   * @param {object} inputProps Props for form component
   * @param {SyntheticEvent} event change event to handle
   */
  executeOnChange: function (inputProps, event) {
    if (inputProps.valueLink) {
      _assertValueLink(inputProps);
      return inputProps.valueLink.requestChange(event.target.value);
    } else if (inputProps.checkedLink) {
      _assertCheckedLink(inputProps);
      return inputProps.checkedLink.requestChange(event.target.checked);
    } else if (inputProps.onChange) {
      return inputProps.onChange.call(undefined, event);
    }
  }
};

var LinkedValueUtils_1 = LinkedValueUtils;

var didWarnValueLink = false;
var didWarnCheckedLink = false;
var didWarnValueDefaultValue = false;
var didWarnCheckedDefaultChecked = false;
var didWarnControlledToUncontrolled = false;
var didWarnUncontrolledToControlled = false;

function forceUpdateIfMounted() {
  if (this._rootNodeID) {
    // DOM component is still mounted; update
    ReactDOMInput.updateWrapper(this);
  }
}

function isControlled(props) {
  var usesChecked = props.type === 'checkbox' || props.type === 'radio';
  return usesChecked ? props.checked != null : props.value != null;
}

/**
 * Implements an <input> host component that allows setting these optional
 * props: `checked`, `value`, `defaultChecked`, and `defaultValue`.
 *
 * If `checked` or `value` are not supplied (or null/undefined), user actions
 * that affect the checked state or value will trigger updates to the element.
 *
 * If they are supplied (and not null/undefined), the rendered element will not
 * trigger updates to the element. Instead, the props must change in order for
 * the rendered element to be updated.
 *
 * The rendered element will be initialized as unchecked (or `defaultChecked`)
 * with an empty value (or `defaultValue`).
 *
 * @see http://www.w3.org/TR/2012/WD-html5-20121025/the-input-element.html
 */
var ReactDOMInput = {
  getHostProps: function (inst, props) {
    var value = LinkedValueUtils_1.getValue(props);
    var checked = LinkedValueUtils_1.getChecked(props);

    var hostProps = index({
      // Make sure we set .type before any other properties (setting .value
      // before .type means .value is lost in IE11 and below)
      type: undefined,
      // Make sure we set .step before .value (setting .value before .step
      // means .value is rounded on mount, based upon step precision)
      step: undefined,
      // Make sure we set .min & .max before .value (to ensure proper order
      // in corner cases such as min or max deriving from value, e.g. Issue #7170)
      min: undefined,
      max: undefined
    }, props, {
      defaultChecked: undefined,
      defaultValue: undefined,
      value: value != null ? value : inst._wrapperState.initialValue,
      checked: checked != null ? checked : inst._wrapperState.initialChecked,
      onChange: inst._wrapperState.onChange
    });

    return hostProps;
  },

  mountWrapper: function (inst, props) {
    {
      LinkedValueUtils_1.checkPropTypes('input', props, inst._currentElement._owner);

      var owner = inst._currentElement._owner;

      if (props.valueLink !== undefined && !didWarnValueLink) {
        warning_1(false, '`valueLink` prop on `input` is deprecated; set `value` and `onChange` instead.');
        didWarnValueLink = true;
      }
      if (props.checkedLink !== undefined && !didWarnCheckedLink) {
        warning_1(false, '`checkedLink` prop on `input` is deprecated; set `value` and `onChange` instead.');
        didWarnCheckedLink = true;
      }
      if (props.checked !== undefined && props.defaultChecked !== undefined && !didWarnCheckedDefaultChecked) {
        warning_1(false, '%s contains an input of type %s with both checked and defaultChecked props. ' + 'Input elements must be either controlled or uncontrolled ' + '(specify either the checked prop, or the defaultChecked prop, but not ' + 'both). Decide between using a controlled or uncontrolled input ' + 'element and remove one of these props. More info: ' + 'https://fb.me/react-controlled-components', owner && owner.getName() || 'A component', props.type);
        didWarnCheckedDefaultChecked = true;
      }
      if (props.value !== undefined && props.defaultValue !== undefined && !didWarnValueDefaultValue) {
        warning_1(false, '%s contains an input of type %s with both value and defaultValue props. ' + 'Input elements must be either controlled or uncontrolled ' + '(specify either the value prop, or the defaultValue prop, but not ' + 'both). Decide between using a controlled or uncontrolled input ' + 'element and remove one of these props. More info: ' + 'https://fb.me/react-controlled-components', owner && owner.getName() || 'A component', props.type);
        didWarnValueDefaultValue = true;
      }
    }

    var defaultValue = props.defaultValue;
    inst._wrapperState = {
      initialChecked: props.checked != null ? props.checked : props.defaultChecked,
      initialValue: props.value != null ? props.value : defaultValue,
      listeners: null,
      onChange: _handleChange.bind(inst),
      controlled: isControlled(props)
    };
  },

  updateWrapper: function (inst) {
    var props = inst._currentElement.props;

    {
      var controlled = isControlled(props);
      var owner = inst._currentElement._owner;

      if (!inst._wrapperState.controlled && controlled && !didWarnUncontrolledToControlled) {
        warning_1(false, '%s is changing an uncontrolled input of type %s to be controlled. ' + 'Input elements should not switch from uncontrolled to controlled (or vice versa). ' + 'Decide between using a controlled or uncontrolled input ' + 'element for the lifetime of the component. More info: https://fb.me/react-controlled-components', owner && owner.getName() || 'A component', props.type);
        didWarnUncontrolledToControlled = true;
      }
      if (inst._wrapperState.controlled && !controlled && !didWarnControlledToUncontrolled) {
        warning_1(false, '%s is changing a controlled input of type %s to be uncontrolled. ' + 'Input elements should not switch from controlled to uncontrolled (or vice versa). ' + 'Decide between using a controlled or uncontrolled input ' + 'element for the lifetime of the component. More info: https://fb.me/react-controlled-components', owner && owner.getName() || 'A component', props.type);
        didWarnControlledToUncontrolled = true;
      }
    }

    // TODO: Shouldn't this be getChecked(props)?
    var checked = props.checked;
    if (checked != null) {
      DOMPropertyOperations_1.setValueForProperty(ReactDOMComponentTree_1.getNodeFromInstance(inst), 'checked', checked || false);
    }

    var node = ReactDOMComponentTree_1.getNodeFromInstance(inst);
    var value = LinkedValueUtils_1.getValue(props);
    if (value != null) {
      if (value === 0 && node.value === '') {
        node.value = '0';
        // Note: IE9 reports a number inputs as 'text', so check props instead.
      } else if (props.type === 'number') {
        // Simulate `input.valueAsNumber`. IE9 does not support it
        var valueAsNumber = parseFloat(node.value, 10) || 0;

        // eslint-disable-next-line
        if (value != valueAsNumber) {
          // Cast `value` to a string to ensure the value is set correctly. While
          // browsers typically do this as necessary, jsdom doesn't.
          node.value = '' + value;
        }
        // eslint-disable-next-line
      } else if (value != node.value) {
        // Cast `value` to a string to ensure the value is set correctly. While
        // browsers typically do this as necessary, jsdom doesn't.
        node.value = '' + value;
      }
    } else {
      if (props.value == null && props.defaultValue != null) {
        // In Chrome, assigning defaultValue to certain input types triggers input validation.
        // For number inputs, the display value loses trailing decimal points. For email inputs,
        // Chrome raises "The specified value <x> is not a valid email address".
        //
        // Here we check to see if the defaultValue has actually changed, avoiding these problems
        // when the user is inputting text
        //
        // https://github.com/facebook/react/issues/7253
        if (node.defaultValue !== '' + props.defaultValue) {
          node.defaultValue = '' + props.defaultValue;
        }
      }
      if (props.checked == null && props.defaultChecked != null) {
        node.defaultChecked = !!props.defaultChecked;
      }
    }
  },

  postMountWrapper: function (inst) {
    var props = inst._currentElement.props;

    // This is in postMount because we need access to the DOM node, which is not
    // available until after the component has mounted.
    var node = ReactDOMComponentTree_1.getNodeFromInstance(inst);

    // Detach value from defaultValue. We won't do anything if we're working on
    // submit or reset inputs as those values & defaultValues are linked. They
    // are not resetable nodes so this operation doesn't matter and actually
    // removes browser-default values (eg "Submit Query") when no value is
    // provided.

    switch (props.type) {
      case 'submit':
      case 'reset':
        break;
      case 'color':
      case 'date':
      case 'datetime':
      case 'datetime-local':
      case 'month':
      case 'time':
      case 'week':
        // This fixes the no-show issue on iOS Safari and Android Chrome:
        // https://github.com/facebook/react/issues/7233
        node.value = '';
        node.value = node.defaultValue;
        break;
      default:
        node.value = node.value;
        break;
    }

    // Normally, we'd just do `node.checked = node.checked` upon initial mount, less this bug
    // this is needed to work around a chrome bug where setting defaultChecked
    // will sometimes influence the value of checked (even after detachment).
    // Reference: https://bugs.chromium.org/p/chromium/issues/detail?id=608416
    // We need to temporarily unset name to avoid disrupting radio button groups.
    var name = node.name;
    if (name !== '') {
      node.name = '';
    }
    node.defaultChecked = !node.defaultChecked;
    node.defaultChecked = !node.defaultChecked;
    if (name !== '') {
      node.name = name;
    }
  }
};

function _handleChange(event) {
  var props = this._currentElement.props;

  var returnValue = LinkedValueUtils_1.executeOnChange(props, event);

  // Here we use asap to wait until all updates have propagated, which
  // is important when using controlled components within layers:
  // https://github.com/facebook/react/issues/1698
  ReactUpdates_1.asap(forceUpdateIfMounted, this);

  var name = props.name;
  if (props.type === 'radio' && name != null) {
    var rootNode = ReactDOMComponentTree_1.getNodeFromInstance(this);
    var queryRoot = rootNode;

    while (queryRoot.parentNode) {
      queryRoot = queryRoot.parentNode;
    }

    // If `rootNode.form` was non-null, then we could try `form.elements`,
    // but that sometimes behaves strangely in IE8. We could also try using
    // `form.getElementsByName`, but that will only return direct children
    // and won't include inputs that use the HTML5 `form=` attribute. Since
    // the input might not even be in a form, let's just use the global
    // `querySelectorAll` to ensure we don't miss anything.
    var group = queryRoot.querySelectorAll('input[name=' + JSON.stringify('' + name) + '][type="radio"]');

    for (var i = 0; i < group.length; i++) {
      var otherNode = group[i];
      if (otherNode === rootNode || otherNode.form !== rootNode.form) {
        continue;
      }
      // This will throw if radio buttons rendered by different copies of React
      // and the same name are rendered into the same form (same as #1939).
      // That's probably okay; we don't support it just as we don't support
      // mixing React radio buttons with non-React ones.
      var otherInstance = ReactDOMComponentTree_1.getInstanceFromNode(otherNode);
      !otherInstance ? invariant_1(false, 'ReactDOMInput: Mixing React and non-React radio inputs with the same `name` is not supported.') : void 0;
      // If this is a controlled radio button group, forcing the input that
      // was previously checked to update will cause it to be come re-checked
      // as appropriate.
      ReactUpdates_1.asap(forceUpdateIfMounted, otherInstance);
    }
  }

  return returnValue;
}

var ReactDOMInput_1 = ReactDOMInput;

var didWarnValueLink$1 = false;
var didWarnValueDefaultValue$1 = false;

function updateOptionsIfPendingUpdateAndMounted() {
  if (this._rootNodeID && this._wrapperState.pendingUpdate) {
    this._wrapperState.pendingUpdate = false;

    var props = this._currentElement.props;
    var value = LinkedValueUtils_1.getValue(props);

    if (value != null) {
      updateOptions(this, Boolean(props.multiple), value);
    }
  }
}

function getDeclarationErrorAddendum$3(owner) {
  if (owner) {
    var name = owner.getName();
    if (name) {
      return ' Check the render method of `' + name + '`.';
    }
  }
  return '';
}

var valuePropNames = ['value', 'defaultValue'];

/**
 * Validation function for `value` and `defaultValue`.
 * @private
 */
function checkSelectPropTypes(inst, props) {
  var owner = inst._currentElement._owner;
  LinkedValueUtils_1.checkPropTypes('select', props, owner);

  if (props.valueLink !== undefined && !didWarnValueLink$1) {
    warning_1(false, '`valueLink` prop on `select` is deprecated; set `value` and `onChange` instead.');
    didWarnValueLink$1 = true;
  }

  for (var i = 0; i < valuePropNames.length; i++) {
    var propName = valuePropNames[i];
    if (props[propName] == null) {
      continue;
    }
    var isArray = Array.isArray(props[propName]);
    if (props.multiple && !isArray) {
      warning_1(false, 'The `%s` prop supplied to <select> must be an array if ' + '`multiple` is true.%s', propName, getDeclarationErrorAddendum$3(owner));
    } else if (!props.multiple && isArray) {
      warning_1(false, 'The `%s` prop supplied to <select> must be a scalar ' + 'value if `multiple` is false.%s', propName, getDeclarationErrorAddendum$3(owner));
    }
  }
}

/**
 * @param {ReactDOMComponent} inst
 * @param {boolean} multiple
 * @param {*} propValue A stringable (with `multiple`, a list of stringables).
 * @private
 */
function updateOptions(inst, multiple, propValue) {
  var selectedValue, i;
  var options = ReactDOMComponentTree_1.getNodeFromInstance(inst).options;

  if (multiple) {
    selectedValue = {};
    for (i = 0; i < propValue.length; i++) {
      selectedValue['' + propValue[i]] = true;
    }
    for (i = 0; i < options.length; i++) {
      var selected = selectedValue.hasOwnProperty(options[i].value);
      if (options[i].selected !== selected) {
        options[i].selected = selected;
      }
    }
  } else {
    // Do not set `select.value` as exact behavior isn't consistent across all
    // browsers for all cases.
    selectedValue = '' + propValue;
    for (i = 0; i < options.length; i++) {
      if (options[i].value === selectedValue) {
        options[i].selected = true;
        return;
      }
    }
    if (options.length) {
      options[0].selected = true;
    }
  }
}

/**
 * Implements a <select> host component that allows optionally setting the
 * props `value` and `defaultValue`. If `multiple` is false, the prop must be a
 * stringable. If `multiple` is true, the prop must be an array of stringables.
 *
 * If `value` is not supplied (or null/undefined), user actions that change the
 * selected option will trigger updates to the rendered options.
 *
 * If it is supplied (and not null/undefined), the rendered options will not
 * update in response to user actions. Instead, the `value` prop must change in
 * order for the rendered options to update.
 *
 * If `defaultValue` is provided, any options with the supplied values will be
 * selected.
 */
var ReactDOMSelect = {
  getHostProps: function (inst, props) {
    return index({}, props, {
      onChange: inst._wrapperState.onChange,
      value: undefined
    });
  },

  mountWrapper: function (inst, props) {
    {
      checkSelectPropTypes(inst, props);
    }

    var value = LinkedValueUtils_1.getValue(props);
    inst._wrapperState = {
      pendingUpdate: false,
      initialValue: value != null ? value : props.defaultValue,
      listeners: null,
      onChange: _handleChange$1.bind(inst),
      wasMultiple: Boolean(props.multiple)
    };

    if (props.value !== undefined && props.defaultValue !== undefined && !didWarnValueDefaultValue$1) {
      warning_1(false, 'Select elements must be either controlled or uncontrolled ' + '(specify either the value prop, or the defaultValue prop, but not ' + 'both). Decide between using a controlled or uncontrolled select ' + 'element and remove one of these props. More info: ' + 'https://fb.me/react-controlled-components');
      didWarnValueDefaultValue$1 = true;
    }
  },

  getSelectValueContext: function (inst) {
    // ReactDOMOption looks at this initial value so the initial generated
    // markup has correct `selected` attributes
    return inst._wrapperState.initialValue;
  },

  postUpdateWrapper: function (inst) {
    var props = inst._currentElement.props;

    // After the initial mount, we control selected-ness manually so don't pass
    // this value down
    inst._wrapperState.initialValue = undefined;

    var wasMultiple = inst._wrapperState.wasMultiple;
    inst._wrapperState.wasMultiple = Boolean(props.multiple);

    var value = LinkedValueUtils_1.getValue(props);
    if (value != null) {
      inst._wrapperState.pendingUpdate = false;
      updateOptions(inst, Boolean(props.multiple), value);
    } else if (wasMultiple !== Boolean(props.multiple)) {
      // For simplicity, reapply `defaultValue` if `multiple` is toggled.
      if (props.defaultValue != null) {
        updateOptions(inst, Boolean(props.multiple), props.defaultValue);
      } else {
        // Revert the select back to its default unselected state.
        updateOptions(inst, Boolean(props.multiple), props.multiple ? [] : '');
      }
    }
  }
};

function _handleChange$1(event) {
  var props = this._currentElement.props;
  var returnValue = LinkedValueUtils_1.executeOnChange(props, event);

  if (this._rootNodeID) {
    this._wrapperState.pendingUpdate = true;
  }
  ReactUpdates_1.asap(updateOptionsIfPendingUpdateAndMounted, this);
  return returnValue;
}

var ReactDOMSelect_1 = ReactDOMSelect;

var didWarnInvalidOptionChildren = false;

function flattenChildren(children) {
  var content = '';

  // Flatten children and warn if they aren't strings or numbers;
  // invalid types are ignored.
  React_1.Children.forEach(children, function (child) {
    if (child == null) {
      return;
    }
    if (typeof child === 'string' || typeof child === 'number') {
      content += child;
    } else if (!didWarnInvalidOptionChildren) {
      didWarnInvalidOptionChildren = true;
      warning_1(false, 'Only strings and numbers are supported as <option> children.');
    }
  });

  return content;
}

/**
 * Implements an <option> host component that warns when `selected` is set.
 */
var ReactDOMOption = {
  mountWrapper: function (inst, props, hostParent) {
    // TODO (yungsters): Remove support for `selected` in <option>.
    {
      warning_1(props.selected == null, 'Use the `defaultValue` or `value` props on <select> instead of ' + 'setting `selected` on <option>.');
    }

    // Look up whether this option is 'selected'
    var selectValue = null;
    if (hostParent != null) {
      var selectParent = hostParent;

      if (selectParent._tag === 'optgroup') {
        selectParent = selectParent._hostParent;
      }

      if (selectParent != null && selectParent._tag === 'select') {
        selectValue = ReactDOMSelect_1.getSelectValueContext(selectParent);
      }
    }

    // If the value is null (e.g., no specified value or after initial mount)
    // or missing (e.g., for <datalist>), we don't change props.selected
    var selected = null;
    if (selectValue != null) {
      var value;
      if (props.value != null) {
        value = props.value + '';
      } else {
        value = flattenChildren(props.children);
      }
      selected = false;
      if (Array.isArray(selectValue)) {
        // multiple
        for (var i = 0; i < selectValue.length; i++) {
          if ('' + selectValue[i] === value) {
            selected = true;
            break;
          }
        }
      } else {
        selected = '' + selectValue === value;
      }
    }

    inst._wrapperState = { selected: selected };
  },

  postMountWrapper: function (inst) {
    // value="" should make a value attribute (#6219)
    var props = inst._currentElement.props;
    if (props.value != null) {
      var node = ReactDOMComponentTree_1.getNodeFromInstance(inst);
      node.setAttribute('value', props.value);
    }
  },

  getHostProps: function (inst, props) {
    var hostProps = index({ selected: undefined, children: undefined }, props);

    // Read state only from initial mount because <select> updates value
    // manually; we need the initial state only for server rendering
    if (inst._wrapperState.selected != null) {
      hostProps.selected = inst._wrapperState.selected;
    }

    var content = flattenChildren(props.children);

    if (content) {
      hostProps.children = content;
    }

    return hostProps;
  }

};

var ReactDOMOption_1 = ReactDOMOption;

var didWarnValueLink$2 = false;
var didWarnValDefaultVal = false;

function forceUpdateIfMounted$1() {
  if (this._rootNodeID) {
    // DOM component is still mounted; update
    ReactDOMTextarea.updateWrapper(this);
  }
}

/**
 * Implements a <textarea> host component that allows setting `value`, and
 * `defaultValue`. This differs from the traditional DOM API because value is
 * usually set as PCDATA children.
 *
 * If `value` is not supplied (or null/undefined), user actions that affect the
 * value will trigger updates to the element.
 *
 * If `value` is supplied (and not null/undefined), the rendered element will
 * not trigger updates to the element. Instead, the `value` prop must change in
 * order for the rendered element to be updated.
 *
 * The rendered element will be initialized with an empty value, the prop
 * `defaultValue` if specified, or the children content (deprecated).
 */
var ReactDOMTextarea = {
  getHostProps: function (inst, props) {
    !(props.dangerouslySetInnerHTML == null) ? invariant_1(false, '`dangerouslySetInnerHTML` does not make sense on <textarea>.') : void 0;

    // Always set children to the same thing. In IE9, the selection range will
    // get reset if `textContent` is mutated.  We could add a check in setTextContent
    // to only set the value if/when the value differs from the node value (which would
    // completely solve this IE9 bug), but Sebastian+Ben seemed to like this solution.
    // The value can be a boolean or object so that's why it's forced to be a string.
    var hostProps = index({}, props, {
      value: undefined,
      defaultValue: undefined,
      children: '' + inst._wrapperState.initialValue,
      onChange: inst._wrapperState.onChange
    });

    return hostProps;
  },

  mountWrapper: function (inst, props) {
    {
      LinkedValueUtils_1.checkPropTypes('textarea', props, inst._currentElement._owner);
      if (props.valueLink !== undefined && !didWarnValueLink$2) {
        warning_1(false, '`valueLink` prop on `textarea` is deprecated; set `value` and `onChange` instead.');
        didWarnValueLink$2 = true;
      }
      if (props.value !== undefined && props.defaultValue !== undefined && !didWarnValDefaultVal) {
        warning_1(false, 'Textarea elements must be either controlled or uncontrolled ' + '(specify either the value prop, or the defaultValue prop, but not ' + 'both). Decide between using a controlled or uncontrolled textarea ' + 'and remove one of these props. More info: ' + 'https://fb.me/react-controlled-components');
        didWarnValDefaultVal = true;
      }
    }

    var value = LinkedValueUtils_1.getValue(props);
    var initialValue = value;

    // Only bother fetching default value if we're going to use it
    if (value == null) {
      var defaultValue = props.defaultValue;
      // TODO (yungsters): Remove support for children content in <textarea>.
      var children = props.children;
      if (children != null) {
        {
          warning_1(false, 'Use the `defaultValue` or `value` props instead of setting ' + 'children on <textarea>.');
        }
        !(defaultValue == null) ? invariant_1(false, 'If you supply `defaultValue` on a <textarea>, do not pass children.') : void 0;
        if (Array.isArray(children)) {
          !(children.length <= 1) ? invariant_1(false, '<textarea> can only have at most one child.') : void 0;
          children = children[0];
        }

        defaultValue = '' + children;
      }
      if (defaultValue == null) {
        defaultValue = '';
      }
      initialValue = defaultValue;
    }

    inst._wrapperState = {
      initialValue: '' + initialValue,
      listeners: null,
      onChange: _handleChange$2.bind(inst)
    };
  },

  updateWrapper: function (inst) {
    var props = inst._currentElement.props;

    var node = ReactDOMComponentTree_1.getNodeFromInstance(inst);
    var value = LinkedValueUtils_1.getValue(props);
    if (value != null) {
      // Cast `value` to a string to ensure the value is set correctly. While
      // browsers typically do this as necessary, jsdom doesn't.
      var newValue = '' + value;

      // To avoid side effects (such as losing text selection), only set value if changed
      if (newValue !== node.value) {
        node.value = newValue;
      }
      if (props.defaultValue == null) {
        node.defaultValue = newValue;
      }
    }
    if (props.defaultValue != null) {
      node.defaultValue = props.defaultValue;
    }
  },

  postMountWrapper: function (inst) {
    // This is in postMount because we need access to the DOM node, which is not
    // available until after the component has mounted.
    var node = ReactDOMComponentTree_1.getNodeFromInstance(inst);
    var textContent = node.textContent;

    // Only set node.value if textContent is equal to the expected
    // initial value. In IE10/IE11 there is a bug where the placeholder attribute
    // will populate textContent as well.
    // https://developer.microsoft.com/microsoft-edge/platform/issues/101525/
    if (textContent === inst._wrapperState.initialValue) {
      node.value = textContent;
    }
  }
};

function _handleChange$2(event) {
  var props = this._currentElement.props;
  var returnValue = LinkedValueUtils_1.executeOnChange(props, event);
  ReactUpdates_1.asap(forceUpdateIfMounted$1, this);
  return returnValue;
}

var ReactDOMTextarea_1 = ReactDOMTextarea;

var injected = false;

var ReactComponentEnvironment = {

  /**
   * Optionally injectable hook for swapping out mount images in the middle of
   * the tree.
   */
  replaceNodeWithMarkup: null,

  /**
   * Optionally injectable hook for processing a queue of child updates. Will
   * later move into MultiChildComponents.
   */
  processChildrenUpdates: null,

  injection: {
    injectEnvironment: function (environment) {
      !!injected ? invariant_1(false, 'ReactCompositeComponent: injectEnvironment() can only be called once.') : void 0;
      ReactComponentEnvironment.replaceNodeWithMarkup = environment.replaceNodeWithMarkup;
      ReactComponentEnvironment.processChildrenUpdates = environment.processChildrenUpdates;
      injected = true;
    }
  }

};

var ReactComponentEnvironment_1 = ReactComponentEnvironment;

/**
 * Copyright 2013-present, Facebook, Inc.
 * All rights reserved.
 *
 * This source code is licensed under the BSD-style license found in the
 * LICENSE file in the root directory of this source tree. An additional grant
 * of patent rights can be found in the PATENTS file in the same directory.
 *
 */

var ReactInstanceMap = {

  /**
   * This API should be called `delete` but we'd have to make sure to always
   * transform these to strings for IE support. When this transform is fully
   * supported we can rename it.
   */
  remove: function (key) {
    key._reactInternalInstance = undefined;
  },

  get: function (key) {
    return key._reactInternalInstance;
  },

  has: function (key) {
    return key._reactInternalInstance !== undefined;
  },

  set: function (key, value) {
    key._reactInternalInstance = value;
  }

};

var ReactInstanceMap_1 = ReactInstanceMap;

var ReactNodeTypes = {
  HOST: 0,
  COMPOSITE: 1,
  EMPTY: 2,

  getType: function (node) {
    if (node === null || node === false) {
      return ReactNodeTypes.EMPTY;
    } else if (React_1.isValidElement(node)) {
      if (typeof node.type === 'function') {
        return ReactNodeTypes.COMPOSITE;
      } else {
        return ReactNodeTypes.HOST;
      }
    }
    invariant_1(false, 'Unexpected node: %s', node);
  }
};

var ReactNodeTypes_1 = ReactNodeTypes;

/**
 * Copyright 2013-present, Facebook, Inc.
 * All rights reserved.
 *
 * This source code is licensed under the BSD-style license found in the
 * LICENSE file in the root directory of this source tree. An additional grant
 * of patent rights can be found in the PATENTS file in the same directory.
 *
 * 
 */

var ReactPropTypeLocationNames$2 = {};

{
  ReactPropTypeLocationNames$2 = {
    prop: 'prop',
    context: 'context',
    childContext: 'child context'
  };
}

var ReactPropTypeLocationNames_1$2 = ReactPropTypeLocationNames$2;

var ReactComponentTreeHook$4;

if (typeof process !== 'undefined' && process.env && "development" === 'test') {
  // Temporary hack.
  // Inline requires don't work well with Jest:
  // https://github.com/facebook/react/issues/7240
  // Remove the inline requires when we don't need them anymore:
  // https://github.com/facebook/react/pull/7178
  ReactComponentTreeHook$4 = ReactComponentTreeHook_1;
}

var loggedTypeFailures$3 = {};

/**
 * Assert that the values match with the type specs.
 * Error messages are memorized and will only be shown once.
 *
 * @param {object} typeSpecs Map of name to a ReactPropType
 * @param {object} values Runtime values that need to be type-checked
 * @param {string} location e.g. "prop", "context", "child context"
 * @param {string} componentName Name of the component for error messages.
 * @param {?object} element The React element that is being type-checked
 * @param {?number} debugID The React component instance that is being type-checked
 * @private
 */
function checkReactTypeSpec$3(typeSpecs, values, location, componentName, element, debugID) {
  for (var typeSpecName in typeSpecs) {
    if (typeSpecs.hasOwnProperty(typeSpecName)) {
      var error;
      // Prop type validation may throw. In case they do, we don't want to
      // fail the render phase where it didn't fail before. So we log it.
      // After these have been cleaned up, we'll let them throw.
      try {
        // This is intentionally an invariant that gets caught. It's the same
        // behavior as without this statement except with a better message.
        !(typeof typeSpecs[typeSpecName] === 'function') ? invariant_1(false, '%s: %s type `%s` is invalid; it must be a function, usually from React.PropTypes.', componentName || 'React class', ReactPropTypeLocationNames_1$2[location], typeSpecName) : void 0;
        error = typeSpecs[typeSpecName](values, typeSpecName, componentName, location, null, ReactPropTypesSecret_1$4);
      } catch (ex) {
        error = ex;
      }
      warning_1(!error || error instanceof Error, '%s: type specification of %s `%s` is invalid; the type checker ' + 'function must return `null` or an `Error` but returned a %s. ' + 'You may have forgotten to pass an argument to the type checker ' + 'creator (arrayOf, instanceOf, objectOf, oneOf, oneOfType, and ' + 'shape all require an argument).', componentName || 'React class', ReactPropTypeLocationNames_1$2[location], typeSpecName, typeof error);
      if (error instanceof Error && !(error.message in loggedTypeFailures$3)) {
        // Only monitor this failure once because there tends to be a lot of the
        // same error.
        loggedTypeFailures$3[error.message] = true;

        var componentStackInfo = '';

        {
          if (!ReactComponentTreeHook$4) {
            ReactComponentTreeHook$4 = ReactComponentTreeHook_1;
          }
          if (debugID !== null) {
            componentStackInfo = ReactComponentTreeHook$4.getStackAddendumByID(debugID);
          } else if (element !== null) {
            componentStackInfo = ReactComponentTreeHook$4.getCurrentStackAddendum(element);
          }
        }

        warning_1(false, 'Failed %s type: %s%s', location, error.message, componentStackInfo);
      }
    }
  }
}

var checkReactTypeSpec_1$2 = checkReactTypeSpec$3;

/**
 * Copyright (c) 2013-present, Facebook, Inc.
 * All rights reserved.
 *
 * This source code is licensed under the BSD-style license found in the
 * LICENSE file in the root directory of this source tree. An additional grant
 * of patent rights can be found in the PATENTS file in the same directory.
 *
 * @typechecks
 * 
 */

/*eslint-disable no-self-compare */

var hasOwnProperty$3 = Object.prototype.hasOwnProperty;

/**
 * inlined Object.is polyfill to avoid requiring consumers ship their own
 * https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Object/is
 */
function is(x, y) {
  // SameValue algorithm
  if (x === y) {
    // Steps 1-5, 7-10
    // Steps 6.b-6.e: +0 != -0
    // Added the nonzero y check to make Flow happy, but it is redundant
    return x !== 0 || y !== 0 || 1 / x === 1 / y;
  } else {
    // Step 6.a: NaN == NaN
    return x !== x && y !== y;
  }
}

/**
 * Performs equality by iterating through keys on an object and returning false
 * when any key has values which are not strictly equal between the arguments.
 * Returns true when the values of all keys are strictly equal.
 */
function shallowEqual(objA, objB) {
  if (is(objA, objB)) {
    return true;
  }

  if (typeof objA !== 'object' || objA === null || typeof objB !== 'object' || objB === null) {
    return false;
  }

  var keysA = Object.keys(objA);
  var keysB = Object.keys(objB);

  if (keysA.length !== keysB.length) {
    return false;
  }

  // Test for A's keys different from B.
  for (var i = 0; i < keysA.length; i++) {
    if (!hasOwnProperty$3.call(objB, keysA[i]) || !is(objA[keysA[i]], objB[keysA[i]])) {
      return false;
    }
  }

  return true;
}

var shallowEqual_1 = shallowEqual;

/**
 * Copyright 2013-present, Facebook, Inc.
 * All rights reserved.
 *
 * This source code is licensed under the BSD-style license found in the
 * LICENSE file in the root directory of this source tree. An additional grant
 * of patent rights can be found in the PATENTS file in the same directory.
 *
 */

function shouldUpdateReactComponent(prevElement, nextElement) {
  var prevEmpty = prevElement === null || prevElement === false;
  var nextEmpty = nextElement === null || nextElement === false;
  if (prevEmpty || nextEmpty) {
    return prevEmpty === nextEmpty;
  }

  var prevType = typeof prevElement;
  var nextType = typeof nextElement;
  if (prevType === 'string' || prevType === 'number') {
    return nextType === 'string' || nextType === 'number';
  } else {
    return nextType === 'object' && prevElement.type === nextElement.type && prevElement.key === nextElement.key;
  }
}

var shouldUpdateReactComponent_1 = shouldUpdateReactComponent;

{
  var checkReactTypeSpec$2 = checkReactTypeSpec_1$2;
}







var CompositeTypes = {
  ImpureClass: 0,
  PureClass: 1,
  StatelessFunctional: 2
};

function StatelessComponent(Component) {}
StatelessComponent.prototype.render = function () {
  var Component = ReactInstanceMap_1.get(this)._currentElement.type;
  var element = Component(this.props, this.context, this.updater);
  warnIfInvalidElement(Component, element);
  return element;
};

function warnIfInvalidElement(Component, element) {
  {
    warning_1(element === null || element === false || React_1.isValidElement(element), '%s(...): A valid React element (or null) must be returned. You may have ' + 'returned undefined, an array or some other invalid object.', Component.displayName || Component.name || 'Component');
    warning_1(!Component.childContextTypes, '%s(...): childContextTypes cannot be defined on a functional component.', Component.displayName || Component.name || 'Component');
  }
}

function shouldConstruct(Component) {
  return !!(Component.prototype && Component.prototype.isReactComponent);
}

function isPureComponent(Component) {
  return !!(Component.prototype && Component.prototype.isPureReactComponent);
}

// Separated into a function to contain deoptimizations caused by try/finally.
function measureLifeCyclePerf(fn, debugID, timerType) {
  if (debugID === 0) {
    // Top-level wrappers (see ReactMount) and empty components (see
    // ReactDOMEmptyComponent) are invisible to hooks and devtools.
    // Both are implementation details that should go away in the future.
    return fn();
  }

  ReactInstrumentation$1.debugTool.onBeginLifeCycleTimer(debugID, timerType);
  try {
    return fn();
  } finally {
    ReactInstrumentation$1.debugTool.onEndLifeCycleTimer(debugID, timerType);
  }
}

/**
 * ------------------ The Life-Cycle of a Composite Component ------------------
 *
 * - constructor: Initialization of state. The instance is now retained.
 *   - componentWillMount
 *   - render
 *   - [children's constructors]
 *     - [children's componentWillMount and render]
 *     - [children's componentDidMount]
 *     - componentDidMount
 *
 *       Update Phases:
 *       - componentWillReceiveProps (only called if parent updated)
 *       - shouldComponentUpdate
 *         - componentWillUpdate
 *           - render
 *           - [children's constructors or receive props phases]
 *         - componentDidUpdate
 *
 *     - componentWillUnmount
 *     - [children's componentWillUnmount]
 *   - [children destroyed]
 * - (destroyed): The instance is now blank, released by React and ready for GC.
 *
 * -----------------------------------------------------------------------------
 */

/**
 * An incrementing ID assigned to each component when it is mounted. This is
 * used to enforce the order in which `ReactUpdates` updates dirty components.
 *
 * @private
 */
var nextMountID = 1;

/**
 * @lends {ReactCompositeComponent.prototype}
 */
var ReactCompositeComponent = {

  /**
   * Base constructor for all composite component.
   *
   * @param {ReactElement} element
   * @final
   * @internal
   */
  construct: function (element) {
    this._currentElement = element;
    this._rootNodeID = 0;
    this._compositeType = null;
    this._instance = null;
    this._hostParent = null;
    this._hostContainerInfo = null;

    // See ReactUpdateQueue
    this._updateBatchNumber = null;
    this._pendingElement = null;
    this._pendingStateQueue = null;
    this._pendingReplaceState = false;
    this._pendingForceUpdate = false;

    this._renderedNodeType = null;
    this._renderedComponent = null;
    this._context = null;
    this._mountOrder = 0;
    this._topLevelWrapper = null;

    // See ReactUpdates and ReactUpdateQueue.
    this._pendingCallbacks = null;

    // ComponentWillUnmount shall only be called once
    this._calledComponentWillUnmount = false;

    {
      this._warnedAboutRefsInRender = false;
    }
  },

  /**
   * Initializes the component, renders markup, and registers event listeners.
   *
   * @param {ReactReconcileTransaction|ReactServerRenderingTransaction} transaction
   * @param {?object} hostParent
   * @param {?object} hostContainerInfo
   * @param {?object} context
   * @return {?string} Rendered markup to be inserted into the DOM.
   * @final
   * @internal
   */
  mountComponent: function (transaction, hostParent, hostContainerInfo, context) {
    var _this = this;

    this._context = context;
    this._mountOrder = nextMountID++;
    this._hostParent = hostParent;
    this._hostContainerInfo = hostContainerInfo;

    var publicProps = this._currentElement.props;
    var publicContext = this._processContext(context);

    var Component = this._currentElement.type;

    var updateQueue = transaction.getUpdateQueue();

    // Initialize the public class
    var doConstruct = shouldConstruct(Component);
    var inst = this._constructComponent(doConstruct, publicProps, publicContext, updateQueue);
    var renderedElement;

    // Support functional components
    if (!doConstruct && (inst == null || inst.render == null)) {
      renderedElement = inst;
      warnIfInvalidElement(Component, renderedElement);
      !(inst === null || inst === false || React_1.isValidElement(inst)) ? invariant_1(false, '%s(...): A valid React element (or null) must be returned. You may have returned undefined, an array or some other invalid object.', Component.displayName || Component.name || 'Component') : void 0;
      inst = new StatelessComponent(Component);
      this._compositeType = CompositeTypes.StatelessFunctional;
    } else {
      if (isPureComponent(Component)) {
        this._compositeType = CompositeTypes.PureClass;
      } else {
        this._compositeType = CompositeTypes.ImpureClass;
      }
    }

    {
      // This will throw later in _renderValidatedComponent, but add an early
      // warning now to help debugging
      if (inst.render == null) {
        warning_1(false, '%s(...): No `render` method found on the returned component ' + 'instance: you may have forgotten to define `render`.', Component.displayName || Component.name || 'Component');
      }

      var propsMutated = inst.props !== publicProps;
      var componentName = Component.displayName || Component.name || 'Component';

      warning_1(inst.props === undefined || !propsMutated, '%s(...): When calling super() in `%s`, make sure to pass ' + 'up the same props that your component\'s constructor was passed.', componentName, componentName);
    }

    // These should be set up in the constructor, but as a convenience for
    // simpler class abstractions, we set them up after the fact.
    inst.props = publicProps;
    inst.context = publicContext;
    inst.refs = emptyObject_1;
    inst.updater = updateQueue;

    this._instance = inst;

    // Store a reference from the instance back to the internal representation
    ReactInstanceMap_1.set(inst, this);

    {
      // Since plain JS classes are defined without any special initialization
      // logic, we can not catch common errors early. Therefore, we have to
      // catch them here, at initialization time, instead.
      warning_1(!inst.getInitialState || inst.getInitialState.isReactClassApproved || inst.state, 'getInitialState was defined on %s, a plain JavaScript class. ' + 'This is only supported for classes created using React.createClass. ' + 'Did you mean to define a state property instead?', this.getName() || 'a component');
      warning_1(!inst.getDefaultProps || inst.getDefaultProps.isReactClassApproved, 'getDefaultProps was defined on %s, a plain JavaScript class. ' + 'This is only supported for classes created using React.createClass. ' + 'Use a static property to define defaultProps instead.', this.getName() || 'a component');
      warning_1(!inst.propTypes, 'propTypes was defined as an instance property on %s. Use a static ' + 'property to define propTypes instead.', this.getName() || 'a component');
      warning_1(!inst.contextTypes, 'contextTypes was defined as an instance property on %s. Use a ' + 'static property to define contextTypes instead.', this.getName() || 'a component');
      warning_1(typeof inst.componentShouldUpdate !== 'function', '%s has a method called ' + 'componentShouldUpdate(). Did you mean shouldComponentUpdate()? ' + 'The name is phrased as a question because the function is ' + 'expected to return a value.', this.getName() || 'A component');
      warning_1(typeof inst.componentDidUnmount !== 'function', '%s has a method called ' + 'componentDidUnmount(). But there is no such lifecycle method. ' + 'Did you mean componentWillUnmount()?', this.getName() || 'A component');
      warning_1(typeof inst.componentWillRecieveProps !== 'function', '%s has a method called ' + 'componentWillRecieveProps(). Did you mean componentWillReceiveProps()?', this.getName() || 'A component');
    }

    var initialState = inst.state;
    if (initialState === undefined) {
      inst.state = initialState = null;
    }
    !(typeof initialState === 'object' && !Array.isArray(initialState)) ? invariant_1(false, '%s.state: must be set to an object or null', this.getName() || 'ReactCompositeComponent') : void 0;

    this._pendingStateQueue = null;
    this._pendingReplaceState = false;
    this._pendingForceUpdate = false;

    var markup;
    if (inst.unstable_handleError) {
      markup = this.performInitialMountWithErrorHandling(renderedElement, hostParent, hostContainerInfo, transaction, context);
    } else {
      markup = this.performInitialMount(renderedElement, hostParent, hostContainerInfo, transaction, context);
    }

    if (inst.componentDidMount) {
      {
        transaction.getReactMountReady().enqueue(function () {
          measureLifeCyclePerf(function () {
            return inst.componentDidMount();
          }, _this._debugID, 'componentDidMount');
        });
      }
    }

    return markup;
  },

  _constructComponent: function (doConstruct, publicProps, publicContext, updateQueue) {
    {
      ReactCurrentOwner_1.current = this;
      try {
        return this._constructComponentWithoutOwner(doConstruct, publicProps, publicContext, updateQueue);
      } finally {
        ReactCurrentOwner_1.current = null;
      }
    }
  },

  _constructComponentWithoutOwner: function (doConstruct, publicProps, publicContext, updateQueue) {
    var Component = this._currentElement.type;

    if (doConstruct) {
      {
        return measureLifeCyclePerf(function () {
          return new Component(publicProps, publicContext, updateQueue);
        }, this._debugID, 'ctor');
      }
    }

    // This can still be an instance in case of factory components
    // but we'll count this as time spent rendering as the more common case.
    {
      return measureLifeCyclePerf(function () {
        return Component(publicProps, publicContext, updateQueue);
      }, this._debugID, 'render');
    }
  },

  performInitialMountWithErrorHandling: function (renderedElement, hostParent, hostContainerInfo, transaction, context) {
    var markup;
    var checkpoint = transaction.checkpoint();
    try {
      markup = this.performInitialMount(renderedElement, hostParent, hostContainerInfo, transaction, context);
    } catch (e) {
      // Roll back to checkpoint, handle error (which may add items to the transaction), and take a new checkpoint
      transaction.rollback(checkpoint);
      this._instance.unstable_handleError(e);
      if (this._pendingStateQueue) {
        this._instance.state = this._processPendingState(this._instance.props, this._instance.context);
      }
      checkpoint = transaction.checkpoint();

      this._renderedComponent.unmountComponent(true);
      transaction.rollback(checkpoint);

      // Try again - we've informed the component about the error, so they can render an error message this time.
      // If this throws again, the error will bubble up (and can be caught by a higher error boundary).
      markup = this.performInitialMount(renderedElement, hostParent, hostContainerInfo, transaction, context);
    }
    return markup;
  },

  performInitialMount: function (renderedElement, hostParent, hostContainerInfo, transaction, context) {
    var inst = this._instance;

    var debugID = 0;
    {
      debugID = this._debugID;
    }

    if (inst.componentWillMount) {
      {
        measureLifeCyclePerf(function () {
          return inst.componentWillMount();
        }, debugID, 'componentWillMount');
      }
      // When mounting, calls to `setState` by `componentWillMount` will set
      // `this._pendingStateQueue` without triggering a re-render.
      if (this._pendingStateQueue) {
        inst.state = this._processPendingState(inst.props, inst.context);
      }
    }

    // If not a stateless component, we now render
    if (renderedElement === undefined) {
      renderedElement = this._renderValidatedComponent();
    }

    var nodeType = ReactNodeTypes_1.getType(renderedElement);
    this._renderedNodeType = nodeType;
    var child = this._instantiateReactComponent(renderedElement, nodeType !== ReactNodeTypes_1.EMPTY /* shouldHaveDebugID */
    );
    this._renderedComponent = child;

    var markup = ReactReconciler_1.mountComponent(child, transaction, hostParent, hostContainerInfo, this._processChildContext(context), debugID);

    {
      if (debugID !== 0) {
        var childDebugIDs = child._debugID !== 0 ? [child._debugID] : [];
        ReactInstrumentation$1.debugTool.onSetChildren(debugID, childDebugIDs);
      }
    }

    return markup;
  },

  getHostNode: function () {
    return ReactReconciler_1.getHostNode(this._renderedComponent);
  },

  /**
   * Releases any resources allocated by `mountComponent`.
   *
   * @final
   * @internal
   */
  unmountComponent: function (safely) {
    if (!this._renderedComponent) {
      return;
    }

    var inst = this._instance;

    if (inst.componentWillUnmount && !inst._calledComponentWillUnmount) {
      inst._calledComponentWillUnmount = true;

      if (safely) {
        var name = this.getName() + '.componentWillUnmount()';
        ReactErrorUtils_1.invokeGuardedCallback(name, inst.componentWillUnmount.bind(inst));
      } else {
        {
          measureLifeCyclePerf(function () {
            return inst.componentWillUnmount();
          }, this._debugID, 'componentWillUnmount');
        }
      }
    }

    if (this._renderedComponent) {
      ReactReconciler_1.unmountComponent(this._renderedComponent, safely);
      this._renderedNodeType = null;
      this._renderedComponent = null;
      this._instance = null;
    }

    // Reset pending fields
    // Even if this component is scheduled for another update in ReactUpdates,
    // it would still be ignored because these fields are reset.
    this._pendingStateQueue = null;
    this._pendingReplaceState = false;
    this._pendingForceUpdate = false;
    this._pendingCallbacks = null;
    this._pendingElement = null;

    // These fields do not really need to be reset since this object is no
    // longer accessible.
    this._context = null;
    this._rootNodeID = 0;
    this._topLevelWrapper = null;

    // Delete the reference from the instance to this internal representation
    // which allow the internals to be properly cleaned up even if the user
    // leaks a reference to the public instance.
    ReactInstanceMap_1.remove(inst);

    // Some existing components rely on inst.props even after they've been
    // destroyed (in event handlers).
    // TODO: inst.props = null;
    // TODO: inst.state = null;
    // TODO: inst.context = null;
  },

  /**
   * Filters the context object to only contain keys specified in
   * `contextTypes`
   *
   * @param {object} context
   * @return {?object}
   * @private
   */
  _maskContext: function (context) {
    var Component = this._currentElement.type;
    var contextTypes = Component.contextTypes;
    if (!contextTypes) {
      return emptyObject_1;
    }
    var maskedContext = {};
    for (var contextName in contextTypes) {
      maskedContext[contextName] = context[contextName];
    }
    return maskedContext;
  },

  /**
   * Filters the context object to only contain keys specified in
   * `contextTypes`, and asserts that they are valid.
   *
   * @param {object} context
   * @return {?object}
   * @private
   */
  _processContext: function (context) {
    var maskedContext = this._maskContext(context);
    {
      var Component = this._currentElement.type;
      if (Component.contextTypes) {
        this._checkContextTypes(Component.contextTypes, maskedContext, 'context');
      }
    }
    return maskedContext;
  },

  /**
   * @param {object} currentContext
   * @return {object}
   * @private
   */
  _processChildContext: function (currentContext) {
    var Component = this._currentElement.type;
    var inst = this._instance;
    var childContext;

    if (inst.getChildContext) {
      {
        ReactInstrumentation$1.debugTool.onBeginProcessingChildContext();
        try {
          childContext = inst.getChildContext();
        } finally {
          ReactInstrumentation$1.debugTool.onEndProcessingChildContext();
        }
      }
    }

    if (childContext) {
      !(typeof Component.childContextTypes === 'object') ? invariant_1(false, '%s.getChildContext(): childContextTypes must be defined in order to use getChildContext().', this.getName() || 'ReactCompositeComponent') : void 0;
      {
        this._checkContextTypes(Component.childContextTypes, childContext, 'child context');
      }
      for (var name in childContext) {
        !(name in Component.childContextTypes) ? invariant_1(false, '%s.getChildContext(): key "%s" is not defined in childContextTypes.', this.getName() || 'ReactCompositeComponent', name) : void 0;
      }
      return index({}, currentContext, childContext);
    }
    return currentContext;
  },

  /**
   * Assert that the context types are valid
   *
   * @param {object} typeSpecs Map of context field to a ReactPropType
   * @param {object} values Runtime values that need to be type-checked
   * @param {string} location e.g. "prop", "context", "child context"
   * @private
   */
  _checkContextTypes: function (typeSpecs, values, location) {
    {
      checkReactTypeSpec$2(typeSpecs, values, location, this.getName(), null, this._debugID);
    }
  },

  receiveComponent: function (nextElement, transaction, nextContext) {
    var prevElement = this._currentElement;
    var prevContext = this._context;

    this._pendingElement = null;

    this.updateComponent(transaction, prevElement, nextElement, prevContext, nextContext);
  },

  /**
   * If any of `_pendingElement`, `_pendingStateQueue`, or `_pendingForceUpdate`
   * is set, update the component.
   *
   * @param {ReactReconcileTransaction} transaction
   * @internal
   */
  performUpdateIfNecessary: function (transaction) {
    if (this._pendingElement != null) {
      ReactReconciler_1.receiveComponent(this, this._pendingElement, transaction, this._context);
    } else if (this._pendingStateQueue !== null || this._pendingForceUpdate) {
      this.updateComponent(transaction, this._currentElement, this._currentElement, this._context, this._context);
    } else {
      this._updateBatchNumber = null;
    }
  },

  /**
   * Perform an update to a mounted component. The componentWillReceiveProps and
   * shouldComponentUpdate methods are called, then (assuming the update isn't
   * skipped) the remaining update lifecycle methods are called and the DOM
   * representation is updated.
   *
   * By default, this implements React's rendering and reconciliation algorithm.
   * Sophisticated clients may wish to override this.
   *
   * @param {ReactReconcileTransaction} transaction
   * @param {ReactElement} prevParentElement
   * @param {ReactElement} nextParentElement
   * @internal
   * @overridable
   */
  updateComponent: function (transaction, prevParentElement, nextParentElement, prevUnmaskedContext, nextUnmaskedContext) {
    var inst = this._instance;
    !(inst != null) ? invariant_1(false, 'Attempted to update component `%s` that has already been unmounted (or failed to mount).', this.getName() || 'ReactCompositeComponent') : void 0;

    var willReceive = false;
    var nextContext;

    // Determine if the context has changed or not
    if (this._context === nextUnmaskedContext) {
      nextContext = inst.context;
    } else {
      nextContext = this._processContext(nextUnmaskedContext);
      willReceive = true;
    }

    var prevProps = prevParentElement.props;
    var nextProps = nextParentElement.props;

    // Not a simple state update but a props update
    if (prevParentElement !== nextParentElement) {
      willReceive = true;
    }

    // An update here will schedule an update but immediately set
    // _pendingStateQueue which will ensure that any state updates gets
    // immediately reconciled instead of waiting for the next batch.
    if (willReceive && inst.componentWillReceiveProps) {
      {
        measureLifeCyclePerf(function () {
          return inst.componentWillReceiveProps(nextProps, nextContext);
        }, this._debugID, 'componentWillReceiveProps');
      }
    }

    var nextState = this._processPendingState(nextProps, nextContext);
    var shouldUpdate = true;

    if (!this._pendingForceUpdate) {
      if (inst.shouldComponentUpdate) {
        {
          shouldUpdate = measureLifeCyclePerf(function () {
            return inst.shouldComponentUpdate(nextProps, nextState, nextContext);
          }, this._debugID, 'shouldComponentUpdate');
        }
      } else {
        if (this._compositeType === CompositeTypes.PureClass) {
          shouldUpdate = !shallowEqual_1(prevProps, nextProps) || !shallowEqual_1(inst.state, nextState);
        }
      }
    }

    {
      warning_1(shouldUpdate !== undefined, '%s.shouldComponentUpdate(): Returned undefined instead of a ' + 'boolean value. Make sure to return true or false.', this.getName() || 'ReactCompositeComponent');
    }

    this._updateBatchNumber = null;
    if (shouldUpdate) {
      this._pendingForceUpdate = false;
      // Will set `this.props`, `this.state` and `this.context`.
      this._performComponentUpdate(nextParentElement, nextProps, nextState, nextContext, transaction, nextUnmaskedContext);
    } else {
      // If it's determined that a component should not update, we still want
      // to set props and state but we shortcut the rest of the update.
      this._currentElement = nextParentElement;
      this._context = nextUnmaskedContext;
      inst.props = nextProps;
      inst.state = nextState;
      inst.context = nextContext;
    }
  },

  _processPendingState: function (props, context) {
    var inst = this._instance;
    var queue = this._pendingStateQueue;
    var replace = this._pendingReplaceState;
    this._pendingReplaceState = false;
    this._pendingStateQueue = null;

    if (!queue) {
      return inst.state;
    }

    if (replace && queue.length === 1) {
      return queue[0];
    }

    var nextState = index({}, replace ? queue[0] : inst.state);
    for (var i = replace ? 1 : 0; i < queue.length; i++) {
      var partial = queue[i];
      index(nextState, typeof partial === 'function' ? partial.call(inst, nextState, props, context) : partial);
    }

    return nextState;
  },

  /**
   * Merges new props and state, notifies delegate methods of update and
   * performs update.
   *
   * @param {ReactElement} nextElement Next element
   * @param {object} nextProps Next public object to set as properties.
   * @param {?object} nextState Next object to set as state.
   * @param {?object} nextContext Next public object to set as context.
   * @param {ReactReconcileTransaction} transaction
   * @param {?object} unmaskedContext
   * @private
   */
  _performComponentUpdate: function (nextElement, nextProps, nextState, nextContext, transaction, unmaskedContext) {
    var _this2 = this;

    var inst = this._instance;

    var hasComponentDidUpdate = Boolean(inst.componentDidUpdate);
    var prevProps;
    var prevState;
    var prevContext;
    if (hasComponentDidUpdate) {
      prevProps = inst.props;
      prevState = inst.state;
      prevContext = inst.context;
    }

    if (inst.componentWillUpdate) {
      {
        measureLifeCyclePerf(function () {
          return inst.componentWillUpdate(nextProps, nextState, nextContext);
        }, this._debugID, 'componentWillUpdate');
      }
    }

    this._currentElement = nextElement;
    this._context = unmaskedContext;
    inst.props = nextProps;
    inst.state = nextState;
    inst.context = nextContext;

    this._updateRenderedComponent(transaction, unmaskedContext);

    if (hasComponentDidUpdate) {
      {
        transaction.getReactMountReady().enqueue(function () {
          measureLifeCyclePerf(inst.componentDidUpdate.bind(inst, prevProps, prevState, prevContext), _this2._debugID, 'componentDidUpdate');
        });
      }
    }
  },

  /**
   * Call the component's `render` method and update the DOM accordingly.
   *
   * @param {ReactReconcileTransaction} transaction
   * @internal
   */
  _updateRenderedComponent: function (transaction, context) {
    var prevComponentInstance = this._renderedComponent;
    var prevRenderedElement = prevComponentInstance._currentElement;
    var nextRenderedElement = this._renderValidatedComponent();

    var debugID = 0;
    {
      debugID = this._debugID;
    }

    if (shouldUpdateReactComponent_1(prevRenderedElement, nextRenderedElement)) {
      ReactReconciler_1.receiveComponent(prevComponentInstance, nextRenderedElement, transaction, this._processChildContext(context));
    } else {
      var oldHostNode = ReactReconciler_1.getHostNode(prevComponentInstance);
      ReactReconciler_1.unmountComponent(prevComponentInstance, false);

      var nodeType = ReactNodeTypes_1.getType(nextRenderedElement);
      this._renderedNodeType = nodeType;
      var child = this._instantiateReactComponent(nextRenderedElement, nodeType !== ReactNodeTypes_1.EMPTY /* shouldHaveDebugID */
      );
      this._renderedComponent = child;

      var nextMarkup = ReactReconciler_1.mountComponent(child, transaction, this._hostParent, this._hostContainerInfo, this._processChildContext(context), debugID);

      {
        if (debugID !== 0) {
          var childDebugIDs = child._debugID !== 0 ? [child._debugID] : [];
          ReactInstrumentation$1.debugTool.onSetChildren(debugID, childDebugIDs);
        }
      }

      this._replaceNodeWithMarkup(oldHostNode, nextMarkup, prevComponentInstance);
    }
  },

  /**
   * Overridden in shallow rendering.
   *
   * @protected
   */
  _replaceNodeWithMarkup: function (oldHostNode, nextMarkup, prevInstance) {
    ReactComponentEnvironment_1.replaceNodeWithMarkup(oldHostNode, nextMarkup, prevInstance);
  },

  /**
   * @protected
   */
  _renderValidatedComponentWithoutOwnerOrContext: function () {
    var inst = this._instance;
    var renderedElement;

    {
      renderedElement = measureLifeCyclePerf(function () {
        return inst.render();
      }, this._debugID, 'render');
    }

    {
      // We allow auto-mocks to proceed as if they're returning null.
      if (renderedElement === undefined && inst.render._isMockFunction) {
        // This is probably bad practice. Consider warning here and
        // deprecating this convenience.
        renderedElement = null;
      }
    }

    return renderedElement;
  },

  /**
   * @private
   */
  _renderValidatedComponent: function () {
    var renderedElement;
    if ("development" !== 'production' || this._compositeType !== CompositeTypes.StatelessFunctional) {
      ReactCurrentOwner_1.current = this;
      try {
        renderedElement = this._renderValidatedComponentWithoutOwnerOrContext();
      } finally {
        ReactCurrentOwner_1.current = null;
      }
    } else {
      renderedElement = this._renderValidatedComponentWithoutOwnerOrContext();
    }
    !(
    // TODO: An `isValidNode` function would probably be more appropriate
    renderedElement === null || renderedElement === false || React_1.isValidElement(renderedElement)) ? invariant_1(false, '%s.render(): A valid React element (or null) must be returned. You may have returned undefined, an array or some other invalid object.', this.getName() || 'ReactCompositeComponent') : void 0;

    return renderedElement;
  },

  /**
   * Lazily allocates the refs object and stores `component` as `ref`.
   *
   * @param {string} ref Reference name.
   * @param {component} component Component to store as `ref`.
   * @final
   * @private
   */
  attachRef: function (ref, component) {
    var inst = this.getPublicInstance();
    !(inst != null) ? invariant_1(false, 'Stateless function components cannot have refs.') : void 0;
    var publicComponentInstance = component.getPublicInstance();
    {
      var componentName = component && component.getName ? component.getName() : 'a component';
      warning_1(publicComponentInstance != null || component._compositeType !== CompositeTypes.StatelessFunctional, 'Stateless function components cannot be given refs ' + '(See ref "%s" in %s created by %s). ' + 'Attempts to access this ref will fail.', ref, componentName, this.getName());
    }
    var refs = inst.refs === emptyObject_1 ? inst.refs = {} : inst.refs;
    refs[ref] = publicComponentInstance;
  },

  /**
   * Detaches a reference name.
   *
   * @param {string} ref Name to dereference.
   * @final
   * @private
   */
  detachRef: function (ref) {
    var refs = this.getPublicInstance().refs;
    delete refs[ref];
  },

  /**
   * Get a text description of the component that can be used to identify it
   * in error messages.
   * @return {string} The name or null.
   * @internal
   */
  getName: function () {
    var type = this._currentElement.type;
    var constructor = this._instance && this._instance.constructor;
    return type.displayName || constructor && constructor.displayName || type.name || constructor && constructor.name || null;
  },

  /**
   * Get the publicly accessible representation of this component - i.e. what
   * is exposed by refs and returned by render. Can be null for stateless
   * components.
   *
   * @return {ReactComponent} the public component instance.
   * @internal
   */
  getPublicInstance: function () {
    var inst = this._instance;
    if (this._compositeType === CompositeTypes.StatelessFunctional) {
      return null;
    }
    return inst;
  },

  // Stub
  _instantiateReactComponent: null

};

var ReactCompositeComponent_1 = ReactCompositeComponent;

/**
 * Copyright 2014-present, Facebook, Inc.
 * All rights reserved.
 *
 * This source code is licensed under the BSD-style license found in the
 * LICENSE file in the root directory of this source tree. An additional grant
 * of patent rights can be found in the PATENTS file in the same directory.
 *
 */

var emptyComponentFactory;

var ReactEmptyComponentInjection = {
  injectEmptyComponentFactory: function (factory) {
    emptyComponentFactory = factory;
  }
};

var ReactEmptyComponent = {
  create: function (instantiate) {
    return emptyComponentFactory(instantiate);
  }
};

ReactEmptyComponent.injection = ReactEmptyComponentInjection;

var ReactEmptyComponent_1 = ReactEmptyComponent;

var genericComponentClass = null;
var textComponentClass = null;

var ReactHostComponentInjection = {
  // This accepts a class that receives the tag string. This is a catch all
  // that can render any kind of tag.
  injectGenericComponentClass: function (componentClass) {
    genericComponentClass = componentClass;
  },
  // This accepts a text component class that takes the text string to be
  // rendered as props.
  injectTextComponentClass: function (componentClass) {
    textComponentClass = componentClass;
  }
};

/**
 * Get a host internal component class for a specific tag.
 *
 * @param {ReactElement} element The element to create.
 * @return {function} The internal class constructor function.
 */
function createInternalComponent(element) {
  !genericComponentClass ? invariant_1(false, 'There is no registered component for the tag %s', element.type) : void 0;
  return new genericComponentClass(element);
}

/**
 * @param {ReactText} text
 * @return {ReactComponent}
 */
function createInstanceForText(text) {
  return new textComponentClass(text);
}

/**
 * @param {ReactComponent} component
 * @return {boolean}
 */
function isTextComponent(component) {
  return component instanceof textComponentClass;
}

var ReactHostComponent = {
  createInternalComponent: createInternalComponent,
  createInstanceForText: createInstanceForText,
  isTextComponent: isTextComponent,
  injection: ReactHostComponentInjection
};

var ReactHostComponent_1 = ReactHostComponent;

/**
 * Copyright 2013-present, Facebook, Inc.
 * All rights reserved.
 *
 * This source code is licensed under the BSD-style license found in the
 * LICENSE file in the root directory of this source tree. An additional grant
 * of patent rights can be found in the PATENTS file in the same directory.
 *
 * 
 */

var nextDebugID = 1;

function getNextDebugID() {
  return nextDebugID++;
}

var getNextDebugID_1 = getNextDebugID;

var ReactCompositeComponentWrapper = function (element) {
  this.construct(element);
};

function getDeclarationErrorAddendum$4(owner) {
  if (owner) {
    var name = owner.getName();
    if (name) {
      return ' Check the render method of `' + name + '`.';
    }
  }
  return '';
}

/**
 * Check if the type reference is a known internal type. I.e. not a user
 * provided composite type.
 *
 * @param {function} type
 * @return {boolean} Returns true if this is a valid internal type.
 */
function isInternalComponentType(type) {
  return typeof type === 'function' && typeof type.prototype !== 'undefined' && typeof type.prototype.mountComponent === 'function' && typeof type.prototype.receiveComponent === 'function';
}

/**
 * Given a ReactNode, create an instance that will actually be mounted.
 *
 * @param {ReactNode} node
 * @param {boolean} shouldHaveDebugID
 * @return {object} A new instance of the element's constructor.
 * @protected
 */
function instantiateReactComponent(node, shouldHaveDebugID) {
  var instance;

  if (node === null || node === false) {
    instance = ReactEmptyComponent_1.create(instantiateReactComponent);
  } else if (typeof node === 'object') {
    var element = node;
    var type = element.type;
    if (typeof type !== 'function' && typeof type !== 'string') {
      var info = '';
      {
        if (type === undefined || typeof type === 'object' && type !== null && Object.keys(type).length === 0) {
          info += ' You likely forgot to export your component from the file ' + 'it\'s defined in.';
        }
      }
      info += getDeclarationErrorAddendum$4(element._owner);
      invariant_1(false, 'Element type is invalid: expected a string (for built-in components) or a class/function (for composite components) but got: %s.%s', type == null ? type : typeof type, info);
    }

    // Special case string values
    if (typeof element.type === 'string') {
      instance = ReactHostComponent_1.createInternalComponent(element);
    } else if (isInternalComponentType(element.type)) {
      // This is temporarily available for custom components that are not string
      // representations. I.e. ART. Once those are updated to use the string
      // representation, we can drop this code path.
      instance = new element.type(element);

      // We renamed this. Allow the old name for compat. :(
      if (!instance.getHostNode) {
        instance.getHostNode = instance.getNativeNode;
      }
    } else {
      instance = new ReactCompositeComponentWrapper(element);
    }
  } else if (typeof node === 'string' || typeof node === 'number') {
    instance = ReactHostComponent_1.createInstanceForText(node);
  } else {
    invariant_1(false, 'Encountered invalid React node of type %s', typeof node);
  }

  {
    warning_1(typeof instance.mountComponent === 'function' && typeof instance.receiveComponent === 'function' && typeof instance.getHostNode === 'function' && typeof instance.unmountComponent === 'function', 'Only React Components can be mounted.');
  }

  // These two fields are used by the DOM and ART diffing algorithms
  // respectively. Instead of using expandos on components, we should be
  // storing the state needed by the diffing algorithms elsewhere.
  instance._mountIndex = 0;
  instance._mountImage = null;

  {
    instance._debugID = shouldHaveDebugID ? getNextDebugID_1() : 0;
  }

  // Internal instances should fully constructed at this point, so they should
  // not get any new fields added to them at this point.
  {
    if (Object.preventExtensions) {
      Object.preventExtensions(instance);
    }
  }

  return instance;
}

index(ReactCompositeComponentWrapper.prototype, ReactCompositeComponent_1, {
  _instantiateReactComponent: instantiateReactComponent
});

var instantiateReactComponent_1 = instantiateReactComponent;

/**
 * Copyright 2013-present, Facebook, Inc.
 * All rights reserved.
 *
 * This source code is licensed under the BSD-style license found in the
 * LICENSE file in the root directory of this source tree. An additional grant
 * of patent rights can be found in the PATENTS file in the same directory.
 *
 * 
 */

function escape$2(key) {
  var escapeRegex = /[=:]/g;
  var escaperLookup = {
    '=': '=0',
    ':': '=2'
  };
  var escapedString = ('' + key).replace(escapeRegex, function (match) {
    return escaperLookup[match];
  });

  return '$' + escapedString;
}

/**
 * Unescape and unwrap key for human-readable display
 *
 * @param {string} key to unescape.
 * @return {string} the unescaped key.
 */
function unescape$2(key) {
  var unescapeRegex = /(=0|=2)/g;
  var unescaperLookup = {
    '=0': '=',
    '=2': ':'
  };
  var keySubstring = key[0] === '.' && key[1] === '$' ? key.substring(2) : key.substring(1);

  return ('' + keySubstring).replace(unescapeRegex, function (match) {
    return unescaperLookup[match];
  });
}

var KeyEscapeUtils$2 = {
  escape: escape$2,
  unescape: unescape$2
};

var KeyEscapeUtils_1$2 = KeyEscapeUtils$2;

/**
 * Copyright 2014-present, Facebook, Inc.
 * All rights reserved.
 *
 * This source code is licensed under the BSD-style license found in the
 * LICENSE file in the root directory of this source tree. An additional grant
 * of patent rights can be found in the PATENTS file in the same directory.
 *
 * 
 */

var REACT_ELEMENT_TYPE$2 = typeof Symbol === 'function' && Symbol['for'] && Symbol['for']('react.element') || 0xeac7;

var ReactElementSymbol$2 = REACT_ELEMENT_TYPE$2;

/**
 * Copyright 2013-present, Facebook, Inc.
 * All rights reserved.
 *
 * This source code is licensed under the BSD-style license found in the
 * LICENSE file in the root directory of this source tree. An additional grant
 * of patent rights can be found in the PATENTS file in the same directory.
 *
 * 
 */

var ITERATOR_SYMBOL$1 = typeof Symbol === 'function' && Symbol.iterator;
var FAUX_ITERATOR_SYMBOL$1 = '@@iterator'; // Before Symbol spec.

/**
 * Returns the iterator method function contained on the iterable object.
 *
 * Be sure to invoke the function with the iterable as context:
 *
 *     var iteratorFn = getIteratorFn(myIterable);
 *     if (iteratorFn) {
 *       var iterator = iteratorFn.call(myIterable);
 *       ...
 *     }
 *
 * @param {?object} maybeIterable
 * @return {?function}
 */
function getIteratorFn$2(maybeIterable) {
  var iteratorFn = maybeIterable && (ITERATOR_SYMBOL$1 && maybeIterable[ITERATOR_SYMBOL$1] || maybeIterable[FAUX_ITERATOR_SYMBOL$1]);
  if (typeof iteratorFn === 'function') {
    return iteratorFn;
  }
}

var getIteratorFn_1$2 = getIteratorFn$2;

var SEPARATOR$1 = '.';
var SUBSEPARATOR$1 = ':';

/**
 * This is inlined from ReactElement since this file is shared between
 * isomorphic and renderers. We could extract this to a
 *
 */

/**
 * TODO: Test that a single child and an array with one item have the same key
 * pattern.
 */

var didWarnAboutMaps$1 = false;

/**
 * Generate a key string that identifies a component within a set.
 *
 * @param {*} component A component that could contain a manual key.
 * @param {number} index Index that is used if a manual key is not provided.
 * @return {string}
 */
function getComponentKey$1(component, index) {
  // Do some typechecking here since we call this blindly. We want to ensure
  // that we don't block potential future ES APIs.
  if (component && typeof component === 'object' && component.key != null) {
    // Explicit key
    return KeyEscapeUtils_1$2.escape(component.key);
  }
  // Implicit key determined by the index in the set
  return index.toString(36);
}

/**
 * @param {?*} children Children tree container.
 * @param {!string} nameSoFar Name of the key path so far.
 * @param {!function} callback Callback to invoke with each child found.
 * @param {?*} traverseContext Used to pass information throughout the traversal
 * process.
 * @return {!number} The number of children in this subtree.
 */
function traverseAllChildrenImpl$1(children, nameSoFar, callback, traverseContext) {
  var type = typeof children;

  if (type === 'undefined' || type === 'boolean') {
    // All of the above are perceived as null.
    children = null;
  }

  if (children === null || type === 'string' || type === 'number' ||
  // The following is inlined from ReactElement. This means we can optimize
  // some checks. React Fiber also inlines this logic for similar purposes.
  type === 'object' && children.$$typeof === ReactElementSymbol$2) {
    callback(traverseContext, children,
    // If it's the only child, treat the name as if it was wrapped in an array
    // so that it's consistent if the number of children grows.
    nameSoFar === '' ? SEPARATOR$1 + getComponentKey$1(children, 0) : nameSoFar);
    return 1;
  }

  var child;
  var nextName;
  var subtreeCount = 0; // Count of children found in the current subtree.
  var nextNamePrefix = nameSoFar === '' ? SEPARATOR$1 : nameSoFar + SUBSEPARATOR$1;

  if (Array.isArray(children)) {
    for (var i = 0; i < children.length; i++) {
      child = children[i];
      nextName = nextNamePrefix + getComponentKey$1(child, i);
      subtreeCount += traverseAllChildrenImpl$1(child, nextName, callback, traverseContext);
    }
  } else {
    var iteratorFn = getIteratorFn_1$2(children);
    if (iteratorFn) {
      var iterator = iteratorFn.call(children);
      var step;
      if (iteratorFn !== children.entries) {
        var ii = 0;
        while (!(step = iterator.next()).done) {
          child = step.value;
          nextName = nextNamePrefix + getComponentKey$1(child, ii++);
          subtreeCount += traverseAllChildrenImpl$1(child, nextName, callback, traverseContext);
        }
      } else {
        {
          var mapsAsChildrenAddendum = '';
          if (ReactCurrentOwner_1.current) {
            var mapsAsChildrenOwnerName = ReactCurrentOwner_1.current.getName();
            if (mapsAsChildrenOwnerName) {
              mapsAsChildrenAddendum = ' Check the render method of `' + mapsAsChildrenOwnerName + '`.';
            }
          }
          warning_1(didWarnAboutMaps$1, 'Using Maps as children is not yet fully supported. It is an ' + 'experimental feature that might be removed. Convert it to a ' + 'sequence / iterable of keyed ReactElements instead.%s', mapsAsChildrenAddendum);
          didWarnAboutMaps$1 = true;
        }
        // Iterator will provide entry [k,v] tuples rather than values.
        while (!(step = iterator.next()).done) {
          var entry = step.value;
          if (entry) {
            child = entry[1];
            nextName = nextNamePrefix + KeyEscapeUtils_1$2.escape(entry[0]) + SUBSEPARATOR$1 + getComponentKey$1(child, 0);
            subtreeCount += traverseAllChildrenImpl$1(child, nextName, callback, traverseContext);
          }
        }
      }
    } else if (type === 'object') {
      var addendum = '';
      {
        addendum = ' If you meant to render a collection of children, use an array ' + 'instead or wrap the object using createFragment(object) from the ' + 'React add-ons.';
        if (children._isReactElement) {
          addendum = ' It looks like you\'re using an element created by a different ' + 'version of React. Make sure to use only one copy of React.';
        }
        if (ReactCurrentOwner_1.current) {
          var name = ReactCurrentOwner_1.current.getName();
          if (name) {
            addendum += ' Check the render method of `' + name + '`.';
          }
        }
      }
      var childrenString = String(children);
      invariant_1(false, 'Objects are not valid as a React child (found: %s).%s', childrenString === '[object Object]' ? 'object with keys {' + Object.keys(children).join(', ') + '}' : childrenString, addendum);
    }
  }

  return subtreeCount;
}

/**
 * Traverses children that are typically specified as `props.children`, but
 * might also be specified through attributes:
 *
 * - `traverseAllChildren(this.props.children, ...)`
 * - `traverseAllChildren(this.props.leftPanelChildren, ...)`
 *
 * The `traverseContext` is an optional argument that is passed through the
 * entire traversal. It can be used to store accumulations or anything else that
 * the callback might find relevant.
 *
 * @param {?*} children Children tree object.
 * @param {!function} callback To invoke upon traversing each child.
 * @param {?*} traverseContext Context for traversal.
 * @return {!number} The number of children in this subtree.
 */
function traverseAllChildren$2(children, callback, traverseContext) {
  if (children == null) {
    return 0;
  }

  return traverseAllChildrenImpl$1(children, '', callback, traverseContext);
}

var traverseAllChildren_1$2 = traverseAllChildren$2;

var ReactComponentTreeHook$3;

if (typeof process !== 'undefined' && process.env && "development" === 'test') {
  // Temporary hack.
  // Inline requires don't work well with Jest:
  // https://github.com/facebook/react/issues/7240
  // Remove the inline requires when we don't need them anymore:
  // https://github.com/facebook/react/pull/7178
  ReactComponentTreeHook$3 = ReactComponentTreeHook_1;
}

function instantiateChild(childInstances, child, name, selfDebugID) {
  // We found a component instance.
  var keyUnique = childInstances[name] === undefined;
  {
    if (!ReactComponentTreeHook$3) {
      ReactComponentTreeHook$3 = ReactComponentTreeHook_1;
    }
    if (!keyUnique) {
      warning_1(false, 'flattenChildren(...): Encountered two children with the same key, ' + '`%s`. Child keys must be unique; when two children share a key, only ' + 'the first child will be used.%s', KeyEscapeUtils_1$2.unescape(name), ReactComponentTreeHook$3.getStackAddendumByID(selfDebugID));
    }
  }
  if (child != null && keyUnique) {
    childInstances[name] = instantiateReactComponent_1(child, true);
  }
}

/**
 * ReactChildReconciler provides helpers for initializing or updating a set of
 * children. Its output is suitable for passing it onto ReactMultiChild which
 * does diffed reordering and insertion.
 */
var ReactChildReconciler = {
  /**
   * Generates a "mount image" for each of the supplied children. In the case
   * of `ReactDOMComponent`, a mount image is a string of markup.
   *
   * @param {?object} nestedChildNodes Nested child maps.
   * @return {?object} A set of child instances.
   * @internal
   */
  instantiateChildren: function (nestedChildNodes, transaction, context, selfDebugID // 0 in production and for roots
  ) {
    if (nestedChildNodes == null) {
      return null;
    }
    var childInstances = {};

    {
      traverseAllChildren_1$2(nestedChildNodes, function (childInsts, child, name) {
        return instantiateChild(childInsts, child, name, selfDebugID);
      }, childInstances);
    }
    return childInstances;
  },

  /**
   * Updates the rendered children and returns a new set of children.
   *
   * @param {?object} prevChildren Previously initialized set of children.
   * @param {?object} nextChildren Flat child element maps.
   * @param {ReactReconcileTransaction} transaction
   * @param {object} context
   * @return {?object} A new set of child instances.
   * @internal
   */
  updateChildren: function (prevChildren, nextChildren, mountImages, removedNodes, transaction, hostParent, hostContainerInfo, context, selfDebugID // 0 in production and for roots
  ) {
    // We currently don't have a way to track moves here but if we use iterators
    // instead of for..in we can zip the iterators and check if an item has
    // moved.
    // TODO: If nothing has changed, return the prevChildren object so that we
    // can quickly bailout if nothing has changed.
    if (!nextChildren && !prevChildren) {
      return;
    }
    var name;
    var prevChild;
    for (name in nextChildren) {
      if (!nextChildren.hasOwnProperty(name)) {
        continue;
      }
      prevChild = prevChildren && prevChildren[name];
      var prevElement = prevChild && prevChild._currentElement;
      var nextElement = nextChildren[name];
      if (prevChild != null && shouldUpdateReactComponent_1(prevElement, nextElement)) {
        ReactReconciler_1.receiveComponent(prevChild, nextElement, transaction, context);
        nextChildren[name] = prevChild;
      } else {
        if (prevChild) {
          removedNodes[name] = ReactReconciler_1.getHostNode(prevChild);
          ReactReconciler_1.unmountComponent(prevChild, false);
        }
        // The child must be instantiated before it's mounted.
        var nextChildInstance = instantiateReactComponent_1(nextElement, true);
        nextChildren[name] = nextChildInstance;
        // Creating mount image now ensures refs are resolved in right order
        // (see https://github.com/facebook/react/pull/7101 for explanation).
        var nextChildMountImage = ReactReconciler_1.mountComponent(nextChildInstance, transaction, hostParent, hostContainerInfo, context, selfDebugID);
        mountImages.push(nextChildMountImage);
      }
    }
    // Unmount children that are no longer present.
    for (name in prevChildren) {
      if (prevChildren.hasOwnProperty(name) && !(nextChildren && nextChildren.hasOwnProperty(name))) {
        prevChild = prevChildren[name];
        removedNodes[name] = ReactReconciler_1.getHostNode(prevChild);
        ReactReconciler_1.unmountComponent(prevChild, false);
      }
    }
  },

  /**
   * Unmounts all rendered children. This should be used to clean up children
   * when this component is unmounted.
   *
   * @param {?object} renderedChildren Previously initialized set of children.
   * @internal
   */
  unmountChildren: function (renderedChildren, safely) {
    for (var name in renderedChildren) {
      if (renderedChildren.hasOwnProperty(name)) {
        var renderedChild = renderedChildren[name];
        ReactReconciler_1.unmountComponent(renderedChild, safely);
      }
    }
  }

};

var ReactChildReconciler_1 = ReactChildReconciler;

var ReactComponentTreeHook$5;

if (typeof process !== 'undefined' && process.env && "development" === 'test') {
  // Temporary hack.
  // Inline requires don't work well with Jest:
  // https://github.com/facebook/react/issues/7240
  // Remove the inline requires when we don't need them anymore:
  // https://github.com/facebook/react/pull/7178
  ReactComponentTreeHook$5 = ReactComponentTreeHook_1;
}

/**
 * @param {function} traverseContext Context passed through traversal.
 * @param {?ReactComponent} child React child component.
 * @param {!string} name String name of key path to child.
 * @param {number=} selfDebugID Optional debugID of the current internal instance.
 */
function flattenSingleChildIntoContext(traverseContext, child, name, selfDebugID) {
  // We found a component instance.
  if (traverseContext && typeof traverseContext === 'object') {
    var result = traverseContext;
    var keyUnique = result[name] === undefined;
    {
      if (!ReactComponentTreeHook$5) {
        ReactComponentTreeHook$5 = ReactComponentTreeHook_1;
      }
      if (!keyUnique) {
        warning_1(false, 'flattenChildren(...): Encountered two children with the same key, ' + '`%s`. Child keys must be unique; when two children share a key, only ' + 'the first child will be used.%s', KeyEscapeUtils_1$2.unescape(name), ReactComponentTreeHook$5.getStackAddendumByID(selfDebugID));
      }
    }
    if (keyUnique && child != null) {
      result[name] = child;
    }
  }
}

/**
 * Flattens children that are typically specified as `props.children`. Any null
 * children will not be included in the resulting object.
 * @return {!object} flattened children keyed by name.
 */
function flattenChildren$1(children, selfDebugID) {
  if (children == null) {
    return children;
  }
  var result = {};

  {
    traverseAllChildren_1$2(children, function (traverseContext, child, name) {
      return flattenSingleChildIntoContext(traverseContext, child, name, selfDebugID);
    }, result);
  }
  return result;
}

var flattenChildren_1 = flattenChildren$1;

function makeInsertMarkup(markup, afterNode, toIndex) {
  // NOTE: Null values reduce hidden classes.
  return {
    type: 'INSERT_MARKUP',
    content: markup,
    fromIndex: null,
    fromNode: null,
    toIndex: toIndex,
    afterNode: afterNode
  };
}

/**
 * Make an update for moving an existing element to another index.
 *
 * @param {number} fromIndex Source index of the existing element.
 * @param {number} toIndex Destination index of the element.
 * @private
 */
function makeMove(child, afterNode, toIndex) {
  // NOTE: Null values reduce hidden classes.
  return {
    type: 'MOVE_EXISTING',
    content: null,
    fromIndex: child._mountIndex,
    fromNode: ReactReconciler_1.getHostNode(child),
    toIndex: toIndex,
    afterNode: afterNode
  };
}

/**
 * Make an update for removing an element at an index.
 *
 * @param {number} fromIndex Index of the element to remove.
 * @private
 */
function makeRemove(child, node) {
  // NOTE: Null values reduce hidden classes.
  return {
    type: 'REMOVE_NODE',
    content: null,
    fromIndex: child._mountIndex,
    fromNode: node,
    toIndex: null,
    afterNode: null
  };
}

/**
 * Make an update for setting the markup of a node.
 *
 * @param {string} markup Markup that renders into an element.
 * @private
 */
function makeSetMarkup(markup) {
  // NOTE: Null values reduce hidden classes.
  return {
    type: 'SET_MARKUP',
    content: markup,
    fromIndex: null,
    fromNode: null,
    toIndex: null,
    afterNode: null
  };
}

/**
 * Make an update for setting the text content.
 *
 * @param {string} textContent Text content to set.
 * @private
 */
function makeTextContent(textContent) {
  // NOTE: Null values reduce hidden classes.
  return {
    type: 'TEXT_CONTENT',
    content: textContent,
    fromIndex: null,
    fromNode: null,
    toIndex: null,
    afterNode: null
  };
}

/**
 * Push an update, if any, onto the queue. Creates a new queue if none is
 * passed and always returns the queue. Mutative.
 */
function enqueue(queue, update) {
  if (update) {
    queue = queue || [];
    queue.push(update);
  }
  return queue;
}

/**
 * Processes any enqueued updates.
 *
 * @private
 */
function processQueue(inst, updateQueue) {
  ReactComponentEnvironment_1.processChildrenUpdates(inst, updateQueue);
}

var setChildrenForInstrumentation = emptyFunction_1;
{
  var getDebugID = function (inst) {
    if (!inst._debugID) {
      // Check for ART-like instances. TODO: This is silly/gross.
      var internal;
      if (internal = ReactInstanceMap_1.get(inst)) {
        inst = internal;
      }
    }
    return inst._debugID;
  };
  setChildrenForInstrumentation = function (children) {
    var debugID = getDebugID(this);
    // TODO: React Native empty components are also multichild.
    // This means they still get into this method but don't have _debugID.
    if (debugID !== 0) {
      ReactInstrumentation$1.debugTool.onSetChildren(debugID, children ? Object.keys(children).map(function (key) {
        return children[key]._debugID;
      }) : []);
    }
  };
}

/**
 * ReactMultiChild are capable of reconciling multiple children.
 *
 * @class ReactMultiChild
 * @internal
 */
var ReactMultiChild = {

  /**
   * Provides common functionality for components that must reconcile multiple
   * children. This is used by `ReactDOMComponent` to mount, update, and
   * unmount child components.
   *
   * @lends {ReactMultiChild.prototype}
   */
  Mixin: {

    _reconcilerInstantiateChildren: function (nestedChildren, transaction, context) {
      {
        var selfDebugID = getDebugID(this);
        if (this._currentElement) {
          try {
            ReactCurrentOwner_1.current = this._currentElement._owner;
            return ReactChildReconciler_1.instantiateChildren(nestedChildren, transaction, context, selfDebugID);
          } finally {
            ReactCurrentOwner_1.current = null;
          }
        }
      }
      return ReactChildReconciler_1.instantiateChildren(nestedChildren, transaction, context);
    },

    _reconcilerUpdateChildren: function (prevChildren, nextNestedChildrenElements, mountImages, removedNodes, transaction, context) {
      var nextChildren;
      var selfDebugID = 0;
      {
        selfDebugID = getDebugID(this);
        if (this._currentElement) {
          try {
            ReactCurrentOwner_1.current = this._currentElement._owner;
            nextChildren = flattenChildren_1(nextNestedChildrenElements, selfDebugID);
          } finally {
            ReactCurrentOwner_1.current = null;
          }
          ReactChildReconciler_1.updateChildren(prevChildren, nextChildren, mountImages, removedNodes, transaction, this, this._hostContainerInfo, context, selfDebugID);
          return nextChildren;
        }
      }
      nextChildren = flattenChildren_1(nextNestedChildrenElements, selfDebugID);
      ReactChildReconciler_1.updateChildren(prevChildren, nextChildren, mountImages, removedNodes, transaction, this, this._hostContainerInfo, context, selfDebugID);
      return nextChildren;
    },

    /**
     * Generates a "mount image" for each of the supplied children. In the case
     * of `ReactDOMComponent`, a mount image is a string of markup.
     *
     * @param {?object} nestedChildren Nested child maps.
     * @return {array} An array of mounted representations.
     * @internal
     */
    mountChildren: function (nestedChildren, transaction, context) {
      var children = this._reconcilerInstantiateChildren(nestedChildren, transaction, context);
      this._renderedChildren = children;

      var mountImages = [];
      var index = 0;
      for (var name in children) {
        if (children.hasOwnProperty(name)) {
          var child = children[name];
          var selfDebugID = 0;
          {
            selfDebugID = getDebugID(this);
          }
          var mountImage = ReactReconciler_1.mountComponent(child, transaction, this, this._hostContainerInfo, context, selfDebugID);
          child._mountIndex = index++;
          mountImages.push(mountImage);
        }
      }

      {
        setChildrenForInstrumentation.call(this, children);
      }

      return mountImages;
    },

    /**
     * Replaces any rendered children with a text content string.
     *
     * @param {string} nextContent String of content.
     * @internal
     */
    updateTextContent: function (nextContent) {
      var prevChildren = this._renderedChildren;
      // Remove any rendered children.
      ReactChildReconciler_1.unmountChildren(prevChildren, false);
      for (var name in prevChildren) {
        if (prevChildren.hasOwnProperty(name)) {
          invariant_1(false, 'updateTextContent called on non-empty component.');
        }
      }
      // Set new text content.
      var updates = [makeTextContent(nextContent)];
      processQueue(this, updates);
    },

    /**
     * Replaces any rendered children with a markup string.
     *
     * @param {string} nextMarkup String of markup.
     * @internal
     */
    updateMarkup: function (nextMarkup) {
      var prevChildren = this._renderedChildren;
      // Remove any rendered children.
      ReactChildReconciler_1.unmountChildren(prevChildren, false);
      for (var name in prevChildren) {
        if (prevChildren.hasOwnProperty(name)) {
          invariant_1(false, 'updateTextContent called on non-empty component.');
        }
      }
      var updates = [makeSetMarkup(nextMarkup)];
      processQueue(this, updates);
    },

    /**
     * Updates the rendered children with new children.
     *
     * @param {?object} nextNestedChildrenElements Nested child element maps.
     * @param {ReactReconcileTransaction} transaction
     * @internal
     */
    updateChildren: function (nextNestedChildrenElements, transaction, context) {
      // Hook used by React ART
      this._updateChildren(nextNestedChildrenElements, transaction, context);
    },

    /**
     * @param {?object} nextNestedChildrenElements Nested child element maps.
     * @param {ReactReconcileTransaction} transaction
     * @final
     * @protected
     */
    _updateChildren: function (nextNestedChildrenElements, transaction, context) {
      var prevChildren = this._renderedChildren;
      var removedNodes = {};
      var mountImages = [];
      var nextChildren = this._reconcilerUpdateChildren(prevChildren, nextNestedChildrenElements, mountImages, removedNodes, transaction, context);
      if (!nextChildren && !prevChildren) {
        return;
      }
      var updates = null;
      var name;
      // `nextIndex` will increment for each child in `nextChildren`, but
      // `lastIndex` will be the last index visited in `prevChildren`.
      var nextIndex = 0;
      var lastIndex = 0;
      // `nextMountIndex` will increment for each newly mounted child.
      var nextMountIndex = 0;
      var lastPlacedNode = null;
      for (name in nextChildren) {
        if (!nextChildren.hasOwnProperty(name)) {
          continue;
        }
        var prevChild = prevChildren && prevChildren[name];
        var nextChild = nextChildren[name];
        if (prevChild === nextChild) {
          updates = enqueue(updates, this.moveChild(prevChild, lastPlacedNode, nextIndex, lastIndex));
          lastIndex = Math.max(prevChild._mountIndex, lastIndex);
          prevChild._mountIndex = nextIndex;
        } else {
          if (prevChild) {
            // Update `lastIndex` before `_mountIndex` gets unset by unmounting.
            lastIndex = Math.max(prevChild._mountIndex, lastIndex);
            // The `removedNodes` loop below will actually remove the child.
          }
          // The child must be instantiated before it's mounted.
          updates = enqueue(updates, this._mountChildAtIndex(nextChild, mountImages[nextMountIndex], lastPlacedNode, nextIndex, transaction, context));
          nextMountIndex++;
        }
        nextIndex++;
        lastPlacedNode = ReactReconciler_1.getHostNode(nextChild);
      }
      // Remove children that are no longer present.
      for (name in removedNodes) {
        if (removedNodes.hasOwnProperty(name)) {
          updates = enqueue(updates, this._unmountChild(prevChildren[name], removedNodes[name]));
        }
      }
      if (updates) {
        processQueue(this, updates);
      }
      this._renderedChildren = nextChildren;

      {
        setChildrenForInstrumentation.call(this, nextChildren);
      }
    },

    /**
     * Unmounts all rendered children. This should be used to clean up children
     * when this component is unmounted. It does not actually perform any
     * backend operations.
     *
     * @internal
     */
    unmountChildren: function (safely) {
      var renderedChildren = this._renderedChildren;
      ReactChildReconciler_1.unmountChildren(renderedChildren, safely);
      this._renderedChildren = null;
    },

    /**
     * Moves a child component to the supplied index.
     *
     * @param {ReactComponent} child Component to move.
     * @param {number} toIndex Destination index of the element.
     * @param {number} lastIndex Last index visited of the siblings of `child`.
     * @protected
     */
    moveChild: function (child, afterNode, toIndex, lastIndex) {
      // If the index of `child` is less than `lastIndex`, then it needs to
      // be moved. Otherwise, we do not need to move it because a child will be
      // inserted or moved before `child`.
      if (child._mountIndex < lastIndex) {
        return makeMove(child, afterNode, toIndex);
      }
    },

    /**
     * Creates a child component.
     *
     * @param {ReactComponent} child Component to create.
     * @param {string} mountImage Markup to insert.
     * @protected
     */
    createChild: function (child, afterNode, mountImage) {
      return makeInsertMarkup(mountImage, afterNode, child._mountIndex);
    },

    /**
     * Removes a child component.
     *
     * @param {ReactComponent} child Child to remove.
     * @protected
     */
    removeChild: function (child, node) {
      return makeRemove(child, node);
    },

    /**
     * Mounts a child with the supplied name.
     *
     * NOTE: This is part of `updateChildren` and is here for readability.
     *
     * @param {ReactComponent} child Component to mount.
     * @param {string} name Name of the child.
     * @param {number} index Index at which to insert the child.
     * @param {ReactReconcileTransaction} transaction
     * @private
     */
    _mountChildAtIndex: function (child, mountImage, afterNode, index, transaction, context) {
      child._mountIndex = index;
      return this.createChild(child, afterNode, mountImage);
    },

    /**
     * Unmounts a rendered child.
     *
     * NOTE: This is part of `updateChildren` and is here for readability.
     *
     * @param {ReactComponent} child Component to unmount.
     * @private
     */
    _unmountChild: function (child, node) {
      var update = this.removeChild(child, node);
      child._mountIndex = null;
      return update;
    }

  }

};

var ReactMultiChild_1 = ReactMultiChild;

function enqueueUpdate$1(internalInstance) {
  ReactUpdates_1.enqueueUpdate(internalInstance);
}

function formatUnexpectedArgument(arg) {
  var type = typeof arg;
  if (type !== 'object') {
    return type;
  }
  var displayName = arg.constructor && arg.constructor.name || type;
  var keys = Object.keys(arg);
  if (keys.length > 0 && keys.length < 20) {
    return displayName + ' (keys: ' + keys.join(', ') + ')';
  }
  return displayName;
}

function getInternalInstanceReadyForUpdate(publicInstance, callerName) {
  var internalInstance = ReactInstanceMap_1.get(publicInstance);
  if (!internalInstance) {
    {
      var ctor = publicInstance.constructor;
      // Only warn when we have a callerName. Otherwise we should be silent.
      // We're probably calling from enqueueCallback. We don't want to warn
      // there because we already warned for the corresponding lifecycle method.
      warning_1(!callerName, '%s(...): Can only update a mounted or mounting component. ' + 'This usually means you called %s() on an unmounted component. ' + 'This is a no-op. Please check the code for the %s component.', callerName, callerName, ctor && (ctor.displayName || ctor.name) || 'ReactClass');
    }
    return null;
  }

  {
    warning_1(ReactCurrentOwner_1.current == null, '%s(...): Cannot update during an existing state transition (such as ' + 'within `render` or another component\'s constructor). Render methods ' + 'should be a pure function of props and state; constructor ' + 'side-effects are an anti-pattern, but can be moved to ' + '`componentWillMount`.', callerName);
  }

  return internalInstance;
}

/**
 * ReactUpdateQueue allows for state updates to be scheduled into a later
 * reconciliation step.
 */
var ReactUpdateQueue = {

  /**
   * Checks whether or not this composite component is mounted.
   * @param {ReactClass} publicInstance The instance we want to test.
   * @return {boolean} True if mounted, false otherwise.
   * @protected
   * @final
   */
  isMounted: function (publicInstance) {
    {
      var owner = ReactCurrentOwner_1.current;
      if (owner !== null) {
        warning_1(owner._warnedAboutRefsInRender, '%s is accessing isMounted inside its render() function. ' + 'render() should be a pure function of props and state. It should ' + 'never access something that requires stale data from the previous ' + 'render, such as refs. Move this logic to componentDidMount and ' + 'componentDidUpdate instead.', owner.getName() || 'A component');
        owner._warnedAboutRefsInRender = true;
      }
    }
    var internalInstance = ReactInstanceMap_1.get(publicInstance);
    if (internalInstance) {
      // During componentWillMount and render this will still be null but after
      // that will always render to something. At least for now. So we can use
      // this hack.
      return !!internalInstance._renderedComponent;
    } else {
      return false;
    }
  },

  /**
   * Enqueue a callback that will be executed after all the pending updates
   * have processed.
   *
   * @param {ReactClass} publicInstance The instance to use as `this` context.
   * @param {?function} callback Called after state is updated.
   * @param {string} callerName Name of the calling function in the public API.
   * @internal
   */
  enqueueCallback: function (publicInstance, callback, callerName) {
    ReactUpdateQueue.validateCallback(callback, callerName);
    var internalInstance = getInternalInstanceReadyForUpdate(publicInstance);

    // Previously we would throw an error if we didn't have an internal
    // instance. Since we want to make it a no-op instead, we mirror the same
    // behavior we have in other enqueue* methods.
    // We also need to ignore callbacks in componentWillMount. See
    // enqueueUpdates.
    if (!internalInstance) {
      return null;
    }

    if (internalInstance._pendingCallbacks) {
      internalInstance._pendingCallbacks.push(callback);
    } else {
      internalInstance._pendingCallbacks = [callback];
    }
    // TODO: The callback here is ignored when setState is called from
    // componentWillMount. Either fix it or disallow doing so completely in
    // favor of getInitialState. Alternatively, we can disallow
    // componentWillMount during server-side rendering.
    enqueueUpdate$1(internalInstance);
  },

  enqueueCallbackInternal: function (internalInstance, callback) {
    if (internalInstance._pendingCallbacks) {
      internalInstance._pendingCallbacks.push(callback);
    } else {
      internalInstance._pendingCallbacks = [callback];
    }
    enqueueUpdate$1(internalInstance);
  },

  /**
   * Forces an update. This should only be invoked when it is known with
   * certainty that we are **not** in a DOM transaction.
   *
   * You may want to call this when you know that some deeper aspect of the
   * component's state has changed but `setState` was not called.
   *
   * This will not invoke `shouldComponentUpdate`, but it will invoke
   * `componentWillUpdate` and `componentDidUpdate`.
   *
   * @param {ReactClass} publicInstance The instance that should rerender.
   * @internal
   */
  enqueueForceUpdate: function (publicInstance) {
    var internalInstance = getInternalInstanceReadyForUpdate(publicInstance, 'forceUpdate');

    if (!internalInstance) {
      return;
    }

    internalInstance._pendingForceUpdate = true;

    enqueueUpdate$1(internalInstance);
  },

  /**
   * Replaces all of the state. Always use this or `setState` to mutate state.
   * You should treat `this.state` as immutable.
   *
   * There is no guarantee that `this.state` will be immediately updated, so
   * accessing `this.state` after calling this method may return the old value.
   *
   * @param {ReactClass} publicInstance The instance that should rerender.
   * @param {object} completeState Next state.
   * @internal
   */
  enqueueReplaceState: function (publicInstance, completeState, callback) {
    var internalInstance = getInternalInstanceReadyForUpdate(publicInstance, 'replaceState');

    if (!internalInstance) {
      return;
    }

    internalInstance._pendingStateQueue = [completeState];
    internalInstance._pendingReplaceState = true;

    // Future-proof 15.5
    if (callback !== undefined && callback !== null) {
      ReactUpdateQueue.validateCallback(callback, 'replaceState');
      if (internalInstance._pendingCallbacks) {
        internalInstance._pendingCallbacks.push(callback);
      } else {
        internalInstance._pendingCallbacks = [callback];
      }
    }

    enqueueUpdate$1(internalInstance);
  },

  /**
   * Sets a subset of the state. This only exists because _pendingState is
   * internal. This provides a merging strategy that is not available to deep
   * properties which is confusing. TODO: Expose pendingState or don't use it
   * during the merge.
   *
   * @param {ReactClass} publicInstance The instance that should rerender.
   * @param {object} partialState Next partial state to be merged with state.
   * @internal
   */
  enqueueSetState: function (publicInstance, partialState) {
    {
      ReactInstrumentation$1.debugTool.onSetState();
      warning_1(partialState != null, 'setState(...): You passed an undefined or null state object; ' + 'instead, use forceUpdate().');
    }

    var internalInstance = getInternalInstanceReadyForUpdate(publicInstance, 'setState');

    if (!internalInstance) {
      return;
    }

    var queue = internalInstance._pendingStateQueue || (internalInstance._pendingStateQueue = []);
    queue.push(partialState);

    enqueueUpdate$1(internalInstance);
  },

  enqueueElementInternal: function (internalInstance, nextElement, nextContext) {
    internalInstance._pendingElement = nextElement;
    // TODO: introduce _pendingContext instead of setting it directly.
    internalInstance._context = nextContext;
    enqueueUpdate$1(internalInstance);
  },

  validateCallback: function (callback, callerName) {
    !(!callback || typeof callback === 'function') ? invariant_1(false, '%s(...): Expected the last optional `callback` argument to be a function. Instead received: %s.', callerName, formatUnexpectedArgument(callback)) : void 0;
  }

};

var ReactUpdateQueue_1 = ReactUpdateQueue;

function _classCallCheck$1(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError("Cannot call a class as a function"); } }





function warnNoop$1(publicInstance, callerName) {
  {
    var constructor = publicInstance.constructor;
    warning_1(false, '%s(...): Can only update a mounting component. ' + 'This usually means you called %s() outside componentWillMount() on the server. ' + 'This is a no-op. Please check the code for the %s component.', callerName, callerName, constructor && (constructor.displayName || constructor.name) || 'ReactClass');
  }
}

/**
 * This is the update queue used for server rendering.
 * It delegates to ReactUpdateQueue while server rendering is in progress and
 * switches to ReactNoopUpdateQueue after the transaction has completed.
 * @class ReactServerUpdateQueue
 * @param {Transaction} transaction
 */

var ReactServerUpdateQueue = function () {
  function ReactServerUpdateQueue(transaction) {
    _classCallCheck$1(this, ReactServerUpdateQueue);

    this.transaction = transaction;
  }

  /**
   * Checks whether or not this composite component is mounted.
   * @param {ReactClass} publicInstance The instance we want to test.
   * @return {boolean} True if mounted, false otherwise.
   * @protected
   * @final
   */


  ReactServerUpdateQueue.prototype.isMounted = function isMounted(publicInstance) {
    return false;
  };

  /**
   * Enqueue a callback that will be executed after all the pending updates
   * have processed.
   *
   * @param {ReactClass} publicInstance The instance to use as `this` context.
   * @param {?function} callback Called after state is updated.
   * @internal
   */


  ReactServerUpdateQueue.prototype.enqueueCallback = function enqueueCallback(publicInstance, callback, callerName) {
    if (this.transaction.isInTransaction()) {
      ReactUpdateQueue_1.enqueueCallback(publicInstance, callback, callerName);
    }
  };

  /**
   * Forces an update. This should only be invoked when it is known with
   * certainty that we are **not** in a DOM transaction.
   *
   * You may want to call this when you know that some deeper aspect of the
   * component's state has changed but `setState` was not called.
   *
   * This will not invoke `shouldComponentUpdate`, but it will invoke
   * `componentWillUpdate` and `componentDidUpdate`.
   *
   * @param {ReactClass} publicInstance The instance that should rerender.
   * @internal
   */


  ReactServerUpdateQueue.prototype.enqueueForceUpdate = function enqueueForceUpdate(publicInstance) {
    if (this.transaction.isInTransaction()) {
      ReactUpdateQueue_1.enqueueForceUpdate(publicInstance);
    } else {
      warnNoop$1(publicInstance, 'forceUpdate');
    }
  };

  /**
   * Replaces all of the state. Always use this or `setState` to mutate state.
   * You should treat `this.state` as immutable.
   *
   * There is no guarantee that `this.state` will be immediately updated, so
   * accessing `this.state` after calling this method may return the old value.
   *
   * @param {ReactClass} publicInstance The instance that should rerender.
   * @param {object|function} completeState Next state.
   * @internal
   */


  ReactServerUpdateQueue.prototype.enqueueReplaceState = function enqueueReplaceState(publicInstance, completeState) {
    if (this.transaction.isInTransaction()) {
      ReactUpdateQueue_1.enqueueReplaceState(publicInstance, completeState);
    } else {
      warnNoop$1(publicInstance, 'replaceState');
    }
  };

  /**
   * Sets a subset of the state. This only exists because _pendingState is
   * internal. This provides a merging strategy that is not available to deep
   * properties which is confusing. TODO: Expose pendingState or don't use it
   * during the merge.
   *
   * @param {ReactClass} publicInstance The instance that should rerender.
   * @param {object|function} partialState Next partial state to be merged with state.
   * @internal
   */


  ReactServerUpdateQueue.prototype.enqueueSetState = function enqueueSetState(publicInstance, partialState) {
    if (this.transaction.isInTransaction()) {
      ReactUpdateQueue_1.enqueueSetState(publicInstance, partialState);
    } else {
      warnNoop$1(publicInstance, 'setState');
    }
  };

  return ReactServerUpdateQueue;
}();

var ReactServerUpdateQueue_1 = ReactServerUpdateQueue;

var TRANSACTION_WRAPPERS$1 = [];

{
  TRANSACTION_WRAPPERS$1.push({
    initialize: ReactInstrumentation$1.debugTool.onBeginFlush,
    close: ReactInstrumentation$1.debugTool.onEndFlush
  });
}

var noopCallbackQueue = {
  enqueue: function () {}
};

/**
 * @class ReactServerRenderingTransaction
 * @param {boolean} renderToStaticMarkup
 */
function ReactServerRenderingTransaction(renderToStaticMarkup) {
  this.reinitializeTransaction();
  this.renderToStaticMarkup = renderToStaticMarkup;
  this.useCreateElement = false;
  this.updateQueue = new ReactServerUpdateQueue_1(this);
}

var Mixin = {
  /**
   * @see Transaction
   * @abstract
   * @final
   * @return {array} Empty list of operation wrap procedures.
   */
  getTransactionWrappers: function () {
    return TRANSACTION_WRAPPERS$1;
  },

  /**
   * @return {object} The queue to collect `onDOMReady` callbacks with.
   */
  getReactMountReady: function () {
    return noopCallbackQueue;
  },

  /**
   * @return {object} The queue to collect React async events.
   */
  getUpdateQueue: function () {
    return this.updateQueue;
  },

  /**
   * `PooledClass` looks for this, and will invoke this before allowing this
   * instance to be reused.
   */
  destructor: function () {},

  checkpoint: function () {},

  rollback: function () {}
};

index(ReactServerRenderingTransaction.prototype, Transaction, Mixin);

PooledClass_1$2.addPoolingTo(ReactServerRenderingTransaction);

var ReactServerRenderingTransaction_1 = ReactServerRenderingTransaction;

var validateDOMNesting = emptyFunction_1;

{
  // This validation code was written based on the HTML5 parsing spec:
  // https://html.spec.whatwg.org/multipage/syntax.html#has-an-element-in-scope
  //
  // Note: this does not catch all invalid nesting, nor does it try to (as it's
  // not clear what practical benefit doing so provides); instead, we warn only
  // for cases where the parser will give a parse tree differing from what React
  // intended. For example, <b><div></div></b> is invalid but we don't warn
  // because it still parses correctly; we do warn for other cases like nested
  // <p> tags where the beginning of the second element implicitly closes the
  // first, causing a confusing mess.

  // https://html.spec.whatwg.org/multipage/syntax.html#special
  var specialTags = ['address', 'applet', 'area', 'article', 'aside', 'base', 'basefont', 'bgsound', 'blockquote', 'body', 'br', 'button', 'caption', 'center', 'col', 'colgroup', 'dd', 'details', 'dir', 'div', 'dl', 'dt', 'embed', 'fieldset', 'figcaption', 'figure', 'footer', 'form', 'frame', 'frameset', 'h1', 'h2', 'h3', 'h4', 'h5', 'h6', 'head', 'header', 'hgroup', 'hr', 'html', 'iframe', 'img', 'input', 'isindex', 'li', 'link', 'listing', 'main', 'marquee', 'menu', 'menuitem', 'meta', 'nav', 'noembed', 'noframes', 'noscript', 'object', 'ol', 'p', 'param', 'plaintext', 'pre', 'script', 'section', 'select', 'source', 'style', 'summary', 'table', 'tbody', 'td', 'template', 'textarea', 'tfoot', 'th', 'thead', 'title', 'tr', 'track', 'ul', 'wbr', 'xmp'];

  // https://html.spec.whatwg.org/multipage/syntax.html#has-an-element-in-scope
  var inScopeTags = ['applet', 'caption', 'html', 'table', 'td', 'th', 'marquee', 'object', 'template',

  // https://html.spec.whatwg.org/multipage/syntax.html#html-integration-point
  // TODO: Distinguish by namespace here -- for <title>, including it here
  // errs on the side of fewer warnings
  'foreignObject', 'desc', 'title'];

  // https://html.spec.whatwg.org/multipage/syntax.html#has-an-element-in-button-scope
  var buttonScopeTags = inScopeTags.concat(['button']);

  // https://html.spec.whatwg.org/multipage/syntax.html#generate-implied-end-tags
  var impliedEndTags = ['dd', 'dt', 'li', 'option', 'optgroup', 'p', 'rp', 'rt'];

  var emptyAncestorInfo = {
    current: null,

    formTag: null,
    aTagInScope: null,
    buttonTagInScope: null,
    nobrTagInScope: null,
    pTagInButtonScope: null,

    listItemTagAutoclosing: null,
    dlItemTagAutoclosing: null
  };

  var updatedAncestorInfo = function (oldInfo, tag, instance) {
    var ancestorInfo = index({}, oldInfo || emptyAncestorInfo);
    var info = { tag: tag, instance: instance };

    if (inScopeTags.indexOf(tag) !== -1) {
      ancestorInfo.aTagInScope = null;
      ancestorInfo.buttonTagInScope = null;
      ancestorInfo.nobrTagInScope = null;
    }
    if (buttonScopeTags.indexOf(tag) !== -1) {
      ancestorInfo.pTagInButtonScope = null;
    }

    // See rules for 'li', 'dd', 'dt' start tags in
    // https://html.spec.whatwg.org/multipage/syntax.html#parsing-main-inbody
    if (specialTags.indexOf(tag) !== -1 && tag !== 'address' && tag !== 'div' && tag !== 'p') {
      ancestorInfo.listItemTagAutoclosing = null;
      ancestorInfo.dlItemTagAutoclosing = null;
    }

    ancestorInfo.current = info;

    if (tag === 'form') {
      ancestorInfo.formTag = info;
    }
    if (tag === 'a') {
      ancestorInfo.aTagInScope = info;
    }
    if (tag === 'button') {
      ancestorInfo.buttonTagInScope = info;
    }
    if (tag === 'nobr') {
      ancestorInfo.nobrTagInScope = info;
    }
    if (tag === 'p') {
      ancestorInfo.pTagInButtonScope = info;
    }
    if (tag === 'li') {
      ancestorInfo.listItemTagAutoclosing = info;
    }
    if (tag === 'dd' || tag === 'dt') {
      ancestorInfo.dlItemTagAutoclosing = info;
    }

    return ancestorInfo;
  };

  /**
   * Returns whether
   */
  var isTagValidWithParent = function (tag, parentTag) {
    // First, let's check if we're in an unusual parsing mode...
    switch (parentTag) {
      // https://html.spec.whatwg.org/multipage/syntax.html#parsing-main-inselect
      case 'select':
        return tag === 'option' || tag === 'optgroup' || tag === '#text';
      case 'optgroup':
        return tag === 'option' || tag === '#text';
      // Strictly speaking, seeing an <option> doesn't mean we're in a <select>
      // but
      case 'option':
        return tag === '#text';

      // https://html.spec.whatwg.org/multipage/syntax.html#parsing-main-intd
      // https://html.spec.whatwg.org/multipage/syntax.html#parsing-main-incaption
      // No special behavior since these rules fall back to "in body" mode for
      // all except special table nodes which cause bad parsing behavior anyway.

      // https://html.spec.whatwg.org/multipage/syntax.html#parsing-main-intr
      case 'tr':
        return tag === 'th' || tag === 'td' || tag === 'style' || tag === 'script' || tag === 'template';

      // https://html.spec.whatwg.org/multipage/syntax.html#parsing-main-intbody
      case 'tbody':
      case 'thead':
      case 'tfoot':
        return tag === 'tr' || tag === 'style' || tag === 'script' || tag === 'template';

      // https://html.spec.whatwg.org/multipage/syntax.html#parsing-main-incolgroup
      case 'colgroup':
        return tag === 'col' || tag === 'template';

      // https://html.spec.whatwg.org/multipage/syntax.html#parsing-main-intable
      case 'table':
        return tag === 'caption' || tag === 'colgroup' || tag === 'tbody' || tag === 'tfoot' || tag === 'thead' || tag === 'style' || tag === 'script' || tag === 'template';

      // https://html.spec.whatwg.org/multipage/syntax.html#parsing-main-inhead
      case 'head':
        return tag === 'base' || tag === 'basefont' || tag === 'bgsound' || tag === 'link' || tag === 'meta' || tag === 'title' || tag === 'noscript' || tag === 'noframes' || tag === 'style' || tag === 'script' || tag === 'template';

      // https://html.spec.whatwg.org/multipage/semantics.html#the-html-element
      case 'html':
        return tag === 'head' || tag === 'body';
      case '#document':
        return tag === 'html';
    }

    // Probably in the "in body" parsing mode, so we outlaw only tag combos
    // where the parsing rules cause implicit opens or closes to be added.
    // https://html.spec.whatwg.org/multipage/syntax.html#parsing-main-inbody
    switch (tag) {
      case 'h1':
      case 'h2':
      case 'h3':
      case 'h4':
      case 'h5':
      case 'h6':
        return parentTag !== 'h1' && parentTag !== 'h2' && parentTag !== 'h3' && parentTag !== 'h4' && parentTag !== 'h5' && parentTag !== 'h6';

      case 'rp':
      case 'rt':
        return impliedEndTags.indexOf(parentTag) === -1;

      case 'body':
      case 'caption':
      case 'col':
      case 'colgroup':
      case 'frame':
      case 'head':
      case 'html':
      case 'tbody':
      case 'td':
      case 'tfoot':
      case 'th':
      case 'thead':
      case 'tr':
        // These tags are only valid with a few parents that have special child
        // parsing rules -- if we're down here, then none of those matched and
        // so we allow it only if we don't know what the parent is, as all other
        // cases are invalid.
        return parentTag == null;
    }

    return true;
  };

  /**
   * Returns whether
   */
  var findInvalidAncestorForTag = function (tag, ancestorInfo) {
    switch (tag) {
      case 'address':
      case 'article':
      case 'aside':
      case 'blockquote':
      case 'center':
      case 'details':
      case 'dialog':
      case 'dir':
      case 'div':
      case 'dl':
      case 'fieldset':
      case 'figcaption':
      case 'figure':
      case 'footer':
      case 'header':
      case 'hgroup':
      case 'main':
      case 'menu':
      case 'nav':
      case 'ol':
      case 'p':
      case 'section':
      case 'summary':
      case 'ul':
      case 'pre':
      case 'listing':
      case 'table':
      case 'hr':
      case 'xmp':
      case 'h1':
      case 'h2':
      case 'h3':
      case 'h4':
      case 'h5':
      case 'h6':
        return ancestorInfo.pTagInButtonScope;

      case 'form':
        return ancestorInfo.formTag || ancestorInfo.pTagInButtonScope;

      case 'li':
        return ancestorInfo.listItemTagAutoclosing;

      case 'dd':
      case 'dt':
        return ancestorInfo.dlItemTagAutoclosing;

      case 'button':
        return ancestorInfo.buttonTagInScope;

      case 'a':
        // Spec says something about storing a list of markers, but it sounds
        // equivalent to this check.
        return ancestorInfo.aTagInScope;

      case 'nobr':
        return ancestorInfo.nobrTagInScope;
    }

    return null;
  };

  /**
   * Given a ReactCompositeComponent instance, return a list of its recursive
   * owners, starting at the root and ending with the instance itself.
   */
  var findOwnerStack = function (instance) {
    if (!instance) {
      return [];
    }

    var stack = [];
    do {
      stack.push(instance);
    } while (instance = instance._currentElement._owner);
    stack.reverse();
    return stack;
  };

  var didWarn = {};

  validateDOMNesting = function (childTag, childText, childInstance, ancestorInfo) {
    ancestorInfo = ancestorInfo || emptyAncestorInfo;
    var parentInfo = ancestorInfo.current;
    var parentTag = parentInfo && parentInfo.tag;

    if (childText != null) {
      warning_1(childTag == null, 'validateDOMNesting: when childText is passed, childTag should be null');
      childTag = '#text';
    }

    var invalidParent = isTagValidWithParent(childTag, parentTag) ? null : parentInfo;
    var invalidAncestor = invalidParent ? null : findInvalidAncestorForTag(childTag, ancestorInfo);
    var problematic = invalidParent || invalidAncestor;

    if (problematic) {
      var ancestorTag = problematic.tag;
      var ancestorInstance = problematic.instance;

      var childOwner = childInstance && childInstance._currentElement._owner;
      var ancestorOwner = ancestorInstance && ancestorInstance._currentElement._owner;

      var childOwners = findOwnerStack(childOwner);
      var ancestorOwners = findOwnerStack(ancestorOwner);

      var minStackLen = Math.min(childOwners.length, ancestorOwners.length);
      var i;

      var deepestCommon = -1;
      for (i = 0; i < minStackLen; i++) {
        if (childOwners[i] === ancestorOwners[i]) {
          deepestCommon = i;
        } else {
          break;
        }
      }

      var UNKNOWN = '(unknown)';
      var childOwnerNames = childOwners.slice(deepestCommon + 1).map(function (inst) {
        return inst.getName() || UNKNOWN;
      });
      var ancestorOwnerNames = ancestorOwners.slice(deepestCommon + 1).map(function (inst) {
        return inst.getName() || UNKNOWN;
      });
      var ownerInfo = [].concat(
      // If the parent and child instances have a common owner ancestor, start
      // with that -- otherwise we just start with the parent's owners.
      deepestCommon !== -1 ? childOwners[deepestCommon].getName() || UNKNOWN : [], ancestorOwnerNames, ancestorTag,
      // If we're warning about an invalid (non-parent) ancestry, add '...'
      invalidAncestor ? ['...'] : [], childOwnerNames, childTag).join(' > ');

      var warnKey = !!invalidParent + '|' + childTag + '|' + ancestorTag + '|' + ownerInfo;
      if (didWarn[warnKey]) {
        return;
      }
      didWarn[warnKey] = true;

      var tagDisplayName = childTag;
      var whitespaceInfo = '';
      if (childTag === '#text') {
        if (/\S/.test(childText)) {
          tagDisplayName = 'Text nodes';
        } else {
          tagDisplayName = 'Whitespace text nodes';
          whitespaceInfo = ' Make sure you don\'t have any extra whitespace between tags on ' + 'each line of your source code.';
        }
      } else {
        tagDisplayName = '<' + childTag + '>';
      }

      if (invalidParent) {
        var info = '';
        if (ancestorTag === 'table' && childTag === 'tr') {
          info += ' Add a <tbody> to your code to match the DOM tree generated by ' + 'the browser.';
        }
        warning_1(false, 'validateDOMNesting(...): %s cannot appear as a child of <%s>.%s ' + 'See %s.%s', tagDisplayName, ancestorTag, whitespaceInfo, ownerInfo, info);
      } else {
        warning_1(false, 'validateDOMNesting(...): %s cannot appear as a descendant of ' + '<%s>. See %s.', tagDisplayName, ancestorTag, ownerInfo);
      }
    }
  };

  validateDOMNesting.updatedAncestorInfo = updatedAncestorInfo;

  // For testing
  validateDOMNesting.isTagValidInContext = function (tag, ancestorInfo) {
    ancestorInfo = ancestorInfo || emptyAncestorInfo;
    var parentInfo = ancestorInfo.current;
    var parentTag = parentInfo && parentInfo.tag;
    return isTagValidWithParent(tag, parentTag) && !findInvalidAncestorForTag(tag, ancestorInfo);
  };
}

var validateDOMNesting_1 = validateDOMNesting;

var Flags$1 = ReactDOMComponentFlags_1;
var deleteListener = EventPluginHub_1.deleteListener;
var getNode = ReactDOMComponentTree_1.getNodeFromInstance;
var listenTo = ReactBrowserEventEmitter_1.listenTo;
var registrationNameModules = EventPluginRegistry_1.registrationNameModules;

// For quickly matching children type, to test if can be treated as content.
var CONTENT_TYPES = { 'string': true, 'number': true };

var STYLE = 'style';
var HTML = '__html';
var RESERVED_PROPS$1 = {
  children: null,
  dangerouslySetInnerHTML: null,
  suppressContentEditableWarning: null
};

// Node type for document fragments (Node.DOCUMENT_FRAGMENT_NODE).
var DOC_FRAGMENT_TYPE = 11;

function getDeclarationErrorAddendum$1(internalInstance) {
  if (internalInstance) {
    var owner = internalInstance._currentElement._owner || null;
    if (owner) {
      var name = owner.getName();
      if (name) {
        return ' This DOM node was rendered by `' + name + '`.';
      }
    }
  }
  return '';
}

function friendlyStringify(obj) {
  if (typeof obj === 'object') {
    if (Array.isArray(obj)) {
      return '[' + obj.map(friendlyStringify).join(', ') + ']';
    } else {
      var pairs = [];
      for (var key in obj) {
        if (Object.prototype.hasOwnProperty.call(obj, key)) {
          var keyEscaped = /^[a-z$_][\w$_]*$/i.test(key) ? key : JSON.stringify(key);
          pairs.push(keyEscaped + ': ' + friendlyStringify(obj[key]));
        }
      }
      return '{' + pairs.join(', ') + '}';
    }
  } else if (typeof obj === 'string') {
    return JSON.stringify(obj);
  } else if (typeof obj === 'function') {
    return '[function object]';
  }
  // Differs from JSON.stringify in that undefined because undefined and that
  // inf and nan don't become null
  return String(obj);
}

var styleMutationWarning = {};

function checkAndWarnForMutatedStyle(style1, style2, component) {
  if (style1 == null || style2 == null) {
    return;
  }
  if (shallowEqual_1(style1, style2)) {
    return;
  }

  var componentName = component._tag;
  var owner = component._currentElement._owner;
  var ownerName;
  if (owner) {
    ownerName = owner.getName();
  }

  var hash = ownerName + '|' + componentName;

  if (styleMutationWarning.hasOwnProperty(hash)) {
    return;
  }

  styleMutationWarning[hash] = true;

  warning_1(false, '`%s` was passed a style object that has previously been mutated. ' + 'Mutating `style` is deprecated. Consider cloning it beforehand. Check ' + 'the `render` %s. Previous style: %s. Mutated style: %s.', componentName, owner ? 'of `' + ownerName + '`' : 'using <' + componentName + '>', friendlyStringify(style1), friendlyStringify(style2));
}

/**
 * @param {object} component
 * @param {?object} props
 */
function assertValidProps(component, props) {
  if (!props) {
    return;
  }
  // Note the use of `==` which checks for null or undefined.
  if (voidElementTags[component._tag]) {
    !(props.children == null && props.dangerouslySetInnerHTML == null) ? invariant_1(false, '%s is a void element tag and must neither have `children` nor use `dangerouslySetInnerHTML`.%s', component._tag, component._currentElement._owner ? ' Check the render method of ' + component._currentElement._owner.getName() + '.' : '') : void 0;
  }
  if (props.dangerouslySetInnerHTML != null) {
    !(props.children == null) ? invariant_1(false, 'Can only set one of `children` or `props.dangerouslySetInnerHTML`.') : void 0;
    !(typeof props.dangerouslySetInnerHTML === 'object' && HTML in props.dangerouslySetInnerHTML) ? invariant_1(false, '`props.dangerouslySetInnerHTML` must be in the form `{__html: ...}`. Please visit https://fb.me/react-invariant-dangerously-set-inner-html for more information.') : void 0;
  }
  {
    warning_1(props.innerHTML == null, 'Directly setting property `innerHTML` is not permitted. ' + 'For more information, lookup documentation on `dangerouslySetInnerHTML`.');
    warning_1(props.suppressContentEditableWarning || !props.contentEditable || props.children == null, 'A component is `contentEditable` and contains `children` managed by ' + 'React. It is now your responsibility to guarantee that none of ' + 'those nodes are unexpectedly modified or duplicated. This is ' + 'probably not intentional.');
    warning_1(props.onFocusIn == null && props.onFocusOut == null, 'React uses onFocus and onBlur instead of onFocusIn and onFocusOut. ' + 'All React events are normalized to bubble, so onFocusIn and onFocusOut ' + 'are not needed/supported by React.');
  }
  !(props.style == null || typeof props.style === 'object') ? invariant_1(false, 'The `style` prop expects a mapping from style properties to values, not a string. For example, style={{marginRight: spacing + \'em\'}} when using JSX.%s', getDeclarationErrorAddendum$1(component)) : void 0;
}

function enqueuePutListener(inst, registrationName, listener, transaction) {
  if (transaction instanceof ReactServerRenderingTransaction_1) {
    return;
  }
  {
    // IE8 has no API for event capturing and the `onScroll` event doesn't
    // bubble.
    warning_1(registrationName !== 'onScroll' || isEventSupported_1('scroll', true), 'This browser doesn\'t support the `onScroll` event');
  }
  var containerInfo = inst._hostContainerInfo;
  var isDocumentFragment = containerInfo._node && containerInfo._node.nodeType === DOC_FRAGMENT_TYPE;
  var doc = isDocumentFragment ? containerInfo._node : containerInfo._ownerDocument;
  listenTo(registrationName, doc);
  transaction.getReactMountReady().enqueue(putListener, {
    inst: inst,
    registrationName: registrationName,
    listener: listener
  });
}

function putListener() {
  var listenerToPut = this;
  EventPluginHub_1.putListener(listenerToPut.inst, listenerToPut.registrationName, listenerToPut.listener);
}

function inputPostMount() {
  var inst = this;
  ReactDOMInput_1.postMountWrapper(inst);
}

function textareaPostMount() {
  var inst = this;
  ReactDOMTextarea_1.postMountWrapper(inst);
}

function optionPostMount() {
  var inst = this;
  ReactDOMOption_1.postMountWrapper(inst);
}

var setAndValidateContentChildDev = emptyFunction_1;
{
  setAndValidateContentChildDev = function (content) {
    var hasExistingContent = this._contentDebugID != null;
    var debugID = this._debugID;
    // This ID represents the inlined child that has no backing instance:
    var contentDebugID = -debugID;

    if (content == null) {
      if (hasExistingContent) {
        ReactInstrumentation$1.debugTool.onUnmountComponent(this._contentDebugID);
      }
      this._contentDebugID = null;
      return;
    }

    validateDOMNesting_1(null, String(content), this, this._ancestorInfo);
    this._contentDebugID = contentDebugID;
    if (hasExistingContent) {
      ReactInstrumentation$1.debugTool.onBeforeUpdateComponent(contentDebugID, content);
      ReactInstrumentation$1.debugTool.onUpdateComponent(contentDebugID);
    } else {
      ReactInstrumentation$1.debugTool.onBeforeMountComponent(contentDebugID, content, debugID);
      ReactInstrumentation$1.debugTool.onMountComponent(contentDebugID);
      ReactInstrumentation$1.debugTool.onSetChildren(debugID, [contentDebugID]);
    }
  };
}

// There are so many media events, it makes sense to just
// maintain a list rather than create a `trapBubbledEvent` for each
var mediaEvents = {
  topAbort: 'abort',
  topCanPlay: 'canplay',
  topCanPlayThrough: 'canplaythrough',
  topDurationChange: 'durationchange',
  topEmptied: 'emptied',
  topEncrypted: 'encrypted',
  topEnded: 'ended',
  topError: 'error',
  topLoadedData: 'loadeddata',
  topLoadedMetadata: 'loadedmetadata',
  topLoadStart: 'loadstart',
  topPause: 'pause',
  topPlay: 'play',
  topPlaying: 'playing',
  topProgress: 'progress',
  topRateChange: 'ratechange',
  topSeeked: 'seeked',
  topSeeking: 'seeking',
  topStalled: 'stalled',
  topSuspend: 'suspend',
  topTimeUpdate: 'timeupdate',
  topVolumeChange: 'volumechange',
  topWaiting: 'waiting'
};

function trapBubbledEventsLocal() {
  var inst = this;
  // If a component renders to null or if another component fatals and causes
  // the state of the tree to be corrupted, `node` here can be null.
  !inst._rootNodeID ? invariant_1(false, 'Must be mounted to trap events') : void 0;
  var node = getNode(inst);
  !node ? invariant_1(false, 'trapBubbledEvent(...): Requires node to be rendered.') : void 0;

  switch (inst._tag) {
    case 'iframe':
    case 'object':
      inst._wrapperState.listeners = [ReactBrowserEventEmitter_1.trapBubbledEvent('topLoad', 'load', node)];
      break;
    case 'video':
    case 'audio':

      inst._wrapperState.listeners = [];
      // Create listener for each media event
      for (var event in mediaEvents) {
        if (mediaEvents.hasOwnProperty(event)) {
          inst._wrapperState.listeners.push(ReactBrowserEventEmitter_1.trapBubbledEvent(event, mediaEvents[event], node));
        }
      }
      break;
    case 'source':
      inst._wrapperState.listeners = [ReactBrowserEventEmitter_1.trapBubbledEvent('topError', 'error', node)];
      break;
    case 'img':
      inst._wrapperState.listeners = [ReactBrowserEventEmitter_1.trapBubbledEvent('topError', 'error', node), ReactBrowserEventEmitter_1.trapBubbledEvent('topLoad', 'load', node)];
      break;
    case 'form':
      inst._wrapperState.listeners = [ReactBrowserEventEmitter_1.trapBubbledEvent('topReset', 'reset', node), ReactBrowserEventEmitter_1.trapBubbledEvent('topSubmit', 'submit', node)];
      break;
    case 'input':
    case 'select':
    case 'textarea':
      inst._wrapperState.listeners = [ReactBrowserEventEmitter_1.trapBubbledEvent('topInvalid', 'invalid', node)];
      break;
  }
}

function postUpdateSelectWrapper() {
  ReactDOMSelect_1.postUpdateWrapper(this);
}

// For HTML, certain tags should omit their close tag. We keep a whitelist for
// those special-case tags.

var omittedCloseTags = {
  'area': true,
  'base': true,
  'br': true,
  'col': true,
  'embed': true,
  'hr': true,
  'img': true,
  'input': true,
  'keygen': true,
  'link': true,
  'meta': true,
  'param': true,
  'source': true,
  'track': true,
  'wbr': true
};

var newlineEatingTags = {
  'listing': true,
  'pre': true,
  'textarea': true
};

// For HTML, certain tags cannot have children. This has the same purpose as
// `omittedCloseTags` except that `menuitem` should still have its closing tag.

var voidElementTags = index({
  'menuitem': true
}, omittedCloseTags);

// We accept any tag to be rendered but since this gets injected into arbitrary
// HTML, we want to make sure that it's a safe tag.
// http://www.w3.org/TR/REC-xml/#NT-Name

var VALID_TAG_REGEX = /^[a-zA-Z][a-zA-Z:_\.\-\d]*$/; // Simplified subset
var validatedTagCache = {};
var hasOwnProperty$2 = {}.hasOwnProperty;

function validateDangerousTag(tag) {
  if (!hasOwnProperty$2.call(validatedTagCache, tag)) {
    !VALID_TAG_REGEX.test(tag) ? invariant_1(false, 'Invalid tag: %s', tag) : void 0;
    validatedTagCache[tag] = true;
  }
}

function isCustomComponent(tagName, props) {
  return tagName.indexOf('-') >= 0 || props.is != null;
}

var globalIdCounter = 1;

/**
 * Creates a new React class that is idempotent and capable of containing other
 * React components. It accepts event listeners and DOM properties that are
 * valid according to `DOMProperty`.
 *
 *  - Event listeners: `onClick`, `onMouseDown`, etc.
 *  - DOM properties: `className`, `name`, `title`, etc.
 *
 * The `style` property functions differently from the DOM API. It accepts an
 * object mapping of style properties to values.
 *
 * @constructor ReactDOMComponent
 * @extends ReactMultiChild
 */
function ReactDOMComponent(element) {
  var tag = element.type;
  validateDangerousTag(tag);
  this._currentElement = element;
  this._tag = tag.toLowerCase();
  this._namespaceURI = null;
  this._renderedChildren = null;
  this._previousStyle = null;
  this._previousStyleCopy = null;
  this._hostNode = null;
  this._hostParent = null;
  this._rootNodeID = 0;
  this._domID = 0;
  this._hostContainerInfo = null;
  this._wrapperState = null;
  this._topLevelWrapper = null;
  this._flags = 0;
  {
    this._ancestorInfo = null;
    setAndValidateContentChildDev.call(this, null);
  }
}

ReactDOMComponent.displayName = 'ReactDOMComponent';

ReactDOMComponent.Mixin = {

  /**
   * Generates root tag markup then recurses. This method has side effects and
   * is not idempotent.
   *
   * @internal
   * @param {ReactReconcileTransaction|ReactServerRenderingTransaction} transaction
   * @param {?ReactDOMComponent} the parent component instance
   * @param {?object} info about the host container
   * @param {object} context
   * @return {string} The computed markup.
   */
  mountComponent: function (transaction, hostParent, hostContainerInfo, context) {
    this._rootNodeID = globalIdCounter++;
    this._domID = hostContainerInfo._idCounter++;
    this._hostParent = hostParent;
    this._hostContainerInfo = hostContainerInfo;

    var props = this._currentElement.props;

    switch (this._tag) {
      case 'audio':
      case 'form':
      case 'iframe':
      case 'img':
      case 'link':
      case 'object':
      case 'source':
      case 'video':
        this._wrapperState = {
          listeners: null
        };
        transaction.getReactMountReady().enqueue(trapBubbledEventsLocal, this);
        break;
      case 'input':
        ReactDOMInput_1.mountWrapper(this, props, hostParent);
        props = ReactDOMInput_1.getHostProps(this, props);
        transaction.getReactMountReady().enqueue(trapBubbledEventsLocal, this);
        break;
      case 'option':
        ReactDOMOption_1.mountWrapper(this, props, hostParent);
        props = ReactDOMOption_1.getHostProps(this, props);
        break;
      case 'select':
        ReactDOMSelect_1.mountWrapper(this, props, hostParent);
        props = ReactDOMSelect_1.getHostProps(this, props);
        transaction.getReactMountReady().enqueue(trapBubbledEventsLocal, this);
        break;
      case 'textarea':
        ReactDOMTextarea_1.mountWrapper(this, props, hostParent);
        props = ReactDOMTextarea_1.getHostProps(this, props);
        transaction.getReactMountReady().enqueue(trapBubbledEventsLocal, this);
        break;
    }

    assertValidProps(this, props);

    // We create tags in the namespace of their parent container, except HTML
    // tags get no namespace.
    var namespaceURI;
    var parentTag;
    if (hostParent != null) {
      namespaceURI = hostParent._namespaceURI;
      parentTag = hostParent._tag;
    } else if (hostContainerInfo._tag) {
      namespaceURI = hostContainerInfo._namespaceURI;
      parentTag = hostContainerInfo._tag;
    }
    if (namespaceURI == null || namespaceURI === DOMNamespaces_1.svg && parentTag === 'foreignobject') {
      namespaceURI = DOMNamespaces_1.html;
    }
    if (namespaceURI === DOMNamespaces_1.html) {
      if (this._tag === 'svg') {
        namespaceURI = DOMNamespaces_1.svg;
      } else if (this._tag === 'math') {
        namespaceURI = DOMNamespaces_1.mathml;
      }
    }
    this._namespaceURI = namespaceURI;

    {
      var parentInfo;
      if (hostParent != null) {
        parentInfo = hostParent._ancestorInfo;
      } else if (hostContainerInfo._tag) {
        parentInfo = hostContainerInfo._ancestorInfo;
      }
      if (parentInfo) {
        // parentInfo should always be present except for the top-level
        // component when server rendering
        validateDOMNesting_1(this._tag, null, this, parentInfo);
      }
      this._ancestorInfo = validateDOMNesting_1.updatedAncestorInfo(parentInfo, this._tag, this);
    }

    var mountImage;
    if (transaction.useCreateElement) {
      var ownerDocument = hostContainerInfo._ownerDocument;
      var el;
      if (namespaceURI === DOMNamespaces_1.html) {
        if (this._tag === 'script') {
          // Create the script via .innerHTML so its "parser-inserted" flag is
          // set to true and it does not execute
          var div = ownerDocument.createElement('div');
          var type = this._currentElement.type;
          div.innerHTML = '<' + type + '></' + type + '>';
          el = div.removeChild(div.firstChild);
        } else if (props.is) {
          el = ownerDocument.createElement(this._currentElement.type, props.is);
        } else {
          // Separate else branch instead of using `props.is || undefined` above becuase of a Firefox bug.
          // See discussion in https://github.com/facebook/react/pull/6896
          // and discussion in https://bugzilla.mozilla.org/show_bug.cgi?id=1276240
          el = ownerDocument.createElement(this._currentElement.type);
        }
      } else {
        el = ownerDocument.createElementNS(namespaceURI, this._currentElement.type);
      }
      ReactDOMComponentTree_1.precacheNode(this, el);
      this._flags |= Flags$1.hasCachedChildNodes;
      if (!this._hostParent) {
        DOMPropertyOperations_1.setAttributeForRoot(el);
      }
      this._updateDOMProperties(null, props, transaction);
      var lazyTree = DOMLazyTree_1(el);
      this._createInitialChildren(transaction, props, context, lazyTree);
      mountImage = lazyTree;
    } else {
      var tagOpen = this._createOpenTagMarkupAndPutListeners(transaction, props);
      var tagContent = this._createContentMarkup(transaction, props, context);
      if (!tagContent && omittedCloseTags[this._tag]) {
        mountImage = tagOpen + '/>';
      } else {
        mountImage = tagOpen + '>' + tagContent + '</' + this._currentElement.type + '>';
      }
    }

    switch (this._tag) {
      case 'input':
        transaction.getReactMountReady().enqueue(inputPostMount, this);
        if (props.autoFocus) {
          transaction.getReactMountReady().enqueue(AutoFocusUtils_1.focusDOMComponent, this);
        }
        break;
      case 'textarea':
        transaction.getReactMountReady().enqueue(textareaPostMount, this);
        if (props.autoFocus) {
          transaction.getReactMountReady().enqueue(AutoFocusUtils_1.focusDOMComponent, this);
        }
        break;
      case 'select':
        if (props.autoFocus) {
          transaction.getReactMountReady().enqueue(AutoFocusUtils_1.focusDOMComponent, this);
        }
        break;
      case 'button':
        if (props.autoFocus) {
          transaction.getReactMountReady().enqueue(AutoFocusUtils_1.focusDOMComponent, this);
        }
        break;
      case 'option':
        transaction.getReactMountReady().enqueue(optionPostMount, this);
        break;
    }

    return mountImage;
  },

  /**
   * Creates markup for the open tag and all attributes.
   *
   * This method has side effects because events get registered.
   *
   * Iterating over object properties is faster than iterating over arrays.
   * @see http://jsperf.com/obj-vs-arr-iteration
   *
   * @private
   * @param {ReactReconcileTransaction|ReactServerRenderingTransaction} transaction
   * @param {object} props
   * @return {string} Markup of opening tag.
   */
  _createOpenTagMarkupAndPutListeners: function (transaction, props) {
    var ret = '<' + this._currentElement.type;

    for (var propKey in props) {
      if (!props.hasOwnProperty(propKey)) {
        continue;
      }
      var propValue = props[propKey];
      if (propValue == null) {
        continue;
      }
      if (registrationNameModules.hasOwnProperty(propKey)) {
        if (propValue) {
          enqueuePutListener(this, propKey, propValue, transaction);
        }
      } else {
        if (propKey === STYLE) {
          if (propValue) {
            {
              // See `_updateDOMProperties`. style block
              this._previousStyle = propValue;
            }
            propValue = this._previousStyleCopy = index({}, props.style);
          }
          propValue = CSSPropertyOperations_1.createMarkupForStyles(propValue, this);
        }
        var markup = null;
        if (this._tag != null && isCustomComponent(this._tag, props)) {
          if (!RESERVED_PROPS$1.hasOwnProperty(propKey)) {
            markup = DOMPropertyOperations_1.createMarkupForCustomAttribute(propKey, propValue);
          }
        } else {
          markup = DOMPropertyOperations_1.createMarkupForProperty(propKey, propValue);
        }
        if (markup) {
          ret += ' ' + markup;
        }
      }
    }

    // For static pages, no need to put React ID and checksum. Saves lots of
    // bytes.
    if (transaction.renderToStaticMarkup) {
      return ret;
    }

    if (!this._hostParent) {
      ret += ' ' + DOMPropertyOperations_1.createMarkupForRoot();
    }
    ret += ' ' + DOMPropertyOperations_1.createMarkupForID(this._domID);
    return ret;
  },

  /**
   * Creates markup for the content between the tags.
   *
   * @private
   * @param {ReactReconcileTransaction|ReactServerRenderingTransaction} transaction
   * @param {object} props
   * @param {object} context
   * @return {string} Content markup.
   */
  _createContentMarkup: function (transaction, props, context) {
    var ret = '';

    // Intentional use of != to avoid catching zero/false.
    var innerHTML = props.dangerouslySetInnerHTML;
    if (innerHTML != null) {
      if (innerHTML.__html != null) {
        ret = innerHTML.__html;
      }
    } else {
      var contentToUse = CONTENT_TYPES[typeof props.children] ? props.children : null;
      var childrenToUse = contentToUse != null ? null : props.children;
      if (contentToUse != null) {
        // TODO: Validate that text is allowed as a child of this node
        ret = escapeTextContentForBrowser_1(contentToUse);
        {
          setAndValidateContentChildDev.call(this, contentToUse);
        }
      } else if (childrenToUse != null) {
        var mountImages = this.mountChildren(childrenToUse, transaction, context);
        ret = mountImages.join('');
      }
    }
    if (newlineEatingTags[this._tag] && ret.charAt(0) === '\n') {
      // text/html ignores the first character in these tags if it's a newline
      // Prefer to break application/xml over text/html (for now) by adding
      // a newline specifically to get eaten by the parser. (Alternately for
      // textareas, replacing "^\n" with "\r\n" doesn't get eaten, and the first
      // \r is normalized out by HTMLTextAreaElement#value.)
      // See: <http://www.w3.org/TR/html-polyglot/#newlines-in-textarea-and-pre>
      // See: <http://www.w3.org/TR/html5/syntax.html#element-restrictions>
      // See: <http://www.w3.org/TR/html5/syntax.html#newlines>
      // See: Parsing of "textarea" "listing" and "pre" elements
      //  from <http://www.w3.org/TR/html5/syntax.html#parsing-main-inbody>
      return '\n' + ret;
    } else {
      return ret;
    }
  },

  _createInitialChildren: function (transaction, props, context, lazyTree) {
    // Intentional use of != to avoid catching zero/false.
    var innerHTML = props.dangerouslySetInnerHTML;
    if (innerHTML != null) {
      if (innerHTML.__html != null) {
        DOMLazyTree_1.queueHTML(lazyTree, innerHTML.__html);
      }
    } else {
      var contentToUse = CONTENT_TYPES[typeof props.children] ? props.children : null;
      var childrenToUse = contentToUse != null ? null : props.children;
      // TODO: Validate that text is allowed as a child of this node
      if (contentToUse != null) {
        // Avoid setting textContent when the text is empty. In IE11 setting
        // textContent on a text area will cause the placeholder to not
        // show within the textarea until it has been focused and blurred again.
        // https://github.com/facebook/react/issues/6731#issuecomment-254874553
        if (contentToUse !== '') {
          {
            setAndValidateContentChildDev.call(this, contentToUse);
          }
          DOMLazyTree_1.queueText(lazyTree, contentToUse);
        }
      } else if (childrenToUse != null) {
        var mountImages = this.mountChildren(childrenToUse, transaction, context);
        for (var i = 0; i < mountImages.length; i++) {
          DOMLazyTree_1.queueChild(lazyTree, mountImages[i]);
        }
      }
    }
  },

  /**
   * Receives a next element and updates the component.
   *
   * @internal
   * @param {ReactElement} nextElement
   * @param {ReactReconcileTransaction|ReactServerRenderingTransaction} transaction
   * @param {object} context
   */
  receiveComponent: function (nextElement, transaction, context) {
    var prevElement = this._currentElement;
    this._currentElement = nextElement;
    this.updateComponent(transaction, prevElement, nextElement, context);
  },

  /**
   * Updates a DOM component after it has already been allocated and
   * attached to the DOM. Reconciles the root DOM node, then recurses.
   *
   * @param {ReactReconcileTransaction} transaction
   * @param {ReactElement} prevElement
   * @param {ReactElement} nextElement
   * @internal
   * @overridable
   */
  updateComponent: function (transaction, prevElement, nextElement, context) {
    var lastProps = prevElement.props;
    var nextProps = this._currentElement.props;

    switch (this._tag) {
      case 'input':
        lastProps = ReactDOMInput_1.getHostProps(this, lastProps);
        nextProps = ReactDOMInput_1.getHostProps(this, nextProps);
        break;
      case 'option':
        lastProps = ReactDOMOption_1.getHostProps(this, lastProps);
        nextProps = ReactDOMOption_1.getHostProps(this, nextProps);
        break;
      case 'select':
        lastProps = ReactDOMSelect_1.getHostProps(this, lastProps);
        nextProps = ReactDOMSelect_1.getHostProps(this, nextProps);
        break;
      case 'textarea':
        lastProps = ReactDOMTextarea_1.getHostProps(this, lastProps);
        nextProps = ReactDOMTextarea_1.getHostProps(this, nextProps);
        break;
    }

    assertValidProps(this, nextProps);
    this._updateDOMProperties(lastProps, nextProps, transaction);
    this._updateDOMChildren(lastProps, nextProps, transaction, context);

    switch (this._tag) {
      case 'input':
        // Update the wrapper around inputs *after* updating props. This has to
        // happen after `_updateDOMProperties`. Otherwise HTML5 input validations
        // raise warnings and prevent the new value from being assigned.
        ReactDOMInput_1.updateWrapper(this);
        break;
      case 'textarea':
        ReactDOMTextarea_1.updateWrapper(this);
        break;
      case 'select':
        // <select> value update needs to occur after <option> children
        // reconciliation
        transaction.getReactMountReady().enqueue(postUpdateSelectWrapper, this);
        break;
    }
  },

  /**
   * Reconciles the properties by detecting differences in property values and
   * updating the DOM as necessary. This function is probably the single most
   * critical path for performance optimization.
   *
   * TODO: Benchmark whether checking for changed values in memory actually
   *       improves performance (especially statically positioned elements).
   * TODO: Benchmark the effects of putting this at the top since 99% of props
   *       do not change for a given reconciliation.
   * TODO: Benchmark areas that can be improved with caching.
   *
   * @private
   * @param {object} lastProps
   * @param {object} nextProps
   * @param {?DOMElement} node
   */
  _updateDOMProperties: function (lastProps, nextProps, transaction) {
    var propKey;
    var styleName;
    var styleUpdates;
    for (propKey in lastProps) {
      if (nextProps.hasOwnProperty(propKey) || !lastProps.hasOwnProperty(propKey) || lastProps[propKey] == null) {
        continue;
      }
      if (propKey === STYLE) {
        var lastStyle = this._previousStyleCopy;
        for (styleName in lastStyle) {
          if (lastStyle.hasOwnProperty(styleName)) {
            styleUpdates = styleUpdates || {};
            styleUpdates[styleName] = '';
          }
        }
        this._previousStyleCopy = null;
      } else if (registrationNameModules.hasOwnProperty(propKey)) {
        if (lastProps[propKey]) {
          // Only call deleteListener if there was a listener previously or
          // else willDeleteListener gets called when there wasn't actually a
          // listener (e.g., onClick={null})
          deleteListener(this, propKey);
        }
      } else if (isCustomComponent(this._tag, lastProps)) {
        if (!RESERVED_PROPS$1.hasOwnProperty(propKey)) {
          DOMPropertyOperations_1.deleteValueForAttribute(getNode(this), propKey);
        }
      } else if (DOMProperty_1.properties[propKey] || DOMProperty_1.isCustomAttribute(propKey)) {
        DOMPropertyOperations_1.deleteValueForProperty(getNode(this), propKey);
      }
    }
    for (propKey in nextProps) {
      var nextProp = nextProps[propKey];
      var lastProp = propKey === STYLE ? this._previousStyleCopy : lastProps != null ? lastProps[propKey] : undefined;
      if (!nextProps.hasOwnProperty(propKey) || nextProp === lastProp || nextProp == null && lastProp == null) {
        continue;
      }
      if (propKey === STYLE) {
        if (nextProp) {
          {
            checkAndWarnForMutatedStyle(this._previousStyleCopy, this._previousStyle, this);
            this._previousStyle = nextProp;
          }
          nextProp = this._previousStyleCopy = index({}, nextProp);
        } else {
          this._previousStyleCopy = null;
        }
        if (lastProp) {
          // Unset styles on `lastProp` but not on `nextProp`.
          for (styleName in lastProp) {
            if (lastProp.hasOwnProperty(styleName) && (!nextProp || !nextProp.hasOwnProperty(styleName))) {
              styleUpdates = styleUpdates || {};
              styleUpdates[styleName] = '';
            }
          }
          // Update styles that changed since `lastProp`.
          for (styleName in nextProp) {
            if (nextProp.hasOwnProperty(styleName) && lastProp[styleName] !== nextProp[styleName]) {
              styleUpdates = styleUpdates || {};
              styleUpdates[styleName] = nextProp[styleName];
            }
          }
        } else {
          // Relies on `updateStylesByID` not mutating `styleUpdates`.
          styleUpdates = nextProp;
        }
      } else if (registrationNameModules.hasOwnProperty(propKey)) {
        if (nextProp) {
          enqueuePutListener(this, propKey, nextProp, transaction);
        } else if (lastProp) {
          deleteListener(this, propKey);
        }
      } else if (isCustomComponent(this._tag, nextProps)) {
        if (!RESERVED_PROPS$1.hasOwnProperty(propKey)) {
          DOMPropertyOperations_1.setValueForAttribute(getNode(this), propKey, nextProp);
        }
      } else if (DOMProperty_1.properties[propKey] || DOMProperty_1.isCustomAttribute(propKey)) {
        var node = getNode(this);
        // If we're updating to null or undefined, we should remove the property
        // from the DOM node instead of inadvertently setting to a string. This
        // brings us in line with the same behavior we have on initial render.
        if (nextProp != null) {
          DOMPropertyOperations_1.setValueForProperty(node, propKey, nextProp);
        } else {
          DOMPropertyOperations_1.deleteValueForProperty(node, propKey);
        }
      }
    }
    if (styleUpdates) {
      CSSPropertyOperations_1.setValueForStyles(getNode(this), styleUpdates, this);
    }
  },

  /**
   * Reconciles the children with the various properties that affect the
   * children content.
   *
   * @param {object} lastProps
   * @param {object} nextProps
   * @param {ReactReconcileTransaction} transaction
   * @param {object} context
   */
  _updateDOMChildren: function (lastProps, nextProps, transaction, context) {
    var lastContent = CONTENT_TYPES[typeof lastProps.children] ? lastProps.children : null;
    var nextContent = CONTENT_TYPES[typeof nextProps.children] ? nextProps.children : null;

    var lastHtml = lastProps.dangerouslySetInnerHTML && lastProps.dangerouslySetInnerHTML.__html;
    var nextHtml = nextProps.dangerouslySetInnerHTML && nextProps.dangerouslySetInnerHTML.__html;

    // Note the use of `!=` which checks for null or undefined.
    var lastChildren = lastContent != null ? null : lastProps.children;
    var nextChildren = nextContent != null ? null : nextProps.children;

    // If we're switching from children to content/html or vice versa, remove
    // the old content
    var lastHasContentOrHtml = lastContent != null || lastHtml != null;
    var nextHasContentOrHtml = nextContent != null || nextHtml != null;
    if (lastChildren != null && nextChildren == null) {
      this.updateChildren(null, transaction, context);
    } else if (lastHasContentOrHtml && !nextHasContentOrHtml) {
      this.updateTextContent('');
      {
        ReactInstrumentation$1.debugTool.onSetChildren(this._debugID, []);
      }
    }

    if (nextContent != null) {
      if (lastContent !== nextContent) {
        this.updateTextContent('' + nextContent);
        {
          setAndValidateContentChildDev.call(this, nextContent);
        }
      }
    } else if (nextHtml != null) {
      if (lastHtml !== nextHtml) {
        this.updateMarkup('' + nextHtml);
      }
      {
        ReactInstrumentation$1.debugTool.onSetChildren(this._debugID, []);
      }
    } else if (nextChildren != null) {
      {
        setAndValidateContentChildDev.call(this, null);
      }

      this.updateChildren(nextChildren, transaction, context);
    }
  },

  getHostNode: function () {
    return getNode(this);
  },

  /**
   * Destroys all event registrations for this instance. Does not remove from
   * the DOM. That must be done by the parent.
   *
   * @internal
   */
  unmountComponent: function (safely) {
    switch (this._tag) {
      case 'audio':
      case 'form':
      case 'iframe':
      case 'img':
      case 'link':
      case 'object':
      case 'source':
      case 'video':
        var listeners = this._wrapperState.listeners;
        if (listeners) {
          for (var i = 0; i < listeners.length; i++) {
            listeners[i].remove();
          }
        }
        break;
      case 'html':
      case 'head':
      case 'body':
        /**
         * Components like <html> <head> and <body> can't be removed or added
         * easily in a cross-browser way, however it's valuable to be able to
         * take advantage of React's reconciliation for styling and <title>
         * management. So we just document it and throw in dangerous cases.
         */
        invariant_1(false, '<%s> tried to unmount. Because of cross-browser quirks it is impossible to unmount some top-level components (eg <html>, <head>, and <body>) reliably and efficiently. To fix this, have a single top-level component that never unmounts render these elements.', this._tag);
        break;
    }

    this.unmountChildren(safely);
    ReactDOMComponentTree_1.uncacheNode(this);
    EventPluginHub_1.deleteAllListeners(this);
    this._rootNodeID = 0;
    this._domID = 0;
    this._wrapperState = null;

    {
      setAndValidateContentChildDev.call(this, null);
    }
  },

  getPublicInstance: function () {
    return getNode(this);
  }

};

index(ReactDOMComponent.prototype, ReactDOMComponent.Mixin, ReactMultiChild_1.Mixin);

var ReactDOMComponent_1 = ReactDOMComponent;

var ReactDOMEmptyComponent = function (instantiate) {
  // ReactCompositeComponent uses this:
  this._currentElement = null;
  // ReactDOMComponentTree uses these:
  this._hostNode = null;
  this._hostParent = null;
  this._hostContainerInfo = null;
  this._domID = 0;
};
index(ReactDOMEmptyComponent.prototype, {
  mountComponent: function (transaction, hostParent, hostContainerInfo, context) {
    var domID = hostContainerInfo._idCounter++;
    this._domID = domID;
    this._hostParent = hostParent;
    this._hostContainerInfo = hostContainerInfo;

    var nodeValue = ' react-empty: ' + this._domID + ' ';
    if (transaction.useCreateElement) {
      var ownerDocument = hostContainerInfo._ownerDocument;
      var node = ownerDocument.createComment(nodeValue);
      ReactDOMComponentTree_1.precacheNode(this, node);
      return DOMLazyTree_1(node);
    } else {
      if (transaction.renderToStaticMarkup) {
        // Normally we'd insert a comment node, but since this is a situation
        // where React won't take over (static pages), we can simply return
        // nothing.
        return '';
      }
      return '<!--' + nodeValue + '-->';
    }
  },
  receiveComponent: function () {},
  getHostNode: function () {
    return ReactDOMComponentTree_1.getNodeFromInstance(this);
  },
  unmountComponent: function () {
    ReactDOMComponentTree_1.uncacheNode(this);
  }
});

var ReactDOMEmptyComponent_1 = ReactDOMEmptyComponent;

function getLowestCommonAncestor(instA, instB) {
  !('_hostNode' in instA) ? invariant_1(false, 'getNodeFromInstance: Invalid argument.') : void 0;
  !('_hostNode' in instB) ? invariant_1(false, 'getNodeFromInstance: Invalid argument.') : void 0;

  var depthA = 0;
  for (var tempA = instA; tempA; tempA = tempA._hostParent) {
    depthA++;
  }
  var depthB = 0;
  for (var tempB = instB; tempB; tempB = tempB._hostParent) {
    depthB++;
  }

  // If A is deeper, crawl up.
  while (depthA - depthB > 0) {
    instA = instA._hostParent;
    depthA--;
  }

  // If B is deeper, crawl up.
  while (depthB - depthA > 0) {
    instB = instB._hostParent;
    depthB--;
  }

  // Walk in lockstep until we find a match.
  var depth = depthA;
  while (depth--) {
    if (instA === instB) {
      return instA;
    }
    instA = instA._hostParent;
    instB = instB._hostParent;
  }
  return null;
}

/**
 * Return if A is an ancestor of B.
 */
function isAncestor(instA, instB) {
  !('_hostNode' in instA) ? invariant_1(false, 'isAncestor: Invalid argument.') : void 0;
  !('_hostNode' in instB) ? invariant_1(false, 'isAncestor: Invalid argument.') : void 0;

  while (instB) {
    if (instB === instA) {
      return true;
    }
    instB = instB._hostParent;
  }
  return false;
}

/**
 * Return the parent instance of the passed-in instance.
 */
function getParentInstance(inst) {
  !('_hostNode' in inst) ? invariant_1(false, 'getParentInstance: Invalid argument.') : void 0;

  return inst._hostParent;
}

/**
 * Simulates the traversal of a two-phase, capture/bubble event dispatch.
 */
function traverseTwoPhase(inst, fn, arg) {
  var path = [];
  while (inst) {
    path.push(inst);
    inst = inst._hostParent;
  }
  var i;
  for (i = path.length; i-- > 0;) {
    fn(path[i], 'captured', arg);
  }
  for (i = 0; i < path.length; i++) {
    fn(path[i], 'bubbled', arg);
  }
}

/**
 * Traverses the ID hierarchy and invokes the supplied `cb` on any IDs that
 * should would receive a `mouseEnter` or `mouseLeave` event.
 *
 * Does not invoke the callback on the nearest common ancestor because nothing
 * "entered" or "left" that element.
 */
function traverseEnterLeave(from, to, fn, argFrom, argTo) {
  var common = from && to ? getLowestCommonAncestor(from, to) : null;
  var pathFrom = [];
  while (from && from !== common) {
    pathFrom.push(from);
    from = from._hostParent;
  }
  var pathTo = [];
  while (to && to !== common) {
    pathTo.push(to);
    to = to._hostParent;
  }
  var i;
  for (i = 0; i < pathFrom.length; i++) {
    fn(pathFrom[i], 'bubbled', argFrom);
  }
  for (i = pathTo.length; i-- > 0;) {
    fn(pathTo[i], 'captured', argTo);
  }
}

var ReactDOMTreeTraversal = {
  isAncestor: isAncestor,
  getLowestCommonAncestor: getLowestCommonAncestor,
  getParentInstance: getParentInstance,
  traverseTwoPhase: traverseTwoPhase,
  traverseEnterLeave: traverseEnterLeave
};

var ReactDOMTextComponent = function (text) {
  // TODO: This is really a ReactText (ReactNode), not a ReactElement
  this._currentElement = text;
  this._stringText = '' + text;
  // ReactDOMComponentTree uses these:
  this._hostNode = null;
  this._hostParent = null;

  // Properties
  this._domID = 0;
  this._mountIndex = 0;
  this._closingComment = null;
  this._commentNodes = null;
};

index(ReactDOMTextComponent.prototype, {

  /**
   * Creates the markup for this text node. This node is not intended to have
   * any features besides containing text content.
   *
   * @param {ReactReconcileTransaction|ReactServerRenderingTransaction} transaction
   * @return {string} Markup for this text node.
   * @internal
   */
  mountComponent: function (transaction, hostParent, hostContainerInfo, context) {
    {
      var parentInfo;
      if (hostParent != null) {
        parentInfo = hostParent._ancestorInfo;
      } else if (hostContainerInfo != null) {
        parentInfo = hostContainerInfo._ancestorInfo;
      }
      if (parentInfo) {
        // parentInfo should always be present except for the top-level
        // component when server rendering
        validateDOMNesting_1(null, this._stringText, this, parentInfo);
      }
    }

    var domID = hostContainerInfo._idCounter++;
    var openingValue = ' react-text: ' + domID + ' ';
    var closingValue = ' /react-text ';
    this._domID = domID;
    this._hostParent = hostParent;
    if (transaction.useCreateElement) {
      var ownerDocument = hostContainerInfo._ownerDocument;
      var openingComment = ownerDocument.createComment(openingValue);
      var closingComment = ownerDocument.createComment(closingValue);
      var lazyTree = DOMLazyTree_1(ownerDocument.createDocumentFragment());
      DOMLazyTree_1.queueChild(lazyTree, DOMLazyTree_1(openingComment));
      if (this._stringText) {
        DOMLazyTree_1.queueChild(lazyTree, DOMLazyTree_1(ownerDocument.createTextNode(this._stringText)));
      }
      DOMLazyTree_1.queueChild(lazyTree, DOMLazyTree_1(closingComment));
      ReactDOMComponentTree_1.precacheNode(this, openingComment);
      this._closingComment = closingComment;
      return lazyTree;
    } else {
      var escapedText = escapeTextContentForBrowser_1(this._stringText);

      if (transaction.renderToStaticMarkup) {
        // Normally we'd wrap this between comment nodes for the reasons stated
        // above, but since this is a situation where React won't take over
        // (static pages), we can simply return the text as it is.
        return escapedText;
      }

      return '<!--' + openingValue + '-->' + escapedText + '<!--' + closingValue + '-->';
    }
  },

  /**
   * Updates this component by updating the text content.
   *
   * @param {ReactText} nextText The next text content
   * @param {ReactReconcileTransaction} transaction
   * @internal
   */
  receiveComponent: function (nextText, transaction) {
    if (nextText !== this._currentElement) {
      this._currentElement = nextText;
      var nextStringText = '' + nextText;
      if (nextStringText !== this._stringText) {
        // TODO: Save this as pending props and use performUpdateIfNecessary
        // and/or updateComponent to do the actual update for consistency with
        // other component types?
        this._stringText = nextStringText;
        var commentNodes = this.getHostNode();
        DOMChildrenOperations_1.replaceDelimitedText(commentNodes[0], commentNodes[1], nextStringText);
      }
    }
  },

  getHostNode: function () {
    var hostNode = this._commentNodes;
    if (hostNode) {
      return hostNode;
    }
    if (!this._closingComment) {
      var openingComment = ReactDOMComponentTree_1.getNodeFromInstance(this);
      var node = openingComment.nextSibling;
      while (true) {
        !(node != null) ? invariant_1(false, 'Missing closing comment for text component %s', this._domID) : void 0;
        if (node.nodeType === 8 && node.nodeValue === ' /react-text ') {
          this._closingComment = node;
          break;
        }
        node = node.nextSibling;
      }
    }
    hostNode = [this._hostNode, this._closingComment];
    this._commentNodes = hostNode;
    return hostNode;
  },

  unmountComponent: function () {
    this._closingComment = null;
    this._commentNodes = null;
    ReactDOMComponentTree_1.uncacheNode(this);
  }

});

var ReactDOMTextComponent_1 = ReactDOMTextComponent;

var RESET_BATCHED_UPDATES = {
  initialize: emptyFunction_1,
  close: function () {
    ReactDefaultBatchingStrategy.isBatchingUpdates = false;
  }
};

var FLUSH_BATCHED_UPDATES = {
  initialize: emptyFunction_1,
  close: ReactUpdates_1.flushBatchedUpdates.bind(ReactUpdates_1)
};

var TRANSACTION_WRAPPERS$2 = [FLUSH_BATCHED_UPDATES, RESET_BATCHED_UPDATES];

function ReactDefaultBatchingStrategyTransaction() {
  this.reinitializeTransaction();
}

index(ReactDefaultBatchingStrategyTransaction.prototype, Transaction, {
  getTransactionWrappers: function () {
    return TRANSACTION_WRAPPERS$2;
  }
});

var transaction = new ReactDefaultBatchingStrategyTransaction();

var ReactDefaultBatchingStrategy = {
  isBatchingUpdates: false,

  /**
   * Call the provided function in a context within which calls to `setState`
   * and friends are batched such that components aren't updated unnecessarily.
   */
  batchedUpdates: function (callback, a, b, c, d, e) {
    var alreadyBatchingUpdates = ReactDefaultBatchingStrategy.isBatchingUpdates;

    ReactDefaultBatchingStrategy.isBatchingUpdates = true;

    // The code is written this way to avoid extra allocations
    if (alreadyBatchingUpdates) {
      return callback(a, b, c, d, e);
    } else {
      return transaction.perform(callback, null, a, b, c, d, e);
    }
  }
};

var ReactDefaultBatchingStrategy_1 = ReactDefaultBatchingStrategy;

var EventListener = {
  /**
   * Listen to DOM events during the bubble phase.
   *
   * @param {DOMEventTarget} target DOM element to register listener on.
   * @param {string} eventType Event type, e.g. 'click' or 'mouseover'.
   * @param {function} callback Callback function.
   * @return {object} Object with a `remove` method.
   */
  listen: function listen(target, eventType, callback) {
    if (target.addEventListener) {
      target.addEventListener(eventType, callback, false);
      return {
        remove: function remove() {
          target.removeEventListener(eventType, callback, false);
        }
      };
    } else if (target.attachEvent) {
      target.attachEvent('on' + eventType, callback);
      return {
        remove: function remove() {
          target.detachEvent('on' + eventType, callback);
        }
      };
    }
  },

  /**
   * Listen to DOM events during the capture phase.
   *
   * @param {DOMEventTarget} target DOM element to register listener on.
   * @param {string} eventType Event type, e.g. 'click' or 'mouseover'.
   * @param {function} callback Callback function.
   * @return {object} Object with a `remove` method.
   */
  capture: function capture(target, eventType, callback) {
    if (target.addEventListener) {
      target.addEventListener(eventType, callback, true);
      return {
        remove: function remove() {
          target.removeEventListener(eventType, callback, true);
        }
      };
    } else {
      {
        console.error('Attempted to listen to events during the capture phase on a ' + 'browser that does not support the capture phase. Your application ' + 'will not receive some events.');
      }
      return {
        remove: emptyFunction_1
      };
    }
  },

  registerDefault: function registerDefault() {}
};

var EventListener_1 = EventListener;

/**
 * Copyright (c) 2013-present, Facebook, Inc.
 * All rights reserved.
 *
 * This source code is licensed under the BSD-style license found in the
 * LICENSE file in the root directory of this source tree. An additional grant
 * of patent rights can be found in the PATENTS file in the same directory.
 *
 * @typechecks
 */

function getUnboundedScrollPosition(scrollable) {
  if (scrollable.Window && scrollable instanceof scrollable.Window) {
    return {
      x: scrollable.pageXOffset || scrollable.document.documentElement.scrollLeft,
      y: scrollable.pageYOffset || scrollable.document.documentElement.scrollTop
    };
  }
  return {
    x: scrollable.scrollLeft,
    y: scrollable.scrollTop
  };
}

var getUnboundedScrollPosition_1 = getUnboundedScrollPosition;

function findParent(inst) {
  // TODO: It may be a good idea to cache this to prevent unnecessary DOM
  // traversal, but caching is difficult to do correctly without using a
  // mutation observer to listen for all DOM changes.
  while (inst._hostParent) {
    inst = inst._hostParent;
  }
  var rootNode = ReactDOMComponentTree_1.getNodeFromInstance(inst);
  var container = rootNode.parentNode;
  return ReactDOMComponentTree_1.getClosestInstanceFromNode(container);
}

// Used to store ancestor hierarchy in top level callback
function TopLevelCallbackBookKeeping(topLevelType, nativeEvent) {
  this.topLevelType = topLevelType;
  this.nativeEvent = nativeEvent;
  this.ancestors = [];
}
index(TopLevelCallbackBookKeeping.prototype, {
  destructor: function () {
    this.topLevelType = null;
    this.nativeEvent = null;
    this.ancestors.length = 0;
  }
});
PooledClass_1$2.addPoolingTo(TopLevelCallbackBookKeeping, PooledClass_1$2.twoArgumentPooler);

function handleTopLevelImpl(bookKeeping) {
  var nativeEventTarget = getEventTarget_1(bookKeeping.nativeEvent);
  var targetInst = ReactDOMComponentTree_1.getClosestInstanceFromNode(nativeEventTarget);

  // Loop through the hierarchy, in case there's any nested components.
  // It's important that we build the array of ancestors before calling any
  // event handlers, because event handlers can modify the DOM, leading to
  // inconsistencies with ReactMount's node cache. See #1105.
  var ancestor = targetInst;
  do {
    bookKeeping.ancestors.push(ancestor);
    ancestor = ancestor && findParent(ancestor);
  } while (ancestor);

  for (var i = 0; i < bookKeeping.ancestors.length; i++) {
    targetInst = bookKeeping.ancestors[i];
    ReactEventListener._handleTopLevel(bookKeeping.topLevelType, targetInst, bookKeeping.nativeEvent, getEventTarget_1(bookKeeping.nativeEvent));
  }
}

function scrollValueMonitor(cb) {
  var scrollPosition = getUnboundedScrollPosition_1(window);
  cb(scrollPosition);
}

var ReactEventListener = {
  _enabled: true,
  _handleTopLevel: null,

  WINDOW_HANDLE: ExecutionEnvironment_1.canUseDOM ? window : null,

  setHandleTopLevel: function (handleTopLevel) {
    ReactEventListener._handleTopLevel = handleTopLevel;
  },

  setEnabled: function (enabled) {
    ReactEventListener._enabled = !!enabled;
  },

  isEnabled: function () {
    return ReactEventListener._enabled;
  },

  /**
   * Traps top-level events by using event bubbling.
   *
   * @param {string} topLevelType Record from `EventConstants`.
   * @param {string} handlerBaseName Event name (e.g. "click").
   * @param {object} element Element on which to attach listener.
   * @return {?object} An object with a remove function which will forcefully
   *                  remove the listener.
   * @internal
   */
  trapBubbledEvent: function (topLevelType, handlerBaseName, element) {
    if (!element) {
      return null;
    }
    return EventListener_1.listen(element, handlerBaseName, ReactEventListener.dispatchEvent.bind(null, topLevelType));
  },

  /**
   * Traps a top-level event by using event capturing.
   *
   * @param {string} topLevelType Record from `EventConstants`.
   * @param {string} handlerBaseName Event name (e.g. "click").
   * @param {object} element Element on which to attach listener.
   * @return {?object} An object with a remove function which will forcefully
   *                  remove the listener.
   * @internal
   */
  trapCapturedEvent: function (topLevelType, handlerBaseName, element) {
    if (!element) {
      return null;
    }
    return EventListener_1.capture(element, handlerBaseName, ReactEventListener.dispatchEvent.bind(null, topLevelType));
  },

  monitorScrollValue: function (refresh) {
    var callback = scrollValueMonitor.bind(null, refresh);
    EventListener_1.listen(window, 'scroll', callback);
  },

  dispatchEvent: function (topLevelType, nativeEvent) {
    if (!ReactEventListener._enabled) {
      return;
    }

    var bookKeeping = TopLevelCallbackBookKeeping.getPooled(topLevelType, nativeEvent);
    try {
      // Event queue being processed in the same cycle allows
      // `preventDefault`.
      ReactUpdates_1.batchedUpdates(handleTopLevelImpl, bookKeeping);
    } finally {
      TopLevelCallbackBookKeeping.release(bookKeeping);
    }
  }
};

var ReactEventListener_1 = ReactEventListener;

var ReactInjection = {
  Component: ReactComponentEnvironment_1.injection,
  DOMProperty: DOMProperty_1.injection,
  EmptyComponent: ReactEmptyComponent_1.injection,
  EventPluginHub: EventPluginHub_1.injection,
  EventPluginUtils: EventPluginUtils_1.injection,
  EventEmitter: ReactBrowserEventEmitter_1.injection,
  HostComponent: ReactHostComponent_1.injection,
  Updates: ReactUpdates_1.injection
};

var ReactInjection_1 = ReactInjection;

/**
 * Copyright 2013-present, Facebook, Inc.
 * All rights reserved.
 *
 * This source code is licensed under the BSD-style license found in the
 * LICENSE file in the root directory of this source tree. An additional grant
 * of patent rights can be found in the PATENTS file in the same directory.
 *
 */

function getLeafNode(node) {
  while (node && node.firstChild) {
    node = node.firstChild;
  }
  return node;
}

/**
 * Get the next sibling within a container. This will walk up the
 * DOM if a node's siblings have been exhausted.
 *
 * @param {DOMElement|DOMTextNode} node
 * @return {?DOMElement|DOMTextNode}
 */
function getSiblingNode(node) {
  while (node) {
    if (node.nextSibling) {
      return node.nextSibling;
    }
    node = node.parentNode;
  }
}

/**
 * Get object describing the nodes which contain characters at offset.
 *
 * @param {DOMElement|DOMTextNode} root
 * @param {number} offset
 * @return {?object}
 */
function getNodeForCharacterOffset(root, offset) {
  var node = getLeafNode(root);
  var nodeStart = 0;
  var nodeEnd = 0;

  while (node) {
    if (node.nodeType === 3) {
      nodeEnd = nodeStart + node.textContent.length;

      if (nodeStart <= offset && nodeEnd >= offset) {
        return {
          node: node,
          offset: offset - nodeStart
        };
      }

      nodeStart = nodeEnd;
    }

    node = getLeafNode(getSiblingNode(node));
  }
}

var getNodeForCharacterOffset_1 = getNodeForCharacterOffset;

function isCollapsed(anchorNode, anchorOffset, focusNode, focusOffset) {
  return anchorNode === focusNode && anchorOffset === focusOffset;
}

/**
 * Get the appropriate anchor and focus node/offset pairs for IE.
 *
 * The catch here is that IE's selection API doesn't provide information
 * about whether the selection is forward or backward, so we have to
 * behave as though it's always forward.
 *
 * IE text differs from modern selection in that it behaves as though
 * block elements end with a new line. This means character offsets will
 * differ between the two APIs.
 *
 * @param {DOMElement} node
 * @return {object}
 */
function getIEOffsets(node) {
  var selection = document.selection;
  var selectedRange = selection.createRange();
  var selectedLength = selectedRange.text.length;

  // Duplicate selection so we can move range without breaking user selection.
  var fromStart = selectedRange.duplicate();
  fromStart.moveToElementText(node);
  fromStart.setEndPoint('EndToStart', selectedRange);

  var startOffset = fromStart.text.length;
  var endOffset = startOffset + selectedLength;

  return {
    start: startOffset,
    end: endOffset
  };
}

/**
 * @param {DOMElement} node
 * @return {?object}
 */
function getModernOffsets(node) {
  var selection = window.getSelection && window.getSelection();

  if (!selection || selection.rangeCount === 0) {
    return null;
  }

  var anchorNode = selection.anchorNode;
  var anchorOffset = selection.anchorOffset;
  var focusNode = selection.focusNode;
  var focusOffset = selection.focusOffset;

  var currentRange = selection.getRangeAt(0);

  // In Firefox, range.startContainer and range.endContainer can be "anonymous
  // divs", e.g. the up/down buttons on an <input type="number">. Anonymous
  // divs do not seem to expose properties, triggering a "Permission denied
  // error" if any of its properties are accessed. The only seemingly possible
  // way to avoid erroring is to access a property that typically works for
  // non-anonymous divs and catch any error that may otherwise arise. See
  // https://bugzilla.mozilla.org/show_bug.cgi?id=208427
  try {
    /* eslint-disable no-unused-expressions */
    currentRange.startContainer.nodeType;
    currentRange.endContainer.nodeType;
    /* eslint-enable no-unused-expressions */
  } catch (e) {
    return null;
  }

  // If the node and offset values are the same, the selection is collapsed.
  // `Selection.isCollapsed` is available natively, but IE sometimes gets
  // this value wrong.
  var isSelectionCollapsed = isCollapsed(selection.anchorNode, selection.anchorOffset, selection.focusNode, selection.focusOffset);

  var rangeLength = isSelectionCollapsed ? 0 : currentRange.toString().length;

  var tempRange = currentRange.cloneRange();
  tempRange.selectNodeContents(node);
  tempRange.setEnd(currentRange.startContainer, currentRange.startOffset);

  var isTempRangeCollapsed = isCollapsed(tempRange.startContainer, tempRange.startOffset, tempRange.endContainer, tempRange.endOffset);

  var start = isTempRangeCollapsed ? 0 : tempRange.toString().length;
  var end = start + rangeLength;

  // Detect whether the selection is backward.
  var detectionRange = document.createRange();
  detectionRange.setStart(anchorNode, anchorOffset);
  detectionRange.setEnd(focusNode, focusOffset);
  var isBackward = detectionRange.collapsed;

  return {
    start: isBackward ? end : start,
    end: isBackward ? start : end
  };
}

/**
 * @param {DOMElement|DOMTextNode} node
 * @param {object} offsets
 */
function setIEOffsets(node, offsets) {
  var range = document.selection.createRange().duplicate();
  var start, end;

  if (offsets.end === undefined) {
    start = offsets.start;
    end = start;
  } else if (offsets.start > offsets.end) {
    start = offsets.end;
    end = offsets.start;
  } else {
    start = offsets.start;
    end = offsets.end;
  }

  range.moveToElementText(node);
  range.moveStart('character', start);
  range.setEndPoint('EndToStart', range);
  range.moveEnd('character', end - start);
  range.select();
}

/**
 * In modern non-IE browsers, we can support both forward and backward
 * selections.
 *
 * Note: IE10+ supports the Selection object, but it does not support
 * the `extend` method, which means that even in modern IE, it's not possible
 * to programmatically create a backward selection. Thus, for all IE
 * versions, we use the old IE API to create our selections.
 *
 * @param {DOMElement|DOMTextNode} node
 * @param {object} offsets
 */
function setModernOffsets(node, offsets) {
  if (!window.getSelection) {
    return;
  }

  var selection = window.getSelection();
  var length = node[getTextContentAccessor_1()].length;
  var start = Math.min(offsets.start, length);
  var end = offsets.end === undefined ? start : Math.min(offsets.end, length);

  // IE 11 uses modern selection, but doesn't support the extend method.
  // Flip backward selections, so we can set with a single range.
  if (!selection.extend && start > end) {
    var temp = end;
    end = start;
    start = temp;
  }

  var startMarker = getNodeForCharacterOffset_1(node, start);
  var endMarker = getNodeForCharacterOffset_1(node, end);

  if (startMarker && endMarker) {
    var range = document.createRange();
    range.setStart(startMarker.node, startMarker.offset);
    selection.removeAllRanges();

    if (start > end) {
      selection.addRange(range);
      selection.extend(endMarker.node, endMarker.offset);
    } else {
      range.setEnd(endMarker.node, endMarker.offset);
      selection.addRange(range);
    }
  }
}

var useIEOffsets = ExecutionEnvironment_1.canUseDOM && 'selection' in document && !('getSelection' in window);

var ReactDOMSelection = {
  /**
   * @param {DOMElement} node
   */
  getOffsets: useIEOffsets ? getIEOffsets : getModernOffsets,

  /**
   * @param {DOMElement|DOMTextNode} node
   * @param {object} offsets
   */
  setOffsets: useIEOffsets ? setIEOffsets : setModernOffsets
};

var ReactDOMSelection_1 = ReactDOMSelection;

function isNode(object) {
  var doc = object ? object.ownerDocument || object : document;
  var defaultView = doc.defaultView || window;
  return !!(object && (typeof defaultView.Node === 'function' ? object instanceof defaultView.Node : typeof object === 'object' && typeof object.nodeType === 'number' && typeof object.nodeName === 'string'));
}

var isNode_1 = isNode;

function isTextNode(object) {
  return isNode_1(object) && object.nodeType == 3;
}

var isTextNode_1 = isTextNode;

function containsNode(outerNode, innerNode) {
  if (!outerNode || !innerNode) {
    return false;
  } else if (outerNode === innerNode) {
    return true;
  } else if (isTextNode_1(outerNode)) {
    return false;
  } else if (isTextNode_1(innerNode)) {
    return containsNode(outerNode, innerNode.parentNode);
  } else if ('contains' in outerNode) {
    return outerNode.contains(innerNode);
  } else if (outerNode.compareDocumentPosition) {
    return !!(outerNode.compareDocumentPosition(innerNode) & 16);
  } else {
    return false;
  }
}

var containsNode_1 = containsNode;

function getActiveElement(doc) /*?DOMElement*/{
  doc = doc || (typeof document !== 'undefined' ? document : undefined);
  if (typeof doc === 'undefined') {
    return null;
  }
  try {
    return doc.activeElement || doc.body;
  } catch (e) {
    return doc.body;
  }
}

var getActiveElement_1 = getActiveElement;

function isInDocument(node) {
  return containsNode_1(document.documentElement, node);
}

/**
 * @ReactInputSelection: React input selection module. Based on Selection.js,
 * but modified to be suitable for react and has a couple of bug fixes (doesn't
 * assume buttons have range selections allowed).
 * Input selection module for React.
 */
var ReactInputSelection = {

  hasSelectionCapabilities: function (elem) {
    var nodeName = elem && elem.nodeName && elem.nodeName.toLowerCase();
    return nodeName && (nodeName === 'input' && elem.type === 'text' || nodeName === 'textarea' || elem.contentEditable === 'true');
  },

  getSelectionInformation: function () {
    var focusedElem = getActiveElement_1();
    return {
      focusedElem: focusedElem,
      selectionRange: ReactInputSelection.hasSelectionCapabilities(focusedElem) ? ReactInputSelection.getSelection(focusedElem) : null
    };
  },

  /**
   * @restoreSelection: If any selection information was potentially lost,
   * restore it. This is useful when performing operations that could remove dom
   * nodes and place them back in, resulting in focus being lost.
   */
  restoreSelection: function (priorSelectionInformation) {
    var curFocusedElem = getActiveElement_1();
    var priorFocusedElem = priorSelectionInformation.focusedElem;
    var priorSelectionRange = priorSelectionInformation.selectionRange;
    if (curFocusedElem !== priorFocusedElem && isInDocument(priorFocusedElem)) {
      if (ReactInputSelection.hasSelectionCapabilities(priorFocusedElem)) {
        ReactInputSelection.setSelection(priorFocusedElem, priorSelectionRange);
      }
      focusNode_1(priorFocusedElem);
    }
  },

  /**
   * @getSelection: Gets the selection bounds of a focused textarea, input or
   * contentEditable node.
   * -@input: Look up selection bounds of this input
   * -@return {start: selectionStart, end: selectionEnd}
   */
  getSelection: function (input) {
    var selection;

    if ('selectionStart' in input) {
      // Modern browser with input or textarea.
      selection = {
        start: input.selectionStart,
        end: input.selectionEnd
      };
    } else if (document.selection && input.nodeName && input.nodeName.toLowerCase() === 'input') {
      // IE8 input.
      var range = document.selection.createRange();
      // There can only be one selection per document in IE, so it must
      // be in our element.
      if (range.parentElement() === input) {
        selection = {
          start: -range.moveStart('character', -input.value.length),
          end: -range.moveEnd('character', -input.value.length)
        };
      }
    } else {
      // Content editable or old IE textarea.
      selection = ReactDOMSelection_1.getOffsets(input);
    }

    return selection || { start: 0, end: 0 };
  },

  /**
   * @setSelection: Sets the selection bounds of a textarea or input and focuses
   * the input.
   * -@input     Set selection bounds of this input or textarea
   * -@offsets   Object of same form that is returned from get*
   */
  setSelection: function (input, offsets) {
    var start = offsets.start;
    var end = offsets.end;
    if (end === undefined) {
      end = start;
    }

    if ('selectionStart' in input) {
      input.selectionStart = start;
      input.selectionEnd = Math.min(end, input.value.length);
    } else if (document.selection && input.nodeName && input.nodeName.toLowerCase() === 'input') {
      var range = input.createTextRange();
      range.collapse(true);
      range.moveStart('character', start);
      range.moveEnd('character', end - start);
      range.select();
    } else {
      ReactDOMSelection_1.setOffsets(input, offsets);
    }
  }
};

var ReactInputSelection_1 = ReactInputSelection;

var SELECTION_RESTORATION = {
  /**
   * @return {Selection} Selection information.
   */
  initialize: ReactInputSelection_1.getSelectionInformation,
  /**
   * @param {Selection} sel Selection information returned from `initialize`.
   */
  close: ReactInputSelection_1.restoreSelection
};

/**
 * Suppresses events (blur/focus) that could be inadvertently dispatched due to
 * high level DOM manipulations (like temporarily removing a text input from the
 * DOM).
 */
var EVENT_SUPPRESSION = {
  /**
   * @return {boolean} The enabled status of `ReactBrowserEventEmitter` before
   * the reconciliation.
   */
  initialize: function () {
    var currentlyEnabled = ReactBrowserEventEmitter_1.isEnabled();
    ReactBrowserEventEmitter_1.setEnabled(false);
    return currentlyEnabled;
  },

  /**
   * @param {boolean} previouslyEnabled Enabled status of
   *   `ReactBrowserEventEmitter` before the reconciliation occurred. `close`
   *   restores the previous value.
   */
  close: function (previouslyEnabled) {
    ReactBrowserEventEmitter_1.setEnabled(previouslyEnabled);
  }
};

/**
 * Provides a queue for collecting `componentDidMount` and
 * `componentDidUpdate` callbacks during the transaction.
 */
var ON_DOM_READY_QUEUEING = {
  /**
   * Initializes the internal `onDOMReady` queue.
   */
  initialize: function () {
    this.reactMountReady.reset();
  },

  /**
   * After DOM is flushed, invoke all registered `onDOMReady` callbacks.
   */
  close: function () {
    this.reactMountReady.notifyAll();
  }
};

/**
 * Executed within the scope of the `Transaction` instance. Consider these as
 * being member methods, but with an implied ordering while being isolated from
 * each other.
 */
var TRANSACTION_WRAPPERS$3 = [SELECTION_RESTORATION, EVENT_SUPPRESSION, ON_DOM_READY_QUEUEING];

{
  TRANSACTION_WRAPPERS$3.push({
    initialize: ReactInstrumentation$1.debugTool.onBeginFlush,
    close: ReactInstrumentation$1.debugTool.onEndFlush
  });
}

/**
 * Currently:
 * - The order that these are listed in the transaction is critical:
 * - Suppresses events.
 * - Restores selection range.
 *
 * Future:
 * - Restore document/overflow scroll positions that were unintentionally
 *   modified via DOM insertions above the top viewport boundary.
 * - Implement/integrate with customized constraint based layout system and keep
 *   track of which dimensions must be remeasured.
 *
 * @class ReactReconcileTransaction
 */
function ReactReconcileTransaction(useCreateElement) {
  this.reinitializeTransaction();
  // Only server-side rendering really needs this option (see
  // `ReactServerRendering`), but server-side uses
  // `ReactServerRenderingTransaction` instead. This option is here so that it's
  // accessible and defaults to false when `ReactDOMComponent` and
  // `ReactDOMTextComponent` checks it in `mountComponent`.`
  this.renderToStaticMarkup = false;
  this.reactMountReady = CallbackQueue_1.getPooled(null);
  this.useCreateElement = useCreateElement;
}

var Mixin$1 = {
  /**
   * @see Transaction
   * @abstract
   * @final
   * @return {array<object>} List of operation wrap procedures.
   *   TODO: convert to array<TransactionWrapper>
   */
  getTransactionWrappers: function () {
    return TRANSACTION_WRAPPERS$3;
  },

  /**
   * @return {object} The queue to collect `onDOMReady` callbacks with.
   */
  getReactMountReady: function () {
    return this.reactMountReady;
  },

  /**
   * @return {object} The queue to collect React async events.
   */
  getUpdateQueue: function () {
    return ReactUpdateQueue_1;
  },

  /**
   * Save current transaction state -- if the return value from this method is
   * passed to `rollback`, the transaction will be reset to that state.
   */
  checkpoint: function () {
    // reactMountReady is the our only stateful wrapper
    return this.reactMountReady.checkpoint();
  },

  rollback: function (checkpoint) {
    this.reactMountReady.rollback(checkpoint);
  },

  /**
   * `PooledClass` looks for this, and will invoke this before allowing this
   * instance to be reused.
   */
  destructor: function () {
    CallbackQueue_1.release(this.reactMountReady);
    this.reactMountReady = null;
  }
};

index(ReactReconcileTransaction.prototype, Transaction, Mixin$1);

PooledClass_1$2.addPoolingTo(ReactReconcileTransaction);

var ReactReconcileTransaction_1 = ReactReconcileTransaction;

/**
 * Copyright 2013-present, Facebook, Inc.
 * All rights reserved.
 *
 * This source code is licensed under the BSD-style license found in the
 * LICENSE file in the root directory of this source tree. An additional grant
 * of patent rights can be found in the PATENTS file in the same directory.
 *
 */

var NS = {
  xlink: 'http://www.w3.org/1999/xlink',
  xml: 'http://www.w3.org/XML/1998/namespace'
};

// We use attributes for everything SVG so let's avoid some duplication and run
// code instead.
// The following are all specified in the HTML config already so we exclude here.
// - class (as className)
// - color
// - height
// - id
// - lang
// - max
// - media
// - method
// - min
// - name
// - style
// - target
// - type
// - width
var ATTRS = {
  accentHeight: 'accent-height',
  accumulate: 0,
  additive: 0,
  alignmentBaseline: 'alignment-baseline',
  allowReorder: 'allowReorder',
  alphabetic: 0,
  amplitude: 0,
  arabicForm: 'arabic-form',
  ascent: 0,
  attributeName: 'attributeName',
  attributeType: 'attributeType',
  autoReverse: 'autoReverse',
  azimuth: 0,
  baseFrequency: 'baseFrequency',
  baseProfile: 'baseProfile',
  baselineShift: 'baseline-shift',
  bbox: 0,
  begin: 0,
  bias: 0,
  by: 0,
  calcMode: 'calcMode',
  capHeight: 'cap-height',
  clip: 0,
  clipPath: 'clip-path',
  clipRule: 'clip-rule',
  clipPathUnits: 'clipPathUnits',
  colorInterpolation: 'color-interpolation',
  colorInterpolationFilters: 'color-interpolation-filters',
  colorProfile: 'color-profile',
  colorRendering: 'color-rendering',
  contentScriptType: 'contentScriptType',
  contentStyleType: 'contentStyleType',
  cursor: 0,
  cx: 0,
  cy: 0,
  d: 0,
  decelerate: 0,
  descent: 0,
  diffuseConstant: 'diffuseConstant',
  direction: 0,
  display: 0,
  divisor: 0,
  dominantBaseline: 'dominant-baseline',
  dur: 0,
  dx: 0,
  dy: 0,
  edgeMode: 'edgeMode',
  elevation: 0,
  enableBackground: 'enable-background',
  end: 0,
  exponent: 0,
  externalResourcesRequired: 'externalResourcesRequired',
  fill: 0,
  fillOpacity: 'fill-opacity',
  fillRule: 'fill-rule',
  filter: 0,
  filterRes: 'filterRes',
  filterUnits: 'filterUnits',
  floodColor: 'flood-color',
  floodOpacity: 'flood-opacity',
  focusable: 0,
  fontFamily: 'font-family',
  fontSize: 'font-size',
  fontSizeAdjust: 'font-size-adjust',
  fontStretch: 'font-stretch',
  fontStyle: 'font-style',
  fontVariant: 'font-variant',
  fontWeight: 'font-weight',
  format: 0,
  from: 0,
  fx: 0,
  fy: 0,
  g1: 0,
  g2: 0,
  glyphName: 'glyph-name',
  glyphOrientationHorizontal: 'glyph-orientation-horizontal',
  glyphOrientationVertical: 'glyph-orientation-vertical',
  glyphRef: 'glyphRef',
  gradientTransform: 'gradientTransform',
  gradientUnits: 'gradientUnits',
  hanging: 0,
  horizAdvX: 'horiz-adv-x',
  horizOriginX: 'horiz-origin-x',
  ideographic: 0,
  imageRendering: 'image-rendering',
  'in': 0,
  in2: 0,
  intercept: 0,
  k: 0,
  k1: 0,
  k2: 0,
  k3: 0,
  k4: 0,
  kernelMatrix: 'kernelMatrix',
  kernelUnitLength: 'kernelUnitLength',
  kerning: 0,
  keyPoints: 'keyPoints',
  keySplines: 'keySplines',
  keyTimes: 'keyTimes',
  lengthAdjust: 'lengthAdjust',
  letterSpacing: 'letter-spacing',
  lightingColor: 'lighting-color',
  limitingConeAngle: 'limitingConeAngle',
  local: 0,
  markerEnd: 'marker-end',
  markerMid: 'marker-mid',
  markerStart: 'marker-start',
  markerHeight: 'markerHeight',
  markerUnits: 'markerUnits',
  markerWidth: 'markerWidth',
  mask: 0,
  maskContentUnits: 'maskContentUnits',
  maskUnits: 'maskUnits',
  mathematical: 0,
  mode: 0,
  numOctaves: 'numOctaves',
  offset: 0,
  opacity: 0,
  operator: 0,
  order: 0,
  orient: 0,
  orientation: 0,
  origin: 0,
  overflow: 0,
  overlinePosition: 'overline-position',
  overlineThickness: 'overline-thickness',
  paintOrder: 'paint-order',
  panose1: 'panose-1',
  pathLength: 'pathLength',
  patternContentUnits: 'patternContentUnits',
  patternTransform: 'patternTransform',
  patternUnits: 'patternUnits',
  pointerEvents: 'pointer-events',
  points: 0,
  pointsAtX: 'pointsAtX',
  pointsAtY: 'pointsAtY',
  pointsAtZ: 'pointsAtZ',
  preserveAlpha: 'preserveAlpha',
  preserveAspectRatio: 'preserveAspectRatio',
  primitiveUnits: 'primitiveUnits',
  r: 0,
  radius: 0,
  refX: 'refX',
  refY: 'refY',
  renderingIntent: 'rendering-intent',
  repeatCount: 'repeatCount',
  repeatDur: 'repeatDur',
  requiredExtensions: 'requiredExtensions',
  requiredFeatures: 'requiredFeatures',
  restart: 0,
  result: 0,
  rotate: 0,
  rx: 0,
  ry: 0,
  scale: 0,
  seed: 0,
  shapeRendering: 'shape-rendering',
  slope: 0,
  spacing: 0,
  specularConstant: 'specularConstant',
  specularExponent: 'specularExponent',
  speed: 0,
  spreadMethod: 'spreadMethod',
  startOffset: 'startOffset',
  stdDeviation: 'stdDeviation',
  stemh: 0,
  stemv: 0,
  stitchTiles: 'stitchTiles',
  stopColor: 'stop-color',
  stopOpacity: 'stop-opacity',
  strikethroughPosition: 'strikethrough-position',
  strikethroughThickness: 'strikethrough-thickness',
  string: 0,
  stroke: 0,
  strokeDasharray: 'stroke-dasharray',
  strokeDashoffset: 'stroke-dashoffset',
  strokeLinecap: 'stroke-linecap',
  strokeLinejoin: 'stroke-linejoin',
  strokeMiterlimit: 'stroke-miterlimit',
  strokeOpacity: 'stroke-opacity',
  strokeWidth: 'stroke-width',
  surfaceScale: 'surfaceScale',
  systemLanguage: 'systemLanguage',
  tableValues: 'tableValues',
  targetX: 'targetX',
  targetY: 'targetY',
  textAnchor: 'text-anchor',
  textDecoration: 'text-decoration',
  textRendering: 'text-rendering',
  textLength: 'textLength',
  to: 0,
  transform: 0,
  u1: 0,
  u2: 0,
  underlinePosition: 'underline-position',
  underlineThickness: 'underline-thickness',
  unicode: 0,
  unicodeBidi: 'unicode-bidi',
  unicodeRange: 'unicode-range',
  unitsPerEm: 'units-per-em',
  vAlphabetic: 'v-alphabetic',
  vHanging: 'v-hanging',
  vIdeographic: 'v-ideographic',
  vMathematical: 'v-mathematical',
  values: 0,
  vectorEffect: 'vector-effect',
  version: 0,
  vertAdvY: 'vert-adv-y',
  vertOriginX: 'vert-origin-x',
  vertOriginY: 'vert-origin-y',
  viewBox: 'viewBox',
  viewTarget: 'viewTarget',
  visibility: 0,
  widths: 0,
  wordSpacing: 'word-spacing',
  writingMode: 'writing-mode',
  x: 0,
  xHeight: 'x-height',
  x1: 0,
  x2: 0,
  xChannelSelector: 'xChannelSelector',
  xlinkActuate: 'xlink:actuate',
  xlinkArcrole: 'xlink:arcrole',
  xlinkHref: 'xlink:href',
  xlinkRole: 'xlink:role',
  xlinkShow: 'xlink:show',
  xlinkTitle: 'xlink:title',
  xlinkType: 'xlink:type',
  xmlBase: 'xml:base',
  xmlns: 0,
  xmlnsXlink: 'xmlns:xlink',
  xmlLang: 'xml:lang',
  xmlSpace: 'xml:space',
  y: 0,
  y1: 0,
  y2: 0,
  yChannelSelector: 'yChannelSelector',
  z: 0,
  zoomAndPan: 'zoomAndPan'
};

var SVGDOMPropertyConfig = {
  Properties: {},
  DOMAttributeNamespaces: {
    xlinkActuate: NS.xlink,
    xlinkArcrole: NS.xlink,
    xlinkHref: NS.xlink,
    xlinkRole: NS.xlink,
    xlinkShow: NS.xlink,
    xlinkTitle: NS.xlink,
    xlinkType: NS.xlink,
    xmlBase: NS.xml,
    xmlLang: NS.xml,
    xmlSpace: NS.xml
  },
  DOMAttributeNames: {}
};

Object.keys(ATTRS).forEach(function (key) {
  SVGDOMPropertyConfig.Properties[key] = 0;
  if (ATTRS[key]) {
    SVGDOMPropertyConfig.DOMAttributeNames[key] = ATTRS[key];
  }
});

var SVGDOMPropertyConfig_1 = SVGDOMPropertyConfig;

var skipSelectionChangeEvent = ExecutionEnvironment_1.canUseDOM && 'documentMode' in document && document.documentMode <= 11;

var eventTypes$3 = {
  select: {
    phasedRegistrationNames: {
      bubbled: 'onSelect',
      captured: 'onSelectCapture'
    },
    dependencies: ['topBlur', 'topContextMenu', 'topFocus', 'topKeyDown', 'topKeyUp', 'topMouseDown', 'topMouseUp', 'topSelectionChange']
  }
};

var activeElement$1 = null;
var activeElementInst$1 = null;
var lastSelection = null;
var mouseDown = false;

// Track whether a listener exists for this plugin. If none exist, we do
// not extract events. See #3639.
var hasListener = false;

/**
 * Get an object which is a unique representation of the current selection.
 *
 * The return value will not be consistent across nodes or browsers, but
 * two identical selections on the same node will return identical objects.
 *
 * @param {DOMElement} node
 * @return {object}
 */
function getSelection(node) {
  if ('selectionStart' in node && ReactInputSelection_1.hasSelectionCapabilities(node)) {
    return {
      start: node.selectionStart,
      end: node.selectionEnd
    };
  } else if (window.getSelection) {
    var selection = window.getSelection();
    return {
      anchorNode: selection.anchorNode,
      anchorOffset: selection.anchorOffset,
      focusNode: selection.focusNode,
      focusOffset: selection.focusOffset
    };
  } else if (document.selection) {
    var range = document.selection.createRange();
    return {
      parentElement: range.parentElement(),
      text: range.text,
      top: range.boundingTop,
      left: range.boundingLeft
    };
  }
}

/**
 * Poll selection to see whether it's changed.
 *
 * @param {object} nativeEvent
 * @return {?SyntheticEvent}
 */
function constructSelectEvent(nativeEvent, nativeEventTarget) {
  // Ensure we have the right element, and that the user is not dragging a
  // selection (this matches native `select` event behavior). In HTML5, select
  // fires only on input and textarea thus if there's no focused element we
  // won't dispatch.
  if (mouseDown || activeElement$1 == null || activeElement$1 !== getActiveElement_1()) {
    return null;
  }

  // Only fire when selection has actually changed.
  var currentSelection = getSelection(activeElement$1);
  if (!lastSelection || !shallowEqual_1(lastSelection, currentSelection)) {
    lastSelection = currentSelection;

    var syntheticEvent = SyntheticEvent_1.getPooled(eventTypes$3.select, activeElementInst$1, nativeEvent, nativeEventTarget);

    syntheticEvent.type = 'select';
    syntheticEvent.target = activeElement$1;

    EventPropagators_1.accumulateTwoPhaseDispatches(syntheticEvent);

    return syntheticEvent;
  }

  return null;
}

/**
 * This plugin creates an `onSelect` event that normalizes select events
 * across form elements.
 *
 * Supported elements are:
 * - input (see `isTextInputElement`)
 * - textarea
 * - contentEditable
 *
 * This differs from native browser implementations in the following ways:
 * - Fires on contentEditable fields as well as inputs.
 * - Fires for collapsed selection.
 * - Fires after user input.
 */
var SelectEventPlugin = {

  eventTypes: eventTypes$3,

  extractEvents: function (topLevelType, targetInst, nativeEvent, nativeEventTarget) {
    if (!hasListener) {
      return null;
    }

    var targetNode = targetInst ? ReactDOMComponentTree_1.getNodeFromInstance(targetInst) : window;

    switch (topLevelType) {
      // Track the input node that has focus.
      case 'topFocus':
        if (isTextInputElement_1(targetNode) || targetNode.contentEditable === 'true') {
          activeElement$1 = targetNode;
          activeElementInst$1 = targetInst;
          lastSelection = null;
        }
        break;
      case 'topBlur':
        activeElement$1 = null;
        activeElementInst$1 = null;
        lastSelection = null;
        break;

      // Don't fire the event while the user is dragging. This matches the
      // semantics of the native select event.
      case 'topMouseDown':
        mouseDown = true;
        break;
      case 'topContextMenu':
      case 'topMouseUp':
        mouseDown = false;
        return constructSelectEvent(nativeEvent, nativeEventTarget);

      // Chrome and IE fire non-standard event when selection is changed (and
      // sometimes when it hasn't). IE's event fires out of order with respect
      // to key and input events on deletion, so we discard it.
      //
      // Firefox doesn't support selectionchange, so check selection status
      // after each key entry. The selection changes after keydown and before
      // keyup, but we check on keydown as well in the case of holding down a
      // key, when multiple keydown events are fired but only one keyup is.
      // This is also our approach for IE handling, for the reason above.
      case 'topSelectionChange':
        if (skipSelectionChangeEvent) {
          break;
        }
      // falls through
      case 'topKeyDown':
      case 'topKeyUp':
        return constructSelectEvent(nativeEvent, nativeEventTarget);
    }

    return null;
  },

  didPutListener: function (inst, registrationName, listener) {
    if (registrationName === 'onSelect') {
      hasListener = true;
    }
  }
};

var SelectEventPlugin_1 = SelectEventPlugin;

var AnimationEventInterface = {
  animationName: null,
  elapsedTime: null,
  pseudoElement: null
};

/**
 * @param {object} dispatchConfig Configuration used to dispatch this event.
 * @param {string} dispatchMarker Marker identifying the event target.
 * @param {object} nativeEvent Native browser event.
 * @extends {SyntheticEvent}
 */
function SyntheticAnimationEvent(dispatchConfig, dispatchMarker, nativeEvent, nativeEventTarget) {
  return SyntheticEvent_1.call(this, dispatchConfig, dispatchMarker, nativeEvent, nativeEventTarget);
}

SyntheticEvent_1.augmentClass(SyntheticAnimationEvent, AnimationEventInterface);

var SyntheticAnimationEvent_1 = SyntheticAnimationEvent;

var ClipboardEventInterface = {
  clipboardData: function (event) {
    return 'clipboardData' in event ? event.clipboardData : window.clipboardData;
  }
};

/**
 * @param {object} dispatchConfig Configuration used to dispatch this event.
 * @param {string} dispatchMarker Marker identifying the event target.
 * @param {object} nativeEvent Native browser event.
 * @extends {SyntheticUIEvent}
 */
function SyntheticClipboardEvent(dispatchConfig, dispatchMarker, nativeEvent, nativeEventTarget) {
  return SyntheticEvent_1.call(this, dispatchConfig, dispatchMarker, nativeEvent, nativeEventTarget);
}

SyntheticEvent_1.augmentClass(SyntheticClipboardEvent, ClipboardEventInterface);

var SyntheticClipboardEvent_1 = SyntheticClipboardEvent;

var FocusEventInterface = {
  relatedTarget: null
};

/**
 * @param {object} dispatchConfig Configuration used to dispatch this event.
 * @param {string} dispatchMarker Marker identifying the event target.
 * @param {object} nativeEvent Native browser event.
 * @extends {SyntheticUIEvent}
 */
function SyntheticFocusEvent(dispatchConfig, dispatchMarker, nativeEvent, nativeEventTarget) {
  return SyntheticUIEvent_1.call(this, dispatchConfig, dispatchMarker, nativeEvent, nativeEventTarget);
}

SyntheticUIEvent_1.augmentClass(SyntheticFocusEvent, FocusEventInterface);

var SyntheticFocusEvent_1 = SyntheticFocusEvent;

/**
 * Copyright 2013-present, Facebook, Inc.
 * All rights reserved.
 *
 * This source code is licensed under the BSD-style license found in the
 * LICENSE file in the root directory of this source tree. An additional grant
 * of patent rights can be found in the PATENTS file in the same directory.
 *
 */

function getEventCharCode(nativeEvent) {
  var charCode;
  var keyCode = nativeEvent.keyCode;

  if ('charCode' in nativeEvent) {
    charCode = nativeEvent.charCode;

    // FF does not set `charCode` for the Enter-key, check against `keyCode`.
    if (charCode === 0 && keyCode === 13) {
      charCode = 13;
    }
  } else {
    // IE8 does not implement `charCode`, but `keyCode` has the correct value.
    charCode = keyCode;
  }

  // Some non-printable keys are reported in `charCode`/`keyCode`, discard them.
  // Must not discard the (non-)printable Enter-key.
  if (charCode >= 32 || charCode === 13) {
    return charCode;
  }

  return 0;
}

var getEventCharCode_1 = getEventCharCode;

var normalizeKey = {
  'Esc': 'Escape',
  'Spacebar': ' ',
  'Left': 'ArrowLeft',
  'Up': 'ArrowUp',
  'Right': 'ArrowRight',
  'Down': 'ArrowDown',
  'Del': 'Delete',
  'Win': 'OS',
  'Menu': 'ContextMenu',
  'Apps': 'ContextMenu',
  'Scroll': 'ScrollLock',
  'MozPrintableKey': 'Unidentified'
};

/**
 * Translation from legacy `keyCode` to HTML5 `key`
 * Only special keys supported, all others depend on keyboard layout or browser
 * @see https://developer.mozilla.org/en-US/docs/Web/API/KeyboardEvent#Key_names
 */
var translateToKey = {
  8: 'Backspace',
  9: 'Tab',
  12: 'Clear',
  13: 'Enter',
  16: 'Shift',
  17: 'Control',
  18: 'Alt',
  19: 'Pause',
  20: 'CapsLock',
  27: 'Escape',
  32: ' ',
  33: 'PageUp',
  34: 'PageDown',
  35: 'End',
  36: 'Home',
  37: 'ArrowLeft',
  38: 'ArrowUp',
  39: 'ArrowRight',
  40: 'ArrowDown',
  45: 'Insert',
  46: 'Delete',
  112: 'F1', 113: 'F2', 114: 'F3', 115: 'F4', 116: 'F5', 117: 'F6',
  118: 'F7', 119: 'F8', 120: 'F9', 121: 'F10', 122: 'F11', 123: 'F12',
  144: 'NumLock',
  145: 'ScrollLock',
  224: 'Meta'
};

/**
 * @param {object} nativeEvent Native browser event.
 * @return {string} Normalized `key` property.
 */
function getEventKey(nativeEvent) {
  if (nativeEvent.key) {
    // Normalize inconsistent values reported by browsers due to
    // implementations of a working draft specification.

    // FireFox implements `key` but returns `MozPrintableKey` for all
    // printable characters (normalized to `Unidentified`), ignore it.
    var key = normalizeKey[nativeEvent.key] || nativeEvent.key;
    if (key !== 'Unidentified') {
      return key;
    }
  }

  // Browser does not implement `key`, polyfill as much of it as we can.
  if (nativeEvent.type === 'keypress') {
    var charCode = getEventCharCode_1(nativeEvent);

    // The enter-key is technically both printable and non-printable and can
    // thus be captured by `keypress`, no other non-printable key should.
    return charCode === 13 ? 'Enter' : String.fromCharCode(charCode);
  }
  if (nativeEvent.type === 'keydown' || nativeEvent.type === 'keyup') {
    // While user keyboard layout determines the actual meaning of each
    // `keyCode` value, almost all function keys have a universal value.
    return translateToKey[nativeEvent.keyCode] || 'Unidentified';
  }
  return '';
}

var getEventKey_1 = getEventKey;

var KeyboardEventInterface = {
  key: getEventKey_1,
  location: null,
  ctrlKey: null,
  shiftKey: null,
  altKey: null,
  metaKey: null,
  repeat: null,
  locale: null,
  getModifierState: getEventModifierState_1,
  // Legacy Interface
  charCode: function (event) {
    // `charCode` is the result of a KeyPress event and represents the value of
    // the actual printable character.

    // KeyPress is deprecated, but its replacement is not yet final and not
    // implemented in any major browser. Only KeyPress has charCode.
    if (event.type === 'keypress') {
      return getEventCharCode_1(event);
    }
    return 0;
  },
  keyCode: function (event) {
    // `keyCode` is the result of a KeyDown/Up event and represents the value of
    // physical keyboard key.

    // The actual meaning of the value depends on the users' keyboard layout
    // which cannot be detected. Assuming that it is a US keyboard layout
    // provides a surprisingly accurate mapping for US and European users.
    // Due to this, it is left to the user to implement at this time.
    if (event.type === 'keydown' || event.type === 'keyup') {
      return event.keyCode;
    }
    return 0;
  },
  which: function (event) {
    // `which` is an alias for either `keyCode` or `charCode` depending on the
    // type of the event.
    if (event.type === 'keypress') {
      return getEventCharCode_1(event);
    }
    if (event.type === 'keydown' || event.type === 'keyup') {
      return event.keyCode;
    }
    return 0;
  }
};

/**
 * @param {object} dispatchConfig Configuration used to dispatch this event.
 * @param {string} dispatchMarker Marker identifying the event target.
 * @param {object} nativeEvent Native browser event.
 * @extends {SyntheticUIEvent}
 */
function SyntheticKeyboardEvent(dispatchConfig, dispatchMarker, nativeEvent, nativeEventTarget) {
  return SyntheticUIEvent_1.call(this, dispatchConfig, dispatchMarker, nativeEvent, nativeEventTarget);
}

SyntheticUIEvent_1.augmentClass(SyntheticKeyboardEvent, KeyboardEventInterface);

var SyntheticKeyboardEvent_1 = SyntheticKeyboardEvent;

var DragEventInterface = {
  dataTransfer: null
};

/**
 * @param {object} dispatchConfig Configuration used to dispatch this event.
 * @param {string} dispatchMarker Marker identifying the event target.
 * @param {object} nativeEvent Native browser event.
 * @extends {SyntheticUIEvent}
 */
function SyntheticDragEvent(dispatchConfig, dispatchMarker, nativeEvent, nativeEventTarget) {
  return SyntheticMouseEvent_1.call(this, dispatchConfig, dispatchMarker, nativeEvent, nativeEventTarget);
}

SyntheticMouseEvent_1.augmentClass(SyntheticDragEvent, DragEventInterface);

var SyntheticDragEvent_1 = SyntheticDragEvent;

var TouchEventInterface = {
  touches: null,
  targetTouches: null,
  changedTouches: null,
  altKey: null,
  metaKey: null,
  ctrlKey: null,
  shiftKey: null,
  getModifierState: getEventModifierState_1
};

/**
 * @param {object} dispatchConfig Configuration used to dispatch this event.
 * @param {string} dispatchMarker Marker identifying the event target.
 * @param {object} nativeEvent Native browser event.
 * @extends {SyntheticUIEvent}
 */
function SyntheticTouchEvent(dispatchConfig, dispatchMarker, nativeEvent, nativeEventTarget) {
  return SyntheticUIEvent_1.call(this, dispatchConfig, dispatchMarker, nativeEvent, nativeEventTarget);
}

SyntheticUIEvent_1.augmentClass(SyntheticTouchEvent, TouchEventInterface);

var SyntheticTouchEvent_1 = SyntheticTouchEvent;

var TransitionEventInterface = {
  propertyName: null,
  elapsedTime: null,
  pseudoElement: null
};

/**
 * @param {object} dispatchConfig Configuration used to dispatch this event.
 * @param {string} dispatchMarker Marker identifying the event target.
 * @param {object} nativeEvent Native browser event.
 * @extends {SyntheticEvent}
 */
function SyntheticTransitionEvent(dispatchConfig, dispatchMarker, nativeEvent, nativeEventTarget) {
  return SyntheticEvent_1.call(this, dispatchConfig, dispatchMarker, nativeEvent, nativeEventTarget);
}

SyntheticEvent_1.augmentClass(SyntheticTransitionEvent, TransitionEventInterface);

var SyntheticTransitionEvent_1 = SyntheticTransitionEvent;

var WheelEventInterface = {
  deltaX: function (event) {
    return 'deltaX' in event ? event.deltaX :
    // Fallback to `wheelDeltaX` for Webkit and normalize (right is positive).
    'wheelDeltaX' in event ? -event.wheelDeltaX : 0;
  },
  deltaY: function (event) {
    return 'deltaY' in event ? event.deltaY :
    // Fallback to `wheelDeltaY` for Webkit and normalize (down is positive).
    'wheelDeltaY' in event ? -event.wheelDeltaY :
    // Fallback to `wheelDelta` for IE<9 and normalize (down is positive).
    'wheelDelta' in event ? -event.wheelDelta : 0;
  },
  deltaZ: null,

  // Browsers without "deltaMode" is reporting in raw wheel delta where one
  // notch on the scroll is always +/- 120, roughly equivalent to pixels.
  // A good approximation of DOM_DELTA_LINE (1) is 5% of viewport size or
  // ~40 pixels, for DOM_DELTA_SCREEN (2) it is 87.5% of viewport size.
  deltaMode: null
};

/**
 * @param {object} dispatchConfig Configuration used to dispatch this event.
 * @param {string} dispatchMarker Marker identifying the event target.
 * @param {object} nativeEvent Native browser event.
 * @extends {SyntheticMouseEvent}
 */
function SyntheticWheelEvent(dispatchConfig, dispatchMarker, nativeEvent, nativeEventTarget) {
  return SyntheticMouseEvent_1.call(this, dispatchConfig, dispatchMarker, nativeEvent, nativeEventTarget);
}

SyntheticMouseEvent_1.augmentClass(SyntheticWheelEvent, WheelEventInterface);

var SyntheticWheelEvent_1 = SyntheticWheelEvent;

var eventTypes$4 = {};
var topLevelEventsToDispatchConfig = {};
['abort', 'animationEnd', 'animationIteration', 'animationStart', 'blur', 'canPlay', 'canPlayThrough', 'click', 'contextMenu', 'copy', 'cut', 'doubleClick', 'drag', 'dragEnd', 'dragEnter', 'dragExit', 'dragLeave', 'dragOver', 'dragStart', 'drop', 'durationChange', 'emptied', 'encrypted', 'ended', 'error', 'focus', 'input', 'invalid', 'keyDown', 'keyPress', 'keyUp', 'load', 'loadedData', 'loadedMetadata', 'loadStart', 'mouseDown', 'mouseMove', 'mouseOut', 'mouseOver', 'mouseUp', 'paste', 'pause', 'play', 'playing', 'progress', 'rateChange', 'reset', 'scroll', 'seeked', 'seeking', 'stalled', 'submit', 'suspend', 'timeUpdate', 'touchCancel', 'touchEnd', 'touchMove', 'touchStart', 'transitionEnd', 'volumeChange', 'waiting', 'wheel'].forEach(function (event) {
  var capitalizedEvent = event[0].toUpperCase() + event.slice(1);
  var onEvent = 'on' + capitalizedEvent;
  var topEvent = 'top' + capitalizedEvent;

  var type = {
    phasedRegistrationNames: {
      bubbled: onEvent,
      captured: onEvent + 'Capture'
    },
    dependencies: [topEvent]
  };
  eventTypes$4[event] = type;
  topLevelEventsToDispatchConfig[topEvent] = type;
});

var onClickListeners = {};

function getDictionaryKey$1(inst) {
  // Prevents V8 performance issue:
  // https://github.com/facebook/react/pull/7232
  return '.' + inst._rootNodeID;
}

function isInteractive$1(tag) {
  return tag === 'button' || tag === 'input' || tag === 'select' || tag === 'textarea';
}

var SimpleEventPlugin = {

  eventTypes: eventTypes$4,

  extractEvents: function (topLevelType, targetInst, nativeEvent, nativeEventTarget) {
    var dispatchConfig = topLevelEventsToDispatchConfig[topLevelType];
    if (!dispatchConfig) {
      return null;
    }
    var EventConstructor;
    switch (topLevelType) {
      case 'topAbort':
      case 'topCanPlay':
      case 'topCanPlayThrough':
      case 'topDurationChange':
      case 'topEmptied':
      case 'topEncrypted':
      case 'topEnded':
      case 'topError':
      case 'topInput':
      case 'topInvalid':
      case 'topLoad':
      case 'topLoadedData':
      case 'topLoadedMetadata':
      case 'topLoadStart':
      case 'topPause':
      case 'topPlay':
      case 'topPlaying':
      case 'topProgress':
      case 'topRateChange':
      case 'topReset':
      case 'topSeeked':
      case 'topSeeking':
      case 'topStalled':
      case 'topSubmit':
      case 'topSuspend':
      case 'topTimeUpdate':
      case 'topVolumeChange':
      case 'topWaiting':
        // HTML Events
        // @see http://www.w3.org/TR/html5/index.html#events-0
        EventConstructor = SyntheticEvent_1;
        break;
      case 'topKeyPress':
        // Firefox creates a keypress event for function keys too. This removes
        // the unwanted keypress events. Enter is however both printable and
        // non-printable. One would expect Tab to be as well (but it isn't).
        if (getEventCharCode_1(nativeEvent) === 0) {
          return null;
        }
      /* falls through */
      case 'topKeyDown':
      case 'topKeyUp':
        EventConstructor = SyntheticKeyboardEvent_1;
        break;
      case 'topBlur':
      case 'topFocus':
        EventConstructor = SyntheticFocusEvent_1;
        break;
      case 'topClick':
        // Firefox creates a click event on right mouse clicks. This removes the
        // unwanted click events.
        if (nativeEvent.button === 2) {
          return null;
        }
      /* falls through */
      case 'topDoubleClick':
      case 'topMouseDown':
      case 'topMouseMove':
      case 'topMouseUp':
      // TODO: Disabled elements should not respond to mouse events
      /* falls through */
      case 'topMouseOut':
      case 'topMouseOver':
      case 'topContextMenu':
        EventConstructor = SyntheticMouseEvent_1;
        break;
      case 'topDrag':
      case 'topDragEnd':
      case 'topDragEnter':
      case 'topDragExit':
      case 'topDragLeave':
      case 'topDragOver':
      case 'topDragStart':
      case 'topDrop':
        EventConstructor = SyntheticDragEvent_1;
        break;
      case 'topTouchCancel':
      case 'topTouchEnd':
      case 'topTouchMove':
      case 'topTouchStart':
        EventConstructor = SyntheticTouchEvent_1;
        break;
      case 'topAnimationEnd':
      case 'topAnimationIteration':
      case 'topAnimationStart':
        EventConstructor = SyntheticAnimationEvent_1;
        break;
      case 'topTransitionEnd':
        EventConstructor = SyntheticTransitionEvent_1;
        break;
      case 'topScroll':
        EventConstructor = SyntheticUIEvent_1;
        break;
      case 'topWheel':
        EventConstructor = SyntheticWheelEvent_1;
        break;
      case 'topCopy':
      case 'topCut':
      case 'topPaste':
        EventConstructor = SyntheticClipboardEvent_1;
        break;
    }
    !EventConstructor ? invariant_1(false, 'SimpleEventPlugin: Unhandled event type, `%s`.', topLevelType) : void 0;
    var event = EventConstructor.getPooled(dispatchConfig, targetInst, nativeEvent, nativeEventTarget);
    EventPropagators_1.accumulateTwoPhaseDispatches(event);
    return event;
  },

  didPutListener: function (inst, registrationName, listener) {
    // Mobile Safari does not fire properly bubble click events on
    // non-interactive elements, which means delegated click listeners do not
    // fire. The workaround for this bug involves attaching an empty click
    // listener on the target node.
    // http://www.quirksmode.org/blog/archives/2010/09/click_event_del.html
    if (registrationName === 'onClick' && !isInteractive$1(inst._tag)) {
      var key = getDictionaryKey$1(inst);
      var node = ReactDOMComponentTree_1.getNodeFromInstance(inst);
      if (!onClickListeners[key]) {
        onClickListeners[key] = EventListener_1.listen(node, 'click', emptyFunction_1);
      }
    }
  },

  willDeleteListener: function (inst, registrationName) {
    if (registrationName === 'onClick' && !isInteractive$1(inst._tag)) {
      var key = getDictionaryKey$1(inst);
      onClickListeners[key].remove();
      delete onClickListeners[key];
    }
  }

};

var SimpleEventPlugin_1 = SimpleEventPlugin;

var alreadyInjected = false;

function inject() {
  if (alreadyInjected) {
    // TODO: This is currently true because these injections are shared between
    // the client and the server package. They should be built independently
    // and not share any injection state. Then this problem will be solved.
    return;
  }
  alreadyInjected = true;

  ReactInjection_1.EventEmitter.injectReactEventListener(ReactEventListener_1);

  /**
   * Inject modules for resolving DOM hierarchy and plugin ordering.
   */
  ReactInjection_1.EventPluginHub.injectEventPluginOrder(DefaultEventPluginOrder_1);
  ReactInjection_1.EventPluginUtils.injectComponentTree(ReactDOMComponentTree_1);
  ReactInjection_1.EventPluginUtils.injectTreeTraversal(ReactDOMTreeTraversal);

  /**
   * Some important event plugins included by default (without having to require
   * them).
   */
  ReactInjection_1.EventPluginHub.injectEventPluginsByName({
    SimpleEventPlugin: SimpleEventPlugin_1,
    EnterLeaveEventPlugin: EnterLeaveEventPlugin_1,
    ChangeEventPlugin: ChangeEventPlugin_1,
    SelectEventPlugin: SelectEventPlugin_1,
    BeforeInputEventPlugin: BeforeInputEventPlugin_1
  });

  ReactInjection_1.HostComponent.injectGenericComponentClass(ReactDOMComponent_1);

  ReactInjection_1.HostComponent.injectTextComponentClass(ReactDOMTextComponent_1);

  ReactInjection_1.DOMProperty.injectDOMPropertyConfig(ARIADOMPropertyConfig_1);
  ReactInjection_1.DOMProperty.injectDOMPropertyConfig(HTMLDOMPropertyConfig_1);
  ReactInjection_1.DOMProperty.injectDOMPropertyConfig(SVGDOMPropertyConfig_1);

  ReactInjection_1.EmptyComponent.injectEmptyComponentFactory(function (instantiate) {
    return new ReactDOMEmptyComponent_1(instantiate);
  });

  ReactInjection_1.Updates.injectReconcileTransaction(ReactReconcileTransaction_1);
  ReactInjection_1.Updates.injectBatchingStrategy(ReactDefaultBatchingStrategy_1);

  ReactInjection_1.Component.injectEnvironment(ReactComponentBrowserEnvironment_1);
}

var ReactDefaultInjection = {
  inject: inject
};

var DOC_NODE_TYPE$1 = 9;

function ReactDOMContainerInfo(topLevelWrapper, node) {
  var info = {
    _topLevelWrapper: topLevelWrapper,
    _idCounter: 1,
    _ownerDocument: node ? node.nodeType === DOC_NODE_TYPE$1 ? node : node.ownerDocument : null,
    _node: node,
    _tag: node ? node.nodeName.toLowerCase() : null,
    _namespaceURI: node ? node.namespaceURI : null
  };
  {
    info._ancestorInfo = node ? validateDOMNesting_1.updatedAncestorInfo(null, info._tag, null) : null;
  }
  return info;
}

var ReactDOMContainerInfo_1 = ReactDOMContainerInfo;

/**
 * Copyright 2013-present, Facebook, Inc.
 * All rights reserved.
 *
 * This source code is licensed under the BSD-style license found in the
 * LICENSE file in the root directory of this source tree. An additional grant
 * of patent rights can be found in the PATENTS file in the same directory.
 *
 */

var ReactDOMFeatureFlags = {
  useCreateElement: true,
  useFiber: false
};

var ReactDOMFeatureFlags_1 = ReactDOMFeatureFlags;

/**
 * Copyright 2013-present, Facebook, Inc.
 * All rights reserved.
 *
 * This source code is licensed under the BSD-style license found in the
 * LICENSE file in the root directory of this source tree. An additional grant
 * of patent rights can be found in the PATENTS file in the same directory.
 *
 * 
 */

var MOD = 65521;

// adler32 is not cryptographically strong, and is only used to sanity check that
// markup generated on the server matches the markup generated on the client.
// This implementation (a modified version of the SheetJS version) has been optimized
// for our use case, at the expense of conforming to the adler32 specification
// for non-ascii inputs.
function adler32(data) {
  var a = 1;
  var b = 0;
  var i = 0;
  var l = data.length;
  var m = l & ~0x3;
  while (i < m) {
    var n = Math.min(i + 4096, m);
    for (; i < n; i += 4) {
      b += (a += data.charCodeAt(i)) + (a += data.charCodeAt(i + 1)) + (a += data.charCodeAt(i + 2)) + (a += data.charCodeAt(i + 3));
    }
    a %= MOD;
    b %= MOD;
  }
  for (; i < l; i++) {
    b += a += data.charCodeAt(i);
  }
  a %= MOD;
  b %= MOD;
  return a | b << 16;
}

var adler32_1 = adler32;

var TAG_END = /\/?>/;
var COMMENT_START = /^<\!\-\-/;

var ReactMarkupChecksum = {
  CHECKSUM_ATTR_NAME: 'data-react-checksum',

  /**
   * @param {string} markup Markup string
   * @return {string} Markup string with checksum attribute attached
   */
  addChecksumToMarkup: function (markup) {
    var checksum = adler32_1(markup);

    // Add checksum (handle both parent tags, comments and self-closing tags)
    if (COMMENT_START.test(markup)) {
      return markup;
    } else {
      return markup.replace(TAG_END, ' ' + ReactMarkupChecksum.CHECKSUM_ATTR_NAME + '="' + checksum + '"$&');
    }
  },

  /**
   * @param {string} markup to use
   * @param {DOMElement} element root React element
   * @returns {boolean} whether or not the markup is the same
   */
  canReuseMarkup: function (markup, element) {
    var existingChecksum = element.getAttribute(ReactMarkupChecksum.CHECKSUM_ATTR_NAME);
    existingChecksum = existingChecksum && parseInt(existingChecksum, 10);
    var markupChecksum = adler32_1(markup);
    return markupChecksum === existingChecksum;
  }
};

var ReactMarkupChecksum_1 = ReactMarkupChecksum;

var ATTR_NAME$1 = DOMProperty_1.ID_ATTRIBUTE_NAME;
var ROOT_ATTR_NAME = DOMProperty_1.ROOT_ATTRIBUTE_NAME;

var ELEMENT_NODE_TYPE$1 = 1;
var DOC_NODE_TYPE = 9;
var DOCUMENT_FRAGMENT_NODE_TYPE$1 = 11;

var instancesByReactRootID = {};

/**
 * Finds the index of the first character
 * that's not common between the two given strings.
 *
 * @return {number} the index of the character where the strings diverge
 */
function firstDifferenceIndex(string1, string2) {
  var minLen = Math.min(string1.length, string2.length);
  for (var i = 0; i < minLen; i++) {
    if (string1.charAt(i) !== string2.charAt(i)) {
      return i;
    }
  }
  return string1.length === string2.length ? -1 : minLen;
}

/**
 * @param {DOMElement|DOMDocument} container DOM element that may contain
 * a React component
 * @return {?*} DOM element that may have the reactRoot ID, or null.
 */
function getReactRootElementInContainer(container) {
  if (!container) {
    return null;
  }

  if (container.nodeType === DOC_NODE_TYPE) {
    return container.documentElement;
  } else {
    return container.firstChild;
  }
}

function internalGetID(node) {
  // If node is something like a window, document, or text node, none of
  // which support attributes or a .getAttribute method, gracefully return
  // the empty string, as if the attribute were missing.
  return node.getAttribute && node.getAttribute(ATTR_NAME$1) || '';
}

/**
 * Mounts this component and inserts it into the DOM.
 *
 * @param {ReactComponent} componentInstance The instance to mount.
 * @param {DOMElement} container DOM element to mount into.
 * @param {ReactReconcileTransaction} transaction
 * @param {boolean} shouldReuseMarkup If true, do not insert markup
 */
function mountComponentIntoNode(wrapperInstance, container, transaction, shouldReuseMarkup, context) {
  var markerName;
  if (ReactFeatureFlags_1.logTopLevelRenders) {
    var wrappedElement = wrapperInstance._currentElement.props.child;
    var type = wrappedElement.type;
    markerName = 'React mount: ' + (typeof type === 'string' ? type : type.displayName || type.name);
    console.time(markerName);
  }

  var markup = ReactReconciler_1.mountComponent(wrapperInstance, transaction, null, ReactDOMContainerInfo_1(wrapperInstance, container), context, 0 /* parentDebugID */
  );

  if (markerName) {
    console.timeEnd(markerName);
  }

  wrapperInstance._renderedComponent._topLevelWrapper = wrapperInstance;
  ReactMount._mountImageIntoNode(markup, container, wrapperInstance, shouldReuseMarkup, transaction);
}

/**
 * Batched mount.
 *
 * @param {ReactComponent} componentInstance The instance to mount.
 * @param {DOMElement} container DOM element to mount into.
 * @param {boolean} shouldReuseMarkup If true, do not insert markup
 */
function batchedMountComponentIntoNode(componentInstance, container, shouldReuseMarkup, context) {
  var transaction = ReactUpdates_1.ReactReconcileTransaction.getPooled(
  /* useCreateElement */
  !shouldReuseMarkup && ReactDOMFeatureFlags_1.useCreateElement);
  transaction.perform(mountComponentIntoNode, null, componentInstance, container, transaction, shouldReuseMarkup, context);
  ReactUpdates_1.ReactReconcileTransaction.release(transaction);
}

/**
 * Unmounts a component and removes it from the DOM.
 *
 * @param {ReactComponent} instance React component instance.
 * @param {DOMElement} container DOM element to unmount from.
 * @final
 * @internal
 * @see {ReactMount.unmountComponentAtNode}
 */
function unmountComponentFromNode(instance, container, safely) {
  {
    ReactInstrumentation$1.debugTool.onBeginFlush();
  }
  ReactReconciler_1.unmountComponent(instance, safely);
  {
    ReactInstrumentation$1.debugTool.onEndFlush();
  }

  if (container.nodeType === DOC_NODE_TYPE) {
    container = container.documentElement;
  }

  // http://jsperf.com/emptying-a-node
  while (container.lastChild) {
    container.removeChild(container.lastChild);
  }
}

/**
 * True if the supplied DOM node has a direct React-rendered child that is
 * not a React root element. Useful for warning in `render`,
 * `unmountComponentAtNode`, etc.
 *
 * @param {?DOMElement} node The candidate DOM node.
 * @return {boolean} True if the DOM element contains a direct child that was
 * rendered by React but is not a root element.
 * @internal
 */
function hasNonRootReactChild(container) {
  var rootEl = getReactRootElementInContainer(container);
  if (rootEl) {
    var inst = ReactDOMComponentTree_1.getInstanceFromNode(rootEl);
    return !!(inst && inst._hostParent);
  }
}

/**
 * True if the supplied DOM node is a React DOM element and
 * it has been rendered by another copy of React.
 *
 * @param {?DOMElement} node The candidate DOM node.
 * @return {boolean} True if the DOM has been rendered by another copy of React
 * @internal
 */
function nodeIsRenderedByOtherInstance(container) {
  var rootEl = getReactRootElementInContainer(container);
  return !!(rootEl && isReactNode(rootEl) && !ReactDOMComponentTree_1.getInstanceFromNode(rootEl));
}

/**
 * True if the supplied DOM node is a valid node element.
 *
 * @param {?DOMElement} node The candidate DOM node.
 * @return {boolean} True if the DOM is a valid DOM node.
 * @internal
 */
function isValidContainer(node) {
  return !!(node && (node.nodeType === ELEMENT_NODE_TYPE$1 || node.nodeType === DOC_NODE_TYPE || node.nodeType === DOCUMENT_FRAGMENT_NODE_TYPE$1));
}

/**
 * True if the supplied DOM node is a valid React node element.
 *
 * @param {?DOMElement} node The candidate DOM node.
 * @return {boolean} True if the DOM is a valid React DOM node.
 * @internal
 */
function isReactNode(node) {
  return isValidContainer(node) && (node.hasAttribute(ROOT_ATTR_NAME) || node.hasAttribute(ATTR_NAME$1));
}

function getHostRootInstanceInContainer(container) {
  var rootEl = getReactRootElementInContainer(container);
  var prevHostInstance = rootEl && ReactDOMComponentTree_1.getInstanceFromNode(rootEl);
  return prevHostInstance && !prevHostInstance._hostParent ? prevHostInstance : null;
}

function getTopLevelWrapperInContainer(container) {
  var root = getHostRootInstanceInContainer(container);
  return root ? root._hostContainerInfo._topLevelWrapper : null;
}

/**
 * Temporary (?) hack so that we can store all top-level pending updates on
 * composites instead of having to worry about different types of components
 * here.
 */
var topLevelRootCounter = 1;
var TopLevelWrapper = function () {
  this.rootID = topLevelRootCounter++;
};
TopLevelWrapper.prototype.isReactComponent = {};
{
  TopLevelWrapper.displayName = 'TopLevelWrapper';
}
TopLevelWrapper.prototype.render = function () {
  return this.props.child;
};
TopLevelWrapper.isReactTopLevelWrapper = true;

/**
 * Mounting is the process of initializing a React component by creating its
 * representative DOM elements and inserting them into a supplied `container`.
 * Any prior content inside `container` is destroyed in the process.
 *
 *   ReactMount.render(
 *     component,
 *     document.getElementById('container')
 *   );
 *
 *   <div id="container">                   <-- Supplied `container`.
 *     <div data-reactid=".3">              <-- Rendered reactRoot of React
 *       // ...                                 component.
 *     </div>
 *   </div>
 *
 * Inside of `container`, the first element rendered is the "reactRoot".
 */
var ReactMount = {

  TopLevelWrapper: TopLevelWrapper,

  /**
   * Used by devtools. The keys are not important.
   */
  _instancesByReactRootID: instancesByReactRootID,

  /**
   * This is a hook provided to support rendering React components while
   * ensuring that the apparent scroll position of its `container` does not
   * change.
   *
   * @param {DOMElement} container The `container` being rendered into.
   * @param {function} renderCallback This must be called once to do the render.
   */
  scrollMonitor: function (container, renderCallback) {
    renderCallback();
  },

  /**
   * Take a component that's already mounted into the DOM and replace its props
   * @param {ReactComponent} prevComponent component instance already in the DOM
   * @param {ReactElement} nextElement component instance to render
   * @param {DOMElement} container container to render into
   * @param {?function} callback function triggered on completion
   */
  _updateRootComponent: function (prevComponent, nextElement, nextContext, container, callback) {
    ReactMount.scrollMonitor(container, function () {
      ReactUpdateQueue_1.enqueueElementInternal(prevComponent, nextElement, nextContext);
      if (callback) {
        ReactUpdateQueue_1.enqueueCallbackInternal(prevComponent, callback);
      }
    });

    return prevComponent;
  },

  /**
   * Render a new component into the DOM. Hooked by hooks!
   *
   * @param {ReactElement} nextElement element to render
   * @param {DOMElement} container container to render into
   * @param {boolean} shouldReuseMarkup if we should skip the markup insertion
   * @return {ReactComponent} nextComponent
   */
  _renderNewRootComponent: function (nextElement, container, shouldReuseMarkup, context) {
    // Various parts of our code (such as ReactCompositeComponent's
    // _renderValidatedComponent) assume that calls to render aren't nested;
    // verify that that's the case.
    warning_1(ReactCurrentOwner_1.current == null, '_renderNewRootComponent(): Render methods should be a pure function ' + 'of props and state; triggering nested component updates from ' + 'render is not allowed. If necessary, trigger nested updates in ' + 'componentDidUpdate. Check the render method of %s.', ReactCurrentOwner_1.current && ReactCurrentOwner_1.current.getName() || 'ReactCompositeComponent');

    !isValidContainer(container) ? invariant_1(false, '_registerComponent(...): Target container is not a DOM element.') : void 0;

    ReactBrowserEventEmitter_1.ensureScrollValueMonitoring();
    var componentInstance = instantiateReactComponent_1(nextElement, false);

    // The initial render is synchronous but any updates that happen during
    // rendering, in componentWillMount or componentDidMount, will be batched
    // according to the current batching strategy.

    ReactUpdates_1.batchedUpdates(batchedMountComponentIntoNode, componentInstance, container, shouldReuseMarkup, context);

    var wrapperID = componentInstance._instance.rootID;
    instancesByReactRootID[wrapperID] = componentInstance;

    return componentInstance;
  },

  /**
   * Renders a React component into the DOM in the supplied `container`.
   *
   * If the React component was previously rendered into `container`, this will
   * perform an update on it and only mutate the DOM as necessary to reflect the
   * latest React component.
   *
   * @param {ReactComponent} parentComponent The conceptual parent of this render tree.
   * @param {ReactElement} nextElement Component element to render.
   * @param {DOMElement} container DOM element to render into.
   * @param {?function} callback function triggered on completion
   * @return {ReactComponent} Component instance rendered in `container`.
   */
  renderSubtreeIntoContainer: function (parentComponent, nextElement, container, callback) {
    !(parentComponent != null && ReactInstanceMap_1.has(parentComponent)) ? invariant_1(false, 'parentComponent must be a valid React Component') : void 0;
    return ReactMount._renderSubtreeIntoContainer(parentComponent, nextElement, container, callback);
  },

  _renderSubtreeIntoContainer: function (parentComponent, nextElement, container, callback) {
    ReactUpdateQueue_1.validateCallback(callback, 'ReactDOM.render');
    !React_1.isValidElement(nextElement) ? invariant_1(false, 'ReactDOM.render(): Invalid component element.%s', typeof nextElement === 'string' ? ' Instead of passing a string like \'div\', pass ' + 'React.createElement(\'div\') or <div />.' : typeof nextElement === 'function' ? ' Instead of passing a class like Foo, pass ' + 'React.createElement(Foo) or <Foo />.' :
    // Check if it quacks like an element
    nextElement != null && nextElement.props !== undefined ? ' This may be caused by unintentionally loading two independent ' + 'copies of React.' : '') : void 0;

    warning_1(!container || !container.tagName || container.tagName.toUpperCase() !== 'BODY', 'render(): Rendering components directly into document.body is ' + 'discouraged, since its children are often manipulated by third-party ' + 'scripts and browser extensions. This may lead to subtle ' + 'reconciliation issues. Try rendering into a container element created ' + 'for your app.');

    var nextWrappedElement = React_1.createElement(TopLevelWrapper, { child: nextElement });

    var nextContext;
    if (parentComponent) {
      var parentInst = ReactInstanceMap_1.get(parentComponent);
      nextContext = parentInst._processChildContext(parentInst._context);
    } else {
      nextContext = emptyObject_1;
    }

    var prevComponent = getTopLevelWrapperInContainer(container);

    if (prevComponent) {
      var prevWrappedElement = prevComponent._currentElement;
      var prevElement = prevWrappedElement.props.child;
      if (shouldUpdateReactComponent_1(prevElement, nextElement)) {
        var publicInst = prevComponent._renderedComponent.getPublicInstance();
        var updatedCallback = callback && function () {
          callback.call(publicInst);
        };
        ReactMount._updateRootComponent(prevComponent, nextWrappedElement, nextContext, container, updatedCallback);
        return publicInst;
      } else {
        ReactMount.unmountComponentAtNode(container);
      }
    }

    var reactRootElement = getReactRootElementInContainer(container);
    var containerHasReactMarkup = reactRootElement && !!internalGetID(reactRootElement);
    var containerHasNonRootReactChild = hasNonRootReactChild(container);

    {
      warning_1(!containerHasNonRootReactChild, 'render(...): Replacing React-rendered children with a new root ' + 'component. If you intended to update the children of this node, ' + 'you should instead have the existing children update their state ' + 'and render the new components instead of calling ReactDOM.render.');

      if (!containerHasReactMarkup || reactRootElement.nextSibling) {
        var rootElementSibling = reactRootElement;
        while (rootElementSibling) {
          if (internalGetID(rootElementSibling)) {
            warning_1(false, 'render(): Target node has markup rendered by React, but there ' + 'are unrelated nodes as well. This is most commonly caused by ' + 'white-space inserted around server-rendered markup.');
            break;
          }
          rootElementSibling = rootElementSibling.nextSibling;
        }
      }
    }

    var shouldReuseMarkup = containerHasReactMarkup && !prevComponent && !containerHasNonRootReactChild;
    var component = ReactMount._renderNewRootComponent(nextWrappedElement, container, shouldReuseMarkup, nextContext)._renderedComponent.getPublicInstance();
    if (callback) {
      callback.call(component);
    }
    return component;
  },

  /**
   * Renders a React component into the DOM in the supplied `container`.
   * See https://facebook.github.io/react/docs/top-level-api.html#reactdom.render
   *
   * If the React component was previously rendered into `container`, this will
   * perform an update on it and only mutate the DOM as necessary to reflect the
   * latest React component.
   *
   * @param {ReactElement} nextElement Component element to render.
   * @param {DOMElement} container DOM element to render into.
   * @param {?function} callback function triggered on completion
   * @return {ReactComponent} Component instance rendered in `container`.
   */
  render: function (nextElement, container, callback) {
    return ReactMount._renderSubtreeIntoContainer(null, nextElement, container, callback);
  },

  /**
   * Unmounts and destroys the React component rendered in the `container`.
   * See https://facebook.github.io/react/docs/top-level-api.html#reactdom.unmountcomponentatnode
   *
   * @param {DOMElement} container DOM element containing a React component.
   * @return {boolean} True if a component was found in and unmounted from
   *                   `container`
   */
  unmountComponentAtNode: function (container) {
    // Various parts of our code (such as ReactCompositeComponent's
    // _renderValidatedComponent) assume that calls to render aren't nested;
    // verify that that's the case. (Strictly speaking, unmounting won't cause a
    // render but we still don't expect to be in a render call here.)
    warning_1(ReactCurrentOwner_1.current == null, 'unmountComponentAtNode(): Render methods should be a pure function ' + 'of props and state; triggering nested component updates from render ' + 'is not allowed. If necessary, trigger nested updates in ' + 'componentDidUpdate. Check the render method of %s.', ReactCurrentOwner_1.current && ReactCurrentOwner_1.current.getName() || 'ReactCompositeComponent');

    !isValidContainer(container) ? invariant_1(false, 'unmountComponentAtNode(...): Target container is not a DOM element.') : void 0;

    {
      warning_1(!nodeIsRenderedByOtherInstance(container), 'unmountComponentAtNode(): The node you\'re attempting to unmount ' + 'was rendered by another copy of React.');
    }

    var prevComponent = getTopLevelWrapperInContainer(container);
    if (!prevComponent) {
      // Check if the node being unmounted was rendered by React, but isn't a
      // root node.
      var containerHasNonRootReactChild = hasNonRootReactChild(container);

      // Check if the container itself is a React root node.
      var isContainerReactRoot = container.nodeType === 1 && container.hasAttribute(ROOT_ATTR_NAME);

      {
        warning_1(!containerHasNonRootReactChild, 'unmountComponentAtNode(): The node you\'re attempting to unmount ' + 'was rendered by React and is not a top-level container. %s', isContainerReactRoot ? 'You may have accidentally passed in a React root node instead ' + 'of its container.' : 'Instead, have the parent component update its state and ' + 'rerender in order to remove this component.');
      }

      return false;
    }
    delete instancesByReactRootID[prevComponent._instance.rootID];
    ReactUpdates_1.batchedUpdates(unmountComponentFromNode, prevComponent, container, false);
    return true;
  },

  _mountImageIntoNode: function (markup, container, instance, shouldReuseMarkup, transaction) {
    !isValidContainer(container) ? invariant_1(false, 'mountComponentIntoNode(...): Target container is not valid.') : void 0;

    if (shouldReuseMarkup) {
      var rootElement = getReactRootElementInContainer(container);
      if (ReactMarkupChecksum_1.canReuseMarkup(markup, rootElement)) {
        ReactDOMComponentTree_1.precacheNode(instance, rootElement);
        return;
      } else {
        var checksum = rootElement.getAttribute(ReactMarkupChecksum_1.CHECKSUM_ATTR_NAME);
        rootElement.removeAttribute(ReactMarkupChecksum_1.CHECKSUM_ATTR_NAME);

        var rootMarkup = rootElement.outerHTML;
        rootElement.setAttribute(ReactMarkupChecksum_1.CHECKSUM_ATTR_NAME, checksum);

        var normalizedMarkup = markup;
        {
          // because rootMarkup is retrieved from the DOM, various normalizations
          // will have occurred which will not be present in `markup`. Here,
          // insert markup into a <div> or <iframe> depending on the container
          // type to perform the same normalizations before comparing.
          var normalizer;
          if (container.nodeType === ELEMENT_NODE_TYPE$1) {
            normalizer = document.createElement('div');
            normalizer.innerHTML = markup;
            normalizedMarkup = normalizer.innerHTML;
          } else {
            normalizer = document.createElement('iframe');
            document.body.appendChild(normalizer);
            normalizer.contentDocument.write(markup);
            normalizedMarkup = normalizer.contentDocument.documentElement.outerHTML;
            document.body.removeChild(normalizer);
          }
        }

        var diffIndex = firstDifferenceIndex(normalizedMarkup, rootMarkup);
        var difference = ' (client) ' + normalizedMarkup.substring(diffIndex - 20, diffIndex + 20) + '\n (server) ' + rootMarkup.substring(diffIndex - 20, diffIndex + 20);

        !(container.nodeType !== DOC_NODE_TYPE) ? invariant_1(false, 'You\'re trying to render a component to the document using server rendering but the checksum was invalid. This usually means you rendered a different component type or props on the client from the one on the server, or your render() methods are impure. React cannot handle this case due to cross-browser quirks by rendering at the document root. You should look for environment dependent code in your components and ensure the props are the same client and server side:\n%s', difference) : void 0;

        {
          warning_1(false, 'React attempted to reuse markup in a container but the ' + 'checksum was invalid. This generally means that you are ' + 'using server rendering and the markup generated on the ' + 'server was not what the client was expecting. React injected ' + 'new markup to compensate which works but you have lost many ' + 'of the benefits of server rendering. Instead, figure out ' + 'why the markup being generated is different on the client ' + 'or server:\n%s', difference);
        }
      }
    }

    !(container.nodeType !== DOC_NODE_TYPE) ? invariant_1(false, 'You\'re trying to render a component to the document but you didn\'t use server rendering. We can\'t do this without using server rendering due to cross-browser quirks. See ReactDOMServer.renderToString() for server rendering.') : void 0;

    if (transaction.useCreateElement) {
      while (container.lastChild) {
        container.removeChild(container.lastChild);
      }
      DOMLazyTree_1.insertTreeBefore(container, markup, null);
    } else {
      setInnerHTML_1(container, markup);
      ReactDOMComponentTree_1.precacheNode(instance, container.firstChild);
    }

    {
      var hostNode = ReactDOMComponentTree_1.getInstanceFromNode(container.firstChild);
      if (hostNode._debugID !== 0) {
        ReactInstrumentation$1.debugTool.onHostOperation({
          instanceID: hostNode._debugID,
          type: 'mount',
          payload: markup.toString()
        });
      }
    }
  }
};

var ReactMount_1 = ReactMount;

/**
 * Copyright 2013-present, Facebook, Inc.
 * All rights reserved.
 *
 * This source code is licensed under the BSD-style license found in the
 * LICENSE file in the root directory of this source tree. An additional grant
 * of patent rights can be found in the PATENTS file in the same directory.
 *
 */

var ReactVersion$3 = '15.5.4';

function getHostComponentFromComposite(inst) {
  var type;

  while ((type = inst._renderedNodeType) === ReactNodeTypes_1.COMPOSITE) {
    inst = inst._renderedComponent;
  }

  if (type === ReactNodeTypes_1.HOST) {
    return inst._renderedComponent;
  } else if (type === ReactNodeTypes_1.EMPTY) {
    return null;
  }
}

var getHostComponentFromComposite_1 = getHostComponentFromComposite;

function findDOMNode(componentOrElement) {
  {
    var owner = ReactCurrentOwner_1.current;
    if (owner !== null) {
      warning_1(owner._warnedAboutRefsInRender, '%s is accessing findDOMNode inside its render(). ' + 'render() should be a pure function of props and state. It should ' + 'never access something that requires stale data from the previous ' + 'render, such as refs. Move this logic to componentDidMount and ' + 'componentDidUpdate instead.', owner.getName() || 'A component');
      owner._warnedAboutRefsInRender = true;
    }
  }
  if (componentOrElement == null) {
    return null;
  }
  if (componentOrElement.nodeType === 1) {
    return componentOrElement;
  }

  var inst = ReactInstanceMap_1.get(componentOrElement);
  if (inst) {
    inst = getHostComponentFromComposite_1(inst);
    return inst ? ReactDOMComponentTree_1.getNodeFromInstance(inst) : null;
  }

  if (typeof componentOrElement.render === 'function') {
    invariant_1(false, 'findDOMNode was called on an unmounted component.');
  } else {
    invariant_1(false, 'Element appears to be neither ReactComponent nor DOMNode (keys: %s)', Object.keys(componentOrElement));
  }
}

var findDOMNode_1 = findDOMNode;

var renderSubtreeIntoContainer = ReactMount_1.renderSubtreeIntoContainer;

{
  var reactProps = {
    children: true,
    dangerouslySetInnerHTML: true,
    key: true,
    ref: true,

    autoFocus: true,
    defaultValue: true,
    valueLink: true,
    defaultChecked: true,
    checkedLink: true,
    innerHTML: true,
    suppressContentEditableWarning: true,
    onFocusIn: true,
    onFocusOut: true
  };
  var warnedProperties = {};

  var validateProperty = function (tagName, name, debugID) {
    if (DOMProperty_1.properties.hasOwnProperty(name) || DOMProperty_1.isCustomAttribute(name)) {
      return true;
    }
    if (reactProps.hasOwnProperty(name) && reactProps[name] || warnedProperties.hasOwnProperty(name) && warnedProperties[name]) {
      return true;
    }
    if (EventPluginRegistry_1.registrationNameModules.hasOwnProperty(name)) {
      return true;
    }
    warnedProperties[name] = true;
    var lowerCasedName = name.toLowerCase();

    // data-* attributes should be lowercase; suggest the lowercase version
    var standardName = DOMProperty_1.isCustomAttribute(lowerCasedName) ? lowerCasedName : DOMProperty_1.getPossibleStandardName.hasOwnProperty(lowerCasedName) ? DOMProperty_1.getPossibleStandardName[lowerCasedName] : null;

    var registrationName = EventPluginRegistry_1.possibleRegistrationNames.hasOwnProperty(lowerCasedName) ? EventPluginRegistry_1.possibleRegistrationNames[lowerCasedName] : null;

    if (standardName != null) {
      warning_1(false, 'Unknown DOM property %s. Did you mean %s?%s', name, standardName, ReactComponentTreeHook_1.getStackAddendumByID(debugID));
      return true;
    } else if (registrationName != null) {
      warning_1(false, 'Unknown event handler property %s. Did you mean `%s`?%s', name, registrationName, ReactComponentTreeHook_1.getStackAddendumByID(debugID));
      return true;
    } else {
      // We were unable to guess which prop the user intended.
      // It is likely that the user was just blindly spreading/forwarding props
      // Components should be careful to only render valid props/attributes.
      // Warning will be invoked in warnUnknownProperties to allow grouping.
      return false;
    }
  };
}

var warnUnknownProperties = function (debugID, element) {
  var unknownProps = [];
  for (var key in element.props) {
    var isValid = validateProperty(element.type, key, debugID);
    if (!isValid) {
      unknownProps.push(key);
    }
  }

  var unknownPropString = unknownProps.map(function (prop) {
    return '`' + prop + '`';
  }).join(', ');

  if (unknownProps.length === 1) {
    warning_1(false, 'Unknown prop %s on <%s> tag. Remove this prop from the element. ' + 'For details, see https://fb.me/react-unknown-prop%s', unknownPropString, element.type, ReactComponentTreeHook_1.getStackAddendumByID(debugID));
  } else if (unknownProps.length > 1) {
    warning_1(false, 'Unknown props %s on <%s> tag. Remove these props from the element. ' + 'For details, see https://fb.me/react-unknown-prop%s', unknownPropString, element.type, ReactComponentTreeHook_1.getStackAddendumByID(debugID));
  }
};

function handleElement(debugID, element) {
  if (element == null || typeof element.type !== 'string') {
    return;
  }
  if (element.type.indexOf('-') >= 0 || element.props.is) {
    return;
  }
  warnUnknownProperties(debugID, element);
}

var ReactDOMUnknownPropertyHook$1 = {
  onBeforeMountComponent: function (debugID, element) {
    handleElement(debugID, element);
  },
  onBeforeUpdateComponent: function (debugID, element) {
    handleElement(debugID, element);
  }
};

var ReactDOMUnknownPropertyHook_1 = ReactDOMUnknownPropertyHook$1;

var didWarnValueNull = false;

function handleElement$1(debugID, element) {
  if (element == null) {
    return;
  }
  if (element.type !== 'input' && element.type !== 'textarea' && element.type !== 'select') {
    return;
  }
  if (element.props != null && element.props.value === null && !didWarnValueNull) {
    warning_1(false, '`value` prop on `%s` should not be null. ' + 'Consider using the empty string to clear the component or `undefined` ' + 'for uncontrolled components.%s', element.type, ReactComponentTreeHook_1.getStackAddendumByID(debugID));

    didWarnValueNull = true;
  }
}

var ReactDOMNullInputValuePropHook$1 = {
  onBeforeMountComponent: function (debugID, element) {
    handleElement$1(debugID, element);
  },
  onBeforeUpdateComponent: function (debugID, element) {
    handleElement$1(debugID, element);
  }
};

var ReactDOMNullInputValuePropHook_1 = ReactDOMNullInputValuePropHook$1;

var warnedProperties$1 = {};
var rARIA = new RegExp('^(aria)-[' + DOMProperty_1.ATTRIBUTE_NAME_CHAR + ']*$');

function validateProperty$1(tagName, name, debugID) {
  if (warnedProperties$1.hasOwnProperty(name) && warnedProperties$1[name]) {
    return true;
  }

  if (rARIA.test(name)) {
    var lowerCasedName = name.toLowerCase();
    var standardName = DOMProperty_1.getPossibleStandardName.hasOwnProperty(lowerCasedName) ? DOMProperty_1.getPossibleStandardName[lowerCasedName] : null;

    // If this is an aria-* attribute, but is not listed in the known DOM
    // DOM properties, then it is an invalid aria-* attribute.
    if (standardName == null) {
      warnedProperties$1[name] = true;
      return false;
    }
    // aria-* attributes should be lowercase; suggest the lowercase version.
    if (name !== standardName) {
      warning_1(false, 'Unknown ARIA attribute %s. Did you mean %s?%s', name, standardName, ReactComponentTreeHook_1.getStackAddendumByID(debugID));
      warnedProperties$1[name] = true;
      return true;
    }
  }

  return true;
}

function warnInvalidARIAProps(debugID, element) {
  var invalidProps = [];

  for (var key in element.props) {
    var isValid = validateProperty$1(element.type, key, debugID);
    if (!isValid) {
      invalidProps.push(key);
    }
  }

  var unknownPropString = invalidProps.map(function (prop) {
    return '`' + prop + '`';
  }).join(', ');

  if (invalidProps.length === 1) {
    warning_1(false, 'Invalid aria prop %s on <%s> tag. ' + 'For details, see https://fb.me/invalid-aria-prop%s', unknownPropString, element.type, ReactComponentTreeHook_1.getStackAddendumByID(debugID));
  } else if (invalidProps.length > 1) {
    warning_1(false, 'Invalid aria props %s on <%s> tag. ' + 'For details, see https://fb.me/invalid-aria-prop%s', unknownPropString, element.type, ReactComponentTreeHook_1.getStackAddendumByID(debugID));
  }
}

function handleElement$2(debugID, element) {
  if (element == null || typeof element.type !== 'string') {
    return;
  }
  if (element.type.indexOf('-') >= 0 || element.props.is) {
    return;
  }

  warnInvalidARIAProps(debugID, element);
}

var ReactDOMInvalidARIAHook$1 = {
  onBeforeMountComponent: function (debugID, element) {
    {
      handleElement$2(debugID, element);
    }
  },
  onBeforeUpdateComponent: function (debugID, element) {
    {
      handleElement$2(debugID, element);
    }
  }
};

var ReactDOMInvalidARIAHook_1 = ReactDOMInvalidARIAHook$1;

ReactDefaultInjection.inject();

var ReactDOM = {
  findDOMNode: findDOMNode_1,
  render: ReactMount_1.render,
  unmountComponentAtNode: ReactMount_1.unmountComponentAtNode,
  version: ReactVersion$3,

  /* eslint-disable camelcase */
  unstable_batchedUpdates: ReactUpdates_1.batchedUpdates,
  unstable_renderSubtreeIntoContainer: renderSubtreeIntoContainer
};

// Inject the runtime into a devtools global hook regardless of browser.
// Allows for debugging when the hook is injected on the page.
if (typeof __REACT_DEVTOOLS_GLOBAL_HOOK__ !== 'undefined' && typeof __REACT_DEVTOOLS_GLOBAL_HOOK__.inject === 'function') {
  __REACT_DEVTOOLS_GLOBAL_HOOK__.inject({
    ComponentTree: {
      getClosestInstanceFromNode: ReactDOMComponentTree_1.getClosestInstanceFromNode,
      getNodeFromInstance: function (inst) {
        // inst is an internal instance (but could be a composite)
        if (inst._renderedComponent) {
          inst = getHostComponentFromComposite_1(inst);
        }
        if (inst) {
          return ReactDOMComponentTree_1.getNodeFromInstance(inst);
        } else {
          return null;
        }
      }
    },
    Mount: ReactMount_1,
    Reconciler: ReactReconciler_1
  });
}

{
  var ExecutionEnvironment = ExecutionEnvironment_1;
  if (ExecutionEnvironment.canUseDOM && window.top === window.self) {

    // First check if devtools is not installed
    if (typeof __REACT_DEVTOOLS_GLOBAL_HOOK__ === 'undefined') {
      // If we're in Chrome or Firefox, provide a download link if not installed.
      if (navigator.userAgent.indexOf('Chrome') > -1 && navigator.userAgent.indexOf('Edge') === -1 || navigator.userAgent.indexOf('Firefox') > -1) {
        // Firefox does not have the issue with devtools loaded over file://
        var showFileUrlMessage = window.location.protocol.indexOf('http') === -1 && navigator.userAgent.indexOf('Firefox') === -1;
        console.debug('Download the React DevTools ' + (showFileUrlMessage ? 'and use an HTTP server (instead of a file: URL) ' : '') + 'for a better development experience: ' + 'https://fb.me/react-devtools');
      }
    }

    var testFunc = function testFn() {};
    warning_1((testFunc.name || testFunc.toString()).indexOf('testFn') !== -1, 'It looks like you\'re using a minified copy of the development build ' + 'of React. When deploying React apps to production, make sure to use ' + 'the production build which skips development warnings and is faster. ' + 'See https://fb.me/react-minification for more details.');

    // If we're in IE8, check to see if we are in compatibility mode and provide
    // information on preventing compatibility mode
    var ieCompatibilityMode = document.documentMode && document.documentMode < 8;

    warning_1(!ieCompatibilityMode, 'Internet Explorer is running in compatibility mode; please add the ' + 'following tag to your HTML to prevent this from happening: ' + '<meta http-equiv="X-UA-Compatible" content="IE=edge" />');

    var expectedFeatures = [
    // shims
    Array.isArray, Array.prototype.every, Array.prototype.forEach, Array.prototype.indexOf, Array.prototype.map, Date.now, Function.prototype.bind, Object.keys, String.prototype.trim];

    for (var i = 0; i < expectedFeatures.length; i++) {
      if (!expectedFeatures[i]) {
        warning_1(false, 'One or more ES5 shims expected by React are not available: ' + 'https://fb.me/react-warning-polyfills');
        break;
      }
    }
  }
}

{
  var ReactInstrumentation = ReactInstrumentation$1;
  var ReactDOMUnknownPropertyHook = ReactDOMUnknownPropertyHook_1;
  var ReactDOMNullInputValuePropHook = ReactDOMNullInputValuePropHook_1;
  var ReactDOMInvalidARIAHook = ReactDOMInvalidARIAHook_1;

  ReactInstrumentation.debugTool.addHook(ReactDOMUnknownPropertyHook);
  ReactInstrumentation.debugTool.addHook(ReactDOMNullInputValuePropHook);
  ReactInstrumentation.debugTool.addHook(ReactDOMInvalidARIAHook);
}

var ReactDOM_1 = ReactDOM;

var index$2 = ReactDOM_1;

var index_1 = index$2.render;

const Components = function (__exports) {
  const LazyView = __exports.LazyView = class LazyView extends react_2 {
    [FSymbol.reflection]() {
      return extendInfo(LazyView, {
        type: "Elmish.React.Components.LazyView",
        interfaces: [],
        properties: {}
      });
    }

    constructor(props) {
      super(props);
    }

    shouldComponentUpdate(nextProps, nextState, nextContext) {
      return !this.props.equal(this.props.model, nextProps.model);
    }

    render() {
      return this.props.render();
    }

  };
  setType("Elmish.React.Components.LazyView", LazyView);
  return __exports;
}({});
const Common = function (__exports) {
  const lazyViewWith = __exports.lazyViewWith = function (equal, view, state) {
    return react_1(Components.LazyView, (() => {
      const render = function () {
        return view(state);
      };

      return {
        model: state,
        render: render,
        equal: equal
      };
    })());
  };

  const lazyView2With = __exports.lazyView2With = function (equal, view, state, dispatch) {
    return react_1(Components.LazyView, (() => {
      const render = function () {
        return view(state, dispatch);
      };

      return {
        model: state,
        render: render,
        equal: equal
      };
    })());
  };

  const lazyView3With = __exports.lazyView3With = function (equal, view, state1, state2, dispatch) {
    return react_1(Components.LazyView, (() => {
      const render = function () {
        return view(state1, state2, dispatch);
      };

      return {
        model: [state1, state2],
        render: render,
        equal: equal
      };
    })());
  };

  const lazyView = __exports.lazyView = function (view) {
    const equal = function (x, y) {
      return equals(x, y);
    };

    return function (state) {
      return lazyViewWith(equal, view, state);
    };
  };

  const lazyView2 = __exports.lazyView2 = function (view) {
    const equal = function (x, y) {
      return equals(x, y);
    };

    return function (state, dispatch) {
      return lazyView2With(equal, view, state, dispatch);
    };
  };

  const lazyView3 = __exports.lazyView3 = function (view) {
    const equal = function (x, y) {
      return equals(x, y);
    };

    return function (state1, state2, dispatch) {
      return lazyView3With(equal, view, state1, state2, dispatch);
    };
  };

  return __exports;
}({});

function withReact(placeholderId, program) {
  let lastRequest = null;

  const setState = function (model, dispatch) {
    if (lastRequest != null) {
      const r = lastRequest;
      window.cancelAnimationFrame(r);
    }

    lastRequest = window.requestAnimationFrame(function (_arg1) {
      index_1(Common.lazyView2With(function (x, y) {
        return x === y;
      }, program.view, model, dispatch), document.getElementById(placeholderId));
    });
  };

  return new Program(program.init, program.update, program.subscribe, program.view, setState, program.onError);
}

class Observer {
    constructor(onNext, onError, onCompleted) {
        this.OnNext = onNext;
        this.OnError = onError || ((e) => { return; });
        this.OnCompleted = onCompleted || (() => { return; });
    }
    [FSymbol.reflection]() {
        return { interfaces: ["System.IObserver"] };
    }
}

function add$5(callback, source) {
    source.Subscribe(new Observer(callback));
}

class Event {
    constructor(_subscriber, delegates) {
        this._subscriber = _subscriber;
        this.delegates = delegates || new Array();
    }
    Add(f) {
        this._addHandler(f);
    }
    // IEvent<T> methods
    get Publish() {
        return this;
    }
    Trigger(value) {
        iterate$1((f) => f(value), this.delegates);
    }
    // IDelegateEvent<T> methods
    AddHandler(handler) {
        if (this._dotnetDelegates == null) {
            this._dotnetDelegates = new Map();
        }
        const f = (x) => handler(null, x);
        this._dotnetDelegates.set(handler, f);
        this._addHandler(f);
    }
    RemoveHandler(handler) {
        if (this._dotnetDelegates != null) {
            const f = this._dotnetDelegates.get(handler);
            if (f != null) {
                this._dotnetDelegates.delete(handler);
                this._removeHandler(f);
            }
        }
    }
    // IObservable<T> methods
    Subscribe(arg) {
        return typeof arg === "function"
            ? this._subscribeFromCallback(arg)
            : this._subscribeFromObserver(arg);
    }
    _addHandler(f) {
        this.delegates.push(f);
    }
    _removeHandler(f) {
        const index = this.delegates.indexOf(f);
        if (index > -1) {
            this.delegates.splice(index, 1);
        }
    }
    _subscribeFromObserver(observer) {
        if (this._subscriber) {
            return this._subscriber(observer);
        }
        const callback = observer.OnNext;
        this._addHandler(callback);
        return createDisposable(() => this._removeHandler(callback));
    }
    _subscribeFromCallback(callback) {
        this._addHandler(callback);
        return createDisposable(() => this._removeHandler(callback));
    }
}

class NotificationProgramEvent {
  constructor(notif) {
    this.notif = notif;
  }

  [FSymbol.reflection]() {
    return {
      type: "Elmish.Bulma.Elements.Notification.NotificationProgramEvent",
      interfaces: ["FSharpRecord", "System.IEquatable"],
      properties: {
        notif: Interface("Fable.Import.React.ReactElement")
      }
    };
  }

  Equals(other) {
    return equalsRecords(this, other);
  }

}
setType("Elmish.Bulma.Elements.Notification.NotificationProgramEvent", NotificationProgramEvent);
class Notification {
  constructor(id, view) {
    this.id = id | 0;
    this.view = view;
  }

  [FSymbol.reflection]() {
    return {
      type: "Elmish.Bulma.Elements.Notification.Notification",
      interfaces: ["FSharpRecord", "System.IEquatable"],
      properties: {
        id: "number",
        view: Interface("Fable.Import.React.ReactElement")
      }
    };
  }

  Equals(other) {
    return equalsRecords(this, other);
  }

}
setType("Elmish.Bulma.Elements.Notification.Notification", Notification);
class Notifiable {
  constructor(tag, data) {
    this.tag = tag;
    this.data = data;
  }

  [FSymbol.reflection]() {
    return {
      type: "Elmish.Bulma.Elements.Notification.Notifiable",
      interfaces: ["FSharpUnion", "System.IEquatable"],
      cases: [["AddNewNotification", Interface("Fable.Import.React.ReactElement")], ["UserMsg", GenericParam("msg")]]
    };
  }

  Equals(other) {
    return this === other || this.tag === other.tag && equals(this.data, other.data);
  }

}
setType("Elmish.Bulma.Elements.Notification.Notifiable", Notifiable);
class NotificationModel {
  constructor(notifications, userModel) {
    this.notifications = notifications;
    this.userModel = userModel;
  }

  [FSymbol.reflection]() {
    return {
      type: "Elmish.Bulma.Elements.Notification.NotificationModel",
      interfaces: ["FSharpRecord", "System.IEquatable"],
      properties: {
        notifications: makeGeneric(List$1, {
          T: Notification
        }),
        userModel: GenericParam("model")
      }
    };
  }

  Equals(other) {
    return equalsRecords(this, other);
  }

}
setType("Elmish.Bulma.Elements.Notification.NotificationModel", NotificationModel);
class Option$1 {
  constructor(tag, data) {
    this.tag = tag;
    this.data = data;
  }

  [FSymbol.reflection]() {
    return {
      type: "Elmish.Bulma.Elements.Notification.Option",
      interfaces: ["FSharpUnion", "System.IEquatable", "System.IComparable"],
      cases: [["Level", ILevelAndColor], ["Closable"]]
    };
  }

  Equals(other) {
    return this === other || this.tag === other.tag && equals(this.data, other.data);
  }

  CompareTo(other) {
    return compareUnions(this, other) | 0;
  }

}
setType("Elmish.Bulma.Elements.Notification.Option", Option$1);
class Options {
  constructor(level, hasDeleteButton) {
    this.level = level;
    this.hasDeleteButton = hasDeleteButton;
  }

  [FSymbol.reflection]() {
    return {
      type: "Elmish.Bulma.Elements.Notification.Options",
      interfaces: ["FSharpRecord", "System.IEquatable", "System.IComparable"],
      properties: {
        level: ILevelAndColor,
        hasDeleteButton: "boolean"
      }
    };
  }

  Equals(other) {
    return equalsRecords(this, other);
  }

  CompareTo(other) {
    return compareRecords(this, other) | 0;
  }

  static get Empty() {
    return new Options(new ILevelAndColor(9), false);
  }

}
setType("Elmish.Bulma.Elements.Notification.Options", Options);
function notification(options, properties, children) {
  const parseOptions = function (options_1, result) {
    if (options_1.tail == null) {
      return result;
    } else {
      return ($var1 => parseOptions(options_1.tail, $var1))(options_1.head.tag === 1 ? new Options(result.level, true) : new Options(options_1.head.data, result.hasDeleteButton));
    }
  };

  const opts = parseOptions(options, Options.Empty);
  const closeArea = toList(delay(function () {
    return opts.hasDeleteButton ? singleton$1(react_1("button", {
      className: "delete"
    })) : empty();
  }));
  const className = new Props.HTMLAttr(22, "notification " + opts.level);
  return react_1("div", createObj(new List$1(className, properties), 1), ...append(closeArea, children));
}
function defaultNotificationArea(notifications) {
  return react_1("div", createObj(ofArray([["style", {
    position: "fixed",
    width: 500,
    top: 55,
    right: 25,
    zIndex: 100
  }]]), 1), ...map(function (x) {
    return x.view;
  }, notifications));
}
const onNotificationEvent = new Event();
const Cmd$1 = function (__exports) {
  const NotifiedEvent = __exports.NotifiedEvent = "NotifiedEvent";

  const newNotification = __exports.newNotification = function (notif) {
    return ofArray([function (_arg1) {
      onNotificationEvent.Trigger(new NotificationProgramEvent(notif));
    }]);
  };

  return __exports;
}({});
const Program$1 = function (__exports) {
  const toNotifiable = __exports.toNotifiable = function (notificationArea, program) {
    const map$$1 = function (tupledArg) {
      return [tupledArg[0], Cmd.map(function (arg0) {
        return new Notifiable(1, arg0);
      }, tupledArg[1])];
    };

    const update = function (msg, model) {
      if (msg.tag === 0) {
        const notification_1 = new Notification((() => {
          let copyOfStruct = now();
          return millisecond(copyOfStruct) | 0;
        })(), msg.data);
        return [new NotificationModel(new List$1(notification_1, model.notifications), model.userModel), new List$1()];
      } else {
        const patternInput = program.update(msg.data, model.userModel);
        return [new NotificationModel(model.notifications, patternInput[0]), Cmd.map(function (arg0_1) {
          return new Notifiable(1, arg0_1);
        }, patternInput[1])];
      }
    };

    const view = function (model_1, dispatch) {
      return react_1("div", {}, notificationArea(model_1.notifications), program.view(model_1.userModel, $var2 => dispatch(function (arg0_2) {
        return new Notifiable(1, arg0_2);
      }($var2))));
    };

    const newNotificationRecieved = function (dispatch_1) {
      add$5(function (evt) {
        dispatch_1(new Notifiable(0, evt.notif));
      }, onNotificationEvent.Publish);
    };

    const subs = function (model_2) {
      return Cmd.batch(ofArray([ofArray([newNotificationRecieved]), Cmd.map(function (arg0_3) {
        return new Notifiable(1, arg0_3);
      }, program.subscribe(model_2.userModel))]));
    };

    const init = function (args) {
      const patternInput_1 = program.init(args);
      return [new NotificationModel(new List$1(), patternInput_1[0]), Cmd.batch(ofArray([Cmd.map(function (arg0_4) {
        return new Notifiable(1, arg0_4);
      }, patternInput_1[1])]))];
    };

    const setState = function (model_3) {
      return $var4 => function (value) {
        value;
      }(($var3 => view(model_3, $var3))($var4));
    };

    return new Program(init, update, subs, view, ($var5, $var6) => setState($var5)($var6), program.onError);
  };

  return __exports;
}({});

class Navigable {
  constructor(tag, data) {
    this.tag = tag;
    this.data = data;
  }

  [FSymbol.reflection]() {
    return {
      type: "Elmish.Browser.Navigation.Navigable",
      interfaces: ["FSharpUnion", "System.IEquatable"],
      cases: [["Change", Interface("Fable.Import.Browser.Location")], ["UserMsg", GenericParam("msg")]]
    };
  }

  Equals(other) {
    return this === other || this.tag === other.tag && equals(this.data, other.data);
  }

}
setType("Elmish.Browser.Navigation.Navigable", Navigable);
const Navigation = function (__exports) {
  const NavigatedEvent = __exports.NavigatedEvent = "NavigatedEvent";

  const modifyUrl = __exports.modifyUrl = function (newUrl) {
    return ofArray([function (_arg1) {
      history.replaceState(null, "", newUrl);
    }]);
  };

  const newUrl = __exports.newUrl = function (newUrl_1) {
    return ofArray([function (_arg1) {
      history.pushState(null, "", newUrl_1);
      const ev = document.createEvent("CustomEvent");
      ev.initCustomEvent("NavigatedEvent", true, true, {});
      window.dispatchEvent(ev);
    }]);
  };

  const jump = __exports.jump = function (n) {
    return ofArray([function (_arg1) {
      history.go(n);
    }]);
  };

  return __exports;
}({});
const ProgramModule$1 = function (__exports) {
  const toNavigable = __exports.toNavigable = function (parser, urlUpdate, program) {
    const map$$1 = function (tupledArg) {
      return [tupledArg[0], Cmd.map(function (arg0) {
        return new Navigable(1, arg0);
      }, tupledArg[1])];
    };

    const update = function (msg, model) {
      return map$$1(msg.tag === 1 ? program.update(msg.data, model) : urlUpdate(parser(msg.data), model));
    };

    const locationChanges = function (dispatch) {
      let lastLocation = null;

      const onChange = function (_arg1) {
        return (() => {
          const $var1 = lastLocation != null ? (() => {
            const href = lastLocation;
            return href === window.location.href;
          })() ? [0, lastLocation] : [1] : [1];

          switch ($var1[0]) {
            case 0:
              break;

            case 1:
              lastLocation = window.location.href;
              dispatch(new Navigable(0, window.location));
              break;
          }
        })();
      };

      window.addEventListener("popstate", onChange);
      window.addEventListener("hashchange", onChange);
      window.addEventListener("NavigatedEvent", onChange);
    };

    const subs = function (model_1) {
      return Cmd.batch(ofArray([ofArray([locationChanges]), Cmd.map(function (arg0_1) {
        return new Navigable(1, arg0_1);
      }, program.subscribe(model_1))]));
    };

    const init = function () {
      return map$$1(program.init(parser(window.location)));
    };

    const setState = function (model_2, dispatch_1) {
      program.setState(model_2, $var2 => dispatch_1(function (arg0_2) {
        return new Navigable(1, arg0_2);
      }($var2)));
    };

    return new Program(init, update, subs, function (model_3, dispatch_2) {
      return program.view(model_3, $var3 => dispatch_2(function (arg0_3) {
        return new Navigable(1, arg0_3);
      }($var3)));
    }, setState, program.onError);
  };

  return __exports;
}({});

function tuple(a, b) {
  const matchValue = [a, b];
  const $var1 = matchValue[0] != null ? matchValue[1] != null ? [0, matchValue[0], matchValue[1]] : [1] : [1];

  switch ($var1[0]) {
    case 0:
      return [$var1[1], $var1[2]];

    case 1:
      return null;
  }
}
function ofFunc(f, arg) {
  try {
    return f(arg);
  } catch (matchValue) {
    return null;
  }
}

class State {
  constructor(visited, unvisited, args, value) {
    this.visited = visited;
    this.unvisited = unvisited;
    this.args = args;
    this.value = value;
  }

  [FSymbol.reflection]() {
    return {
      type: "Elmish.Browser.UrlParser.State",
      interfaces: ["FSharpRecord", "System.IEquatable", "System.IComparable"],
      properties: {
        visited: makeGeneric(List$1, {
          T: "string"
        }),
        unvisited: makeGeneric(List$1, {
          T: "string"
        }),
        args: makeGeneric(FableMap, {
          Key: "string",
          Value: "string"
        }),
        value: GenericParam("v")
      }
    };
  }

  Equals(other) {
    return equalsRecords(this, other);
  }

  CompareTo(other) {
    return compareRecords(this, other) | 0;
  }

}
setType("Elmish.Browser.UrlParser.State", State);
const StateModule = function (__exports) {
  const mkState = __exports.mkState = function (visited, unvisited, args, value) {
    return new State(visited, unvisited, args, value);
  };

  const map$$1 = __exports.map = function (f, _arg1) {
    return new State(_arg1.visited, _arg1.unvisited, _arg1.args, f(_arg1.value));
  };

  return __exports;
}({});



function s(str_1) {
  const inner = function (_arg1) {
    if (_arg1.unvisited.tail != null) {
      if (_arg1.unvisited.head === str_1) {
        return ofArray([StateModule.mkState(new List$1(_arg1.unvisited.head, _arg1.visited), _arg1.unvisited.tail, _arg1.args, _arg1.value)]);
      } else {
        return new List$1();
      }
    } else {
      return new List$1();
    }
  };

  return inner;
}

function map_1(subValue, parse$$1) {
  const inner = function (_arg1) {
    return map(function (arg10_) {
      return StateModule.map(_arg1.value, arg10_);
    }, parse$$1(new State(_arg1.visited, _arg1.unvisited, _arg1.args, subValue)));
  };

  return inner;
}

function oneOf(parsers, state) {
  return collect(function (parser) {
    return parser(state);
  }, parsers);
}
function top(state) {
  return ofArray([state]);
}




function parseHelp(states) {
  parseHelp: while (true) {
    if (states.tail != null) {
      const $var2 = states.head.unvisited.tail != null ? states.head.unvisited.head === "" ? states.head.unvisited.tail.tail == null ? [1] : [2] : [2] : [0];

      switch ($var2[0]) {
        case 0:
          return states.head.value;

        case 1:
          return states.head.value;

        case 2:
          states = states.tail;
          continue parseHelp;
      }
    } else {
      return null;
    }
  }
}
function splitUrl(url) {
  const matchValue = ofArray(split(url, "/"));
  const $var3 = matchValue.tail != null ? matchValue.head === "" ? [0, matchValue.tail] : [1, matchValue] : [1, matchValue];

  switch ($var3[0]) {
    case 0:
      return $var3[1];

    case 1:
      return $var3[1];
  }
}
function parse$3(parser, url, args) {
  return parseHelp(parser(new State(new List$1(), splitUrl(url), args, function (x) {
    return x;
  })));
}
function toKeyValuePair(segment) {
  const matchValue = split(segment, "=");

  if (matchValue.length === 2) {
    const value = matchValue[1];
    const key = matchValue[0];
    return tuple(ofFunc(decodeURI, key), ofFunc(decodeURI, value));
  } else {
    return null;
  }
}
function parseParams(querystring) {
  return create(choose$1(function (x) {
    return x;
  }, function (source) {
    return map$2(function (segment) {
      return toKeyValuePair(segment);
    }, source);
  }(split(querystring.substr(1), "&"))), new Comparer(comparePrimitives));
}

function parseHash(parser, location) {
  let patternInput;
  const hash$$1 = location.hash.substr(1);

  if (hash$$1.indexOf("?") >= 0) {
    const h = hash$$1.substr(0, hash$$1.indexOf("?"));
    patternInput = [h, hash$$1.substr(h.length)];
  } else {
    patternInput = [hash$$1, "?"];
  }

  return parse$3(parser, patternInput[0], parseParams(patternInput[1]));
}

function init$1() {
  return ["", new List$1()];
}
function update$1(msg, model) {
  return [msg.data, new List$1()];
}

function init$2() {
  return new Model$1("\r\n# Buttons\r\nThe **button** can have different colors, sizes and states.\r\n      ", "\r\n```fsharp\r\nButton.button [ Button.isWhite ] [ str \"White\" ]\r\nButton.button [ Button.isDark ] [ str \"Dark\" ]\r\nButton.button [ Button.isInfo ] [ str \"Info\" ]\r\nButton.button [ Button.isSuccess ] [ str \"Success\" ]\r\n```\r\n      ", "## Sizes", "\r\n```fsharp\r\nButton.button [ ] [ str \"Normal\" ]\r\nButton.button [ Button.isMedium ] [ str \"Medium\" ]\r\n```\r\n      ", "\r\n## Styles\r\nThe button can be **outlined** and/or **inverted**.\r\n      ", "\r\n```fsharp\r\nButton.button [ Button.isSuccess; Button.isOutlined ] [str \"Outlined\" ]\r\nButton.button [ Button.isPrimary; Button.isOutlined ] [ str \"Outlined\" ]\r\n```\r\n      ", "\r\n```fsharp\r\nButton.button [ Button.isSuccess; Button.isInverted ] [ str \"Inverted\" ]\r\nButton.button [ Button.isPrimary; Button.isInverted ] [ str \"Inverted\" ]\r\n```\r\n      ", "\r\n```fsharp\r\nButton.button\r\n  [ Button.isSuccess;\r\n    Button.isOutlined;\r\n    Button.isInverted ] [ str \"Invert outlined\" ]\r\n```\r\n      ", "\r\n## State\r\nYou can control the state of the buttons.\r\n      ", "\r\n```fsharp\r\nButton.button [ Button.isSuccess ] [ str \"Normal\" ]\r\nButton.button [ Button.isHovered; Button.isSuccess ] [ str \"Hover\" ]\r\nButton.button [ Button.isFocused; Button.isSuccess ] [ str \"Hover\" ]\r\nButton.button [ Button.isActive; Button.isSuccess ] [ str \"Hover\" ]\r\nButton.button [ Button.isLoading; dButton.isSuccess ] [ str \"Hover\" ]\r\n```\r\n      ");
}

function init$3() {
  return new Model$2("\r\n# Icons\r\n      ", "\r\n```fsharp\r\nIcon.icon\r\n  [ Icon.isSmall ]\r\n  [ i [ ClassName \"fa fa-home\" ] [ ] ]\r\nIcon.icon\r\n  [  ]\r\n  [ i [ ClassName \"fa fa-home\" ] [ ] ]\r\nIcon.icon\r\n  [ Icon.isMedium ]\r\n  [ i [ ClassName \"fa fa-home\" ] [ ] ]\r\nIcon.icon\r\n  [ Icon.isLarge ]\r\n  [ i [ ClassName \"fa fa-home\" ] [ ] ]\r\n```\r\n      ");
}

function init$4() {
  return new Model$3("\r\n# Image\r\nA container for **responsive** images\r\n      ", "## Fixed square images", "\r\n```fsharp\r\nImage.image\r\n  [ Image.is64x64 ]\r\n  [ img\r\n      [ Src \"https://dummyimage.com/64x64/7a7a7a/fff\" ] ]\r\nImage.image\r\n  [ Image.is128x128 ]\r\n  [ img\r\n      [ Src \"https://dummyimage.com/128x128/7a7a7a/fff\" ] ]\r\n```\r\n      ", "## Responsive images with ratios", "\r\n```fsharp\r\nImage.image\r\n  [ Image.is2by1 ]\r\n  [ img\r\n      [ Src \"https://dummyimage.com/640x320/7a7a7a/fff\" ] ]\r\n```\r\n      ");
}

function init$5() {
  return new Model$4("\r\n# Progress bars\r\nProgress bars can have **colors** or **sizes** modifiers\r\n      ", "\r\n```fsharp\r\nProgress.progress\r\n  [ Progress.isSuccess\r\n    Progress.isSmall\r\n    Progress.props\r\n      [ Value !^\"15\"\r\n        Max !^\"100\" ] ]\r\n  [ str \"15%\" ]\r\nProgress.progress\r\n  [ Progress.isPrimary\r\n    Progress.isMedium\r\n    Progress.props\r\n      [ Value !^\"85\"\r\n        Max !^\"100\" ] ]\r\n  [ str \"85%\" ]\r\nProgress.progress\r\n  [ Progress.isDanger\r\n    Progress.isLarge\r\n    Progress.props\r\n      [ Value !^\"50\"\r\n        Max !^\"100\" ] ]\r\n  [ str \"50%\" ]\r\n```\r\n      ");
}

function init$6() {
  return new Model$6("\r\n# Buttons\r\nThe **button** can have different colors, sizes and states.\r\n      ", "\r\n```fsharp\r\nButton.button [ Button.isWhite ] [ str \"White\" ]\r\nButton.button [ Button.isDark ] [ str \"Dark\" ]\r\nButton.button [ Button.isInfo ] [ str \"Info\" ]\r\nButton.button [ Button.isSuccess ] [ str \"Success\" ]\r\n```\r\n      ", "## Sizes", "\r\n```fsharp\r\nButton.button [ ] [ str \"Normal\" ]\r\nButton.button [ Button.isMedium ] [ str \"Medium\" ]\r\n```\r\n      ", "\r\n## Styles\r\nThe button can be **outlined** and/or **inverted**.\r\n      ", "\r\n```fsharp\r\nButton.button [ Button.isSuccess; Button.isOutlined ] [str \"Outlined\" ]\r\nButton.button [ Button.isPrimary; Button.isOutlined ] [ str \"Outlined\" ]\r\n```\r\n      ", "\r\n```fsharp\r\nButton.button [ Button.isSuccess; Button.isInverted ] [ str \"Inverted\" ]\r\nButton.button [ Button.isPrimary; Button.isInverted ] [ str \"Inverted\" ]\r\n```\r\n      ", "\r\n```fsharp\r\nButton.button [ Button.isSuccess; Button.isOutlined; Button.isInverted ] [ str \"Invert outlined\" ]\r\n```\r\n      ", "\r\n## State\r\nYou can control the state of the buttons.\r\n      ", "\r\n```fsharp\r\nButton.button [ Button.isSuccess ] [ str \"Normal\" ]\r\nButton.button [ Button.isHovered; Button.isSuccess ] [ str \"Hover\" ]\r\nButton.button [ Button.isFocused; Button.isSuccess ] [ str \"Hover\" ]\r\nButton.button [ Button.isActive; Button.isSuccess ] [ str \"Hover\" ]\r\nButton.button [ Button.isLoading; Button.isSuccess ] [ str \"Hover\" ]\r\n```\r\n      ");
}

function init$7() {
  return new Model$5("\r\n# Table\r\n            ", "\r\n```fsharp\r\n  Table.table\r\n    [ ]\r\n    [ thead\r\n        [ ]\r\n        [ tr\r\n            [ ]\r\n            [ th [ ] [ str \"Firstname\" ]\r\n              th [ ] [ str \"Surname\" ]\r\n              th [ ] [ str \"Birthday\" ] ] ]\r\n      tbody\r\n        [ ]\r\n        [ tr\r\n            [ ]\r\n            [ td [ ] [ str \"Maxime\" ]\r\n              td [ ] [ str \"Mangel\" ]\r\n              td [ ] [ str \"28/02/1992\" ] ]\r\n          tr\r\n            [ Table.Row.isSelected ]\r\n            [ td [ ] [ str \"Jane\" ]\r\n              td [ ] [ str \"Doe\" ]\r\n              td [ ] [ str \"21/07/1987\" ] ]\r\n          tr\r\n            [  ]\r\n            [ td [ ] [ str \"John\" ]\r\n              td [ ] [ str \"Doe\" ]\r\n              td [ ] [ str \"11/07/1978\" ] ] ]\r\n```\r\n            ", "\r\n## Modifiers\r\nYou can also apply modifiers to the table\r\n            ", "\r\n```fsharp\r\n  Table.table\r\n    [ Table.isBordered\r\n      Table.isNarrow\r\n      Table.isStripped ]\r\n    [ thead\r\n        [ ]\r\n        [ tr\r\n            [ ]\r\n            [ th [ ] [ str \"Firstname\" ]\r\n              th [ ] [ str \"Surname\" ]\r\n              th [ ] [ str \"Birthday\" ] ] ]\r\n      tbody\r\n        [ ]\r\n        [ tr\r\n            [ ]\r\n            [ td [ ] [ str \"Maxime\" ]\r\n              td [ ] [ str \"Mangel\" ]\r\n              td [ ] [ str \"28/02/1992\" ] ]\r\n          tr\r\n            [ Table.Row.isSelected ]\r\n            [ td [ ] [ str \"Jane\" ]\r\n              td [ ] [ str \"Doe\" ]\r\n              td [ ] [ str \"21/07/1987\" ] ]\r\n          tr\r\n            [  ]\r\n            [ td [ ] [ str \"John\" ]\r\n              td [ ] [ str \"Doe\" ]\r\n              td [ ] [ str \"11/07/1978\" ] ] ]\r\n```\r\n            ");
}

function init$8() {
  return new Model$7("\r\n# Titles\r\nSimple **headings** to add depth to your page\r\n          ", "\r\n## Types\r\n**Title** can be of two types *Title* and *Subtitle*.\r\n            ", "\r\n```fsharp\r\nHeading.h1 [ ] [str \"Title\"]\r\nbr []\r\nHeading.h3 [ Heading.isSubtitle ] [str \"Subtitle\"]\r\n```\r\n            ", "\r\n## Sizes\r\nThere can be **six** different sizes for title\r\n            ", "\r\n```fsharp\r\nHeading.h1 [ Heading.isTitle; Heading.is1 ] [str \"Title 1\"]\r\nHeading.h1 [ Heading.isTitle; Heading.is2 ] [str \"Title 2\"]\r\nHeading.h1 [ Heading.isTitle; Heading.is3 ] [str \"Title 3 (Default size)\"]\r\nHeading.h1 [ Heading.isTitle; Heading.is4 ] [str \"Title 4\"]\r\nHeading.h1 [ Heading.isTitle; Heading.is5 ] [str \"Title 5\"]\r\nHeading.h1 [ Heading.isTitle; Heading.is6 ] [str \"Title 6\"]\r\nbr []\r\nHeading.h1 [ Heading.isSubtitle; Heading.is1 ] [str \"Subtitle 1\"]\r\nHeading.h1 [ Heading.isSubtitle; Heading.is2 ] [str \"Subtitle 2\"]\r\nHeading.h1 [ Heading.isSubtitle; Heading.is3 ] [str \"Subtitle 3\"]\r\nHeading.h1 [ Heading.isSubtitle; Heading.is4 ] [str \"Subtitle 4\"]\r\nHeading.h1 [ Heading.isSubtitle; Heading.is5 ] [str \"Subtitle 5 (Default size)\"]\r\nHeading.h1 [ Heading.isSubtitle; Heading.is6 ] [str \"Subtitle 6\"]\r\n```\r\n            ", "\r\nWhen **conbining** a title and a subtile, they move closer together.\r\n\r\nYou can prevent this behavior by adding `IsSpaced` on the first element.\r\n          ", "\r\n```fsharp\r\nHeading.p [ Heading.isTitle; Heading.is1; Heading.isSpaced ] [ str \"Title 1\" ]\r\nHeading.p [ Heading.isSubtitle; Heading.is3 ] [ str \"Subtitle 3\" ]\r\n```\r\n        ");
}

function init$9() {
  return new Model$8("\r\n# Delete\r\n      ", "\r\n```fsharp\r\nDelete.delete\r\n  [ Delete.isSmall ] [ ]\r\nDelete.delete\r\n  [ ] [ ]\r\nDelete.delete\r\n  [ Delete.isMedium ] [ ]\r\nDelete.delete\r\n  [ Delete.isLarge ] [ ]\r\n```\r\n      ");
}

function init$10() {
  return new Model$9("\r\n# Box\r\n      ", "\r\n```fsharp\r\n\r\n// Example\r\nbox' [\r\n      str\r\n          \"Lorem ipsum dolor sit amet, consectetur adipisicing elit\r\n          , sed do eiusmod tempor incididunt ut labore et dolore\r\n          magna aliqua.\r\n          \"\r\n      ]\r\n```\r\n      ");
}

function init$11() {
  return new Model$10("\r\n# Content\r\n\r\nA single class to handle WYSIWYG generated content, where only **HTML tags** are available.\r\n      ", "\r\n## Sizes\r\n        ", "\r\n```fsharp\r\n  // Normal size\r\n  Content.content\r\n    [] []\r\n    [ h1 [] [str \"Hello World\"]\r\n      ..... ]\r\n\r\n  // Small size\r\n  Content.content\r\n    [ Content.isSmall ] []\r\n    [ h1 [] [str \"Hello World\"]\r\n      ..... ]\r\n\r\n  // Medium size\r\n  Content.content\r\n    [ Content.isMedium ] []\r\n    [ h1 [] [str \"Hello World\"]\r\n      ..... ]\r\n\r\n  // Large size\r\n  Content.content\r\n    [ Content.isLarge ] []\r\n    [ h1 [] [str \"Hello World\"]\r\n      ..... ]\r\n```\r\n    ");
}

function init$12() {
  return new Model$11("\r\n# Tags\r\n            ", "\r\n```fsharp\r\n//Example\r\ntag [] [] [str \"Tag label\"]\r\n```\r\n            ", "\r\n## Colors\r\n            ", "\r\n```fsharp\r\nTag.tag [ Tag.isBlack ] [ str \"Black\" ]\r\nTag.tag [ Tag.isDark ] [ str \"Dark\" ]\r\nTag.tag [ Tag.isLight ] [ str \"Light\" ]\r\nTag.tag [ Tag.isWhite ] [ str \"White\" ]\r\nTag.tag [ Tag.isPrimary ] [ str \"Primary\"]\r\nTag.tag [ Tag.isInfo ] [ str \"Info\" ]\r\nTag.tag [ Tag.isSuccess ] [ str \"Success\" ]\r\nTag.tag [ Tag.isWarning ] [ str \"Warning\" ]\r\nTag.tag [ Tag.isDanger ] [ str \"Danger\" ]\r\n```\r\n            ", "\r\n## Sizes\r\n            ", "\r\n```fsharp\r\nTag.tag [ Tag.isSuccess; Tag.isMedium ] [ str \"Medium\" ]\r\nTag.tag [ Tag.isInfo; Tag.isLarge ] [ str \"Large\" ]\r\n```\r\n            ");
}

const pageParser = (() => {
  const parsers = ofArray([map_1(new Page(0), s("home")), map_1(new Page(1, new Elements(0)), (() => {
    const parseBefore = s("elements");
    const parseAfter = s("button");
    return function (state) {
      return collect(parseAfter, parseBefore(state));
    };
  })()), map_1(new Page(1, new Elements(1)), (() => {
    const parseBefore_1 = s("elements");
    const parseAfter_1 = s("icon");
    return function (state_1) {
      return collect(parseAfter_1, parseBefore_1(state_1));
    };
  })()), map_1(new Page(1, new Elements(2)), (() => {
    const parseBefore_2 = s("elements");
    const parseAfter_2 = s("title");
    return function (state_2) {
      return collect(parseAfter_2, parseBefore_2(state_2));
    };
  })()), map_1(new Page(1, new Elements(3)), (() => {
    const parseBefore_3 = s("elements");
    const parseAfter_3 = s("delete");
    return function (state_3) {
      return collect(parseAfter_3, parseBefore_3(state_3));
    };
  })()), map_1(new Page(1, new Elements(4)), (() => {
    const parseBefore_4 = s("elements");
    const parseAfter_4 = s("box");
    return function (state_4) {
      return collect(parseAfter_4, parseBefore_4(state_4));
    };
  })()), map_1(new Page(1, new Elements(5)), (() => {
    const parseBefore_5 = s("elements");
    const parseAfter_5 = s("content");
    return function (state_5) {
      return collect(parseAfter_5, parseBefore_5(state_5));
    };
  })()), map_1(new Page(1, new Elements(6)), (() => {
    const parseBefore_6 = s("elements");
    const parseAfter_6 = s("tag");
    return function (state_6) {
      return collect(parseAfter_6, parseBefore_6(state_6));
    };
  })()), map_1(new Page(1, new Elements(7)), (() => {
    const parseBefore_7 = s("elements");
    const parseAfter_7 = s("image");
    return function (state_7) {
      return collect(parseAfter_7, parseBefore_7(state_7));
    };
  })()), map_1(new Page(1, new Elements(8)), (() => {
    const parseBefore_8 = s("elements");
    const parseAfter_8 = s("progress");
    return function (state_8) {
      return collect(parseAfter_8, parseBefore_8(state_8));
    };
  })()), map_1(new Page(1, new Elements(9)), (() => {
    const parseBefore_9 = s("elements");
    const parseAfter_9 = s("table");
    return function (state_9) {
      return collect(parseAfter_9, parseBefore_9(state_9));
    };
  })()), map_1(new Page(1, new Elements(10)), (() => {
    const parseBefore_10 = s("elements");
    const parseAfter_10 = s("form");
    return function (state_10) {
      return collect(parseAfter_10, parseBefore_10(state_10));
    };
  })()), map_1(new Page(0), function (state_11) {
    return top(state_11);
  })]);
  return function (state_12) {
    return oneOf(parsers, state_12);
  };
})();
function urlUpdate(result, model) {
  if (result != null) {
    return [new Model(result, model.home, model.elements), new List$1()];
  } else {
    console.error("Error parsing url");
    return [model, Navigation.modifyUrl(toHash(model.currentPage))];
  }
}
function init(result) {
  const patternInput = init$1();
  let elements;
  const button = init$2();
  const icon = init$3();
  const image = init$4();
  const progress = init$5();
  const form = init$6();
  elements = new ElementsModel(button, icon, image, progress, init$7(), form, init$8(), init$9(), init$10(), init$11(), init$12());
  const patternInput_1 = urlUpdate(result, new Model(new Page(0), patternInput[0], elements));
  return [patternInput_1[0], Cmd.batch(ofArray([patternInput_1[1], Cmd.map(function (arg0) {
    return new Msg$1(0, arg0);
  }, patternInput[1])]))];
}
function update(msg, model) {
  if (msg.tag === 1) {
    return [model, Cmd$1.newNotification(notification(new List$1(), new List$1(), ofArray(["coucou"])))];
  } else if (msg.tag === 2) {
    console.log("couocuo");
    return [model, new List$1()];
  } else {
    const patternInput = update$1(msg.data, model.home);
    return [new Model(model.currentPage, patternInput[0], model.elements), Cmd.map(function (arg0) {
      return new Msg$1(0, arg0);
    }, patternInput[1])];
  }
}

const options = {
  highlight: function (code) {
    return Prism.highlight(code, Prism.languages.fsharp);
  },
  langPrefix: "language-"
};
marked.setOptions(options);
function menuItem(label, page, currentPage) {
  return react_1("li", {}, react_1("a", createObj(ofArray([classList(ofArray([["is-active", page.Equals(currentPage)]])), new Props.HTMLAttr(51, toHash(page))]), 1), label));
}
function menu(currentPage) {
  return react_1("aside", {
    className: "menu"
  }, react_1("p", {
    className: "menu-label"
  }, "General"), react_1("ul", {
    className: "menu-list"
  }, menuItem("Home", new Page(0), currentPage), menuItem("Button", new Page(1, new Elements(0)), currentPage), menuItem("Icon", new Page(1, new Elements(1)), currentPage), menuItem("Image", new Page(1, new Elements(7)), currentPage), menuItem("Title", new Page(1, new Elements(2)), currentPage), menuItem("Delete", new Page(1, new Elements(3)), currentPage), menuItem("Progress", new Page(1, new Elements(8)), currentPage), menuItem("Box", new Page(1, new Elements(4)), currentPage), menuItem("Content", new Page(1, new Elements(5)), currentPage), menuItem("Table", new Page(1, new Elements(9)), currentPage), menuItem("Form", new Page(1, new Elements(10)), currentPage), menuItem("Tag", new Page(1, new Elements(6)), currentPage)));
}
const header = react_1("div", {
  className: "hero is-primary"
}, react_1("div", {
  className: "hero-body"
}, react_1("div", {
  className: "column has-text-centered"
}, react_1("h2", {
  className: "subtitle"
}, "Binding for Elmish using Bulma CSS framework"))));
function root(model, dispatch) {
  const pageHtml = function (_arg1) {
    if (_arg1.tag === 1) {
      if (_arg1.data.tag === 1) {
        return root$1(model.elements.icon);
      } else if (_arg1.data.tag === 2) {
        return root$2(model.elements.title);
      } else if (_arg1.data.tag === 3) {
        return root$3(model.elements.delete);
      } else if (_arg1.data.tag === 4) {
        return root$4(model.elements.box);
      } else if (_arg1.data.tag === 5) {
        return root$5(model.elements.content);
      } else if (_arg1.data.tag === 6) {
        return root$6(model.elements.tag);
      } else if (_arg1.data.tag === 7) {
        return root$7(model.elements.image);
      } else if (_arg1.data.tag === 8) {
        return root$8(model.elements.progress);
      } else if (_arg1.data.tag === 9) {
        return root$9(model.elements.table);
      } else if (_arg1.data.tag === 10) {
        return root$10(model.elements.form);
      } else {
        return root$11(model.elements.button);
      }
    } else {
      return root$12(model.home, $var1 => dispatch(function (arg0) {
        return new Msg$1(0, arg0);
      }($var1)));
    }
  };

  return react_1("div", {}, react_1("div", {
    className: "navbar-bg"
  }, react_1("div", {
    className: "container"
  }, root$13)), header, react_1("div", {
    className: "section"
  }, react_1("div", {
    className: "container"
  }, react_1("div", {
    className: "columns"
  }, react_1("div", {
    className: "column is-2"
  }, menu(model.currentPage)), react_1("div", {
    className: "column"
  }, pageHtml(model.currentPage))))));
}
ProgramModule.run(withReact("elmish-app", function (program) {
  return Program$1.toNotifiable(function (notifications) {
    return defaultNotificationArea(notifications);
  }, program);
}(ProgramModule$1.toNavigable(function (location) {
  return parseHash(pageParser, location);
}, function (result, model) {
  return urlUpdate(result, model);
}, ProgramModule.mkProgram(function (result_1) {
  return init(result_1);
}, function (msg, model_1) {
  return update(msg, model_1);
}, function (model_2, dispatch) {
  return root(model_2, dispatch);
})))));

exports.options = options;
exports.menuItem = menuItem;
exports.menu = menu;
exports.header = header;
exports.root = root;

}((this.bulmaDocSite = this.bulmaDocSite || {})));
