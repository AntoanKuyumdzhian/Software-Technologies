package softuniBlog.repository;

import org.springframework.data.jpa.repository.JpaRepository;
import softuniBlog.entity.Article;

/**
 * Created by Antoan on 12.04.2017.
 */
public interface ArticleRepository extends JpaRepository<Article, Integer> {
}
