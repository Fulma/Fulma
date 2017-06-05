module Elements.Table.View

open Fable.Core
open Fable.Core.JsInterop
open Fable.Import
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Types
open Elmish
open Elmish.Bulma.Elements
open Global

let sectionGeneral model =
  Table.table
    [ ]
    [ thead
        [ ]
        [ tr
            [ ]
            [ th
                [ ]
                [ str "Firstname" ]
              th
                [ ]
                [ str "Surname" ]
              th
                [ ]
                [ str "Birthday" ] ] ]
      tbody
        [ ]
        [ tr
            [ ]
            [ td
                [ ]
                [ str "Maxime" ]
              td
                [ ]
                [ str "Mangel" ]
              td
                [ ]
                [ str "28/02/1992" ] ]
          tr
            [ Table.Row.isSelected ]
            [ td
                [ ]
                [ str "Jane" ]
              td
                [ ]
                [ str "Doe" ]
              td
                [ ]
                [ str "21/07/1987" ] ]
          tr
            [  ]
            [ td
                [ ]
                [ str "John" ]
              td
                [ ]
                [ str "Doe" ]
              td
                [ ]
                [ str "11/07/1978" ] ] ] ]
  |> docBlock model.generalCode
  |> toList
  |> sectionBase model.generalText


let sectionStyle model =
  Table.table
    [ Table.isBordered
      Table.isNarrow
      Table.isStripped ]
    [ thead
        [ ]
        [ tr
            [ ]
            [ th
                [ ]
                [ str "Firstname" ]
              th
                [ ]
                [ str "Surname" ]
              th
                [ ]
                [ str "Birthday" ] ] ]
      tbody
        [ ]
        [ tr
            [ ]
            [ td
                [ ]
                [ str "Maxime" ]
              td
                [ ]
                [ str "Mangel" ]
              td
                [ ]
                [ str "28/02/1992" ] ]
          tr
            [ Table.Row.isSelected ]
            [ td
                [ ]
                [ str "Jane" ]
              td
                [ ]
                [ str "Doe" ]
              td
                [ ]
                [ str "21/07/1987" ] ]
          tr
            [  ]
            [ td
                [ ]
                [ str "John" ]
              td
                [ ]
                [ str "Doe" ]
              td
                [ ]
                [ str "11/07/1978" ] ] ] ]
  |> docBlock model.styleCode
  |> toList
  |> sectionBase model.styleText


let root model =
  div
    [ ]
    [ sectionGeneral model
      hr []
      sectionStyle model ]
