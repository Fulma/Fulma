namespace Elmish.Bulma.Elements

open Elmish
open Elmish.Bulma.BulmaClasses
open Fable.Core
open Fable.Core.JsInterop
open Fable.Import
open Fable.Helpers.React
open Fable.Helpers.React.Props

module Tag =

  type Option =
  | Size of string
  | Color of string
  | Props of IHTMLProp list

  type Options =
    { size: string
      color: string
      props: IHTMLProp list }

    static member Empty =
      { size = ""
        color = ""
        props = [] }

  // Size
  let isMedium = Size bulma.tag.size.isMedium
  let isLarge = Size bulma.tag.size.isLarge

  // Colors
  let isBlack = Color bulma.tag.color.isBlack
  let isDark = Color bulma.tag.color.isDark
  let isLight = Color bulma.tag.color.isLight
  let isWhite = Color bulma.tag.color.isWhite
  let isPrimary = Color bulma.tag.color.isPrimary
  let isInfo = Color bulma.tag.color.isInfo
  let isSuccess = Color bulma.tag.color.isSuccess
  let isWarning = Color bulma.tag.color.isWarning
  let isDanger = Color bulma.tag.color.isDanger
  let props props = Props props

  let tag (options: Option list) children =
    let parseOption (result: Options) opt =
      match opt with
      | Size s ->
          { result with size = s }
      | Color c ->
          { result with color = c }
      | Props props ->
          { result with props = props }

    let opts = options |> List.fold parseOption Options.Empty

    let className =
      ClassName (bulma.tag.container ++ opts.size ++ opts.color)

    span
      (className :> IHTMLProp :: opts.props)
      children
