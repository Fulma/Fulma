module Fulma.Versions

let view =
    Render.contentFromMarkdown
        """
<center style="width: 200px;margin: auto;">
    ![Fulma logo](assets/logo_transparent.svg)
</center>

Here you can find which libraries versions are supported by Fulma.

<table class="table" style="width: auto;">
    <thead>
        <tr>
            <th>Fulma</th>
            <th>Bulma</th>
            <th>Font Awesome</th>
        </tr>
    </thead>
    <tbody>
        <tr>
            <td>Current</td>
            <td>0.5.2</td>
            <td>4.7.0</td>
        </tr>
    </tbody>
<table>
        """
