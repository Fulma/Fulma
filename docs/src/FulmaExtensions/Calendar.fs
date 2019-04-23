module FulmaExtensions.Calendar

open Fable.React
open Fulma
open Fulma.Extensions.Wikiki
open Fable.FontAwesome

let basic () =
    Calendar.calendar [ ]
        [ Calendar.Nav.nav [ ]
            [ Calendar.Nav.left [ ]
                [ Button.button [ Button.IsLink ]
                    [ Icon.icon [ ]
                        [ Fa.i [ Fa.Solid.ChevronLeft ]
                            [ ] ] ] ]
              span [ ] [ str "August 2017" ]
              Calendar.Nav.right [ ]
                [ Button.button [ Button.IsLink ]
                    [ Icon.icon [ ]
                        [ Fa.i [ Fa.Solid.ChevronRight ]
                            [ ] ] ] ] ]
          div [ ]
            [ Calendar.header [ ]
                [ Calendar.Date.date [ ]
                    [ str "Sun" ]
                  Calendar.Date.date [ ]
                    [ str "Mon" ]
                  Calendar.Date.date [ ]
                    [ str "Tue" ]
                  Calendar.Date.date [ ]
                    [ str "Wed" ]
                  Calendar.Date.date [ ]
                    [ str "Thu" ]
                  Calendar.Date.date [ ]
                    [ str "Fri" ]
                  Calendar.Date.date [ ]
                    [ str "Sat" ] ]
              Calendar.body [ ]
                [ Calendar.Date.date [ Calendar.Date.IsDisabled true ]
                      [ Calendar.Date.item [ ]
                          [ str "31" ] ]
                  Calendar.Date.date [ ]
                      [ Calendar.Date.item [ ]
                          [ str "1" ] ]
                  Calendar.Date.date [ ]
                      [ Calendar.Date.item [ ]
                          [ str "2" ] ]
                  Calendar.Date.date [ ]
                      [ Calendar.Date.item [ ]
                          [ str "3" ] ]
                  Calendar.Date.date [ ]
                      [ Calendar.Date.item [ ]
                          [ str "4" ] ]
                  Calendar.Date.date [ ]
                      [ Calendar.Date.item [ ]
                          [ str "5" ] ]
                  Calendar.Date.date [ ]
                      [ Calendar.Date.item [ ]
                          [ str "6" ] ]
                  Calendar.Date.date [ ]
                      [ Calendar.Date.item [ Calendar.Date.Item.IsToday true ]
                          [ str "7" ] ]
                  Calendar.Date.date [ ]
                      [ Calendar.Date.item [ ]
                          [ str "8" ] ]
                  Calendar.Date.date [ ]
                      [ Calendar.Date.item [ ]
                          [ str "9" ] ]
                  Calendar.Date.date [ ]
                      [ Calendar.Date.item [ ]
                          [ str "10" ] ]
                  Calendar.Date.date [ Calendar.Date.IsRangeStart ]
                      [ Calendar.Date.item [ Calendar.Date.Item.IsActive true ]
                          [ str "11" ] ]
                  Calendar.Date.date [ Calendar.Date.IsRange ]
                      [ Calendar.Date.item [ ]
                          [ str "12" ] ]
                  Calendar.Date.date [ Calendar.Date.IsRange ]
                      [ Calendar.Date.item [ ]
                          [ str "13" ] ]
                  Calendar.Date.date [ Calendar.Date.IsRange ]
                      [ Calendar.Date.item [ ]
                          [ str "14" ] ]
                  Calendar.Date.date [ Calendar.Date.IsRange ]
                      [ Calendar.Date.item [ ]
                          [ str "15" ] ]
                  Calendar.Date.date [ Calendar.Date.IsRange ]
                      [ Calendar.Date.item [ ]
                          [ str "16" ] ]
                  Calendar.Date.date [ Calendar.Date.IsRangeEnd ]
                      [ Calendar.Date.item [ Calendar.Date.Item.IsActive true ]
                          [ str "17" ] ]
                  Calendar.Date.date [ ]
                      [ Calendar.Date.item [ ]
                          [ str "18" ] ]
                  Calendar.Date.date [ ]
                      [ Calendar.Date.item [ ]
                          [ str "19" ] ]
                  Calendar.Date.date [ ]
                      [ Calendar.Date.item [ ]
                          [ str "20" ] ]
                  Calendar.Date.date [ ]
                      [ Calendar.Date.item [ ]
                          [ str "21" ] ]
                  Calendar.Date.date [ ]
                      [ Calendar.Date.item [ ]
                          [ str "22" ] ]
                  Calendar.Date.date [ ]
                      [ Calendar.Date.item [ ]
                          [ str "23" ] ]
                  Calendar.Date.date [ ]
                      [ Calendar.Date.item [ ]
                          [ str "24" ] ]
                  Calendar.Date.date [ ]
                      [ Calendar.Date.item [ ]
                          [ str "25" ] ]
                  Calendar.Date.date [ ]
                      [ Calendar.Date.item [ ]
                          [ str "26" ] ]
                  Calendar.Date.date [ ]
                      [ Calendar.Date.item [ ]
                          [ str "27" ] ]
                  Calendar.Date.date [ ]
                      [ Calendar.Date.item [ ]
                          [ str "28" ] ]
                  Calendar.Date.date [ ]
                      [ Calendar.Date.item [ ]
                          [ str "29" ] ]
                  Calendar.Date.date [ ]
                      [ Calendar.Date.item [ ]
                          [ str "30" ] ]
                  Calendar.Date.date [ ]
                      [ Calendar.Date.item [ ]
                          [ str "31" ] ]
                  Calendar.Date.date [ Calendar.Date.IsDisabled true ]
                      [ Calendar.Date.item [ ]
                          [ str "1" ] ]
                  Calendar.Date.date [ Calendar.Date.IsDisabled true ]
                      [ Calendar.Date.item [ ]
                          [ str "2" ] ]
                  Calendar.Date.date [ Calendar.Date.IsDisabled true ]
                      [ Calendar.Date.item [ ]
                          [ str "3" ] ] ] ] ]

let view =
    Render.docPage [ Render.contentFromMarkdown
                        """
# Calendar

Display a **calendar** for date selection or for planning management, in different colors and sizes.

*[Documentation](https://wikiki.github.io/components/calendar/)*

### Installation

- `paket add Fulma.Extensions.Wikiki.Calendar --project <your project>`
- `yarn add bulma-calendar@0.1.7 bulma-tooltip`

### Versions compatibility

<table class="table" style="width: auto;">
    <thead>
        <tr>
            <th>Fulma.Extensions.Wikiki.Calendar</th>
            <th>bulma-calendar</th>
            <th>bulma-tooltip</th>
        </tr>
    </thead>
    <tbody>
        <tr>
            <td>Latest</td>
            <td>0.1.7</td>
            <td>2.0.2</td>
        </tr>
    </tbody>
<table>
                        """
                     Render.docSection
                        ""
                        (Widgets.Showcase.view basic (Render.includeCode __LINE__ __SOURCE_FILE__)) ]
