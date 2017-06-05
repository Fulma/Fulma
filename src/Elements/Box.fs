namespace Elmish.Bulma.Elements

open Elmish
open Elmish.Bulma.BulmaClasses
open Fable.Core
open Fable.Core.JsInterop
open Fable.Import
open Fable.Helpers.React
open Fable.Helpers.React.Props

module Box =

  let box' children =

    div
      [ ClassName bulma.box.container ]
      children
