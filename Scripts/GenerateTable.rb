require 'oj'
Oj.default_options = {:escape_mode => :ascii, :indent => 4}
eng_lines = File.read("Corpus-English.txt").split("\n")
eng_parts = File.read("Corpus-English-Parts.txt").split("\n")
pid_lines = File.read("Corpus-Pidgin.txt").split("\n")
pid_parts = File.read("Corpus-Pidgin-Parts.txt").split("\n")
table = {}
i = 0
pid_lines.each do |plines|
    p = 0
    elines = eng_lines[i].split(" ")
    eparts = eng_parts[i].split(" ")
    pparts = pid_parts[i].split(" ")
    pid_words = plines.split(" ")
    pid_words.each do |word|
        q = 0
        ppart = pparts[p]
        elines.each do |eword|
            epart = eparts[q]
            if ppart == epart
                table[word] = eword
            end
            q += 1
        end
        p += 1
    end
    i += 1
end
Oj.to_file("Table.json", table)