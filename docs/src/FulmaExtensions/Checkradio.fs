module FulmaExtensions.Checkradio

open Fable.Core
open Fable.Import
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fulma
open Fulma.Extensions.Wikiki
open Fable.FontAwesome

let inlineBlockInteractive () =
    Columns.columns [ ]
        [ Column.column [ ]
            [ div [ ClassName "block" ]
                  [ // Block sample
                    b [ ] [str "Block"]
                    Checkradio.checkbox [ Checkradio.Id "checkradio-1" ]
                        [ str "One" ]
                    Checkradio.checkbox [ Checkradio.Id "checkradio-2" ]
                        [ str "Two" ]
                    // Inline sample
                    b [ ] [str "Inline"]
                    Field.div [ ]
                        [ Checkradio.checkboxInline [ Checkradio.Id "checkradio-3" ]
                            [ str "One " ]
                          Checkradio.checkboxInline [ Checkradio.Id "checkradio-4" ]
                            [ str "Two " ] ] ] ]
          // Second column
          Column.column [ ]
            [ div [ ClassName "block" ]
                  [ // Block sample
                    b [ ] [str "Block"]
                    Checkradio.radio [ Checkradio.Name "block"
                                       Checkradio.Id "checkradio-5" ]
                        [ str "One" ]
                    Checkradio.radio [ Checkradio.Name "block"
                                       Checkradio.Id "checkradio-6" ]
                        [ str "Two" ]
                    // Inline sample
                    b [ ] [ str "Inline"]
                    Field.div [ ]
                        [ Checkradio.radioInline [ Checkradio.Name "inline"
                                                   Checkradio.Id "checkradio-7" ]
                            [ str "One" ]
                          Checkradio.radioInline [ Checkradio.Name "inline"
                                                   Checkradio.Id "checkradio-8" ]
                            [ str "Two " ] ] ] ] ]

let rtl () =
    Columns.columns [ ]
        [ Column.column [ ]
            [ Checkradio.checkbox [ Checkradio.IsRtl
                                    Checkradio.Id "checkradio-9" ]
                [ str "Label is on the left" ] ]
          Column.column [ ]
            [ Checkradio.radio [ Checkradio.IsRtl
                                 Checkradio.Id "checkradio-10" ]
                [ str "Label is on the left" ] ] ]

let colorInteractive () =
    Columns.columns [ ]
        [ // Column n°1
          Column.column [ ]
            [ Checkradio.checkbox [ Checkradio.Checked true
                                    Checkradio.Id "checkradio-11" ]
                [ str "Checkbox" ]
              Checkradio.checkbox [ Checkradio.Checked true
                                    Checkradio.Id "checkradio-12"
                                    Checkradio.Color IsInfo ]
                [ str "Info" ]
              Checkradio.checkbox [ Checkradio.Checked true
                                    Checkradio.Id "checkradio-13"
                                    Checkradio.Color IsDark ]
                [ str "Dark" ]
              Checkradio.checkbox [ Checkradio.Checked true
                                    Checkradio.Id "checkradio-14"
                                    Checkradio.Color IsBlack ]
                [ str "Black" ] ]
          // Column n°2
          Column.column [ ]
            [ Checkradio.checkbox [ Checkradio.Checked true
                                    Checkradio.Id "checkradio-15"
                                    Checkradio.Color IsPrimary ]
                [ str "Primary" ]
              Checkradio.checkbox [ Checkradio.Checked true
                                    Checkradio.Id "checkradio-16"
                                    Checkradio.Color IsSuccess ]
                [ str "Success" ]
              Checkradio.checkbox [ Checkradio.Checked true
                                    Checkradio.Id "checkradio-17"
                                    Checkradio.Color IsWarning ]
                [ str "Warning" ]
              Checkradio.checkbox [ Checkradio.Checked true
                                    Checkradio.Id "checkradio-18"
                                    Checkradio.Color IsDanger ]
                [ str "Danger" ] ]
          // Column n°3
          Column.column [ ]
            [ Checkradio.radio [ Checkradio.Checked true
                                 Checkradio.Id "checkradio-19"
                                 Checkradio.Name "rad" ]
                [ str "Checkbox" ]
              Checkradio.radio [ Checkradio.Checked true
                                 Checkradio.Id "checkradio-20"
                                 Checkradio.Color IsInfo
                                 Checkradio.Name "rad" ]
                [ str "Info" ]
              Checkradio.radio [ Checkradio.Checked true
                                 Checkradio.Id "checkradio-21"
                                 Checkradio.Color IsDark
                                 Checkradio.Name "rad" ]
                [ str "Dark" ]
              Checkradio.radio [ Checkradio.Checked true
                                 Checkradio.Id "checkradio-22"
                                 Checkradio.Color IsBlack
                                 Checkradio.Name "rad" ]
                [ str "Black" ] ]
          // Column n°4
          Column.column [ ]
            [ Checkradio.radio [ Checkradio.Checked true
                                 Checkradio.Id "checkradio-23"
                                 Checkradio.Color IsPrimary
                                 Checkradio.Name "rad1" ]
                [ str "Primary" ]
              Checkradio.radio [ Checkradio.Checked true
                                 Checkradio.Id "checkradio-24"
                                 Checkradio.Color IsSuccess
                                 Checkradio.Name "rad1" ]
                [ str "Success" ]
              Checkradio.radio [ Checkradio.Checked true
                                 Checkradio.Id "checkradio-25"
                                 Checkradio.Color IsWarning
                                 Checkradio.Name "rad1" ]
                [ str "Warning" ]
              Checkradio.radio [ Checkradio.Checked true
                                 Checkradio.Id "checkradio-26"
                                 Checkradio.Color IsDanger
                                 Checkradio.Name "rad1" ]
                [ str "Danger" ] ] ]

let sizeInteractive () =
    Columns.columns [ ]
        [ // Column n°1
          Column.column [ ]
            [ Checkradio.checkbox [ Checkradio.Checked true
                                    Checkradio.Id "checkradio-27"
                                    Checkradio.Size IsSmall ]
                [ str "Small" ]
              Checkradio.checkbox [ Checkradio.Checked true
                                    Checkradio.Id "checkradio-27b" ]
                [ str "Normal" ]
              Checkradio.checkbox [ Checkradio.Checked true
                                    Checkradio.Id "checkradio-28"
                                    Checkradio.Size IsMedium ]
                [ str "Medium" ]
              Checkradio.checkbox [ Checkradio.Checked true
                                    Checkradio.Id "checkradio-29"
                                    Checkradio.Size IsLarge ]
                [ str "Large" ] ]
          // Column n°2
          Column.column [ ]
            [ Checkradio.radio [ Checkradio.Name "rSize"
                                 Checkradio.Id "checkradio-30"
                                 Checkradio.Size IsSmall ]
                [ str "Small" ]
              Checkradio.radio [ Checkradio.Name "rSize"
                                 Checkradio.Id "checkradio-31" ]
                [ str "Normal" ]
              Checkradio.radio [ Checkradio.Name "rSize"
                                 Checkradio.Id "checkradio-32"
                                 Checkradio.Size IsMedium ]
                [ str "Medium" ]
              Checkradio.radio [ Checkradio.Name "rSize"
                                 Checkradio.Id "checkradio-33"
                                 Checkradio.Size IsLarge ]
                [ str "Large" ] ] ]

let stylesInteractive () =
    div [ ]
        [ b [ ]
            [ str "Checkbox" ]
          br [ ]
          Columns.columns [ ]
              [ // Column n°1
                Column.column [ ]
                  [ Checkradio.checkbox [ Checkradio.Checked true
                                          Checkradio.Id "checkradio-34"
                                          Checkradio.IsCircle
                                          Checkradio.Disabled true ]
                        [ str "Checkbox" ]
                    Checkradio.checkbox [ Checkradio.Checked true
                                          Checkradio.Id "checkradio-35"
                                          Checkradio.IsCircle ]
                        [ str "Checkbox" ]
                    Checkradio.checkbox [ Checkradio.Checked true
                                          Checkradio.Id "checkradio-36"
                                          Checkradio.IsCircle
                                          Checkradio.Color IsPrimary ]
                        [ str "Primary" ]
                    Checkradio.checkbox [ Checkradio.Checked true
                                          Checkradio.Id "checkradio-37"
                                          Checkradio.IsCircle
                                          Checkradio.Color IsDanger ]
                        [ str "Danger" ]
                    Checkradio.checkbox [ Checkradio.Checked true
                                          Checkradio.Id "checkradio-38"
                                          Checkradio.IsCircle
                                          Checkradio.Color IsInfo ]
                        [ str "Info" ]
                    Checkradio.checkbox [ Checkradio.Checked true
                                          Checkradio.Id "checkradio-39"
                                          Checkradio.IsCircle
                                          Checkradio.Color IsWarning ]
                        [ str "Warning" ] ]
                // Column n°2
                Column.column [ ]
                  [ Checkradio.checkbox [ Checkradio.Checked true
                                          Checkradio.Id "checkradio-40"
                                          Checkradio.HasNoBorder
                                          Checkradio.Disabled true ]
                        [ str "Checkbox" ]
                    Checkradio.checkbox [ Checkradio.Checked true
                                          Checkradio.Id "checkradio-41"
                                          Checkradio.HasNoBorder ]
                        [ str "Checkbox" ]
                    Checkradio.checkbox [ Checkradio.Checked true
                                          Checkradio.Id "checkradio-42"
                                          Checkradio.HasNoBorder
                                          Checkradio.Color IsPrimary ]
                        [ str "Primary" ]
                    Checkradio.checkbox [ Checkradio.Checked true
                                          Checkradio.Id "checkradio-43"
                                          Checkradio.HasNoBorder
                                          Checkradio.Color IsDanger ]
                        [ str "Danger" ]
                    Checkradio.checkbox [ Checkradio.Checked true
                                          Checkradio.Id "checkradio-44"
                                          Checkradio.HasNoBorder
                                          Checkradio.Color IsInfo ]
                        [ str "Info" ]
                    Checkradio.checkbox [ Checkradio.Checked true
                                          Checkradio.Id "checkradio-45"
                                          Checkradio.HasNoBorder
                                          Checkradio.Color IsWarning ]
                        [ str "Warning" ] ]
                // Hide the isBlock display for now as the display is bad: https://github.com/Wikiki/bulma-checkradio/issues/10
                // Column n°3
                // Column.column [ ]
                //   [ Checkradio.checkbox [ Checkradio.Checked true; Checkradio.isBlock; Checkradio.Disabled true ] [ str "Checkbox" ]
                //     Checkradio.checkbox [ Checkradio.Checked true; Checkradio.isBlock;  ] [ str "Checkbox" ]
                //     Checkradio.checkbox [ Checkradio.Checked true; Checkradio.isBlock; Checkradio.isPrimary ] [ str "Primary" ]
                //     Checkradio.checkbox [ Checkradio.Checked true; Checkradio.isBlock; Checkradio.isDanger ] [ str "Danger" ]
                //     Checkradio.checkbox [ Checkradio.Checked true; Checkradio.isBlock; Checkradio.isInfo ] [ str "Info" ]
                //     Checkradio.checkbox [ Checkradio.Checked true; Checkradio.isBlock; Checkradio.isWarning ] [ str "Warning" ] ]
                // Column n°4
                Column.column [ ]
                  [ Checkradio.checkbox [ Checkradio.Checked true
                                          Checkradio.Id "checkradio-46"
                                          Checkradio.HasBackgroundColor
                                          Checkradio.Disabled true ]
                        [ str "Checkbox" ]
                    Checkradio.checkbox [ Checkradio.Checked true
                                          Checkradio.Id "checkradio-47"
                                          Checkradio.HasBackgroundColor ]
                        [ str "Checkbox" ]
                    Checkradio.checkbox [ Checkradio.Checked true
                                          Checkradio.Id "checkradio-48"
                                          Checkradio.HasBackgroundColor
                                          Checkradio.Color IsPrimary ]
                        [ str "Primary" ]
                    Checkradio.checkbox [ Checkradio.Checked true
                                          Checkradio.Id "checkradio-49"
                                          Checkradio.HasBackgroundColor
                                          Checkradio.Color IsDanger ]
                        [ str "Danger" ]
                    Checkradio.checkbox [ Checkradio.Checked true
                                          Checkradio.Id "checkradio-50"
                                          Checkradio.HasBackgroundColor
                                          Checkradio.Color IsInfo ]
                        [ str "Info" ]
                    Checkradio.checkbox [ Checkradio.Checked true
                                          Checkradio.Id "checkradio-51"
                                          Checkradio.HasBackgroundColor
                                          Checkradio.Color IsWarning ]
                        [ str "Warning" ] ] ]
          b [ ]
            [ str "Radio" ]
          br [ ]
          Columns.columns [ ]
              [ Column.column [ ]
                  [ Checkradio.radio [ Checkradio.Checked true
                                       Checkradio.Id "checkradio-52"
                                       Checkradio.HasBackgroundColor
                                       Checkradio.Disabled true ]
                        [ str "Checkbox" ]
                    Checkradio.radio [ Checkradio.Checked true
                                       Checkradio.Id "checkradio-53"
                                       Checkradio.HasBackgroundColor ]
                        [ str "Checkbox" ]
                    Checkradio.radio [ Checkradio.Checked true
                                       Checkradio.Id "checkradio-54"
                                       Checkradio.HasBackgroundColor
                                       Checkradio.Color IsPrimary ]
                        [ str "Primary" ]
                    Checkradio.radio [ Checkradio.Checked true
                                       Checkradio.Id "checkradio-55"
                                       Checkradio.HasBackgroundColor
                                       Checkradio.Color IsDanger ]
                        [ str "Danger" ]
                    Checkradio.radio [ Checkradio.Checked true
                                       Checkradio.Id "checkradio-56"
                                       Checkradio.HasBackgroundColor
                                       Checkradio.Color IsInfo ]
                        [ str "Info" ]
                    Checkradio.radio [ Checkradio.Checked true
                                       Checkradio.Id "checkradio-57"
                                       Checkradio.HasBackgroundColor
                                       Checkradio.Color IsWarning ]
                        [ str "Warning" ] ] ] ]

let stateInteractive () =
    Columns.columns [ ]
        [ // Column n°1
          Column.column [ ]
            [ div [ ClassName "block" ]
                  [ Checkradio.checkbox [ Checkradio.Disabled true
                                          Checkradio.Id "checkradio-58" ]
                        [ str "Disabled" ]
                    Checkradio.checkbox [ Checkradio.Disabled true
                                          Checkradio.Id "checkradio-59"
                                          Checkradio.Checked true ]
                        [ str "Disabled & Checked" ]
                    Checkradio.checkbox [ Checkradio.Id "checkradio-60" ]
                        [ str "Unchecked" ]
                    Checkradio.checkbox [ Checkradio.Checked true
                                          Checkradio.Id "checkradio-61" ]
                        [ str "Checked" ] ] ]
          // Column n°2
          Column.column [ ]
            [ div [ ClassName "block" ]
                  [ Checkradio.radio [ Checkradio.Disabled true
                                       Checkradio.Id "checkradio-62" ]
                        [ str "Disabled" ]
                    Checkradio.radio [ Checkradio.Disabled true
                                       Checkradio.Id "checkradio-63"
                                       Checkradio.Checked true ]
                       [ str "Disabled & Checked" ]
                    Checkradio.radio [ Checkradio.Id "checkradio-64" ]
                        [ str "Unchecked" ]
                    Checkradio.radio [ Checkradio.Checked true
                                       Checkradio.Id "checkradio-65" ]
                        [ str "Checked" ] ] ] ]

type CheckradioDemoProps =
    interface end

type CheckradioDemoState =
    { IsChecked : bool }

type CheckradioDemo(props) =
    inherit React.Component<CheckradioDemoProps, CheckradioDemoState>(props)
    do base.setInitState({ IsChecked = false })

    member this.toggleState _ =
        this.setState (fun prevState _ ->
            { prevState with IsChecked = not this.state.IsChecked}
        )

    override this.render () =
        div [ ClassName "block" ]
            [ Checkradio.checkbox
                [ Checkradio.Checked this.state.IsChecked
                  Checkradio.OnChange this.toggleState
                  Checkradio.Id "checkradio-66" ]
                [ str  (string this.state.IsChecked) ]

              Checkradio.checkbox
                    [ Checkradio.Checked this.state.IsChecked
                      Checkradio.OnChange this.toggleState
                      Checkradio.Id "checkradio-67" ]
                    [ if this.state.IsChecked then
                        yield Icon.icon [ ]
                                [ Fa.i [ Fa.Solid.Plane ]
                                    [ ] ]
                      else
                        yield Icon.icon [ ]
                                [ Fa.i [ Fa.Solid.Rocket ]
                                    [ ] ] ] ]

let view =
    Render.docPage [ Render.contentFromMarkdown
                        """
# Checkradio

Make classic **checkbox** and **radio** more sexy in different colors, sizes, and states.

*[Documentation](https://wikiki.github.io/form/checkradio/)*

### Installation

- `paket add Fulma.Extensions.Wikiki.Checkradio --project <your project>`
- `yarn add bulma-checkradio@2.1.0`

### Versions compatibility

<table class="table" style="width: auto;">
    <thead>
        <tr>
            <th>Fulma.Extensions.Wikiki.Checkradio</th>
            <th>bulma-checkradio</th>
        </tr>
    </thead>
    <tbody>
        <tr>
            <td>Latest</td>
            <td>2.1.0</td>
        </tr>
    </tbody>
<table>
                        """
                     Render.docSection
                        """
<div class="message is-info">
    <div class="message-body">
        You need to provide <code>Checkradio.Id "unique-id"</code> in order to make <code>Checkradio</code> works
    </div>
</div>

### Inline vs Block
By default checkradio are include in `div.field` element, so it's presented in block.
You can use helpers functions to retrieve the input and the label by yourself.
                        """
                        (Widgets.Showcase.view inlineBlockInteractive (Render.includeCode __LINE__ __SOURCE_FILE__))
                     Render.docSection
                        "### Text position"
                        (Widgets.Showcase.view rtl (Render.includeCode __LINE__ __SOURCE_FILE__))
                     Render.docSection
                        "### Colors"
                        (Widgets.Showcase.view colorInteractive (Render.includeCode __LINE__ __SOURCE_FILE__))
                     Render.docSection
                        "### Sizes"
                        (Widgets.Showcase.view sizeInteractive (Render.includeCode __LINE__ __SOURCE_FILE__))
                     Render.docSection
                        """
### Styles
The checkbox can be **circle**.
                        """
                        (Widgets.Showcase.view stylesInteractive (Render.includeCode __LINE__ __SOURCE_FILE__))
                     Render.docSection
                        "### States"
                        (Widgets.Showcase.view stateInteractive (Render.includeCode __LINE__ __SOURCE_FILE__))
                     Render.docSection
                        "### Event handler"
                        (Widgets.Showcase.view (fun _ -> ofType<CheckradioDemo,_,_> (unbox null) [ ]) (Render.includeCode __LINE__ __SOURCE_FILE__)) ]
