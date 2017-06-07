namespace Elmish.Bulma.Elements

open Elmish
open Elmish.Bulma.BulmaClasses
open Elmish.Bulma.Common
open Fable.Core
open Fable.Core.JsInterop
open Fable.Import
open Fable.Helpers.React
open Fable.Helpers.React.Props

module Tag =

  module Types =

    type ITagSize =
      | IsMedium
      | IsLarge

    type Option =
      | Size of ITagSize
      | Color of ILevelAndColor
      | Props of IHTMLProp list

    let ofTagSize size =
      match size with
      | IsMedium -> bulma.tag.size.isMedium
      | IsLarge -> bulma.tag.size.isLarge

    type Options =
      { size: string option
        color: string option
        props: IHTMLProp list }

      static member Empty =
        { size = None
          color = None
          props = [] }

  open Types

  // Size
  let isMedium = Size IsMedium
  let isLarge = Size IsLarge

  // Colors
  let isBlack = Color IsBlack
  let isDark = Color IsDark
  let isLight = Color IsLight
  let isWhite = Color IsWhite
  let isPrimary = Color IsPrimary
  let isInfo = Color IsInfo
  let isSuccess = Color IsSuccess
  let isWarning = Color IsWarning
  let isDanger = Color IsDanger
  let props props = Props props

  let tag (options: Option list) children =
    let parseOption (result: Options) opt =
      match opt with
      | Size size ->
          { result with size = ofTagSize size |> Some }
      | Color color ->
          { result with color = ofLevelAndColor color |> Some }
      | Props props ->
          { result with props = props }

    let opts = options |> List.fold parseOption Options.Empty

    let className =
      ClassName
        ( Helpers.generateClassName
            bulma.tag.container
            [ opts.size
              opts.color ] )

    span
      (className :> IHTMLProp :: opts.props)
      children
