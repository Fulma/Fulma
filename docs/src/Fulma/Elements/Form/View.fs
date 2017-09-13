module Elements.Form.View

open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Types
open Fulma.Elements
open Fulma.Extra.FontAwesome
open Fulma.Elements.Form

let iconInteractive =
    form [ ]
         [ Field.field_div [ ]
                [ Label.label [ ]
                    [ str "Name" ]
                  Control.control_div [ ]
                    [ Input.input [ Input.typeIsText
                                    Input.placeholder "Ex: Maxime" ] ] ]
           Field.field_div [ ]
                [ Label.label [ ]
                    [ str "Username" ]
                  Control.control_div [ Control.hasIconLeft
                                        Control.hasIconRight ]
                    [ Input.text [ Input.isSuccess
                                   Input.defaultValue "Maxime" ]
                      Icon.faIcon [ Icon.isSmall; Icon.isLeft ] Fa.User
                      Icon.faIcon [ Icon.isSmall; Icon.isRight ] Fa.Check ]
                  Help.help [ Help.isSuccess ]
                    [ str "This username is available" ] ]

           Field.field_div [ ]
                [ Label.label [ ]
                    [ str "Email" ]
                  Control.control_div [ Control.hasIconLeft
                                        Control.hasIconRight ]
                    [ Input.email [ Input.isDanger
                                    Input.defaultValue "hello@" ]
                      Icon.faIcon [ Icon.isSmall; Icon.isLeft ] Fa.Envelope
                      Icon.faIcon [ Icon.isSmall; Icon.isRight ] Fa.Warning ]
                  Help.help [ Help.isDanger ]
                    [ str "This email is invalid" ] ]

           Field.field_div [ ]
                [ Label.label [ ]
                    [ str "Subject" ]
                  Control.control_div [ ]
                    [ Select.select [ ]
                        [ select [ DefaultValue "2" ]
                            [ option [ Value "1" ] [ str "Value n°1" ]
                              option [ Value "2"] [ str "Value n°2" ]
                              option [ Value "3"] [ str "Value n°3" ] ] ] ] ]
           Field.field_div [ ]
                [ Label.label [ ]
                    [ str "Message" ]
                  Control.control_div [ Control.isLoading ]
                    [ Textarea.textarea [ ]
                        [ ] ] ]

           Field.field_div [ ]
                [ Control.control_div [ ]
                    [ Checkbox.checkbox [ ]
                        [ Checkbox.input [ ]
                          str "I agree with the terms and conditions" ] ] ]

           Field.field_div [ Field.isGrouped ]
                [ Control.control_div [ ]
                    [ Button.button [ Button.isPrimary ]
                        [ str "Submit" ] ]
                  Control.control_div [ ]
                    [ Button.button [ Button.isLink ]
                        [ str "Cancel" ] ] ]
                        ]

let root model dispatch =
    Render.docPage [ Render.contentFromMarkdown model.Intro
                     Render.docSection
                        ""
                        (Viewer.View.root iconInteractive model.BoxViewer (BoxViewerMsg >> dispatch)) ]

// <div class="field">
//   <div class="control">
//     <label class="radio">
//       <input type="radio" name="question">
//       Yes
//     </label>
//     <label class="radio">
//       <input type="radio" name="question">
//       No
//     </label>
//   </div>
// </div>
