# Reperto-backend (in production)
**backend of Reperto App**

**technology:**
- ASP.Net 3 core EF MVC

**Controllers:**
- Songs
- Chords
- Repertoires

**Functionalities:**
- acces data such as songs, chords and custom made repertoires
- edit repertoires by adding new songs to it
- edit songs by adding chords to the song (configure txt file)
- discover new chords (using SVGuitar)
- List repertoires properly for music performance purposes
- delete data

**TODO:**
- add index to Lyrics URL when creating (0 = songs[0])'
- when user adds pastes text into Lyrics input, generate & save lyrics txt file or directly save uploaded txt file
- images to byte service (FileHelper)
- all basic chords already do have to be loaded when opening app
- add SVGuitar chord generator - save svg as byte[] into ASP (byte conversion) 
  - https://stackoverflow.com/questions/40157077/sending-files-from-client-angular-to-server-asp-net-wed-api-request-always-ha

**Libraries:**
- SVGuitar (generating chords) -- https://github.com/omnibrain/svguitar
