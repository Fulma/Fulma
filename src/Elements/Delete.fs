namespace Elmish.Bulma.Elements

open Elmish
open Elmish.Bulma.BulmaClasses
open Fable.Core
open Fable.Core.JsInterop
open Fable.Import
open Fable.Helpers.React
open Fable.Helpers.React.Props

module Delete =

  type Option =
    | Size of string
    | Props of IHTMLProp list

  type Options =
    { size: string
      props: IHTMLProp list }

    static member Empty =
      { size = ""
        props = [] }

  let isSmall = Size bulma.delete.size.isSmall

  let isMedium = Size bulma.delete.size.isMedium

  let isLarge = Size bulma.delete.size.isLarge

  let props props = Props props

  let delete (options: Option list) children =
    let parseOption (result: Options) opt =
        match opt with
        | Size s ->
            { result with size = s }
        | Props props ->
            { result with props = props }

    let opts = options |> List.fold parseOption Options.Empty

    let className =
      ClassName (bulma.delete.container ++ opts.size)

    a
      (className :> IHTMLProp :: opts.props)
      children
