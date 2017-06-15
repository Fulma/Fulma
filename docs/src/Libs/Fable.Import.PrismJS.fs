namespace Fable.Import

open Fable.Core
open Fable.Import.Browser
open System
open System.Text.RegularExpressions

module PrismJS =
    [<AllowNullLiteral>]
    type Prism =
        abstract util : Util with get, set
        abstract languages : Languages with get, set
        abstract plugins : obj with get, set
        abstract hooks : Hooks with get, set
        abstract highlightAll : bool * Func<Element, unit> -> unit
        abstract highlightElement : Element * bool * Func<Element, unit> -> unit
        abstract highlight : text: string * grammer: LanguageDefinition * ?language: LanguageDefinition -> string
        abstract tokenize : string * LanguageDefinition * LanguageDefinition -> ResizeArray<string>
        abstract fileHighlight : unit -> unit

    and [<AllowNullLiteral>] Environment =
        abstract element : Element option with get, set
        abstract language : LanguageDefinition option with get, set
        abstract grammer : obj option with get, set
        abstract code : obj option with get, set
        abstract highlightedCode : obj option with get, set
        abstract ``type`` : string option with get, set
        abstract content : string option with get, set
        abstract tag : string option with get, set
        abstract classes : ResizeArray<string> option with get, set
        abstract attributes : U2<ResizeArray<string>, obj> option with get, set
        abstract parent : Element option with get, set

    and [<AllowNullLiteral>] Identifier =
        abstract value : float with get, set

    and [<AllowNullLiteral>] Util =
        abstract encode : U3<Token, ResizeArray<Token>, string> -> U3<Token, ResizeArray<Token>, string>
        abstract ``type`` : obj -> string
        abstract objId : obj -> Identifier
        abstract clone : LanguageDefinition -> LanguageDefinition

    and [<AllowNullLiteral>] LanguageDefinition =
        abstract keyword : U2<Regex, LanguageDefinition> option with get, set
        abstract number : U2<Regex, LanguageDefinition> option with get, set
        abstract ``function`` : U2<Regex, LanguageDefinition> option with get, set
        abstract string : U2<Regex, LanguageDefinition> option with get, set
        abstract boolean : U2<Regex, LanguageDefinition> option with get, set
        abstract operator : U2<Regex, LanguageDefinition> option with get, set
        abstract punctuation : U2<Regex, LanguageDefinition> option with get, set
        abstract atrule : U2<Regex, LanguageDefinition> option with get, set
        abstract url : U2<Regex, LanguageDefinition> option with get, set
        abstract selector : U2<Regex, LanguageDefinition> option with get, set
        abstract property : U2<Regex, LanguageDefinition> option with get, set
        abstract important : U2<Regex, LanguageDefinition> option with get, set
        abstract style : U2<Regex, LanguageDefinition> option with get, set
        abstract alias : string option with get, set
        abstract pattern : Regex option with get, set
        abstract lookbehind : bool option with get, set
        abstract inside : LanguageDefinition option with get, set
        abstract rest : ResizeArray<Token> option with get, set

    and [<AllowNullLiteral>] Languages =
        //inherit ResizeArray<LanguageDefinition>
        abstract extend : string * LanguageDefinition -> LanguageDefinition
        abstract insertBefore : string * string * LanguageDefinition * obj -> obj

    and [<AllowNullLiteral>] Hooks =
        abstract all : ResizeArray<ResizeArray<Func<Environment, unit>>> with get, set
        abstract add : string * Func<Environment, unit> -> unit
        abstract run : string * Environment -> unit

    and [<AllowNullLiteral>] Token =
        abstract ``type`` : string with get, set
        abstract content : U3<Token, ResizeArray<Token>, string> with get, set
        abstract alias : string with get, set
        abstract stringify : U2<string, ResizeArray<obj>> * LanguageDefinition * HTMLPreElement -> string

    [<Erase>]
    type Globals =
        [<Global>]
        static member Prism with get () = jsNative : Prism
