namespace Fable.Import

open System
open Fable.Core
open Fable.Import.JS

module Marked =

  type [<AllowNullLiteral>] MarkedStatic =
    abstract Renderer: obj with get, set
    abstract Parser: obj with get, set
    [<Emit("$0($1...)")>] abstract Invoke: src: string * callback: Function -> string
    [<Emit("$0($1...)")>] abstract Invoke: src: string * ?options: MarkedOptions * ?callback: Function -> string
    abstract lexer: src: string * ?options: MarkedOptions -> ResizeArray<obj>
    abstract parse: src: string * callback: Function -> string
    abstract parse: src: string * ?options: MarkedOptions * ?callback: Function -> string
    abstract parser: src: ResizeArray<obj> * ?options: MarkedOptions -> string
    abstract setOptions: options: MarkedOptions -> MarkedStatic

  and [<AllowNullLiteral>] MarkedRenderer =
    abstract code: code: string * language: string -> string
    abstract blockquote: quote: string -> string
    abstract html: html: string -> string
    abstract heading: text: string * level: float -> string
    abstract hr: unit -> string
    abstract list: body: string * ordered: bool -> string
    abstract listitem: text: string -> string
    abstract paragraph: text: string -> string
    abstract table: header: string * body: string -> string
    abstract tablerow: content: string -> string
    abstract tablecell: content: string * flags: obj -> string
    abstract strong: text: string -> string
    abstract em: text: string -> string
    abstract codespan: code: string -> string
    abstract br: unit -> string
    abstract del: text: string -> string
    abstract link: href: string * title: string * text: string -> string
    abstract image: href: string * title: string * text: string -> string
    abstract text: text: string -> string

  and [<AllowNullLiteral>] MarkedParser =
    abstract parse: source: ResizeArray<obj> -> string

  and [<AllowNullLiteral>] MarkedOptions =
    abstract renderer: MarkedRenderer option with get, set
    abstract gfm: bool option with get, set
    abstract tables: bool option with get, set
    abstract breaks: bool option with get, set
    abstract pedantic: bool option with get, set
    abstract sanitize: bool option with get, set
    abstract smartLists: bool option with get, set
    abstract silent: bool option with get, set
    abstract langPrefix: string option with get, set
    abstract smartypants: bool option with get, set
    abstract highlight: code: string * ?lang: string * ?callback: Function -> string

  type [<Erase>]Globals =
    [<Global>] static member marked : MarkedStatic = jsNative
