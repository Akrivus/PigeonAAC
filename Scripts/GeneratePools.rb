require 'oj'
Oj.default_options = {:escape_mode => :ascii, :indent => 4}
["English", "Pidgin"].each do |lang|
    pid_parts = File.read("Corpus-" + lang + "-Parts.txt").split("\n")
    pid_lines = File.read("Corpus-" + lang + ".txt").split("\n")
    pool = {}
    i = 0
    pid_parts.each do |parts|
        p = 0
        lines = pid_lines[i].split(" ")
        pid_words = parts.split(" ")
        pid_words.each do |word|
            pool[lines[p]] = word
            p += 1
        end
        i += 1
    end
    Oj.to_file("PosPool-" + lang + ".json", pool)
end